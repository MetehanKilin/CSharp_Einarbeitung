using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class BasisModulForm : Form
    {
        private Patient patient;
        private bool closing;
        private bool useSql;
        private IDAOB Database = new DaoDatabaseB();
        private IDAOB xml = new DaoXmlB();


        public BasisModulForm()
        {
            InitializeComponent();
            closing = true;
        }

        public List<Patient> getPatienten()
        {
            if (UseSql)
            {
                return Database.PatientenLaden();
            }
            else
            {
                return xml.PatientenLaden();
            }
        }
        public List<string> getModule()
        {
            if (UseSql)
            {
                return Database.ModuleLaden();
            }
            else
            {
                return xml.ModuleLaden();
            }
        }
        public List<string> getForms()
        {
            if (UseSql)
            {
                return Database.FormsLaden();
            }
            else
            {
                return xml.FormsLaden();
            }
        }

        public Boolean Closing1
        {
            get
            {
                return closing;
            }
            set
            {
                closing = value;
            }
        }

        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }

        public bool UseSql
        {
            get
            {
                return useSql;
            }
            set
            {
                useSql = value;
            }
        }

        public void DatenLaden()
        {
            load();
            buttonsPassed(false);
        }

        protected void buttonsPassed(bool b)
        {
            verwerfen.Enabled = b;
            speichern.Enabled = b;
            Closing1 = !b;
        }

        protected virtual void load()
        {
        }

        protected virtual void saveData()
        {
        }

        public void savedData()
        {
            saveData();
            storageSave(patient);
            buttonsPassed(false);
        }

        private void speichern_Click(object sender, EventArgs e)
        {
            saveData();
            storageSave(patient);
            DatenLaden();
         }

        private void storageSave(Patient patient)
        {
            if (UseSql)
            {
                Database.update(patient);
            }
            else
            {
                xml.update(patient);
            }
        }

        private void verwerfen_Click(object sender, EventArgs e)
        {
            DatenLaden();
        }

        private void BasisModulForm_Load(object sender, EventArgs e)
        {
            DatenLaden();
        }
        private void BasisModulForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow(e);
        }

        public void CloseWindow(FormClosingEventArgs e)
        {
            if (!Closing1)
            {
                switch (CloseWindowCheck())
                {
                    case 1:
                        savedData();
                        closing = true;
                        return;
                    case 2:
                        closing = true;
                        return;
                    default:
                        e.Cancel = true;
                        return;
                }
            }
        }

        public int CloseWindowCheck()
        {
            DialogResult result = MessageBox.Show("nicht gespeicherte Daten,\n jetzt Speichern?", "speichern / verwerfen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                closing = true;
                return 1;
            }
            else if(result==DialogResult.No)
            {
                closing = true;
                return 2;
            }
            else
	        {
                closing = false;
                return 3;
            }
        }

    }
}

