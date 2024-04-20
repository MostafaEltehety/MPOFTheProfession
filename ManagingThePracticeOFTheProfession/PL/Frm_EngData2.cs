
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_EngData2 : Form
    {
        public Frm_EngData2()
        {
            InitializeComponent();
            dateGraduation.Format = DateTimePickerFormat.Custom;
            dateGraduation.CustomFormat = "yyyy-MM";
            dateGraduation.ShowUpDown = true;
        }
        string recordingeng, taxCard = "";

        private void Frm_EngData2_Load(object sender, EventArgs e)
        {
            btn_New_Click(null, null);
        }

        private void txt_Name_Enter(object sender, EventArgs e)
        {
            DAL.ClassDAL.Arabic();
        }

        private void txt_RegistrationNo_Enter(object sender, EventArgs e)
        {
            DAL.ClassDAL.English();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dgv.Enabled = true;
            try
            {
                if (string.IsNullOrEmpty(txt_Phone.Text) && string.IsNullOrEmpty(txt_Mobile.Text) && string.IsNullOrEmpty(txt_Email.Text) && string.IsNullOrEmpty(txt_FaceBook.Text) && string.IsNullOrEmpty(txt_Address.Text))
                {
                    MessageBox.Show("يجب ادخال بيانات التواصل ", "بيانات التواصل ");
                    return;
                }
                if (dgv.Rows.Count == 0)
                {
                    if (string.IsNullOrEmpty(txt_Address.Text))
                    {
                        MessageBox.Show("يجب ادخال العنوان");
                    }
                }
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell id = new DataGridViewTextBoxCell();
                DataGridViewCell phone = new DataGridViewTextBoxCell();
                DataGridViewCell mobile = new DataGridViewTextBoxCell();
                DataGridViewCell email = new DataGridViewTextBoxCell();
                DataGridViewCell facebook = new DataGridViewTextBoxCell();
                DataGridViewCell address = new DataGridViewTextBoxCell();


                row.Cells.Add(id);
                row.Cells.Add(phone);
                row.Cells.Add(mobile);
                row.Cells.Add(email);
                row.Cells.Add(facebook);
                row.Cells.Add(address);
                if (IDContect.Text != "")
                {
                    row.Cells[0].Value = IDContect.Text;
                }
                else
                {
                    row.Cells[0].Value = "";
                }


                row.Cells[1].Value = txt_Phone.Text;
                row.Cells[2].Value = txt_Mobile.Text;
                row.Cells[3].Value = txt_Email.Text;
                row.Cells[4].Value = txt_FaceBook.Text;
                row.Cells[5].Value = txt_Address.Text;

                dgv.Rows.Add(row);
                DAL.ClassDAL.ClearText(this, groupBox2);
                dgv.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            if (DAL.Cls_EngineersData.SearchByName(txt_Name.Text).Rows.Count > 0)
            {
                MessageBox.Show("اسم المهندس موجود مسبقاً");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByNationalID(txt_NationalID.Text).Rows.Count > 0)
            {
                MessageBox.Show("الرقم القومى لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByRegistrationNo(txt_RegistrationNo.Text).Rows.Count > 0)
            {
                MessageBox.Show(" رقم العضوية لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByEngineeringRecordNo(txt_EngineeringRecordNo.Text).Rows.Count > 0 && checkBox1.Checked == false)
            {
                MessageBox.Show(" رقم السجل الهندسي لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByConsultantNo(txt_ConsultantNo.Text).Rows.Count > 0)
            {

                MessageBox.Show(" رقم الإستشارى لايمكن تكراره");
                return;
            }
            if (checkBox1.Checked == true)
            {
                if (string.IsNullOrEmpty(txt_ConsultantNo.Text))
                {
                    MessageBox.Show(" يجب ادخال رقم الإستشارى ");
                    txt_ConsultantNo.Focus();
                    return;
                }
            }
            try
            {

                if (string.IsNullOrEmpty(txt_Name.Text) || string.IsNullOrEmpty(txt_RegistrationNo.Text) || string.IsNullOrEmpty(txt_NationalID.Text) || string.IsNullOrEmpty(txt_EngineeringRecordNo.Text))
                {
                    MessageBox.Show("يجب إدخال البيانات الاساسية للمهندس ", "بيانات أساسية");
                    return;
                }

                if (dgv.Rows.Count == 0)
                {
                    DialogResult r = MessageBox.Show("لا يوجد بيانات تواصل هل تريد اكمال عملية الحفظ ؟", "بيانات التواصل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (r == DialogResult.No)
                    {
                        return;
                    }
                }
                MemoryStream ms = new MemoryStream();
                PicProfile.Image.Save(ms, PicProfile.Image.RawFormat);
                byte[] pictuer = ms.ToArray();
                DAL.Cls_EngineersData.Save(dgv, txt_Name.Text, txt_RegistrationNo.Text, combDivision.Text, Convert.ToDateTime(dateGraduation.Value.ToString()), comb_Syndicate.Text, comb_Qualification.Text, txt_University.Text, txt_NationalID.Text, txt_ConsultantNo.Text, combGender.Text, txt_Notes.Text, pictuer, txt_EngineeringRecordNo.Text, txt_Specialization.Text, txt_TaxCardNo.Text, IDOfficeCon.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            btn_New_Click(null, null);
        }

        private void btn_Documnt_Click(object sender, EventArgs e)
        {
            PL.Frm_DocumentEng frm = new PL.Frm_DocumentEng(Convert.ToInt64(lbl_IDEng.Text));
            frm.ShowDialog();
        }

        private void txt_RegistrationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_RegistrationNo);
        }

        private void txt_ConsultantNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.Dot_Refused(e, txt_ConsultantNo);
        }

        private void txt_NationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_NationalID);
        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_Phone);
        }

        private void txt_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
            DAL.ClassDAL.Dot_Refused(e, txt_Mobile);
        }

        private void PicProfile_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.OpenImage(PicProfile);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            btn_New_Click(null, null);
            PL.Frm_SearchEngData frm = new Frm_SearchEngData();
            frm.ShowDialog();
            if (frm.dgv.Rows.Count == 0)
            {
                return;
            }
            btn_Edit.Enabled = btn_Delete.Enabled = true;
            btn_Save.Enabled = false;

            if (frm.dtData.Rows.Count == 0)
            {
                return;
            }
            try
            {
                lbl_IDEng.Text = frm.dtData.Rows[0]["IDEng"].ToString();
                txt_Name.Text = frm.dtData.Rows[0]["EngName"].ToString();
                txt_RegistrationNo.Text = frm.dtData.Rows[0]["RegistrationNo"].ToString();
                combDivision.Text = frm.dtData.Rows[0]["Division"].ToString();
                dateGraduation.Value = Convert.ToDateTime(frm.dtData.Rows[0]["GraduationYear"].ToString());
                comb_Syndicate.Text = frm.dtData.Rows[0]["Syndicate"].ToString();
                comb_Qualification.Text = frm.dtData.Rows[0]["Qualification"].ToString();
                txt_University.Text = frm.dtData.Rows[0]["University"].ToString();
                txt_NationalID.Text = frm.dtData.Rows[0]["NationalID"].ToString();
                txt_ConsultantNo.Text = frm.dtData.Rows[0]["ConsultantNo"].ToString();
                combGender.Text = frm.dtData.Rows[0]["Gender"].ToString();
                txt_Notes.Text = frm.dtData.Rows[0]["Notes"].ToString();
                MemoryStream ms = new MemoryStream((byte[])frm.dtData.Rows[0]["Image"]);
                PicProfile.Image = Image.FromStream(ms);
                txt_EngineeringRecordNo.Text = frm.dtData.Rows[0]["EngineeringRecordNo"].ToString();
                txt_Specialization.Text = frm.dtData.Rows[0]["Specialization"].ToString();
                txt_TaxCardNo.Text = frm.dtData.Rows[0]["TaxCardNo"].ToString();
                recordingeng = frm.dtData.Rows[0]["EngineeringRecordNo"].ToString();
                taxCard = frm.dtData.Rows[0]["TaxCardNo"].ToString();

                if (frm.dtData.Rows[0]["IDOfficeCons"].ToString() != "0")// null
                {
                    checkBox1.Checked = true;
                    combOfficeCons.SelectedValue = frm.dtData.Rows[0]["IDOfficeCons"].ToString();
                    combOfficeCons_Validating(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                // GetDocument
                DAL.ClassDAL.cmd = new SqlCommand("INSERT INTO [dbo].[VariableDoc_Tbl] ([image], [Descri],[IDEng],[ID]) SELECT[image], Descri,[IDEng],[IDDouc] FROM Documant_Tbl where IDEng='" + lbl_IDEng.Text + "'", DAL.ClassDAL.con);
                DAL.ClassDAL.cmd.ExecuteNonQuery();

                // GetDataConact
                DataTable dtContact = new DataTable();
                dtContact = DAL.Cls_EngineersData.GetContactData(Convert.ToInt64(lbl_IDEng.Text));
                dgv.DataSource = null;
                foreach (DataRow item in dtContact.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewCell IDContact = new DataGridViewTextBoxCell();
                    DataGridViewCell Address = new DataGridViewTextBoxCell();
                    DataGridViewCell Phone = new DataGridViewTextBoxCell();
                    DataGridViewCell Email = new DataGridViewTextBoxCell();
                    DataGridViewCell Mobile = new DataGridViewTextBoxCell();
                    DataGridViewCell FaceBook = new DataGridViewTextBoxCell();
                    row.Cells.Add(IDContact);
                    row.Cells.Add(Address);
                    row.Cells.Add(Phone);
                    row.Cells.Add(Email);
                    row.Cells.Add(Mobile);
                    row.Cells.Add(FaceBook);
                    row.Cells[0].Value = item["IDContact"].ToString();
                    row.Cells[5].Value = item["Address"].ToString();
                    row.Cells[1].Value = item["Phone"].ToString();
                    row.Cells[3].Value = item["Email"].ToString();
                    row.Cells[2].Value = item["Mobile"].ToString();
                    row.Cells[4].Value = item["FaceBook"].ToString();
                    dgv.Rows.Add(row);
                }
            }
            catch
            {
                return;
            }


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // يتم تعديل كود المستندات 

            if (DAL.Cls_EngineersData.SearchByNameToEdit(txt_Name.Text, Convert.ToInt64(lbl_IDEng.Text)).Rows.Count > 0)
            {
                MessageBox.Show("اسم المهندس موجود مسبقاً");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByNationalIDToEdit(txt_NationalID.Text, Convert.ToInt64(lbl_IDEng.Text)).Rows.Count > 0)
            {
                MessageBox.Show("الرقم القومى لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByRegistrationNoToEdit(txt_RegistrationNo.Text, Convert.ToInt64(lbl_IDEng.Text)).Rows.Count > 0)
            {
                MessageBox.Show(" رقم العضوية لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByEngineeringRecordNoTOEdit(txt_EngineeringRecordNo.Text, Convert.ToInt64(lbl_IDEng.Text)).Rows.Count > 0 && checkBox1.Checked == false)
            {
                MessageBox.Show(" رقم السجل الهندسي لايمكن تكراره");
                return;
            }
            if (DAL.Cls_EngineersData.SearchByConsultantNoTOEdit(txt_ConsultantNo.Text, Convert.ToInt64(lbl_IDEng.Text)).Rows.Count > 0)
            {

                MessageBox.Show(" رقم الإستشارى لايمكن تكراره");
                return;
            }
            if (checkBox1.Checked == true)
            {
                if (string.IsNullOrEmpty(txt_ConsultantNo.Text))
                {
                    MessageBox.Show(" يجب ادخال رقم الإستشارى ");
                    txt_ConsultantNo.Focus();
                    return;
                }
            }
            try
            {

                if (string.IsNullOrEmpty(txt_Name.Text) || string.IsNullOrEmpty(txt_RegistrationNo.Text) || string.IsNullOrEmpty(txt_NationalID.Text))
                {
                    MessageBox.Show("يجب إدخال البيانات الاساسية للمهندس ", "بيانات أساسية");
                    return;
                }

                if (dgv.Rows.Count == 0)
                {
                    DialogResult r = MessageBox.Show("لا يوجد بيانات تواصل هل تريد اكمال عملية التعديل ؟", "بيانات التواصل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (r == DialogResult.No)
                    {
                        return;
                    }
                }
                MemoryStream ms = new MemoryStream();
                PicProfile.Image.Save(ms, PicProfile.Image.RawFormat);
                byte[] pictuer = ms.ToArray();
                // Update 
                DAL.Cls_EngineersData.Update(dgv, txt_Name.Text, txt_RegistrationNo.Text, combDivision.Text, Convert.ToDateTime(dateGraduation.Value.ToString()), comb_Syndicate.Text, comb_Qualification.Text, txt_University.Text, txt_NationalID.Text, txt_ConsultantNo.Text, combGender.Text, txt_Notes.Text, pictuer, Convert.ToInt64(lbl_IDEng.Text), txt_EngineeringRecordNo.Text, txt_Specialization.Text, txt_TaxCardNo.Text, IDOfficeCon.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            btn_New_Click(null, null);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DAL.Cls_EngineersData.Delete(Convert.ToInt64(lbl_IDEng.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Specialization_Enter(object sender, EventArgs e)
        {
            DAL.ClassDAL.Arabic();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                combOfficeCons.Visible = true;
                combOfficeCons_Validating(null, null);
            }
            else
            {
                combOfficeCons.Visible = false;
                txt_EngineeringRecordNo.Enabled = txt_TaxCardNo.Enabled = true;
                txt_EngineeringRecordNo.Text = recordingeng;
                txt_TaxCardNo.Text = taxCard;

                IDOfficeCon.Text = "";
            }
        }

        private void combOfficeCons_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DAL.Cls_ConsultingOffice.GETSomedata(combOfficeCons.SelectedValue.ToString());
                txt_EngineeringRecordNo.Text = dt.Rows[0]["OfficeRecordingNo"].ToString();
                txt_TaxCardNo.Text = dt.Rows[0]["TaxNo"].ToString();
                IDOfficeCon.Text = dt.Rows[0]["IDOffice"].ToString();
                txt_EngineeringRecordNo.Enabled = txt_TaxCardNo.Enabled = false;
            }
            catch
            {
                return;
            }
        }

        private void تعديلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            IDContect.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txt_Phone.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txt_Mobile.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txt_Email.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            txt_FaceBook.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            txt_Address.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            dgv.Rows.Remove(dgv.CurrentRow);
            dgv.Enabled = false;
        }

        private void حذفToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            DialogResult reslut = MessageBox.Show("هل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reslut == DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  Contact_Tbl set state=0 where IDContact='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
                dgv.Rows.Remove(dgv.CurrentRow);
            }
            else
            {
                return;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            combDivision.SelectedIndex = 0;
            combGender.SelectedIndex = 0;
            comb_Qualification.SelectedIndex = 0;
            comb_Syndicate.SelectedIndex = 0;
            lbl_IDEng.Text = DAL.ClassDAL.GetID("[dbo].[EngBasicData_Tbl]", "[IDEng]");
            PicProfile.Image = PicProfile.BackgroundImage;
            //DAL.ClassDAL.ClearText(this, groupBox1);
            //DAL.ClassDAL.ClearText(this, groupBox2);

            DAL.ClassDAL.ClearGroup(groupBox1);
            DAL.ClassDAL.ClearGroup(groupBox2);
            dgv.Rows.Clear();
            btn_Edit.Enabled = btn_Delete.Enabled = false;
            DAL.Cls_EngineersData.AutoCompletUniversity(txt_University);
            DAL.Cls_EngineersData.AutoCompletName(txt_Name);
            dgv.Enabled = true;
            IDContect.Text = txt_Address.Text = txt_Email.Text = txt_FaceBook.Text = txt_Mobile.Text = txt_Phone.Text = "";
            DAL.Cls_ConsultingOffice.FillComb(combOfficeCons);
            checkBox1_CheckedChanged(null, null);
            recordingeng = taxCard = "";
        }
    }
}
