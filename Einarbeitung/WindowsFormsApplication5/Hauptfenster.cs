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
    public partial class Hauptfenster : Form
    {
        private List<VerwaltungForms> Verwaltung = new List<VerwaltungForms>();
        private List<Patient> Patienten = new List<Patient>();
        private Patient Currentpatient;

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
            MemberModulForm1 MemberForm;
            TabPage tabpage;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm1)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;

            MemberForm = new MemberModulForm1 { Text = button1Text };
            tabpage = new TabPage { Text = button1Text };

            MemberForm.Patient = Currentpatient;

            tabControl1.SelectedTab = tabpage;
            tabControl1.TabPages.Add(tabpage);
            MemberForm.Text = button1Text;
            MemberForm.TopLevel = false;
            MemberForm.Parent = tabpage;
            MemberForm.Show();
            MemberForm.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(MemberForm, tabpage));
        }



        private void button2_Click(object sender, EventArgs e)
        {
            MemberModulForm2 MemberForm;
            TabPage tabpage;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm2)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;


            MemberForm = new MemberModulForm2 { Text = button1Text };
            tabpage = new TabPage { Text = button1Text };

            MemberForm.Patient = Currentpatient;

            tabControl1.SelectedTab = tabpage;
            tabControl1.TabPages.Add(tabpage);
            MemberForm.Text = button1Text;
            MemberForm.TopLevel = false;
            MemberForm.Parent = tabpage;
            MemberForm.Show();
            MemberForm.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(MemberForm, tabpage));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemberModulForm3 MemberForm;
            TabPage tabpage;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm3)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;


            MemberForm = new MemberModulForm3 { Text = button1Text };
            tabpage = new TabPage { Text = button1Text };

            MemberForm.Patient = Currentpatient;

            tabControl1.SelectedTab = tabpage;
            tabControl1.TabPages.Add(tabpage);
            MemberForm.Text = button1Text;
            MemberForm.TopLevel = false;
            MemberForm.Parent = tabpage;
            MemberForm.Show();
            MemberForm.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(MemberForm, tabpage));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MemberModulForm4 MemberForm;
            TabPage tabpage;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm4)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;


            MemberForm = new MemberModulForm4 { Text = button1Text };
            tabpage = new TabPage { Text = button1Text };

            MemberForm.Patient = Currentpatient;

            tabControl1.SelectedTab = tabpage;
            tabControl1.TabPages.Add(tabpage);
            MemberForm.Text = button1Text;
            MemberForm.TopLevel = false;
            MemberForm.Parent = tabpage;
            MemberForm.Show();
            MemberForm.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(MemberForm, tabpage));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemberModulForm5 MemberForm;
            TabPage tabpage;

            for (int i = 0; i < Verwaltung.Count; i++)
            {
                if (Verwaltung[i].Form is MemberModulForm5)
                {
                    tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;


            MemberForm = new MemberModulForm5 { Text = button1Text };
            tabpage = new TabPage { Text = button1Text };

            MemberForm.Patient = Currentpatient;

            tabControl1.SelectedTab = tabpage;
            tabControl1.TabPages.Add(tabpage);
            MemberForm.Text = button1Text;
            MemberForm.TopLevel = false;
            MemberForm.Parent = tabpage;
            MemberForm.Show();
            MemberForm.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            Verwaltung.Add(new VerwaltungForms(MemberForm, tabpage));
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Verwaltung.Count; i++)
            {

                if (Verwaltung[i].Tabpage == this.tabControl1.SelectedTab)
                {

                    Verwaltung[i].Form.Close();

                    if (Verwaltung[i].Form.Closing1 == true)
                    {
                        Verwaltung[i].Form.Dispose();

                        Verwaltung[i].Tabpage.Dispose();
                        Verwaltung.RemoveAt(i);
                    }
                    else
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Currentpatient == null)
            {
                Console.WriteLine("ohnePatient");
            }
            else if (Verwaltung.Count < 1)
            {
                Console.WriteLine("ohneVerwaltung");
            }
            else if (comboBox1.SelectedItem != Currentpatient)
            {
                comboBox1.SelectedItem = Currentpatient;

                return;
            }
            else
            {   //Pruefung ob modul geoeffnet ist
                for (int i = 0; i < Verwaltung.Count; i++)
                {

                    if (!Verwaltung[i].Form.Closing1)
                    {
                        DialogResult result = MessageBox.Show("Nicht gespeicherte Daten, trotzdem Benutzer wechseln?", "speichern / verwerfen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Verwaltung[i].Form.Closing1 = true;
                        }
                        else if (result == DialogResult.No)
                        {
                            comboBox1.SelectedItem = Currentpatient;

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

                BasisModulForm f1 = Verwaltung[i].Form;
                f1.Patient = Currentpatient;

                f1.load();
            }


            if (Currentpatient != null)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("Es wurde kein Patient ausgewählt");
            }
        }








        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Currentpatient == null)
            {
                Console.WriteLine("ohnePatient");
            }
            else if (Verwaltung.Count < 1)
            {
                Console.WriteLine("ohneVerwaltung");
            }
            else
            {   //Pruefung ob modul geoeffnet ist
                for (int i = 0; i < Verwaltung.Count; i++)
                {

                    if (!Verwaltung[i].Form.Closing1)
                    {
                        tabControl1.SelectedTab = Verwaltung[i].Tabpage;
                        DialogResult result = MessageBox.Show("Nicht gespeicherte Daten, trotzdem schließen?", "speichern / verwerfen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            Verwaltung[i].Form.Closing1 = true;
                            return;
                        }
                        else if (result == DialogResult.No)
                        {
                            e.Cancel = (result == DialogResult.No);
                            return;
                        }






                    }

                    Verwaltung[i].Form.Close();
                    Verwaltung[i].Form.Dispose();
                    Verwaltung[i].Tabpage.Dispose();
                    Verwaltung.RemoveAt(i);
                    i--;


                }
            }
        }
    }
}
