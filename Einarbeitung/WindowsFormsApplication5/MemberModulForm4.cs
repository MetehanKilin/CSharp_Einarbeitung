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
        DateTimePicker d;
        public MemberModulForm4()
        {
            InitializeComponent();
        }

        public override void load()
        {
            label1.Text = "Geburtstag: " + Patient.Geburtstag.ToString("MM/dd/yyyy");
            //textBox1.Text = Patient.Geburtstag.ToString("MM/dd/yyyy");
            textBox1.Visible = false;

            d = new DateTimePicker();
            d.Value = Patient.Geburtstag;
            d.Dock = DockStyle.Right;
            d.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y));
            d.ValueChanged += DateTimePicker1_ValueChanged;

            //d.ValueChanged += new EventHandler(sender, e) =>
            //{
            //    verwerfen.Enabled = false;
            //};
            Controls.Add(d);
        }

        private void DateTimePicker1_ValueChanged(Object sender, EventArgs e)
        {
            if (Patient.Geburtstag!=d.Value)
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
            Patient.Geburtstag = d.Value;
            label1.Text = "Geburtstag: " + Patient.Geburtstag.ToString("dd/MM/yyyy");
            Closing1 = true;
            verwerfen.Enabled = false;
        }

        protected override void reset()
        {
            verwerfen.Enabled = true;
            //textBox1.Text = Patient.VorName + " " + Patient.NachName;
            d.Value = Patient.Geburtstag;
            Closing1=true;
        }


    }
}
