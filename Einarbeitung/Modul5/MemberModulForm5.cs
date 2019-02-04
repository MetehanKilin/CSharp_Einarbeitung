﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Modul5
{
    public partial class MemberModulForm5 : BasisModulForm
    {
        public MemberModulForm5()
        {
            InitializeComponent();
            speichern.Visible = false;
            verwerfen.Visible = false;
        }

        protected override void load()
        {
            label1.Text = " ID: " + Patient.Id + "\n "
                            + "Geschlecht: " + Patient.Geschlecht + "\n "
                            + "Vorname: " + Patient.VorName + "\n "
                            + "Nachname: " + Patient.NachName + "\n "
                            + "Geburtstag: " + Patient.Geburtstag.ToString("MM/dd/yyyy");
        }

      
    }
}