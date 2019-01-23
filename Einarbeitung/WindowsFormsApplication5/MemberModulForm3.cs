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
    public partial class MemberModulForm3 : BasisModulForm
    {
        public MemberModulForm3()
        {
            InitializeComponent();
            
        }


        public override void load()
        {
            Closing1 = true;
            label1.Text = "Vor- und Nachname: " + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
        }

        private void ModulFormLoad(object sender, EventArgs e)
        {
            load();
            verwerfen.Enabled = false;
        }

        protected override void saveData()
        {
            string[] split = textBox1.Text.Split(null);

            if (split.Length>2)
            {
            MessageBox.Show("Bitte Vorname und Nachme eingeben: (Max Mustermann)");
            }

            Patient.VorName = split[0];
            Patient.NachName = split[1];


            label1.Text = "Vor- und Nachname: " + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
            Closing1 = true;
            verwerfen.Enabled = false;
            Closing1 = true;
        }

        protected override void reset()
        {
            verwerfen.Enabled = true;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
            Closing1 = true;

        }





    }
}
