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
    public partial class MemberModulForm5 : BasisModulForm
    {
        public MemberModulForm5()
        {
            InitializeComponent();
        }

        public override void load()
        {
            label1.Text = " ID: " + Patient.id + "\n "
                            + "Geschlecht: " + Patient.geschlecht + "\n "
                            + "Vorname: " + Patient.vorName + "\n "
                            + "Nachname: " + Patient.nachName + "\n "
                            + "Geburtstag: " + Patient.geburtstag.ToString("MM/dd/yyyy");
        }

        public void ModulFormLoad(object sender, EventArgs e)
        {
            label1.Text=" ID: " + Patient.id + "\n "
                            + "Geschlecht: " + Patient.geschlecht + "\n "
                            + "Vorname: " + Patient.vorName + "\n "
                            + "Nachname: " + Patient.nachName + "\n "
                            + "Geburtstag: " + Patient.geburtstag.ToString("MM/dd/yyyy")
                            ;
            //print(text);


            //label1.Text = " ID: " + patient.id + "\n "
            //                + "Geschlecht: " + patient.geschlecht + "\n "
            //                + "Vorname: " + patient.vorName + "\n "
            //                + "Nachname: " + patient.nachName + "\n "
            //                + "Geburtstag: " + patient.geburtstag.ToString("MM/dd/yyyy");

        }
    }
}
