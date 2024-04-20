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
    public partial class Frm_ConsultingOffice : Form
    {
        public Frm_ConsultingOffice()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txt_TaxCardNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.ClearText(this, groupBox1);
            DAL.ClassDAL.ClearText(this, groupBox2);
            DAL.Cls_ConsultingOffice.AutoCompletName(txt_searchName);
            //groupBox2.Enabled = false;
            //groupBox1.Enabled = true;
            txt_TaxCardNo.Text = txt_EngineeringRecordNo.Text = txt_Name.Text=txt_Address.Text=txt_Phone.Text = lbl_IDOfficeCons.Text =lbl_IDContact.Text=lbl_ID.Text= "";
            groupBox1.Enabled =btn_Delete.Enabled= false;
            groupBox2.Enabled=button2.Enabled = true;  
            btn_Save.Enabled = true;
            dgv.Rows.Clear();
            dgv.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (dgv.Rows.Count == 0)
            //{
            //    return;
            //}
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                txt_Name.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_EngineeringRecordNo.Text))
            {
                txt_EngineeringRecordNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_OfficeNo.Text))
            {
                txt_OfficeNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_TaxCardNo.Text))
            {
                txt_TaxCardNo.Focus();
                return;
            }
            if (lbl_IDOfficeCons.Text=="")
            {
                if (DAL.Cls_ConsultingOffice.CheckToSave(txt_Name.Text, txt_OfficeNo.Text, txt_EngineeringRecordNo.Text, txt_TaxCardNo.Text) ==1)
                {
                    MessageBox.Show("لايمكن تكرار البيانات الاساسية");
                    return;
                }
                DAL.Cls_ConsultingOffice.Save(dgv, txt_Name.Text, txt_OfficeNo.Text, txt_EngineeringRecordNo.Text, true, Convert.ToInt32(DAL.ClassDAL.IDUser), txt_TaxCardNo.Text);
              
            }
            else
            {
                if (DAL.Cls_ConsultingOffice.CheckToEdit(txt_Name.Text, txt_OfficeNo.Text, txt_EngineeringRecordNo.Text, txt_TaxCardNo.Text,Convert.ToInt32(lbl_IDOfficeCons.Text)) == 1)
                {
                    MessageBox.Show("لايمكن تكرار البيانات الاساسية");
                    return;
                }
                DAL.Cls_ConsultingOffice.Update(dgv, txt_Name.Text, txt_OfficeNo.Text, txt_EngineeringRecordNo.Text, true, Convert.ToInt32(DAL.ClassDAL.IDUser), txt_TaxCardNo.Text, lbl_IDOfficeCons.Text);
              
            }
        
            btn_New_Click(null, null);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dgv.Enabled = true;

          

            if (string.IsNullOrEmpty(txt_Address.Text))
            {
                txt_Address.Focus();
                return;
            }
           

            dgv.Enabled = true;
            try
            {

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell id = new DataGridViewTextBoxCell();
          
                DataGridViewCell adresOffice = new DataGridViewTextBoxCell();
                DataGridViewCell PhoneOfice = new DataGridViewTextBoxCell();
                DataGridViewCell mobile = new DataGridViewTextBoxCell();
                DataGridViewCell IdOffice = new DataGridViewTextBoxCell();
                row.Cells.Add(id);
                row.Cells.Add(adresOffice);
                row.Cells.Add(PhoneOfice);
                row.Cells.Add(mobile);
                row.Cells.Add(IdOffice);
                if (lbl_IDContact.Text != "")
                {
                    row.Cells[0].Value = lbl_IDContact.Text;
                }
                else
                {
                    row.Cells[0].Value = "";
                }

                row.Cells[1].Value = txt_Address.Text;
                row.Cells[2].Value =txt_Phone.Text;
                row.Cells[3].Value = txt_mobile.Text;
                row.Cells[4].Value = "";

                dgv.Rows.Add(row);




               ;
                dgv.Enabled = true;
                lbl_IDContact.Text = txt_Address.Text= txt_Phone.Text= txt_mobile.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Frm_ConsultingOffice_Load(object sender, EventArgs e)
        {
            btn_New_Click(null, null);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAL.Cls_ConsultingOffice.SearchByName(txt_searchName.Text.Trim());
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("لاتوجد بيانات ");
            }
            else
            {
                btn_Delete.Enabled = true;
                button2.Enabled = false;    
                txt_Name.Text = dt.Rows[0]["OfficeName"].ToString();
                txt_OfficeNo.Text = dt.Rows[0]["OfficeNo"].ToString();
                txt_TaxCardNo.Text= dt.Rows[0]["TaxNo"].ToString();
                txt_EngineeringRecordNo.Text= dt.Rows[0]["OfficeRecordingNo"].ToString();
                lbl_IDOfficeCons.Text = dt.Rows[0]["IDOffice"].ToString();
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                DataTable dt2 = new DataTable();
                dt2 = DAL.Cls_ConsultingOffice.GetContactOffice(lbl_IDOfficeCons.Text);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow item in dt2.Rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        DataGridViewCell id = new DataGridViewTextBoxCell();
                        DataGridViewCell adresOffice = new DataGridViewTextBoxCell();
                        DataGridViewCell PhoneOfice = new DataGridViewTextBoxCell();
                        DataGridViewCell mobile = new DataGridViewTextBoxCell();
                        DataGridViewCell IdOffice = new DataGridViewTextBoxCell();
                        row.Cells.Add(id);
                        row.Cells.Add(adresOffice);
                        row.Cells.Add(PhoneOfice);
                        row.Cells.Add(mobile);
                        row.Cells.Add(IdOffice);

                        row.Cells[0].Value = item["IDContanetOffice"].ToString();
                        row.Cells[1].Value = item["Address"].ToString();
                        row.Cells[2].Value = item["phone"].ToString();
                        row.Cells[3].Value = item["moble"].ToString();
                        row.Cells[4].Value = item["IDOfficeCons"].ToString();

                        dgv.Rows.Add(row);
                       
                    }
                }

            }
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_IDContact.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txt_Address.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txt_Phone.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txt_mobile.Text = dgv.CurrentRow.Cells[3].Value.ToString();

            dgv.Rows.Remove(dgv.CurrentRow);
            dgv.Enabled = false;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            DialogResult re = MessageBox.Show("هل تريد حذف بيانات المكتب ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (re == DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  ContanetOfficeCons_tbl set state=0 where IDContanetOffice='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("هل تريد حذف المكتب ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (re == DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  ConsultingOffice_Tbl set state=0 where [IDOffice]='" + lbl_IDOfficeCons.Text + "'");
                btn_New_Click(null, null);
            }
        }
    }
}
