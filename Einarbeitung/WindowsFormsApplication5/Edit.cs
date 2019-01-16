using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Edit : Form
    {
        Patient patient;
        Form form;

        public Edit()
        {
            InitializeComponent();
        }



        internal Patient Patient
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

        public Form Form
        {
            get
            {
                return form;
            }

            set
            {
                form = value;
            }
        }

        public void load()
        {
            editLabel.Text = "ID: "+patient.id ;
        }



        private void abbrechenButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void speichernButton_Click(object sender, EventArgs e)
        {
            bool b=true;
            int a;


            if (b)
            {
                if (int.TryParse(textBox1.Text, out a))
                {

                    //Hauptseite.

                    BasisModulForm ab = (BasisModulForm)form;

                    //hier die veränderung herausnehmen
                    //abspeichern in der Verwaltung
                    //MemberModulForm patient updaten
                    //laden Methode aufrufen

                    patient.id = a;

                    Hauptseite.manipulationPatient(patient);
                    
                    //ab.label1.Text = a.ToString();



                    this.Close();
                    this.Dispose();
                    b = false;
                }
                else
                {
                    MessageBox.Show("Bitte geben Sie ein Int ein");
                }
            }





        }

        private void verwerfenButton_Click(object sender, EventArgs e)
        {

            Hauptseite.createPatients();
            Console.WriteLine(patient.id);

            Hauptseite.zurücksetzen(patient);




            this.Close();
            this.Dispose();
        }

       
    }
} 
