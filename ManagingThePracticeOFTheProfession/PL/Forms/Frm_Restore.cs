using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    public partial class Frm_Restore : Form
    {
        public Frm_Restore()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = openFileDialog1.FileName;
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.Restore(txt_path.Text);
            MessageBox.Show("تم استعادة النسخة الإحتياطية بنجاح");
            button2.Enabled = false;
        }
    }
}
