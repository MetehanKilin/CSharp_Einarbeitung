using System;
using ClassLibrary;


namespace Modul2
{
    public partial class MemberModulForm2 : BasisModulForm
    {
        public MemberModulForm2()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Geschlecht: \n" + Patient.Geschlecht;

            if (Patient.Geschlecht == 'M')
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        protected override void saveData()
        {
            if (radioButton1.Checked)
            {
                Patient.Geschlecht = 'M';
            }
            else
            {
                Patient.Geschlecht = 'W';
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
