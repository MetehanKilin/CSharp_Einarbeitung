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
    public partial class MemberModulForm1 : BasisModulForm
    {
        public MemberModulForm1()
        {
            InitializeComponent();
        }

        public override void load()
        {
            label1.Text = "Die ID lautet: " + Patient.id;
        }

        public override void edit()
        {
            Edit edit = new Edit();
            edit.Patient = Patient;
            edit.Form = this;
            edit.load();
            edit.Show();   
            




            //DialogResult dialogResult = MessageBox.Show("editieren", "Editieren", MessageBoxButtons.YesNoCancel);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    Console.WriteLine("yes");
            //}
            //else if (dialogResult == DialogResult.No)
            //{

            //    Console.WriteLine("no");
            //}
            //else if (dialogResult== DialogResult.Cancel)
            //{
            //    Console.WriteLine("abbrechen");
            //}
            //else
            //{
            //    MessageBox.Show("Da ist was schief gelaufen");
            //}
        }
        public override void editPatient(string s)
        {
            label1.Text = "Die ID lautet: " + s;
        }

        private void ModulFormLoad(object sender, EventArgs e)
        {
            label1.Text = "Die ID lautet: " + Patient.id;
           
        }
       
    }
}
