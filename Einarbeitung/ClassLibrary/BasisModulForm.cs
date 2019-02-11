using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClassLibrary
{
    public partial class BasisModulForm : Form
    {
        private Patient patient;
        private Boolean closing;
        private string path = Environment.CurrentDirectory;
        private bool DatabaseActive;
        private string MyConnectionString = "SERVER=127.0.0.1;" +
                                            "DATABASE=patienten;" +
                                            "UID=admin;" +
                                            "PASSWORD=admin;";
        private XmlDocument xml = new XmlDocument();
        private bool useSql;

        public BasisModulForm()
        {
            InitializeComponent();
            closing = true;
        }

        public BasisModulForm(bool useSql)
        {
            this.useSql = useSql;
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

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public bool DatabaseActive1
        {
            get
            {
                return DatabaseActive;
            }

            set
            {
                DatabaseActive = value;
            }
        }

        public string MyConnectionString1
        {
            get
            {
                return MyConnectionString;
            }

           
        }

        public XmlDocument Xml
        {
            get
            {
                return xml;
            }

            set
            {
                xml = value;
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
            buttonsPassed(false);
        }

        private void speichern_Click(object sender, EventArgs e)
        {
            saveData();
            DatenLaden();
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

