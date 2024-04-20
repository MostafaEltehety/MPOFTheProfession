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
    public partial class Frm_SearchOffice : Form
    {
        public DataTable dt = new DataTable();
        public Frm_SearchOffice()
        {
            InitializeComponent();
            DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
        }
        public Frm_SearchOffice(Int64 ideng)
        {
            InitializeComponent();
            //DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count>0)
            {
                dgv.Rows.Clear();
            }

            #region SearchByRegistrationNo
            if (!string.IsNullOrEmpty(txt_SearRegistrationNo.Text))
            {
                DataTable dtSearchByRegistrationNo = new DataTable();
                dtSearchByRegistrationNo = DAL.Cls_OfficeData.SearchByRegistrationNo(txt_SearRegistrationNo.Text);
                if (dtSearchByRegistrationNo.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByRegistrationNo.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell EngineeringRecordNo = new DataGridViewTextBoxCell();
                        DataGridViewCell Address = new DataGridViewTextBoxCell();
                        DataGridViewCell TaxCardNo = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(EngineeringRecordNo);
                        row.Cells.Add(Address);
                        row.Cells.Add(TaxCardNo);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["EngineeringRecordNo"].ToString();
                        row.Cells[4].Value = item["Address"].ToString();
                        row.Cells[5].Value = item["TaxCardNo"].ToString();
                        dgv.Rows.Add(row);
                        dt = new DataTable();
                        dt = dtSearchByRegistrationNo;
                    }
                }
            }
            #endregion

            #region SearchByNationalID
            if (!string.IsNullOrEmpty(txt_NationalID.Text))
            {
                DataTable dtSearchByNationalID = new DataTable();
                dtSearchByNationalID = DAL.Cls_OfficeData.SearchByNationalID(txt_NationalID.Text);
                if (dtSearchByNationalID.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByNationalID.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell EngineeringRecordNo = new DataGridViewTextBoxCell();
                        DataGridViewCell Address = new DataGridViewTextBoxCell();
                        DataGridViewCell TaxCardNo = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(EngineeringRecordNo);
                        row.Cells.Add(Address);
                        row.Cells.Add(TaxCardNo);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["EngineeringRecordNo"].ToString();
                        row.Cells[4].Value = item["Address"].ToString();
                        row.Cells[5].Value = item["TaxCardNo"].ToString();
                        dgv.Rows.Add(row);
                        dt = new DataTable();
                        dt = dtSearchByNationalID;
                    }
                }
            }
            #endregion

            #region SearchByNameEng
            if (!string.IsNullOrEmpty(txt_searchName.Text))
            {
                DataTable dtSearchByNameEng = new DataTable();
                dtSearchByNameEng = DAL.Cls_OfficeData.SearchByNameEng(txt_searchName.Text);
                if (dtSearchByNameEng.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByNameEng.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell EngineeringRecordNo = new DataGridViewTextBoxCell();
                        DataGridViewCell Address = new DataGridViewTextBoxCell();
                        DataGridViewCell TaxCardNo = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(EngineeringRecordNo);
                        row.Cells.Add(Address);
                        row.Cells.Add(TaxCardNo);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["EngineeringRecordNo"].ToString();
                        row.Cells[4].Value = item["Address"].ToString();
                        row.Cells[5].Value = item["TaxCardNo"].ToString();
                        dgv.Rows.Add(row);
                        dt = new DataTable();
                        dt = dtSearchByNameEng;
                    }
                }
                else
                {
                    MessageBox.Show("لاتوجد مكاتب للمهندس " + txt_searchName.Text);
                    //dgv.Enabled = false;
                }
            }
            
            #endregion

            #region SearchByEngineeringRecordNo
            if (!string.IsNullOrEmpty(txt_EngineeringRecordNo.Text))
            {
                DataTable dtSearchByEngineeringRecordNo = new DataTable();
                dtSearchByEngineeringRecordNo = DAL.Cls_OfficeData.SearchByEngineeringRecordNo(txt_EngineeringRecordNo.Text);
                if (dtSearchByEngineeringRecordNo.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSearchByEngineeringRecordNo.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell RegistrationNo = new DataGridViewTextBoxCell();
                        DataGridViewCell name = new DataGridViewTextBoxCell();
                        DataGridViewCell EngineeringRecordNo = new DataGridViewTextBoxCell();
                        DataGridViewCell Address = new DataGridViewTextBoxCell();
                        DataGridViewCell TaxCardNo = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(RegistrationNo);
                        row.Cells.Add(name);
                        row.Cells.Add(EngineeringRecordNo);
                        row.Cells.Add(Address);
                        row.Cells.Add(TaxCardNo);
                        row.Cells[0].Value = item["IDEng"].ToString();
                        row.Cells[1].Value = item["RegistrationNo"].ToString();
                        row.Cells[2].Value = item["EngName"].ToString();
                        row.Cells[3].Value = item["EngineeringRecordNo"].ToString();
                        row.Cells[4].Value = item["Address"].ToString();
                        row.Cells[5].Value = item["TaxCardNo"].ToString();
                        dgv.Rows.Add(row);
                        dt = new DataTable();
                        dt = dtSearchByEngineeringRecordNo;
                    }
                }
            }
            #endregion

           
        }

        private void txt_NationalID_KeyDown(object sender, KeyEventArgs e)
        {
            txt_searchName.Text = txt_searchName.Text = txt_SearRegistrationNo.Text = "";
        }

        private void txt_NationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_NationalID);
        }

        private void txt_SearRegistrationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_SearRegistrationNo);
        }

        private void txt_EngineeringRecordNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_EngineeringRecordNo);
        }

        private void Frm_SearchOffice_Load(object sender, EventArgs e)
        {

        }

        private void txt_SearRegistrationNo_KeyDown(object sender, KeyEventArgs e)
        {
            txt_searchName.Text = txt_NationalID.Text = txt_EngineeringRecordNo.Text = "";
        }

        private void txt_searchName_KeyDown(object sender, KeyEventArgs e)
        {
            txt_EngineeringRecordNo.Text = txt_NationalID.Text = txt_SearRegistrationNo.Text = "";
        }

        private void txt_EngineeringRecordNo_KeyDown(object sender, KeyEventArgs e)
        {
            txt_searchName.Text = txt_NationalID.Text = txt_SearRegistrationNo.Text = "";
        }

        private void dgv_Click(object sender, EventArgs e)
        {
          
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
