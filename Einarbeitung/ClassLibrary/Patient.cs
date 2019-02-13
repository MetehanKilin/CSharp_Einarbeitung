using System;

namespace ClassLibrary
{
    public class Patient
    {
        private int id;
        private char geschlecht;
        private string vorName;
        private string nachName;
        private DateTime geburtstag;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public char Geschlecht
        {
            get
            {
                return geschlecht;
            }
            set
            {
                geschlecht = value;
            }
        }

        public string VorName
        {
            get
            {
                return vorName;
            }
            set
            {
                vorName = value;
            }
        }

        public string NachName
        {
            get
            {
                return nachName;
            }
            set
            {
                nachName = value;
            }
        }

        public DateTime Geburtstag
        {
            get
            {
                return geburtstag;
            }
            set
            {
                geburtstag = value;
            }
        }

        public Patient(int id, char geschlecht, string vorName, string nachName, DateTime geburtstag)
        {
            this.id = id;
            this.geschlecht = geschlecht;
            this.vorName = vorName;
            this.nachName = nachName;
            this.geburtstag = geburtstag;
        }
        
        public override string ToString()
        {
            return  "ID: " + id +
                    "\n Geschlecht" + Geschlecht +
                    "\n Vorname" + VorName +
                    "\n Nachname" + NachName +
                    "\n Geburtstag" + Geburtstag ;
        }
    }
}
