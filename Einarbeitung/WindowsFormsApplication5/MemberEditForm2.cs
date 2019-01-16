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
    public partial class MemberEditForm2 : BaseEdit
    {
        public MemberEditForm2()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            textBox1.Dispose();


            RadioButton rM = new RadioButton();
            rM.Text = "M";
            rM.Location = new System.Drawing.Point(textBox1.Location.X, textBox1.Location.Y);
            RadioButton rW = new RadioButton();
            rW.Text = "W";
            rW.Location = new System.Drawing.Point((textBox1.Location.X), (textBox1.Location.Y+20));


            Controls.Add(rM);
            Controls.Add(rW);



        }
    }
}
