using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace WindowsFormsApplication5
{
    class VerwaltungForms
    {
        private BasisModulForm form;
        private TabPage tabpage;
        

        public VerwaltungForms(BasisModulForm f, TabPage t)
        {
            this.Form = f;
            this.Tabpage = t;
        }

        public BasisModulForm Form
        {
            get
            {
                return form;
            }

            set
            {
                form = value;
            }
        }

        public TabPage Tabpage
        {
            get
            {
                return tabpage;
            }

            set
            {
                tabpage = value;
            }
        }
    }
}
