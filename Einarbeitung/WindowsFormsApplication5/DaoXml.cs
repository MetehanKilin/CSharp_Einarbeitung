using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Xml;

namespace WindowsFormsApplication5
{
    class DaoXml : IDAO
    {
        private List<Patient> Patienten = new List<Patient>();
        private List<String> Module = new List<string>();
        private List<String> Forms = new List<string>();
        private XmlDocument xml = new XmlDocument();
        private string path = Environment.CurrentDirectory;


        public List<Patient> PatientenLaden()
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
            return Patienten;
        }

        public void update(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<string> ModuleLaden()
        {
            xml.Load(path + @"\Module.xml");
            XmlNodeList xnList = xml.SelectNodes("/Kis/Module/Modul");

            foreach (XmlNode node in xnList)
            {
                string modul = node["name"].InnerText;
                Module.Add(modul);
            }
            return Module;
        }

        public List<string> FormsLaden()
        {
            xml.Load(path + @"\Module.xml");
            XmlNodeList xnList = xml.SelectNodes("/Kis/Module/Modul");

            foreach (XmlNode node in xnList)
            {
                string form = node["Form"].InnerText;
                Forms.Add(form);
            }
            return Forms;
        }
    }
}
