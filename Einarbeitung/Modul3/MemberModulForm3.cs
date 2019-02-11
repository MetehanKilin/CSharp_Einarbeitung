using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using MySql.Data.MySqlClient;
using System.Xml;

namespace Modul3
{
    public partial class MemberModulForm3 : BasisModulForm
    {

        public MemberModulForm3()
        {
            InitializeComponent();
        }

        protected override void load()
        {
            label1.Text = "Vor- und Nachname: \n" + Patient.VorName + " " + Patient.NachName;
            textBox1.Text = Patient.VorName + " " + Patient.NachName;
        }


        protected override void saveData()
        {
            string[] split = textBox1.Text.Split(null);
            Patient.VorName = split[0];
            Patient.NachName = split[1];

            if (DatabaseActive1)
            {
                try
                {
                    string update = "UPDATE patienten.patienten SET Nachname = '" + Patient.NachName.ToString() +
                                        "', Vorname = '"+ Patient.VorName.ToString()+"'WHERE(ID = '" + Patient.Id + "')";

                    MySqlConnection connection = new MySqlConnection(MyConnectionString1);

                    MySqlCommand command = new MySqlCommand(update,connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    command.Connection.Dispose();
                    command.Dispose();
                    connection.ClearAllPoolsAsync();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Datenbank Modul 3 Update Fehler\n" + e.Message);
                }
            }
            else
            {
                Xml.Load(Path + @"\Patienten.xml");
                XmlNodeList xnList = Xml.SelectNodes("/Kis/Patienten/Patient");

                foreach (XmlNode node in xnList)
                {
                    if (Int32.Parse(node["ID"].InnerText).Equals(Patient.Id))
                    {
                        node["Vorname"].InnerText = Patient.VorName.ToString();
                        node["Nachname"].InnerText = Patient.NachName.ToString();
                    }
                }
                Xml.Save(Environment.CurrentDirectory + @"\Patienten.xml");
                Xml.RemoveAll();
                xnList = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
