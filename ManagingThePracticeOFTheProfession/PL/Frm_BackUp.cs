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
    public partial class Frm_BackUp : Form
    {
        public Frm_BackUp()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = folderBrowserDialog1.SelectedPath;
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.BackUp(txt_path.Text + "\\ManagingThePracticeOFTheProfession " + DateTime.Now.ToString("yyyy_MM_dd __ HH_mm") + ".bak");
            MessageBox.Show("تم عمل النسخة الإحتياطية بنجاح");
            button2.Enabled = false;
        }
    }
}
