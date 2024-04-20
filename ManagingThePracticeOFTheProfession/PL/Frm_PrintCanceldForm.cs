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
    public partial class Frm_PrintCanceldForm : Form
    {
        public Frm_PrintCanceldForm()
        {
            InitializeComponent();
        }

        private void btn_Searsh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt= DAL.Cls_Cancel.PrintCanceld(txt_NoForm.Text, txt_Barcode.Text);
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("لا توجد بيانات ");
                return;
            }

            Reports.Frm_SH_D frm = new Reports.Frm_SH_D();

            Reports.Print.CryCancelSH_DCustom crpt = new Reports.Print.CryCancelSH_DCustom();
            crpt.SetDataSource(dt);
            crpt.SetParameterValue(0, DAL.ClassDAL.ReferentialOfficer);
            crpt.SetParameterValue(1, DAL.ClassDAL.Manager);
            crpt.SetParameterValue(2, DAL.ClassDAL.MangerEngneer);
            frm.crystalReportViewer1.ReportSource = null;
            frm.crystalReportViewer1.ReportSource = crpt;
            frm.ShowDialog();

            //if (txt_NoForm.Text.Contains("د"))
            //{
            //        Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
            //        DataTable dt = new DataTable();
            //        dt = DAL.ClassDAL.Select("SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.D].EngPhone, dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].DateForm,  dbo.[Form_SH.D].TitleProject  FROM  dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN  dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN   dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng where dbo.Stope.SerialNumber ='" + txt_NoForm.Text + "' ");
            //        Reports.Print.CryCancelSH_DCustom crpt = new Reports.Print.CryCancelSH_DCustom();
            //        crpt.SetDataSource(dt);
            //        frm.crystalReportViewer1.ReportSource = null;
            //        frm.crystalReportViewer1.ReportSource = crpt;
            //        frm.ShowDialog();
            //    }

        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode==Keys.Enter)
            {
                txt_NoForm.Text = "";
                btn_Searsh_Click(null,null);
            }
        }

        private void txt_NoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Barcode.Text = "";
                btn_Searsh_Click(null, null);
            }
        }

        private void txt_Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_NoForm.Text = "";
        }

        private void txt_NoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_Barcode.Text = "";
        }
    }
    }

