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
    public partial class Frm_SearchEngData : Form
    {
        public DataTable dtData=new DataTable() ;
        public Frm_SearchEngData()
        {
            InitializeComponent();
            DAL.ClassDAL.Close();
            DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
        }

        private void Frm_SearchEngData_Load(object sender, EventArgs e)
        {
        
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                dgv.Rows.Clear();
            }
            else
            {
                #region SearchByRegistrationNo
                DataTable dtSearchByRegistrationNo = new DataTable();
                dtSearchByRegistrationNo = DAL.Cls_EngineersData.SearchByRegistrationNo(txt_SearRegistrationNo.Text);
                if (dtSearchByRegistrationNo.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByRegistrationNo.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell NationalID = new DataGridViewTextBoxCell();
                        DataGridViewCell Division = new DataGridViewTextBoxCell();
                        DataGridViewCell year = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(NationalID);
                        row.Cells.Add(Division);
                        row.Cells.Add(year);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["NationalID"].ToString();
                        row.Cells[4].Value = item["Division"].ToString();
                        row.Cells[5].Value = Convert.ToDateTime(item["GraduationYear"].ToString()).ToString("yyyy");
                        dgv.Rows.Add(row);
                        dtData = new DataTable();
                        dtData = dtSearchByRegistrationNo;
                    }
                }
                #endregion

                #region SearchByNationalID
                DataTable dtSearchByNationalID = new DataTable();
                dtSearchByNationalID = DAL.Cls_EngineersData.SearchByNationalID(txt_NationalID.Text);
                if (dtSearchByNationalID.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByNationalID.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell NationalID = new DataGridViewTextBoxCell();
                        DataGridViewCell Division = new DataGridViewTextBoxCell();
                        DataGridViewCell year = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(NationalID);
                        row.Cells.Add(Division);
                        row.Cells.Add(year);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["NationalID"].ToString();
                        row.Cells[4].Value = item["Division"].ToString();
                        row.Cells[5].Value = Convert.ToDateTime(item["GraduationYear"].ToString()).ToString("yyyy");
                        dgv.Rows.Add(row);
                        dtData = new DataTable();
                        dtData = dtSearchByNationalID;
                    }
                }
                #endregion

                #region SearchByName
                DataTable dtSearchByName = new DataTable();
                dtSearchByName = DAL.Cls_EngineersData.SearchByName(txt_searchName.Text);
                if (dtSearchByName.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByName.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell NationalID = new DataGridViewTextBoxCell();
                        DataGridViewCell Division = new DataGridViewTextBoxCell();
                        DataGridViewCell year = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(NationalID);
                        row.Cells.Add(Division);
                        row.Cells.Add(year);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["NationalID"].ToString();
                        row.Cells[4].Value = item["Division"].ToString();
                        row.Cells[5].Value = Convert.ToDateTime(item["GraduationYear"].ToString()).ToString("yyyy");
                        dgv.Rows.Add(row);
                        dtData = new DataTable();
                        dtData = dtSearchByName;
                    }
                }
                #endregion
            }
        }

        private void dgv_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        

        private void txt_SearRegistrationNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_NationalID.Text!="" || txt_searchName.Text!="")
            {
                txt_NationalID.Text = txt_searchName.Text = "";
            }
        }

        private void txt_SearRegistrationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_SearRegistrationNo);
        }

        private void txt_NationalID_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_SearRegistrationNo.Text != "" || txt_searchName.Text != "")
            {
                txt_SearRegistrationNo.Text = txt_searchName.Text = "";
            }
        }

        private void txt_searchName_KeyDown(object sender, KeyEventArgs e)
        {
            //DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
            if (txt_SearRegistrationNo.Text != "" || txt_NationalID.Text != "")
            {
                txt_SearRegistrationNo.Text = txt_NationalID.Text = "";
            }
            if (e.KeyCode==Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void txt_NationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_NationalID);
        }

        private void txt_searchName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
