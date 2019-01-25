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
    public partial class MemberModulForm4 : BasisModulForm
    {
        public MemberModulForm4()
        {
            InitializeComponent();
        }

        public override void load()
        {
            label1.Text = "Geburtstag: " + Patient.Geburtstag.ToString("MM/dd/yyyy");
            dateTimePicker1.Value = Patient.Geburtstag;
            Console.WriteLine("1");

        }

        private void DateTimePicker1_ValueChanged(Object sender, EventArgs e)
        {
            Console.WriteLine("ola");
            if (Patient.Geburtstag!=dateTimePicker1.Value)
            {
                Closing1 = false;
                verwerfen.Enabled = true;
            }else
            {
                verwerfen.Enabled = false;
            }
        }

        public void ModulFormLoad(object sender, EventArgs e)
        {
            Closing1 = true;
            load();
            verwerfen.Enabled = false;
        }

        protected override void saveData()
        {
            Patient.Geburtstag = dateTimePicker1.Value;
            label1.Text = "Geburtstag: " + Patient.Geburtstag.ToString("dd/MM/yyyy");
            Closing1 = true;
            verwerfen.Enabled = false;
        }

        protected override void reset()
        {
            verwerfen.Enabled = true;
            dateTimePicker1.Value = Patient.Geburtstag;
            Closing1=true;
        }


    }
}
