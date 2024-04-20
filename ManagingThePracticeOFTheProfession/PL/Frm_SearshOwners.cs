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
    public partial class Frm_SearshOwners : Form
    {
        public Frm_SearshOwners()
        {
            InitializeComponent();
            DAL.Clss_Owners.AutoCompletName(textBox1);
        }

        private void Frm_SearshOwners_Load(object sender, EventArgs e)
        {

        }



        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                DataTable dt = new DataTable();

                dt = DAL.Clss_Owners.Select("SELECT   IDOwner, Name, NationalID  FROM   dbo.OwnerData_Tbl  where Name= '" + textBox1.Text + "' and state=1");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell IDOwner = new DataGridViewTextBoxCell();
                        DataGridViewCell Name = new DataGridViewTextBoxCell();
                        DataGridViewCell NationalID = new DataGridViewTextBoxCell();

                        row.Cells.Add(IDOwner);
                        row.Cells.Add(Name);
                        row.Cells.Add(NationalID);

                        row.Cells[0].Value = item["IDOwner"].ToString();
                        row.Cells[1].Value = item["Name"].ToString();
                        row.Cells[2].Value = item["NationalID"].ToString();

                        dgv.Rows.Add(row);
                    }
                    return;
                }

            }

            #region NationlID
            if (!string.IsNullOrEmpty(txt_NationalID.Text))
            {
                DataTable dt = new DataTable();

                dt = DAL.Clss_Owners.Select("SELECT   IDOwner, Name, NationalID  FROM   dbo.OwnerData_Tbl  where NationalID= '" + txt_NationalID.Text + "' and state=1");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell IDOwner = new DataGridViewTextBoxCell();
                        DataGridViewCell Name = new DataGridViewTextBoxCell();
                        DataGridViewCell NationalID = new DataGridViewTextBoxCell();

                        row.Cells.Add(IDOwner);
                        row.Cells.Add(Name);
                        row.Cells.Add(NationalID);

                        row.Cells[0].Value = item["IDOwner"].ToString();
                        row.Cells[1].Value = item["Name"].ToString();
                        row.Cells[2].Value = item["NationalID"].ToString();

                        dgv.Rows.Add(row);
                    }
                    return;
                }

            }
            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
