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

        public override void load()
        {
            label1.Text="Geschlecht: " + Patient.Geschlecht;
        }

        public void ModulFormLoad(object sender, EventArgs e)
        {
            label1.Text = "Geschlecht: " + Patient.Geschlecht;
        }

        public override void edit()
        {
            MemberEditForm2 edit = new MemberEditForm2();
            edit.Patient = Patient;
            edit.Form = this;
            edit.load();
            edit.Show();

        }
        //public override void editPatient(string s)
        //{
        //    label1.Text = "Die ID lautet: " + s;
        //}
    }
}
