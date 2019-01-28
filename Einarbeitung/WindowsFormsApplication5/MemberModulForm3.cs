using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            label1.Text = "Vor- und Nachname: \n" + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
            verwerfen.Enabled = false;
            Closing1 = true;
        }

        private void ModulFormLoad(object sender, EventArgs e)
        {
            load();
        }

        protected override void saveData()
        {
            string[] split = textBox1.Text.Split(null);


               
            //REGEX einbauen 

            if (split.Length > 2 )
            {
                MessageBox.Show("Bitte Vorname und Nachme eingeben: (Max Mustermann)");
            }

            Patient.VorName = split[0];
            Patient.NachName = split[1];


            label1.Text = "Vor- und Nachname: \n" + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
            Closing1 = true;
            verwerfen.Enabled = false;
        }

        protected override void reset()
        {
            verwerfen.Enabled = true;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
            Closing1 = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Closing1 = false;
            verwerfen.Enabled = true;
        }
    }
}
