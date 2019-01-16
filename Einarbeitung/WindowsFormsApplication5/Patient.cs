using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public class Patient
    {
        int id;
        public char geschlecht;
        public string vorName;
        public string nachName;
        public DateTime geburtstag;

        public Patient(int id, char geschlecht, string vorName, string nachName, DateTime geburtstag)
        {
            this.id = id;
            this.geschlecht = geschlecht;
            this.vorName = vorName;
            this.nachName = nachName;
            this.geburtstag = geburtstag;
        }



    }


}
