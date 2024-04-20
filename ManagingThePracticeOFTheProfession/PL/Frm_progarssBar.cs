using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_progarssBar : Form
    {
        public Frm_progarssBar()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelProg.Width += 4;
        }

        private void Frm_progarssBar_Load(object sender, EventArgs e)
        {

        }
    }
}
