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
    public partial class Frm_EngineeringRecord :Form
    {
        public Frm_EngineeringRecord()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            #region SearchByRegistrationNo
            DataTable dtSearchByRegistrationNo = new DataTable();
            dtSearchByRegistrationNo = DAL.Cls_EngineersData.SearchByRegistrationNo(txt_SearRegistrationNo.Text);
            if (dtSearchByRegistrationNo.Rows.Count > 0)
            {
                txt_EngNam.Text = dtSearchByRegistrationNo.Rows[0]["EngName"].ToString();
                txt_RegistrationNo.Text = dtSearchByRegistrationNo.Rows[0]["RegistrationNo"].ToString();
                txt_ConsultantNo.Text = dtSearchByRegistrationNo.Rows[0]["ConsultantNo"].ToString();
                txt_EngineeringRecordNo.Text = dtSearchByRegistrationNo.Rows[0]["ConsultantNo"].ToString();
                lbl_IDEng.Text = dtSearchByRegistrationNo.Rows[0]["IDEng"].ToString();
            }
            #endregion

            #region SearchByNationalID
            DataTable dtSearchByNationalID = new DataTable();
            dtSearchByNationalID = DAL.Cls_EngineersData.SearchByNationalID(txt_NationalID.Text);
            if (dtSearchByNationalID.Rows.Count > 0)
            {
                txt_EngNam.Text = dtSearchByNationalID.Rows[0]["EngName"].ToString();
                txt_RegistrationNo.Text = dtSearchByNationalID.Rows[0]["RegistrationNo"].ToString();
                txt_ConsultantNo.Text = dtSearchByNationalID.Rows[0]["ConsultantNo"].ToString();
                txt_EngineeringRecordNo.Text = dtSearchByNationalID.Rows[0]["ConsultantNo"].ToString();
                lbl_IDEng.Text = dtSearchByNationalID.Rows[0]["IDEng"].ToString();
            }
            #endregion

            #region SearchByName
            DataTable dtSearchByName = new DataTable();
            dtSearchByName = DAL.Cls_EngineersData.SearchByName(txt_searchName.Text);
            if (dtSearchByName.Rows.Count > 0)
            {
                txt_EngNam.Text = dtSearchByName.Rows[0]["EngName"].ToString();
                txt_RegistrationNo.Text = dtSearchByName.Rows[0]["RegistrationNo"].ToString();
                txt_ConsultantNo.Text = dtSearchByName.Rows[0]["ConsultantNo"].ToString();
                txt_EngineeringRecordNo.Text = dtSearchByName.Rows[0]["ConsultantNo"].ToString();
                lbl_IDEng.Text = dtSearchByName.Rows[0]["IDEng"].ToString();
            }
            #endregion
            groupBox1.Enabled = false;
            #region SearchByEngineeringRecordNo
            if (!string.IsNullOrEmpty(txt_EngineeringRecordNo.Text))
            {
                DataTable dtSearchByEngineeringRecordNo = new DataTable();
                dtSearchByEngineeringRecordNo = DAL.Cls_OfficeData.SearchByEngineeringRecordNo(txt_EngineeringRecordNo.Text);
                if (dtSearchByEngineeringRecordNo.Rows.Count > 0)
                {
                    txt_EngNam.Text = dtSearchByName.Rows[0]["EngName"].ToString();
                    txt_RegistrationNo.Text = dtSearchByName.Rows[0]["RegistrationNo"].ToString();
                    txt_ConsultantNo.Text = dtSearchByName.Rows[0]["ConsultantNo"].ToString();
                    txt_EngineeringRecordNo.Text = dtSearchByName.Rows[0]["ConsultantNo"].ToString();
                    lbl_IDEng.Text = dtSearchByName.Rows[0]["IDEng"].ToString();
                }
            }
            #endregion
        }

        private void txt_SearRegistrationNo_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
