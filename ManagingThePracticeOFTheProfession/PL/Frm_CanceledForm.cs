using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagingThePracticeOFTheProfession.DAL;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_CanceledForm : Form
    {
        public Frm_CanceledForm()
        {
            InitializeComponent();
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_Searsh_Click(object sender, EventArgs e)
        {
            txt_Number.Text = txt_date.Text = txt_EngName.Text = txt_OwnerName.Text = txt_Busnies.Text = txt_TitleProject.Text = txt_NumberLicen.Text = txt_DateLicen.Text = txt_IssuedFrom.Text = txt_CostProject.Text = "";
            DataTable dt = new DataTable();
            
            dt = DAL.Cls_Cancel.getSearshData(txt_NoForm.Text,txt_Barcode.Text);
            lbltblname.Text =Cls_Cancel.tblname;
            DataTable dt2 = new DataTable();
            
            dt2 = DAL.Cls_Cancel.searchInStope(txt_NoForm.Text,txt_Barcode.Text);
            if (dt2.Rows.Count>0)
            {
                MessageBox.Show("تم الالغاء مسبقاً بتاريخ"+" "+dt2.Rows[0]["Date"].ToString());
                return;
            }

            if (dt.Rows.Count==0)
            {
                MessageBox.Show("لاتوجد بيانات ");
                return;
            }
            groupBox1.Enabled = false;
            lbl.Text = dt.Rows[0]["IDForm"].ToString();
            txt_Number.Text = dt.Rows[0]["SerailNumber"].ToString();
            txt_date.Text = dt.Rows[0]["Date1"].ToString();
            txt_EngName.Text = dt.Rows[0]["EngName"].ToString();
            txt_OwnerName.Text = dt.Rows[0]["Name"].ToString();
            txt_Busnies.Text = dt.Rows[0]["BusinessStatement"].ToString();
            txt_TitleProject.Text = dt.Rows[0]["TitleProject"].ToString();
            txt_NumberLicen.Text = dt.Rows[0]["NumberLicense"].ToString();
            txt_DateLicen.Text = dt.Rows[0]["Date2"].ToString();
            txt_IssuedFrom.Text = dt.Rows[0]["IssuedFrom"].ToString();
            txt_CostProject.Text = Convert.ToDecimal(dt.Rows[0]["CostLicense"].ToString()).ToString("#.##");
            txt_Code2.Text = dt.Rows[0]["Code"].ToString();
        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {
            txt_NoForm.Text = "";
        }

        private void txt_NoForm_TextChanged(object sender, EventArgs e)
        {
            txt_Barcode.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Resion.Text) || string.IsNullOrEmpty(txt_PostOffice.Text))
            {
                txt_Resion.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txt_SearchOrderPaied.Text)&& string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                MessageBox.Show("يجب إدخال رقم الايصال ");
                return;
            }
            DialogResult re = MessageBox.Show("هل تريد إيقاف شهادة الاشراف ؟","إيقاف",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (re==DialogResult.Yes)
            {

                DAL.Cls_Cancel.save(lbl.Text, txt_Number.Text, Convert.ToInt32(DAL.ClassDAL.IDUser), txt_Resion.Text, txt_PostOffice.Text,Convert.ToDecimal(txt_Rev.Text),lbltblname.Text,txt_Code2.Text,textBox1.Text);
                groupBox1.Enabled = true;
                button3_Click(null, null);

            }
        }

        private void txt_NoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btn_Searsh_Click(null,null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            Clear(groupBox2);
            Clear(groupBox1);
            DAL.Cls_Cancel.AutoCompletPOstOffice(txt_PostOffice);
            DAL.Cls_Cancel.AutoCompletResion(txt_Resion);
            txt_Rev.SelectedIndex = 0;
            txt_Rev.Enabled = txt_Resion.Enabled = txt_PostOffice.Enabled = true;
            lbltblname.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_CanceledForm_Load(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void txt_SearchOrderPaied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT * FROM  dbo.Tbl_OrderPaid  where IDOrederPayed ='" + txt_SearchOrderPaied.Text + "' and TypeForm ='نموذج الغاء'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("رقم إذن التوريد غير صحيح");
                    button3_Click(null, null);
                    return;
                }
                else
                {
                    txt_NoForm.Text = dt.Rows[0]["SerailNumberForm"].ToString();
                    txt_Resion.Text = dt.Rows[0]["Resion"].ToString();
                    txt_PostOffice.Text = dt.Rows[0]["PostOffice"].ToString();
                    txt_Rev.Text = dt.Rows[0]["Payed"].ToString();
                    txt_Rev.Enabled = txt_Resion.Enabled = txt_PostOffice.Enabled = false;
                    btn_Searsh_Click(null,null);
                }
               
            }
        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Barcode.Text))
            {
                return ;
            }
            if (e.KeyCode==Keys.Enter)
            {
                btn_Searsh_Click(null, null);
            }
        }
    }
}
