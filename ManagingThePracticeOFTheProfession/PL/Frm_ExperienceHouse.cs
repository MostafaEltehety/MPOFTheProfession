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
    public partial class Frm_ExperienceHouse : Form
    {
        public Frm_ExperienceHouse()
        {
            InitializeComponent();
        }

        void restart()
        {
            txt_No.Text = "";
        }

        private void btn_New_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_No.Text))
            {
                DAL.Cls_ExperienceHouse.Save(txt_No.Text.Trim());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
