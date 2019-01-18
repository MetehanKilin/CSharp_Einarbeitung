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
            button1.Visible = false;
        }

        protected override void load()
        {
            label1.Text = "Die ID lautet: " + Patient.Id;
        }

     
        protected override void editPatient(string s)
        {
            label1.Text = "Die ID lautet: " + s;
        }

        private void ModulFormLoad(object sender, EventArgs e)
        {
            label1.Text = "Die ID lautet: " + Patient.Id;
           
        }
       
    }
}
