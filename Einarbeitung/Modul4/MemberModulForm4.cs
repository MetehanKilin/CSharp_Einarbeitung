using System;
using ClassLibrary;

namespace Modul4
{
    public partial class MemberModulForm4 : BasisModulForm
    {
        public MemberModulForm4()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Geburtstag: \n" + Patient.Geburtstag.ToString("dd/MM/yyyy");
            dateTimePicker1.Value = Patient.Geburtstag;
        }
        protected override void saveData()
        {
            Patient.Geburtstag = dateTimePicker1.Value;
        }
      
        private void DateTimePicker1_ValueChanged(Object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
