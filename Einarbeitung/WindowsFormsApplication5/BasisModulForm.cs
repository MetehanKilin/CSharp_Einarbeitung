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

        }

        protected virtual void reset()
        {

        }

        private void verwerfen_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected virtual void saveData()
        {

        }

        private void speichern_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            verwerfen.Enabled = true;
        }
    }
}
