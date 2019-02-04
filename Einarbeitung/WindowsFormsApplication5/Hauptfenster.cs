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
using Modul1;
using Modul2;
using Modul3;
using Modul4;
using Modul5;

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
            Patienten.Add(new Patient(1, 'M', "Metehan", "Kilin", new DateTime(1990, 01, 01)));
            Patienten.Add(new Patient(2, 'M', "Ingo", "Temme", new DateTime(1992, 02, 02)));
            Patienten.Add(new Patient(3, 'M', "Ivaylo", "Topalov", new DateTime(1993, 03, 03)));
            Patienten.Add(new Patient(4, 'M', "Roberto", "Danti", new DateTime(1994, 04, 04)));
            Patienten.Add(new Patient(5, 'M', "Stefan", "Lober", new DateTime(1995, 05, 05)));
            Patienten.Add(new Patient(6, 'W', "Bettina", "Araya", new DateTime(1996, 06, 06)));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm1)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            BasisModulForm modul = new MemberModulForm1();

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
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm2)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }
            BasisModulForm modul = new MemberModulForm2();
            
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
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm3)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            BasisModulForm modul = new MemberModulForm3();

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
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm4)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            BasisModulForm modul = new MemberModulForm4();

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
            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm5)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            BasisModulForm modul = new MemberModulForm5();

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