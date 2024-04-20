using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession
{
    public partial class Main :Form
    {
        public Main()
        {
            InitializeComponent();

        }


        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        private void TitleEngData_Click(object sender, EventArgs e)
        {
            PL.FrmEngData frm = new PL.FrmEngData();
            frm.ShowDialog();
        }

        private void TileEngRecording_Click(object sender, EventArgs e)
        {
            PL.Frm_EngineeringRecord frm = new PL.Frm_EngineeringRecord();
            frm.ShowDialog();
        }

        private void TitleOfficeData_Click(object sender, EventArgs e)
        {
            PL.Frm_OfficeData frm = new PL.Frm_OfficeData();
            frm.ShowDialog();
        }

        private void TitleOwnersData_Click(object sender, EventArgs e)
        {
            PL.Frm_Owners frm = new PL.Frm_Owners();
            frm.ShowDialog();
        }

        private void TitleSH_D_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D frm = new PL.Forms.Frm_SH_D();
            frm.ShowDialog();
        }
    }
}
