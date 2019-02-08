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
using System.Reflection;
using System.IO;
using System.Xml;
using System.Collections;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication5
{
    public partial class Hauptfenster : Form
    {
        private List<VerwaltungForms> Verwaltung = new List<VerwaltungForms>();
        private List<Patient> Patienten = new List<Patient>();
        private Patient Currentpatient;
        private bool CurrentPatientSwitch;
        private string path = Environment.CurrentDirectory;
        private XmlDocument xml = new XmlDocument();
        private List<String> Module = new List<string>();
        private List<String> Forms = new List<string>();
        private string path_Namespace;
        private string myConnectionString;
        private bool datanbankgeladen;

        public bool Datanbankgeladen
        {
            get
            {
                return datanbankgeladen;
            }

            set
            {
                datanbankgeladen = value;
            }
        }

        public Hauptfenster()
        {
            InitializeComponent();
            int startWith = start();
            loadPatients(startWith);
            loadModules(startWith);

            foreach (var item in Patienten)
            {
                comboBox1.Items.Add(item);
            }
        }
        private int start()
        {
            DialogResult result = MessageBox.Show("Woher sollen die Daten geladen werden?\n\n Datenbank = ja\n XML = nein", "Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                datanbankgeladen = true;
                return 1;
            }
            else 
            {
                return 2;
            }
        }

        private void loadPatients(int startWith)
        {
            if (startWith.Equals(1))
            {

                try
                {
                    myConnectionString = "SERVER=127.0.0.1;" +
                                            "DATABASE=patienten;" +
                                            "UID=admin;" +
                                            "PASSWORD=admin;";


                    MySqlConnection connection = new MySqlConnection(myConnectionString);
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
                    connection.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("Datenbank Patienten Fehler\n"+e.Message);
                }
                
            }
            else
            {
                xml.Load(path + @"\Patienten.xml");
                XmlNodeList xnList = xml.SelectNodes("/Kis/Patienten/Patient");

                foreach (XmlNode node in xnList)
                {
                    int id = Int32.Parse(node["ID"].InnerText);
                    string geschlechttemp = node["Geschlecht"].InnerText;
                    char geschlecht = geschlechttemp[0];
                    string vorname = node["Vorname"].InnerText;
                    string nachname = node["Nachname"].InnerText;
                    string geburtstagTemp = node["Geburtstag"].InnerText;
                    DateTime geburtstag = DateTime.Parse(geburtstagTemp);
                    Patienten.Add(new Patient(id, geschlecht, vorname, nachname, geburtstag));
                }
                xml.RemoveAll();
                xnList = null;
            }
        }

        private void loadModules(int startWith)
        {
            if (startWith.Equals(1))
            {



                try
                {
                    myConnectionString = "SERVER=127.0.0.1;" +
                                            "DATABASE=patienten;" +
                                            "UID=admin;" +
                                            "PASSWORD=admin;";


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
                        modul = Reader.GetValue(0).ToString()+".dll";
                        modulForm = Reader.GetValue(1).ToString();
                        Module.Add(modul);
                        Forms.Add(modulForm);

                        Console.WriteLine(modul);
                        Console.WriteLine(modulForm);
                    }
                    connection.Close();

                }
                catch (Exception e)
                {

                    MessageBox.Show("Datenbank Modul Fehler\n" + e.Message);
                }

            }
            else
            {
                xml.Load(path + @"\Module.xml");
                XmlNodeList xnList = xml.SelectNodes("/Kis/Module/Modul");

                foreach (XmlNode node in xnList)
                {
                    string modul = node["name"].InnerText;
                    string form = node["Form"].InnerText;
                    Module.Add(modul);
                    Forms.Add(form);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            path_Namespace = Module[0].Substring(0, (Module[0].Length - 4));
            Console.WriteLine(path_Namespace);
            Assembly assembly = Assembly.LoadFile(path + @"\" + Module[0]);
            Object obj = assembly.CreateInstance(path_Namespace+"."+ Forms[0]);
            BasisModulForm modul = obj as BasisModulForm;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form.GetType() == modul.GetType())   // noch überprüfen
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            TabPage tabpage = new TabPage { Text = button1.Text };
            modul.Patient = Currentpatient;
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
            modul.TopLevel = false;
            modul.Parent = tabpage;
            modul.Show();
            modul.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(modul, tabpage));
            Verwaltung[0].Form.DatabaseActive1 = datanbankgeladen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path_Namespace = Module[1].Substring(0, (Module[1].Length - 4));

            Assembly assembly = Assembly.LoadFile(path + @"\" + Module[1]);
            Object obj = assembly.CreateInstance(path_Namespace + "." + Forms[1]);
            BasisModulForm modul = obj as BasisModulForm;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form.GetType() == modul.GetType())
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }


            TabPage tabpage = new TabPage { Text = button2.Text };
            modul.Patient = Currentpatient;
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
            modul.TopLevel = false;
            modul.Parent = tabpage;
            modul.Show();
            modul.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(modul, tabpage));
            Verwaltung[0].Form.DatabaseActive1 = datanbankgeladen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            path_Namespace = Module[2].Substring(0, (Module[2].Length - 4));

            Assembly assembly = Assembly.LoadFile(path + @"\" + Module[2]);
            Object obj = assembly.CreateInstance(path_Namespace + "." + Forms[2]);
            BasisModulForm modul = obj as BasisModulForm;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form.GetType() == modul.GetType())
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            TabPage tabpage = new TabPage { Text = button3.Text };
            modul.Patient = Currentpatient;
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
            modul.TopLevel = false;
            modul.Parent = tabpage;
            modul.Show();
            modul.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(modul, tabpage));
            Verwaltung[0].Form.DatabaseActive1 = datanbankgeladen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            path_Namespace = Module[3].Substring(0, (Module[3].Length - 4));

            Assembly assembly = Assembly.LoadFile(path + @"\" + Module[3]);
            Object obj = assembly.CreateInstance(path_Namespace + "." + Forms[3]);
            BasisModulForm modul = obj as BasisModulForm;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form.GetType() == modul.GetType())
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            TabPage tabpage = new TabPage { Text = button4.Text };
            modul.Patient = Currentpatient;
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
            modul.Text = button4.Text;
            modul.TopLevel = false;
            modul.Parent = tabpage;
            modul.Show();
            modul.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(modul, tabpage));
            Verwaltung[0].Form.DatabaseActive1 = datanbankgeladen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            path_Namespace = Module[4].Substring(0, (Module[4].Length - 4));

            Assembly assembly = Assembly.LoadFile(path + @"\" + Module[4]);
            Object obj = assembly.CreateInstance(path_Namespace + "." + Forms[4]);
            BasisModulForm modul = obj as BasisModulForm;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form.GetType() == modul.GetType())
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            TabPage tabpage = new TabPage { Text = button5.Text };
            modul.Patient = Currentpatient;
            tabControl1.TabPages.Add(tabpage);
            tabControl1.SelectedTab = tabpage;
            modul.Text = button5.Text;
            modul.TopLevel = false;
            modul.Parent = tabpage;
            modul.Show();
            modul.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(modul, tabpage));
            Verwaltung[0].Form.DatabaseActive1 = datanbankgeladen;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentPatientSwitch)
            {
                return;
            }
            {   //Pruefung ob modul geoeffnet ist
                for (int i = 0; i < Verwaltung.Count; i++)
                {
                    
                    if (!Verwaltung[i].Form.Closing1)
                    {
                        tabControl1.SelectedTab = Verwaltung[i].Tabpage;

                        switch (Verwaltung[i].Form.CloseWindowCheck())
                        {
                            case 1:
                                Verwaltung[i].Form.savedData();
                                break;
                            case 2:
                                break;
                            default:
                                CurrentPatientSwitch = true;
                                comboBox1.SelectedItem = Currentpatient;
                                CurrentPatientSwitch = false;
                                return;
                        }
                    }
                }
            }

            //Patienten Suchen 
            Currentpatient = comboBox1.SelectedItem as Patient;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                Verwaltung[i].Form.Patient = Currentpatient;
                Verwaltung[i].Form.DatenLaden();
            }

            if (Currentpatient != null)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Tabpage == this.tabControl1.SelectedTab)
                {
                    if (!Fensterschließen(i))
                    {
                        return;
                    }
                }
            }
            if (Verwaltung.Count == 0)
            {
                Delete.Enabled = false;
            }
        }

        private bool Fensterschließen(int index)
        {
            Verwaltung[index].Form.Close();
            if (Verwaltung[index].Form.Closing1 == true)
            {
                Verwaltung[index].Form.Dispose();
                Verwaltung[index].Tabpage.Dispose();
                Verwaltung.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Pruefung ob modul geoeffnet ist
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                tabControl1.SelectedTab = Verwaltung[i].Tabpage;

                if (!Fensterschließen(i))
                {
                    e.Cancel = true;
                    return;
                }
                i--;
            }
        }
    }
}