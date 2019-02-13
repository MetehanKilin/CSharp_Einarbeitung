using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ClassLibrary
{
    class DaoDatabaseB : IDAOB
    {
        private string myConnectionString = "SERVER=127.0.0.1;" +
                                        "DATABASE=patienten;" +
                                        "UID=admin;" +
                                        "PASSWORD=admin;";
        private MySqlConnection connection;
        private MySqlCommand command;
        private List<Patient> Patienten=new List<Patient>();
        private List<String> Module = new List<string>();
        private List<String> Forms = new List<string>();


        public List<Patient> PatientenLaden()
        {
            try
            {
                connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM patienten";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();

                int id = 0;
                char a = ' ';
                string Vname = " ";
                string Nname = " ";
                DateTime geb = new DateTime();

                while (Reader.Read())
                {
                    id = Int32.Parse(Reader.GetValue(0).ToString());
                    string tempGeschlecht = Reader.GetValue(1).ToString();
                    a = tempGeschlecht[0];
                    Vname = Reader.GetValue(2).ToString();
                    Nname = Reader.GetValue(3).ToString();
                    geb = DateTime.Parse(Reader.GetValue(4).ToString());

                    Patienten.Add(new Patient(id, a, Vname, Nname, geb));
                }
                return Patienten;
            }
            catch (Exception e)
            {
                Console.WriteLine("Datenbank Fehler: Patientenladen\n" + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public void update(Patient patient)
        {
            try
            {
                string update = "UPDATE patienten.patienten SET Geschlecht = '"+
                    patient.Geschlecht.ToString()+"', Vorname='"+
                    patient.VorName.ToString()+"', Nachname='"+
                    patient.NachName.ToString()+"', Geburtstag = '" + 
                    patient.Geburtstag.ToString("yyyy/MM/dd") + 
                    "'WHERE(ID = '" + patient.Id + "')";

                connection = new MySqlConnection(myConnectionString);

                command = new MySqlCommand(update, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Datenbank Fehler: Update\n" + e.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public List<string> ModuleLaden()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM module";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();

                string modul = " ";
                string modulForm = " ";

                while (Reader.Read())
                {
                    modul = Reader.GetValue(0).ToString() + ".dll";
                    modulForm = Reader.GetValue(1).ToString();
                    Module.Add(modul);
                    Forms.Add(modulForm);
                }
                return Module;
            }
            catch (Exception e)
            {
                Console.WriteLine("Datenbank Fehler: ModulLaden\n" + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public List<string> FormsLaden()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myConnectionString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM module";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();

                string modulForm = " ";

                while (Reader.Read())
                {
                    modulForm = Reader.GetValue(1).ToString();
                    Forms.Add(modulForm);
                }
                return Forms;
            }
            catch (Exception e)
            {
                Console.WriteLine("Datenbank Fehler: FormLaden\n" + e.Message);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
