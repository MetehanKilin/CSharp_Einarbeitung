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
