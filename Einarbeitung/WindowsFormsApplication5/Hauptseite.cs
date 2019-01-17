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
    public partial class Hauptseite : Form
    {
        static List<VerwaltungForms> verwaltung = new List<VerwaltungForms>();
        static List<Patient> patienten = new List<Patient>();

        static Patient p1;
        static Patient p2;
        static Patient p3;
        static Patient p4;
        static Patient p5;



        static Patient patient;
        BasisModulForm form;
        TabPage tabpage1;

        //MemberModulForm1 form1;
        //MemberModulForm2 form2;
        //MemberModulForm3 form3;
        //MemberModulForm4 form4;
        //MemberModulForm5 form5;



        //comboBox1.Items[1] = p2.vorName;
        //comboBox1.Items[2] = p3.vorName;
        //comboBox1.Items[3] = p4.vorName;
        //comboBox1.Items[4] = p5.vorName;



        public Hauptseite()
        {
            InitializeComponent();

            createPatients();
            loadPatients();

            comboBox1.Items.Add(p1.VorName);
            comboBox1.Items.Add(p2.VorName);
            comboBox1.Items.Add(p3.VorName);
            comboBox1.Items.Add(p4.VorName);
            comboBox1.Items.Add(p5.VorName);

        }


        public static void createPatients()
        {
            p1 = new Patient(1, 'm', "AAA", "BBB", new DateTime(1990, 01, 01));
            p2 = new Patient(2, 'w', "CCC", "DDD", new DateTime(1991, 02, 02));
            p3 = new Patient(3, 'm', "EEE", "FFF", new DateTime(1992, 03, 03));
            p4 = new Patient(4, 'w', "GGG", "HHH", new DateTime(1993, 04, 04));
            p5 = new Patient(5, 'm', "III", "JJJ", new DateTime(1994, 05, 05));
        }
        


        public static void loadPatients()
        {
            patienten.Add(p1);
            patienten.Add(p2);
            patienten.Add(p3);
            patienten.Add(p4);
            patienten.Add(p5);
        }

       

        public static void manipulationPatient(Patient p)
        {
            for (int i = 0; i < patienten.Count; i++)
            {
                if (patienten[i].Id==p.Id)
                {
                    patienten[i] = p;
                    patient = p;
                    for (int j = 0; j < verwaltung.Count; j++)
                    {
                        BasisModulForm f1 = (BasisModulForm)verwaltung[j].form;
                        f1.Patient = patient;
                        f1.load();
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add(p1.VorName);
                        comboBox1.Items.Add(p2.VorName);
                        comboBox1.Items.Add(p3.VorName);
                        comboBox1.Items.Add(p4.VorName);
                        comboBox1.Items.Add(p5.VorName);

                        //comboBox1.SelectedItem = comboBox1.FindString(patient.VorName);
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(patient.VorName);
                        break;
                    }
                    break;
                }
            }


            
        }


        public static void zurücksetzen(Patient p)
        {
            patienten.Clear();
            loadPatients();


            for (int i = 0; i < patienten.Count; i++)
            {
                if (patienten[i].Id == p.Id)
                {
                    //patienten[i] = p;
                    patient = patienten[i];
                    for (int j = 0; j < verwaltung.Count; j++)
                    {
                        BasisModulForm f1 = (BasisModulForm)verwaltung[j].form;
                        f1.Patient = patient;

                        f1.load();


                        comboBox1.Items.Clear();

                        comboBox1.Items.Add(p1.VorName);
                        comboBox1.Items.Add(p2.VorName);
                        comboBox1.Items.Add(p3.VorName);
                        comboBox1.Items.Add(p4.VorName);
                        comboBox1.Items.Add(p5.VorName);

                        comboBox1.SelectedIndex = comboBox1.FindStringExact(patient.VorName);

                        break;
                    }
                    break;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < verwaltung.Count; i++)
            {
                if (verwaltung[i].form is MemberModulForm1)
                {
                    tabControl1.SelectedTab = verwaltung[i].tabpage;
                    return;
                }
            }

            Button button1 = (Button)sender;
            string button1Text = button1.Text;


            form = new MemberModulForm1 { Text = button1Text };
            tabpage1 = new TabPage { Text = button1Text };

            form.Patient = patient;

            tabControl1.SelectedTab = tabpage1;
            tabControl1.TabPages.Add(tabpage1);
            form.Text = button1Text;
            form.TopLevel = false;
            form.Parent = tabpage1;
            form.Show();
            form.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            verwaltung.Add(new VerwaltungForms(form, tabpage1));
        }



        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < verwaltung.Count; i++)
            {
                if (verwaltung[i].form is MemberModulForm2)
                {
                    tabControl1.SelectedTab = verwaltung[i].tabpage;
                    return;
                }
            }

            Button button2 = (Button)sender;
            string button2Text = button2.Text;


            form = new MemberModulForm2 { Text = button2Text };
            tabpage1 = new TabPage { Text = button2Text };

            form.Patient = patient;

            tabControl1.SelectedTab = tabpage1;
            tabControl1.TabPages.Add(tabpage1);
            form.Text = button2Text;
            form.TopLevel = false;
            form.Parent = tabpage1;
            form.Show();
            form.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            verwaltung.Add(new VerwaltungForms(form, tabpage1));
          


            //Button button2 = (Button)sender;
            //string button2Text = button2.Text;


            //MemberModulForm2 form2 = new MemberModulForm2 { Text = button2Text };
            //TabPage tabpage2 = new TabPage { Text = button2Text };

            //form2.Patient = patient;

            //tabControl1.SelectedTab = tabpage2;
            //tabControl1.TabPages.Add(tabpage2);
            //form2.Text = button2Text;
            //form2.TopLevel = false;
            //form2.Parent = tabpage2;
            //form2.Show();
            //Delete.Enabled = true;

            //verwaltung.Add(new VerwaltungForms(form2, tabpage2, patient));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < verwaltung.Count; i++)
            {
                if (verwaltung[i].form is MemberModulForm3)
                {
                    tabControl1.SelectedTab = verwaltung[i].tabpage;
                    return;
                }
            }

            Button button3 = (Button)sender;
            string button3Text = button3.Text;


            form = new MemberModulForm3 { Text = button3Text };
            tabpage1 = new TabPage { Text = button3Text };

            form.Patient = patient;

            tabControl1.SelectedTab = tabpage1;
            tabControl1.TabPages.Add(tabpage1);
            form.Text = button3Text;
            form.TopLevel = false;
            form.Parent = tabpage1;
            form.Show();
            form.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            verwaltung.Add(new VerwaltungForms(form, tabpage1));


            //for (int i = 0; i < verwaltung.Count; i++)
            //{
            //    if (verwaltung[i].form is MemberModulForm3)
            //    {
            //        tabControl1.SelectedTab = verwaltung[i].tabpage;
            //        return;
            //    }
            //}


            //Button button3 = (Button)sender;
            //string button3Text = button3.Text;


            //MemberModulForm3 form3 = new MemberModulForm3 { Text = button3Text };
            //TabPage tabpage3 = new TabPage { Text = button3Text };

            //form3.Patient = patient;

            //tabControl1.SelectedTab = tabpage3;
            //tabControl1.TabPages.Add(tabpage3);
            //form3.Text = button3Text;
            //form3.TopLevel = false;
            //form3.Parent = tabpage3;
            //form3.Show();
            //Delete.Enabled = true;

            //verwaltung.Add(new VerwaltungForms(form3, tabpage3, patient));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < verwaltung.Count; i++)
            {
                if (verwaltung[i].form is MemberModulForm4)
                {
                    tabControl1.SelectedTab = verwaltung[i].tabpage;
                    return;
                }
            }

            Button button4 = (Button)sender;
            string button4Text = button4.Text;


            form = new MemberModulForm4 { Text = button4Text };
            tabpage1 = new TabPage { Text = button4Text };

            form.Patient = patient;

            tabControl1.SelectedTab = tabpage1;
            tabControl1.TabPages.Add(tabpage1);
            form.Text = button4Text;
            form.TopLevel = false;
            form.Parent = tabpage1;
            form.Show();
            form.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            verwaltung.Add(new VerwaltungForms(form, tabpage1));


            //for (int i = 0; i < verwaltung.Count; i++)
            //{
            //    if (verwaltung[i].form is MemberModulForm4)
            //    {
            //        tabControl1.SelectedTab = verwaltung[i].tabpage;
            //        return;
            //    }
            //}

            //Button button4 = (Button)sender;
            //string button4Text = button4.Text;


            //MemberModulForm4 form4 = new MemberModulForm4 { Text = button4Text };
            //TabPage tabpage4 = new TabPage { Text = button4Text };

            //form4.Patient = patient;

            //tabControl1.SelectedTab = tabpage4;
            //tabControl1.TabPages.Add(tabpage4);
            //form4.Text = button4Text;
            //form4.TopLevel = false;
            //form4.Parent = tabpage4;
            //form4.Show();
            //Delete.Enabled = true;

            //verwaltung.Add(new VerwaltungForms(form4, tabpage4, patient));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < verwaltung.Count; i++)
            {
                if (verwaltung[i].form is MemberModulForm5)
                {
                    tabControl1.SelectedTab = verwaltung[i].tabpage;
                    return;
                }
            }

            Button button5 = (Button)sender;
            string button5Text = button5.Text;


            form = new MemberModulForm5 { Text = button5Text };
            tabpage1 = new TabPage { Text = button5Text };

            form.Patient = patient;

            tabControl1.SelectedTab = tabpage1;
            tabControl1.TabPages.Add(tabpage1);
            form.Text = button5Text;
            form.TopLevel = false;
            form.Parent = tabpage1;
            form.Show();
            form.Dock = DockStyle.Fill;
            Delete.Enabled = true;
            verwaltung.Add(new VerwaltungForms(form, tabpage1));


            //for (int i = 0; i < verwaltung.Count; i++)
            //{
            //    if (verwaltung[i].form is MemberModulForm5)
            //    {
            //        tabControl1.SelectedTab = verwaltung[i].tabpage;
            //        verwaltung[i].patient = patient;

            //        return;
            //    }
            //}


            //Button button5 = (Button)sender;
            //string button5Text = button5.Text;

            //MemberModulForm5 form5 = new MemberModulForm5 { Text = button5Text };
            //TabPage tabpage5 = new TabPage { Text = button5Text };

            //form5.Patient = patient;

            //tabControl1.SelectedTab = tabpage5;
            //tabControl1.TabPages.Add(tabpage5);
            //form5.Text = button5Text;
            //form5.TopLevel = false;
            //form5.Parent = tabpage5;
            //form5.Show();
            //Delete.Enabled = true;

            //verwaltung.Add(new VerwaltungForms(form5, tabpage5, patient));
        }


        private void Delete_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < verwaltung.Count; i++)
                {
                    if (verwaltung[i].tabpage == this.tabControl1.SelectedTab)
                    {

                        verwaltung[i].form.Close();
                        verwaltung[i].form.Dispose();
                    
                        verwaltung[i].tabpage.Dispose();
                        verwaltung.RemoveAt(i);
                    }

                }
                

                if (verwaltung.Count == 0)
                {
                    Delete.Enabled = false;
                    //comboBox1.Enabled = true;
                }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedPatient = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            //Patienten Suchen 
            for (int i = 0; i < patienten.Count; i++)
            {
                //Console.WriteLine(patienten[i].vorName);
                if (patienten[i].VorName == comboBox1.SelectedItem.ToString())
                {
                    patient = patienten[i];
                    //patient = new Patient(patienten[i].Id, patienten[i].Geschlecht, patienten[i].VorName, patienten[i].NachName, patienten[i].Geburtstag);
                    break; 
                }
            }


            
            




            for (int i = 0; i < verwaltung.Count; i++)
            {
                BasisModulForm f1 = (BasisModulForm)verwaltung[i].form;
                f1.Patient = patient;
                f1.load();
                



            }





            //if (verwaltung.Count != 0)
            //{
            //}

            

            if (patient != null)
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


        public void update()
        {
          

        }


    }
}
