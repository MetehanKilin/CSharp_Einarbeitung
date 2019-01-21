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
            speichern.Visible = false;
            verwerfen.Visible=false;
            textBox1.Visible = false;
        }

        public override void load()
        {
            label1.Text = "Die ID lautet: " + Patient.Id;
            //textBox1.Text = Patient.Id.ToString();
        }

  

        private void ModulFormLoad(object sender, EventArgs e)
        {
            load();          
        }
       
    }
}
