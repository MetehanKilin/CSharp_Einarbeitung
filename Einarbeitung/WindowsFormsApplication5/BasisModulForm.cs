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
    public partial class BasisModulForm : Form
    {
        public BasisModulForm()
        {
            InitializeComponent();
        }

        private Patient patient;

        internal Patient Patient
        {
            get
            {
                return patient;
            }

            set
            {
                patient = value;
            }
        }

        public virtual void load()
        {
            Console.WriteLine("hallo");
        }

        private void BasisModulForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //löscht leider nicht die verwaltung in der Hauptseite

            //((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);

          
        }

        public virtual void edit()
        {
            


        }



        private void button1_Click(object sender, EventArgs e)
        {
            edit();
        }

        public virtual void editPatient(string s)
        {

        }
    }
}
