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
    public partial class Frm_OfficeData : Form
    {
        DataTable dtData = new DataTable();
        Int64 IDOffice = 0;
        public Frm_OfficeData()
        {
            InitializeComponent();
            DAL.Cls_EngineersData.AutoCompletNameNOTCON(txt_searchName);
            btn_New_Click(null, null);
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
                lbl_IDEng.Text= dtSearchByRegistrationNo.Rows[0]["IDEng"].ToString();
                txt_TaxCardNo.Text= dtSearchByRegistrationNo.Rows[0]["TaxCardNo"].ToString();
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

                txt_TaxCardNo.Text= dtSearchByNationalID.Rows[0]["TaxCardNo"].ToString();
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
                txt_EngineeringRecordNo.Text = dtSearchByName.Rows[0]["EngineeringRecordNo"].ToString();
                lbl_IDEng.Text = dtSearchByName.Rows[0]["IDEng"].ToString();
                txt_TaxCardNo.Text = dtSearchByName.Rows[0]["TaxCardNo"].ToString();

            }
            #endregion
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;



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
                        DataGridViewCell oficeName = new DataGridViewTextBoxCell();
                        DataGridViewCell adresOffice = new DataGridViewTextBoxCell();
                        DataGridViewCell PhoneOfice = new DataGridViewTextBoxCell();
                        DataGridViewCell Notes = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(oficeName);
                        row.Cells.Add(adresOffice);
                        row.Cells.Add(PhoneOfice);
                        row.Cells.Add(Notes);
                   
                        row.Cells[0].Value = item["IDOffice"].ToString();
                        row.Cells[1].Value = item["OFficeName"].ToString();
                        row.Cells[2].Value = item["Address"].ToString();
                        row.Cells[3].Value = item["Phone"].ToString();
                        row.Cells[4].Value = item["Notes"].ToString();
                     
                        dgv.Rows.Add(row);
                        //dt = new DataTable();
                        //dt = dtSearchByNameEng;
                    }
                }
                else
                {
                    MessageBox.Show("لاتوجد مكاتب للمهندس " + txt_searchName.Text);
                    //dgv.Enabled = false;
                }
            }

            #endregion
            dgv.Enabled = true;
        }




        private void Frm_OfficeData_Load(object sender, EventArgs e)
        {

        }
        void Clear(GroupBox GB)
        {
            foreach (Control ctr in GB.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                if (ctr is ComboBox)
                {
                    ctr.Text = "";
                }

            }
        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            Clear(groupBox1);
            Clear(groupBox2);
            txt_TaxCardNo.Text = "";
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            txt_ConsultantNo.Text = txt_EngineeringRecordNo.Text = txt_EngNam.Text =txt_RegistrationNo.Text= "";
            btn_Delete.Enabled = btn_Edit.Enabled = false;
            btn_Save.Enabled = true;
            dgv.Rows.Clear();
            dgv.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count==0)
            {
                return;
            }
          
            DAL.Cls_OfficeData.Save(dgv,Convert.ToInt64(lbl_IDEng.Text));
            btn_New_Click(null,null);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //لايسمح بالحذف فى حالة التعامل مع الشهادات 
            DialogResult result = MessageBox.Show("هل تريد حذف المكتب "  , "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                DAL.Cls_OfficeData.Delete(Convert.ToInt64(lbl_IDOffice.Text));
                btn_New_Click(null, null);
            }
         
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //if (DAL.ClassDAL.Select("select [TaxCardNo] from [dbo].[Office_Tbl] where TaxCardNo= '" + txt_TaxCardNo.Text + "' and [IDOffice]!='" + IDOffice + "'").Rows.Count > 0)
            //{
            //    MessageBox.Show("رقم البطاقة الضريبية لايمكن تكراره");
            //    txt_TaxCardNo.Focus();
            //    return;
            //}
            DAL.Cls_OfficeData.Update(  txt_Address.Text, txt_Phone.Text, txt_Notes.Text, Convert.ToInt64(lbl_IDOffice.Text), Convert.ToInt64(lbl_IDEng.Text),txt_Name.Text);
        }

        private void bt_SearchOffice_Click(object sender, EventArgs e)
        {
            PL.Frm_SearchOffice frm = new PL.Frm_SearchOffice();
            frm.ShowDialog();
            if (frm.dt.Rows.Count>0)
            {
                //lbl_IDOffice.Text = frm.dgv.CurrentRow.Cells["IDOffice"].Value.ToString();

                //lbl_IDOffice.Text = frm.dgv.CurrentRow.Cells["IDOffice"].Value.ToString();
                lbl_IDEng.Text = frm.dt.Rows[0]["IDEng"].ToString();
                //lbl_IDEng.Text = frm.dgv.CurrentRow.Cells["IDEng"].Value.ToString();
                //txt_TaxCardNo.Text = frm.dgv.CurrentRow.Cells["TaxCardNo"].Value.ToString();

                //txt_TaxCardNo.Text = frm.dt.Rows[0]["TaxCardNo"].ToString();
                txt_Address.Text = frm.dt.Rows[0]["Address"].ToString();
                txt_Address.Text = frm.dgv.CurrentRow.Cells["Address"].Value.ToString();
                //txt_Phone.Text = frm.dt.Rows[0]["Phone"].ToString();
                txt_Phone.Text = frm.dgv.CurrentRow.Cells["Phone"].Value.ToString();
                //txt_Notes.Text = frm.dt.Rows[0]["Notes"].ToString();
                txt_Notes.Text = frm.dgv.CurrentRow.Cells["Notes"].Value.ToString();
                txt_ConsultantNo.Text = frm.dt.Rows[0]["ConsultantNo"].ToString();
                txt_ConsultantNo.Text = frm.dgv.CurrentRow.Cells["ConsultantNo"].Value.ToString();
                txt_EngNam.Text = frm.dt.Rows[0]["EngName"].ToString();
                txt_EngNam.Text = frm.dgv.CurrentRow.Cells["EngName"].Value.ToString();
                txt_RegistrationNo.Text = frm.dt.Rows[0]["RegistrationNo"].ToString();
                txt_RegistrationNo.Text = frm.dgv.CurrentRow.Cells["RegistrationNo"].Value.ToString();
                txt_EngineeringRecordNo.Text = frm.dt.Rows[0]["EngineeringRecordNo"].ToString();
                //txt_EngineeringRecordNo.Text = frm.dgv.CurrentRow.Cells["EngineeringRecordNo"].Value.ToString();
            }
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            btn_Delete.Enabled = btn_Edit.Enabled = true;
            btn_Save.Enabled = false;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dgv.Enabled = true;

            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                txt_Name.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txt_Address.Text))
            {
                txt_Address.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_Phone.Text))
            {
                txt_Phone.Focus();
                return;
            }

            dgv.Enabled = true;
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell id = new DataGridViewTextBoxCell();
                DataGridViewCell oficeName = new DataGridViewTextBoxCell();
                DataGridViewCell adresOffice = new DataGridViewTextBoxCell();
                DataGridViewCell PhoneOfice = new DataGridViewTextBoxCell();
                DataGridViewCell Notes = new DataGridViewTextBoxCell();
                row.Cells.Add(id);
                row.Cells.Add(oficeName);
                row.Cells.Add(adresOffice);
                row.Cells.Add(PhoneOfice);
                row.Cells.Add(Notes);
                if (lbl_IDOffice.Text != "")
                {
                    row.Cells[0].Value = lbl_IDOffice.Text;
                }
                else
                {
                    row.Cells[0].Value = "";
                }
               
                row.Cells[1].Value = txt_Name.Text;
                row.Cells[2].Value = txt_Address.Text;
                row.Cells[3].Value = txt_Phone.Text;
                row.Cells[4].Value = txt_Notes.Text;

                dgv.Rows.Add(row);
               


               
                DAL.ClassDAL.ClearText(this, groupBox2);
                dgv.Enabled = true;
                lbl_IDOffice.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_IDOffice.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dgv.CurrentRow.Cells[1].Value.ToString() ;
            txt_Address.Text= dgv.CurrentRow.Cells[2].Value.ToString();
            txt_Phone.Text= dgv.CurrentRow.Cells[3].Value.ToString();
            txt_Notes.Text= dgv.CurrentRow.Cells[4].Value.ToString();
            dgv.Rows.Remove(dgv.CurrentRow);
            dgv.Enabled = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            DialogResult re = MessageBox.Show("هل تريد حذف المكتب" +" "+ dgv.CurrentRow.Cells[1].Value.ToString(), "",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
            if (re==DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  Office_Tbl set state=0 where IDOffice='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
                dgv.Rows.Remove(dgv.CurrentRow);
            }
         
        }

        private void txt_searchName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
