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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Modul2
{
    public partial class MemberModulForm2 : BasisModulForm
    {
        private System.Xml.XmlDocument xml = new XmlDocument();

        public MemberModulForm2()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Geschlecht: \n" + Patient.Geschlecht;

            if (Patient.Geschlecht == 'M')
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }


        protected override void saveData()
        {
            //Console.WriteLine("sprn");  


            //xml.Load(Path + @"\Patienten.xml");
            //XmlNodeList xnList = xml.SelectNodes("/Kis/Patienten/Patient");
            //XmlDocument doc = new XmlDocument();
            //doc.Load(Path + @"\Patienten.xml");

            

            if (radioButton1.Checked)
            {
                Patient.Geschlecht = 'M';

                

                //foreach (XmlNode node in xnList)
                //{
                   
                //    Console.WriteLine(node["ID"].InnerText);
                //    node["ID"].InnerText = "9999";      //läuft
                //}



                //doc.Save("C:\\temp\\neue.xml");
                

            }
            else
            {
                Patient.Geschlecht = 'W';
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);

        }

    }
}
