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
    public partial class Frm_TechnicalReportCivilProtection : Form
    {
        string orderPayed, fess, box, tax, orderWord, datePayed, IDTecRe = "";
        bool state;
        public Frm_TechnicalReportCivilProtection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            comboBox1.Enabled = btn_Search.Enabled = txt_OwnerName.Enabled = txt_IssuedFrom.Enabled = txt_Governator.Enabled = txt_TilteProject.Enabled = txt_BassinesStatement.Enabled =lbl.Visible= false;
            button1.Text = "حفظ";
            labelOrder.Visible = txt_SearchOrderPaied.Visible = labelRec.Visible = txt_ReciptNo.Visible = true;
            labelRevnue.Visible = txt_Rev.Visible = false;

        }

        public Frm_TechnicalReportCivilProtection(string order)
        {
            InitializeComponent();
            labelOrder.Visible = txt_SearchOrderPaied.Visible = labelRec.Visible = txt_ReciptNo.Visible = false;
            labelRevnue.Visible = txt_Rev.Visible = true;
        }
        void restart()
        {
            txt_SearchOrderPaied.Enabled = true;
            txt_OwnerName.Text = txt_IssuedFrom.Text = txt_Governator.Text = txt_TilteProject.Text = txt_BassinesStatement.Text = lblIDOwner.Text = lbl_IDEng.Text=txt_ReciptNo.Text=txt_SearchOrderPaied.Text = "";

            DAL.Cls_OrderPaied.AutoCompletIssuedForm(txt_IssuedFrom);
            DAL.Cls_OrderPaied.AutoCompletGovernator(txt_Governator);
            DAL.Cls_OrderPaied.AutoCompletBusinesStatement(txt_BassinesStatement);

            DataTable dt = new DataTable();
            dt = DAL.ClassDAL.Select("SELECT [IDEng],[EngName] FROM EngBasicData_Tbl where state=1 and ConsultantNo!=''  ");
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = dt.Columns["IDEng"].ToString();
            comboBox1.DisplayMember = dt.Columns["EngName"].ToString();
            DAL.Clss_Owners.AutoCompletName(txt_OwnerName);

            comboBox1_Validating(null, null);


            DataTable dtRev = new DataTable();
            dtRev = DAL.ClassDAL.Select("select * from BusinessValue_Tbl where TypePayed = 'إعتماد تقرير فنى (الحماية المدنية)' or    [IDBusinessValue]='104' ");
            lbl_Fess.Text = dtRev.Rows[0]["Amount"].ToString();
            lbl_Tax.Text = dtRev.Rows[0]["Taxes"].ToString();
            lbl_Box.Text = dtRev.Rows[0]["box"].ToString();
            decimal alltax = Convert.ToDecimal(lbl_Tax.Text) * Convert.ToDecimal(lbl_Fess.Text);
            decimal revnue = Convert.ToDecimal(lbl_Fess.Text) + alltax + Convert.ToDecimal(lbl_Box.Text);
            txt_Rev.Text = revnue.ToString("#.##");
            clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
            lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);


        }
        private void Frm_TechnicalReportCivilProtection_Load(object sender, EventArgs e)
        {
            restart();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex<0)
            {
                comboBox1.Focus();
                return;
            }
            lbl_IDEng.Text = comboBox1.SelectedValue.ToString();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            btn_Search_Click(null, null);
        }

        private void txt_OwnerName_Validating(object sender, CancelEventArgs e)
        {
            btn_SearchOwner_Click(null, null);
        }

        private void btn_SearchOwner_Click(object sender, EventArgs e)
        {
            lblIDOwner.Text = "";
            //DAL.Clss_Owners.SearchBYNationalID(txt_NationIDOwner.Text, lblIDOwner, txt_OwnerName);
            DAL.Clss_Owners.SearchBYNationalName(txt_NationIDOwner, lblIDOwner, txt_OwnerName);
            DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
            if (lblIDOwner.Text == "")
            {
                DAL.Clss_Owners.SearchBYNationalName(txt_NationIDOwner, lblIDOwner, txt_OwnerName);
                DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
                txt_OwnerName.Focus();
            }
            try
            {
                DataTable dtAdres = new DataTable();
                dtAdres = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                //if (dtAdres.Rows.Count>0)
                //{
                combAdressOwner.DataSource = dtAdres;
                combAdressOwner.ValueMember = dtAdres.Columns["Address"].ToString();
                //}

                DataTable dtPhone = new DataTable();
                dtPhone = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                //if (dtPhone.Rows.Count > 0)
                //{
                combPhoneOwners.DataSource = dtPhone;
                combPhoneOwners.ValueMember = dtPhone.Columns["Phone"].ToString();
                //}

                DataTable dtMobile = new DataTable();
                dtMobile = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                //if (dtPhone.Rows.Count > 0)
                //{
                comb_MobileOwner.DataSource = dtMobile;
                comb_MobileOwner.ValueMember = dtMobile.Columns["Mobile"].ToString();
                //}

                DataTable dtEmail = new DataTable();
                dtEmail = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                //if (dtEmail.Rows.Count > 0)
                //{
                combEmailOwners.DataSource = dtEmail;
                combEmailOwners.ValueMember = dtEmail.Columns["Email"].ToString();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void txt_BassinesStatement_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TilteProject_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text== "حفظ")
            {
                if (string.IsNullOrEmpty(txt_SearchOrderPaied.Text))
                {
                    txt_SearchOrderPaied.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_ReciptNo.Text))
                {
                    MessageBox.Show("يجب إخال رقم الايصال");
                    return;
                }
               
                DAL.Cls_TechnicalReportCivilProtection.Save(Convert.ToInt64(lbl_IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_BassinesStatement.Text, txt_TilteProject.Text, txt_IssuedFrom.Text, txt_Governator.Text, Convert.ToInt64(txt_SearchOrderPaied.Text), txt_ReciptNo.Text, orderPayed, fess, box, tax, orderWord, true);
                btn_New_Click(null, null);
                return;
            }
            DAL.Cls_OrderPaied.Save(Convert.ToInt64(lbl_IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_OwnerName.Text, txt_TilteProject.Text, txt_BassinesStatement.Text, groupBox1.Text, Convert.ToDecimal(txt_Rev.Text), lbl.Text, DAL.ClassDAL.ReferentialOfficer, Convert.ToDecimal(lbl_Fess.Text), Convert.ToDecimal(lbl_Box.Text), Convert.ToDecimal(lbl_Tax.Text),int.Parse( DAL.ClassDAL.IDUser), txt_IssuedFrom.Text,txt_Governator.Text);

            Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
            Reports.Print.CryTechnicalReportCivilProtection crpt = new Reports.Print.CryTechnicalReportCivilProtection();
            DataTable dt = new DataTable();
            dt = DAL.ClassDAL.Select("SELECT  dbo.Tbl_OrderPaid.IssuedFrom, dbo.Tbl_OrderPaid.IDOrederPayed, dbo.EngBasicData_Tbl.EngName, dbo.Tbl_OrderPaid.BusinesStatement, dbo.Tbl_OrderPaid.OrderPayed, dbo.Tbl_OrderPaid.OrderPayedWord,  dbo.OwnerData_Tbl.Name, dbo.Tbl_OrderPaid.RefEmp, dbo.Tbl_OrderPaid.box, dbo.Tbl_OrderPaid.tax, dbo.Tbl_OrderPaid.TypeForm, dbo.Tbl_OrderPaid.Fess, dbo.Tbl_OrderPaid.Governator FROM  dbo.Tbl_OrderPaid INNER JOIN dbo.EngBasicData_Tbl ON dbo.Tbl_OrderPaid.IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.Tbl_OrderPaid.IDOwner = dbo.OwnerData_Tbl.IDOwner  WHERE (dbo.Tbl_OrderPaid.IDOrederPayed = (SELECT MAX(IDOrederPayed) AS ID FROM   dbo.Tbl_OrderPaid AS Tbl_OrderPaid_1)) ");
            crpt.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = null;
            frm.crystalReportViewer1.ReportSource = crpt;
            btn_New_Click(null, null);
            frm.ShowDialog();
        }

        private void txt_SearchOrderPaied_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_ReciptNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            DAL.ClassDAL.UseNumbersOnly(e);

        }

        private void txt_SearchOrderPaied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                DataTable dt2 = new DataTable();
                dt2 = DAL.ClassDAL.Select("select OrderID from [TechnicalReportCivilProtection] where OrderID='" + txt_SearchOrderPaied.Text + "' ");
                if (dt2.Rows.Count > 0)
                {
                    MessageBox.Show("تم عمل الشهادة لهذا الاذن ");
                    comboBox1.Enabled = btn_Search.Enabled = txt_OwnerName.Enabled = txt_IssuedFrom.Enabled = txt_Governator.Enabled = txt_TilteProject.Enabled = txt_BassinesStatement.Enabled = lbl.Visible = false;
                    return;
                }
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT * FROM  dbo.Tbl_OrderPaid  where IDOrederPayed ='" + txt_SearchOrderPaied.Text + "' and TypeForm ='"+groupBox1.Text+"'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("رقم إذن التوريد غير صحيح");
                    comboBox1.Enabled = btn_Search.Enabled = txt_OwnerName.Enabled = txt_IssuedFrom.Enabled = txt_Governator.Enabled = txt_TilteProject.Enabled = txt_BassinesStatement.Enabled = lbl.Visible = false;
                    return;
                }
                else
                {
                    lbl_IDEng.Text = dt.Rows[0]["IDEng"].ToString();
                    lblIDOwner.Text = dt.Rows[0]["IDOwner"].ToString();
                    comboBox1.SelectedValue = Convert.ToInt64(lbl_IDEng.Text);
                    txt_OwnerName.Text = dt.Rows[0]["NameOwner"].ToString();
                    txt_IssuedFrom.Text = dt.Rows[0]["IssuedFrom"].ToString();
                    txt_Governator.Text = dt.Rows[0]["Governator"].ToString();
                    txt_TilteProject.Text = dt.Rows[0]["TitleProject"].ToString();
                    txt_BassinesStatement.Text = dt.Rows[0]["BusinesStatement"].ToString();
                    orderPayed = dt.Rows[0]["OrderPayed"].ToString();
                    fess = dt.Rows[0]["Fess"].ToString();
                    box = dt.Rows[0]["box"].ToString();
                    tax = dt.Rows[0]["tax"].ToString();
                    orderWord = dt.Rows[0]["OrderPayedWord"].ToString();

                    state = true;
      
                    txt_SearchOrderPaied.Enabled = false;
                }
            }
        }
    }
}
