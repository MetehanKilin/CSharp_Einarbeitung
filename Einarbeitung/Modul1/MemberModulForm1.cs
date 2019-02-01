using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Modul1
{
    public partial class MemberModulForm1 : BasisModulForm
    {
        public MemberModulForm1()
        {
            InitializeComponent();
            speichern.Visible = false;
            verwerfen.Visible=false;
        }

        protected override void load()
        {
            label1.Text = "Die ID lautet: " + Patient.Id;
        }

     
       
    }
}
