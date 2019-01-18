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
    public partial class MemberEditForm4 : BaseEdit
    {
        public MemberEditForm4()
        {
            InitializeComponent();
        }
        DateTimePicker d;
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            textBox1.Dispose();

            d = new DateTimePicker();
            //d.Value = Patient.Geburtstag;
            d.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y));       
            Controls.Add(d);
            
        

        }




        public override void verwerfenButton_Click(object sender, EventArgs e)
        {
            //Hauptseite.createPatients();

            Hauptseite.zurücksetzen(Patient, "4");

            this.Close();
            this.Dispose();

        }





        public override void speichernButton_Click(object sender, EventArgs e)
        {
            BasisModulForm ab = (BasisModulForm)Form;

            Patient.Geburtstag = d.Value;
            Hauptseite.manipulationPatient(Patient);
   
            this.Close();
            this.Dispose();
     
        }
        

    }
}
