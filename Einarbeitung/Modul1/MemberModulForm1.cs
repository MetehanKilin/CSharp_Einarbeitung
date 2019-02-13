using ClassLibrary;

namespace Modul1
{
    public partial class MemberModulForm1 : BasisModulForm
    {
        public MemberModulForm1()
        {
            InitializeComponent();
            speichern.Visible = false;
            verwerfen.Visible=false;
        }

        protected override void load()
        {
            label1.Text = "Die ID lautet: " + Patient.Id;
        }
    }
}
