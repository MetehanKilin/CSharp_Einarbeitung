using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    interface IDAOB
    {
        List<Patient> PatientenLaden();
        void update(Patient patient);
        List<String> ModuleLaden();
        List<String> FormsLaden();
    }
}
