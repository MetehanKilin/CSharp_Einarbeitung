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
            label1.Text = "Geschlecht: " + Patient.Geschlecht;

            radioButton1.Text = "M";
            radioButton2.Text = "W";

            if (Patient.Geschlecht == 'M' || Patient.Geschlecht == 'm')
            {
                radioButton1.Checked = true;
            }
            else if (Patient.Geschlecht == 'W' || Patient.Geschlecht == 'w')
            {
                radioButton2.Checked = true;
               
            }else
            {
                MessageBox.Show("nicht zugeordnet");
            }

            radioButton1.Click += (sender, e) =>
            {
                if (Patient.Geschlecht=='W')
                {
                    verwerfen.Enabled = true;
                }



                Closing1 = false;
                temp = 'M';
            };

            radioButton2.Click += (sender, e) =>
            {

                if (Patient.Geschlecht == 'M')
                {
                    verwerfen.Enabled = true;
                }

                Closing1 = false;
                temp = 'W';
            };
        }

        public void ModulFormLoad(object sender, EventArgs e)
        {
            Closing1 = true;
            load();
            verwerfen.Enabled = false;
        }

        protected override void saveData()
        {
            Patient.Geschlecht = temp;
            Closing1 = true;
            verwerfen.Enabled = false;


            if (Patient.Geschlecht == 'M')
            {
                radioButton1.Checked = true;
            }
            else if (Patient.Geschlecht == 'W')
            {
                radioButton2.Checked = true;

            }
            else
            {
                MessageBox.Show("nicht zugeordnet");
            }

        }

        protected override void reset()
        {


            verwerfen.Enabled = false;
            Closing1 = true;


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

        }

       
    }
}
