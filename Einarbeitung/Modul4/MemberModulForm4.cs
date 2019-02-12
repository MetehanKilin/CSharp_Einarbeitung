using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using MySql.Data.MySqlClient;
using System.Xml;

namespace Modul4
{
    public partial class MemberModulForm4 : BasisModulForm
    {
        public MemberModulForm4()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Geburtstag: \n" + Patient.Geburtstag.ToString("dd/MM/yyyy");
            dateTimePicker1.Value = Patient.Geburtstag;
        }
        protected override void saveData()
        {
            Patient.Geburtstag = dateTimePicker1.Value;

            if (DatabaseActive1)
            {
                Console.WriteLine("DB Passiert");
            }
            else
            {
                Xml.Load(Path + @"\Patienten.xml");


                XmlNodeList xnList = Xml.SelectNodes("/Kis/Patienten/Patient");

                foreach (XmlNode node in xnList)
                {
                    if (Int32.Parse(node["ID"].InnerText).Equals(Patient.Id))
                    {
                        node["Geburtstag"].InnerText = Patient.Geburtstag.ToString("dd/MM/yyyy");
                    }
                }
                Xml.Save(Environment.CurrentDirectory + @"\Patienten.xml");
                Xml.RemoveAll();
                xnList = null;
            }
        }
      
        private void DateTimePicker1_ValueChanged(Object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
