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

namespace Modul3
{
    public partial class MemberModulForm3 : BasisModulForm
    {
        private string myConnectionString;

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
                    myConnectionString = "SERVER=127.0.0.1;" +
                                            "DATABASE=patienten;" +
                                            "UID=admin;" +
                                            "PASSWORD=admin;";

                    string update = "UPDATE patienten.patienten SET Nachname = '" + Patient.NachName.ToString() + "' WHERE(ID = '" + Patient.Id + "')";

                    MySqlConnection connection = new MySqlConnection(myConnectionString);

                    MySqlCommand c = new MySqlCommand(update,connection);
                    connection.Open();
                    c.ExecuteNonQuery();
                    connection.Close();

                    Console.WriteLine(update);
                }
                catch (Exception e)
                {

                    MessageBox.Show("Datenbank Modul3 Update Fehler\n" + e.Message);
                }







                Console.WriteLine("Datenbank");
            }
            else
            {
                Console.WriteLine("XML_SPEICHERN");
            }




            //Console.WriteLine("speichern");

            //string[] split = textBox1.Text.Split(null);

            //string pattern = "^([a-zA-ZäöüÄÖÜß])+ {1,}$ ([a-zA-ZäöüÄÖÜß])+$";
            //Match match = Regex.Match(textBox1.Text, pattern);

            //if (!match.Success == false)
            //{
            //    MessageBox.Show("Bitte Vorname und Nachme eingeben: (Max Mustermann)");
            //    return;
            //}
            //else
            //{
            //    Patient.VorName = split[0];
            //    Patient.NachName = split[1];
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonsPassed(true);
        }
    }
}
