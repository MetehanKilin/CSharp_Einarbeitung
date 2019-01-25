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
    public partial class BasisModulForm : Form
    {

        public BasisModulForm()
        {
            InitializeComponent();
            closing = false;
        }

        private Patient patient;
        private Boolean closing=true;

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

        public bool Closing1
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

        public virtual void load()
        {

        }

        protected virtual void reset()
        {

        }

        private void verwerfen_Click(object sender, EventArgs e)
        {
            reset();
            verwerfen.Enabled = false;
        }

        protected virtual void saveData()
        {

        }

        private void speichern_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            verwerfen.Enabled = true;
            Closing1 = false;
        }


        private Boolean schließen()
        {
            if (closing==true)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public void patientenwechsel()
        {
            saveData();
        }
        
       

        private void BasisModulForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!schließen())
            {
                DialogResult result = MessageBox.Show("Nicht gespeicherte Daten, trotzdem schließen?", "speichern / verwerfen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    closing = true;
                    return;
                }

                else if (result == DialogResult.No)
                {
                    closing = false;
                    e.Cancel = (result == DialogResult.No);
                }
                //else if(result==DialogResult.Ignore)          welches ereignis bei X-press
                //{
                //    closing = false;
                //    e.Cancel = (result == DialogResult.Ignore);
                //}
                else
                {
                    e.Cancel = true;
                }


            }
            
          

           




        }

     
    }
}
