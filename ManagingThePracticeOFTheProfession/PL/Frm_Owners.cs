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
    public partial class Frm_Owners :Form
    {
        public Frm_Owners()
        {
            InitializeComponent();
        }
        public Frm_Owners(string name)
        {
            InitializeComponent();
            txt_Name.Text = name;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txt_Name.Text)|| string.IsNullOrEmpty(txt_NationalID.Text) || dgv.Rows.Count==0 || dgv.Rows[0].Cells[4].Value.ToString()=="")
            //{
            //    MessageBox.Show("يجب إدخال البيانات الاساسية للمالك ");
            //    return;
            //}

            if (string.IsNullOrEmpty(txt_Name.Text) )
            {
                MessageBox.Show("يجب إدخال البيانات الاساسية للمالك ");
                txt_Name.Focus();
                return;
            }
            if (DAL.Clss_Owners.CheckData(txt_Name.Text,txt_NationalID.Text).Rows.Count>0)
            {
                MessageBox.Show("لا يمكن تكرار البيانات الاساسية للمالك ");
                return;
            }
            DAL.Clss_Owners.Save(dgv, txt_Name.Text, txt_NationalID.Text);
            btn_New_Click(null, null);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
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

            DataGridViewCell address = new DataGridViewTextBoxCell();


            row.Cells.Add(id);
            row.Cells.Add(phone);
            row.Cells.Add(mobile);
            row.Cells.Add(email);

            row.Cells.Add(address);

            if (IDContect.Text=="")
            {
                row.Cells[0].Value = "";
            }
            else
            {
                row.Cells[0].Value = IDContect.Text;
            }
           
            row.Cells[1].Value = txt_Phone.Text;
            row.Cells[2].Value = txt_Mobile.Text;
            row.Cells[3].Value = txt_Email.Text;

            row.Cells[4].Value = txt_Address.Text;

            dgv.Rows.Add(row);
            DAL.ClassDAL.ClearText(this, groupBox2);
            IDContect.Text = "";
            dgv.Enabled = true;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.ClearText(this);
            DAL.ClassDAL.ClearText(this,groupBox2);
            dgv.Rows.Clear();
            DAL.Clss_Owners.AutoCompletName(txt_Name);
            dgv.Enabled = true;
            IDOwner.Text = IDContect.Text = "";
            btn_Edit.Enabled = btn_Delete.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("يجب إدخال البيانات الاساسية للمالك ");
                txt_Name.Focus();
                return;
            }
            if (DAL.Clss_Owners.CheckDataToEdit(txt_Name.Text, txt_NationalID.Text,Convert.ToInt64(IDOwner.Text)).Rows.Count > 0)
            {
                MessageBox.Show("لا يمكن تكرار البيانات الاساسية للمالك ");
                return;
            }
            DAL.Clss_Owners.Update(dgv, txt_Name.Text, txt_NationalID.Text,Convert.ToInt64(IDOwner.Text ));
            btn_New_Click(null, null);

        }

        private void Frm_Owners_Load(object sender, EventArgs e)
        {

            btn_Edit.Enabled = btn_Delete.Enabled = false;
            btn_Save.Enabled = true;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            PL.Frm_SearshOwners frm  = new PL.Frm_SearshOwners();
            frm.ShowDialog();
            if (frm.dgv.Rows.Count == 0)
            {
                return;
            }
            btn_Edit.Enabled = btn_Delete.Enabled = true;
            btn_Save.Enabled = false;
            IDOwner.Text = frm.dgv.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = frm.dgv.CurrentRow.Cells[1].Value.ToString();
            txt_NationalID.Text = frm.dgv.CurrentRow.Cells[2].Value.ToString();

            DataTable dtContact = new DataTable();
            dtContact = DAL.Clss_Owners.GetContactData(Convert.ToInt64(IDOwner.Text));
            dgv.DataSource = null;
            foreach (DataRow item in dtContact.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell IDContactOwners = new DataGridViewTextBoxCell();
                DataGridViewCell Phone = new DataGridViewTextBoxCell();
                DataGridViewCell Mobile = new DataGridViewTextBoxCell();
                DataGridViewCell Email = new DataGridViewTextBoxCell();
                DataGridViewCell Address = new DataGridViewTextBoxCell();

                row.Cells.Add(IDContactOwners);
                row.Cells.Add(Phone);
                row.Cells.Add(Mobile);
                row.Cells.Add(Email);
                row.Cells.Add(Address);
          
                row.Cells[0].Value = item["IDContactOwners"].ToString();
                row.Cells[1].Value = item["Phone"].ToString();
                row.Cells[2].Value = item["Mobile"].ToString();
                row.Cells[3].Value = item["Email"].ToString();
                row.Cells[4].Value = item["Address"].ToString();
                dgv.Rows.Add(row);
            }
            btn_Edit.Enabled = btn_Delete.Enabled = true;
            btn_Save.Enabled = false;
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            IDContect.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txt_Phone.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txt_Mobile.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txt_Email.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            txt_Address.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            dgv.Rows.Remove(dgv.CurrentRow);
            dgv.Enabled = false;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            DialogResult reslut = MessageBox.Show("هل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reslut == DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  ContactOwners_Tbl set state=0 where IDContactOwners='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
                dgv.Rows.Remove(dgv.CurrentRow);
            }
            else
            {
                return;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult reslut = MessageBox.Show("هل تريد حذف المالك؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if (reslut == DialogResult.Yes)
            {
                DAL.ClassDAL.Run("update  [dbo].[OwnerData_Tbl] set state=0 where IDOwner='" + IDOwner.Text+ "'");
                btn_New_Click(null, null);
            }
            else
            {
                return;
            }
        }

        private void txt_NationalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
