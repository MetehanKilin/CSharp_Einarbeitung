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
        private RadioButton r;
        public MemberModulForm2()
        {
            InitializeComponent();

        }

        public override void load()
        {
            //verwerfen.Enabled = false;
            //label1.Text= "Geschlecht: " + Patient.Geschlecht;
            //textBox1.Text = Patient.Geschlecht.ToString();

            textBox1.Visible = false;



            label1.Text = "Geschlecht: " + Patient.Geschlecht;


            if (r != null)
            {
                r.Dispose();
            }


            if (Patient.Geschlecht == 'M' || Patient.Geschlecht == 'm')
            {
                r = new RadioButton();



                r.Dock = DockStyle.Right;
                r.Text = "W";
                r.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y));


                r.Click += (sender, e) =>
                {
                    verwerfen.Enabled = true;
                    Closing1 = false;

                };



                Controls.Add(r);
                Patient.Geschlecht = 'W';

            }
            else if (Patient.Geschlecht == 'W' || Patient.Geschlecht == 'w')
            {
                r = new RadioButton();
                r.Dock = DockStyle.Right;

                r.Text = "M";
                r.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y));

                r.Click += (sender, e) =>
                {
                    verwerfen.Enabled = true;
                    Closing1 = false;
                };

                Controls.Add(r);
                Patient.Geschlecht = 'M';
            }
            else
            {
                MessageBox.Show("Kein Geschlecht zugeordnet");
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
            //char[] c = textBox1.Text.ToCharArray();
            //Console.WriteLine(c.Length);
            //if (c.Length > 1)
            //{
            //    MessageBox.Show("Bitte nur 'M' oder 'W' eingeben");
            //}

            //Patient.Geschlecht = c[0];


            //label1.Text = "Geschlecht: " + Patient.Geschlecht;
            //textBox1.Text = Patient.Geschlecht.ToString();



            char[] c = r.Text.ToCharArray();

            Patient.Geschlecht = c[0];
            Closing1 = true;

            load();
            verwerfen.Enabled = false;


        }

        protected override void reset()
        {
            //label1.Text = "Geschlecht: " + Patient.Geschlecht;
            //textBox1.Text = Patient.Geschlecht.ToString();
            //verwerfen.Enabled = false;
            ////r.Checked = false;



            //label1.Text = "Geschlecht: " + Patient.Geschlecht;
            //textBox1.Text = Patient.Geschlecht.ToString();
            r.Checked = false;
            verwerfen.Enabled = false;


            Console.WriteLine("reset");


        }


    }
}
