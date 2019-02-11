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
using MySql.Data.MySqlClient;

namespace Modul2
{
    public partial class MemberModulForm2 : BasisModulForm
    {

        public MemberModulForm2()
        {
            InitializeComponent();
        }
        //public MemberModulForm2(bool useSql) : base(useSql)
        //{
        //    _daoModul2 = ApplicationInit.GetDaoModul2()
        //    InitializeComponent();
        //}

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
            if (radioButton1.Checked)
            {
                Patient.Geschlecht= 'M';
            }
            else
            {
                Patient.Geschlecht = 'W';
            }

            if (DatabaseActive1)
            {
                try
                {

                    string update = "UPDATE patienten.patienten SET Geschlecht = '" + Patient.Geschlecht + "'WHERE(ID = '" + Patient.Id + "')";

                    MySqlConnection connection = new MySqlConnection(MyConnectionString1);

                    MySqlCommand command = new MySqlCommand(update, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Datenbank Modul 2 Update Fehler\n" + e.Message);
                }
                finally
                {
                    //command.Dispose();
                    //connection.ClearAllPoolsAsync();
                    //connection.Close();
                    //connection.Dispose();
                } 
            }
            else
            {
                Xml.Load(Path + @"\Patienten.xml");

                Console.WriteLine(Path + @"\Patienten.xml");

                XmlNodeList xnList = Xml.SelectNodes("/Kis/Patienten/Patient");

                foreach (XmlNode node in xnList)
                {
                    if (Int32.Parse(node["ID"].InnerText).Equals(Patient.Id))
                    {
                        node["Geschlecht"].InnerText = Patient.Geschlecht.ToString();
                    }
                }
                Xml.Save(Environment.CurrentDirectory + @"\Patienten.xml");
                Xml.RemoveAll();
                xnList = null;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }

      

    }
}
