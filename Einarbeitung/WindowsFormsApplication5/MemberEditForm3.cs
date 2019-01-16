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
    public partial class MemberEditForm3 : BaseEdit
    {
        public MemberEditForm3()
        {
            InitializeComponent();
        }


        public override void speichernButton_Click(object sender, EventArgs e)
        {
           

                    //Hauptseite.

                    BasisModulForm ab = (BasisModulForm) Form;

                    //hier die veränderung herausnehmen
                    //abspeichern in der Verwaltung
                    //MemberModulForm patient updaten
                    //laden Methode aufrufen

                    Patient.VorName = textBox1.Text;
                    Patient.NachName = textBox2.Text;
                    
                    Hauptseite.manipulationPatient(Patient);

                    //ab.label1.Text = a.ToString();



                    this.Close();
                    this.Dispose();
              
            

        }

        public override void load()
        {
            
            //editLabel.Text = "Vor- und Nachname: " + Patient.VorName + " " + Patient.NachName;
        }


        //public override void edit()
        //{


        //}




    }
}
