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
    public partial class MemberEditForm2 : BaseEdit
    {
        public MemberEditForm2()
        {
            InitializeComponent();
        }

        char geschlecht;

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            textBox1.Dispose();


            if (Patient.Geschlecht=='M' || Patient.Geschlecht=='m')
            {
                RadioButton rW = new RadioButton();
                rW.Text = "W";
                rW.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y));
                Controls.Add(rW);
                geschlecht = 'W';
               
            }
            else if (Patient.Geschlecht=='W' || Patient.Geschlecht=='w')
            {
                RadioButton rM = new RadioButton();
                rM.Text = "M";
                rM.Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
                Controls.Add(rM);
                geschlecht = 'M';
            }
            else
            {
                MessageBox.Show("Kein Geschlecht zugeordnet");
                
            }
        }



        public override void speichernButton_Click(object sender, EventArgs e)
        {
            BasisModulForm ab = (BasisModulForm)Form;

            //hier die veränderung herausnehmen
            //abspeichern in der Verwaltung
            //MemberModulForm patient updaten
            //laden Methode aufrufen

            Patient.Geschlecht = geschlecht;
            Hauptseite.manipulationPatient(Patient);


            this.Close();
            this.Dispose();
                   
            }

        public override void verwerfenButton_Click(object sender, EventArgs e)
        {
            //Hauptseite.createPatients();

            Hauptseite.zurücksetzen(Patient, "2");

            this.Close();
            this.Dispose();

        }




    }




    //public override void speichernButton_Click(object sender, EventArgs e)
    //{
    //    bool b = true;
    //    int a;


    //    if (b)
    //    {
    //        if (int.TryParse(textBox1.Text, out a))
    //        {

    //            //Hauptseite.

    //            BasisModulForm ab = (BasisModulForm)Form;

    //            //hier die veränderung herausnehmen
    //            //abspeichern in der Verwaltung
    //            //MemberModulForm patient updaten
    //            //laden Methode aufrufen

    //            Patient.Geschlecht = 'a';

    //            Hauptseite.manipulationPatient(Patient);

    //            //ab.label1.Text = a.ToString();



    //            this.Close();
    //            this.Dispose();
    //            b = false;
    //        }
    //        else
    //        {
    //            MessageBox.Show("Bitte geben Sie ein Int ein");
    //        }
    //    }

    //}



}
