using System;
using ClassLibrary;


namespace Modul3
{
    public partial class MemberModulForm3 : BasisModulForm
    {
        public MemberModulForm3()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Vor- und Nachname: \n" + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
        }

        protected override void saveData()
        {
            string[] split = textBox1.Text.Split(null);
            Patient.VorName = split[0];
            Patient.NachName = split[1];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
