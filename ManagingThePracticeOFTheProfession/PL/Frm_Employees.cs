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
    public partial class Frm_Employees : Form
    {
        public Frm_Employees()
        {
            InitializeComponent();
        }

        void restart()
        {
            comboActive.SelectedIndex =comboJob.SelectedIndex= 0;
            txt_searchName.Text =lbl_IDEmp.Text= "";
            DAL.Cls_Employee.dgv(dataGridView1);
            dataGridView1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Employees_Load(object sender, EventArgs e)
        {
            restart();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (lbl_IDEmp.Text!="")
            {
                DAL.Cls_Employee.Edit(txt_searchName.Text.Trim(), comboJob.Text, comboActive.Text,Convert.ToInt16(lbl_IDEmp.Text));
                restart();
                return;
            }

            DAL.Cls_Employee.Save(txt_searchName.Text.Trim(), comboJob.Text, comboActive.Text);
            restart();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            lbl_IDEmp.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_searchName.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboJob.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboActive.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dataGridView1.Enabled = false;
            //restart();
        }
    }
}
