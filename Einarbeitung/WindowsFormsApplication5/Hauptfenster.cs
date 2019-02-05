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

namespace WindowsFormsApplication5
{
    public partial class Hauptfenster : Form
    {
        private List<VerwaltungForms> Verwaltung = new List<VerwaltungForms>();
        private List<Patient> Patienten = new List<Patient>();
        private Patient Currentpatient;
        private bool CurrentPatientSwitch;
        string path = Environment.CurrentDirectory;

        public Hauptfenster()
        {
            InitializeComponent();
            loadPatients();

            foreach (var item in Patienten)
            {
                comboBox1.Items.Add(item);
            }

        }


        private void loadPatients()
        {
            //Patienten.Add(new Patient(1, 'M', "Metehan", "Kilin", new DateTime(1990, 01, 01)));
            //Patienten.Add(new Patient(2, 'M', "Ingo", "Temme", new DateTime(1992, 02, 02)));
            //Patienten.Add(new Patient(3, 'M', "Ivaylo", "Topalov", new DateTime(1993, 03, 03)));
            //Patienten.Add(new Patient(4, 'M', "Roberto", "Danti", new DateTime(1994, 04, 04)));
            //Patienten.Add(new Patient(5, 'M', "Stefan", "Lober", new DateTime(1995, 05, 05)));
            //Patienten.Add(new Patient(6, 'W', "Bettina", "Araya", new DateTime(1996, 06, 06)));



            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\metehan.kilin\Source\Repos\CSharp_Einarbeitung\Einarbeitung\WindowsFormsApplication5\Patienten.xml");
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
                Console.WriteLine("Patient: {0} {1} {2} {3} {4}", id, geschlecht, vorname, nachname, geburtstag.ToString("dd/MM/yyyy"));
                Patienten.Add(new Patient(id, geschlecht, vorname, nachname, geburtstag));
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(path+@"\Modul1.dll");
            Object obj = assembly.CreateInstance("Modul1.MemberModulForm1");
            TypeInfo tp = obj.GetType().GetTypeInfo();
            Console.WriteLine(tp.Name);
            String a = tp.Name;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(path + @"\Modul2.dll");
            Object obj = assembly.CreateInstance("Modul2.MemberModulForm2");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(path + @"\Modul3.dll");
            Object obj = assembly.CreateInstance("Modul3.MemberModulForm3");
            BasisModulForm modul = obj as BasisModulForm;

            Object a = obj.GetType();

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(path + @"\Modul4.dll");
            Object obj = assembly.CreateInstance("Modul4.MemberModulForm4");
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFile(path + @"\Modul1.dll");
            Object obj = assembly.CreateInstance("Modul5.MemberModulForm5");
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