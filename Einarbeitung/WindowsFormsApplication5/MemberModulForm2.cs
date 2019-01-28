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
    public partial class MemberModulForm2 : BasisModulForm
    {
        public MemberModulForm2()
        {
            InitializeComponent();
        }
        private char temp;

        public override void load()
        {
            label1.Text = "Geschlecht: \n" + Patient.Geschlecht;

            radioButton1.Text = "M";
            radioButton2.Text = "W";

            if (Patient.Geschlecht == 'M' || Patient.Geschlecht == 'm')
            {
                radioButton1.Checked = true;
            }
            else if (Patient.Geschlecht == 'W' || Patient.Geschlecht == 'w')
            {
                radioButton2.Checked = true;

            }
            else
            {
                MessageBox.Show("nicht zugeordnet");
            }

            Closing1 = true;
            verwerfen.Enabled = false;
        }


        public void ModulFormLoad(object sender, EventArgs e)
        {
            load();
            
        }

        protected override void saveData()
        {
            Patient.Geschlecht = temp;
            Closing1 = true;
            verwerfen.Enabled = false;


            if (Patient.Geschlecht == 'M')
            {
                radioButton1.Checked = true;
                label1.Text = "Geschlecht: \n" + Patient.Geschlecht;
            }
            else if (Patient.Geschlecht == 'W')
            {
                radioButton2.Checked = true;
                label1.Text = "Geschlecht: \n" + Patient.Geschlecht;
            }
            else
            {
                MessageBox.Show("nicht zugeordnet");
            }

        }

        protected override void reset()
        {
            
            if (Patient.Geschlecht == 'M' || Patient.Geschlecht == 'm')
            {
                radioButton1.Checked = true;
            }
            else if (Patient.Geschlecht == 'W' || Patient.Geschlecht == 'w')
            {
                radioButton2.Checked = true;

            }
            else
            {
                MessageBox.Show("nicht zugeordnet");
            }

            Closing1 = true;
            verwerfen.Enabled = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Patient.Geschlecht == 'W')
            {
                verwerfen.Enabled = true;
            }
            temp = 'M';
            Closing1 = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (Patient.Geschlecht == 'M')
            {
                verwerfen.Enabled = true;
            }
            temp = 'W';
            Closing1 = false;
        }
    }
}
