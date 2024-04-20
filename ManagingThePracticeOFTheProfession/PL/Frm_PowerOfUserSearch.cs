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
    public partial class Frm_PowerOfUserSearch : Form
    {
        public DataTable dt;
        public Frm_PowerOfUserSearch()
        {
            InitializeComponent();
        }
       
        private void Frm_PowerOfUserSearch_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = DAL.ClassDAL.Select("select* from Users_Tbl");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = dt.Columns["UserID"].ToString();
            comboBox1.DisplayMember = dt.Columns["FullName"].ToString();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex<1)
            {
                this.Close();
                return;
            }
            lbl_ID.Text = comboBox1.SelectedValue.ToString();
            this.Close();
        }
    }
}
