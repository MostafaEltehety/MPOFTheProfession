using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    public partial class Frm_PrintForm : Form
    {
        PL.Frm_Main2 frmMain = new Frm_Main2();
        
        public Frm_PrintForm()
        {
            InitializeComponent();
            DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
        }

        private void Frm_PrintForm_Load(object sender, EventArgs e)
        {
            DAL.Cls_PrintForms.FillComb(combType);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            txt_Registration.Text = txt_searchName.Text = "";
            combOwners.DataSource = null;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Registration_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (lbl_IDForm.Text=="2")   //D
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_D(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "3")  //G
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_G(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "6") //B
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_B(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "5") //W
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_W(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "4") //H
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_H(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "8")   //D2
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_D2(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "9")  //G2
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_G2(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
                if (lbl_IDForm.Text == "10") //B2
                {
                    DAL.Clss_Owners.FillComboxOwnersNameByRegistrationEngSH_B2(combOwners, txt_Registration.Text, lbl_IDForm.Text);
                }
            }
            catch 
            {
                return;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            if (lbl_IDForm.Text=="2")
            {
                DAL.Cls_SH_D.SH(lbl_IDOwner.Text, txt_Registration.Text,dataGridView1);
            }
            if (lbl_IDForm.Text == "3")
            {
                DAL.Cls_SH_G.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "6")
            {
                DAL.Cls_SH_B.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "5")
            {
                DAL.Cls_SH_W.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "4")
            {
                DAL.Cls_SH_H.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "8")
            {
                DAL.Cls_SH_D2.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "9")
            {
                DAL.Cls_SH_G2.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
            if (lbl_IDForm.Text == "10")
            {
                DAL.Cls_SH_B2.SH(lbl_IDOwner.Text, txt_Registration.Text, dataGridView1);
            }
        }

        private void combType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Registration.Focus();
                lbl_IDForm.Text = combType.SelectedValue.ToString();
            }
            catch
            {
                return;
            }
        }

        private void combOwners_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
            lbl_IDOwner.Text = combOwners.SelectedValue.ToString();
            }
            catch
            {
                return;
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            #region PrintCode
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            #region Print D2
            if (lbl_IDForm.Text == "2") // SH_D
            {
                //Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
                {

                    string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

                    Reports.SH.CrySH_D crpt = new Reports.SH.CrySH_D();
                    DataTable dt = new DataTable();
                    dt = DAL.ClassDAL.Select("SELECT   dbo.[Form_SH.D].IDForm, dbo.[Form_SH.D].Code, dbo.[Form_SH.D].CostForm, dbo.[Form_SH.D].TypeForm, dbo.[Form_SH.D].DateForm,   dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].YearLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].TypeLicense, dbo.[Form_SH.D].IssuedFrom,  dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Department, dbo.[Form_SH.D].City, dbo.[Form_SH.D].Governorate, dbo.[Form_SH.D].BusinessStatement,   dbo.[Form_SH.D].CostWord, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].OtherData, dbo.[Form_SH.D].EngEmail, dbo.[Form_SH.D].EngPhone,  dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].OfficeAdress, dbo.[Form_SH.D].OfficePhone, dbo.[Form_SH.D].OwnerAdrees,   dbo.[Form_SH.D].OwnerEmail, dbo.[Form_SH.D].OwnerPhone, dbo.[Form_SH.D].OwnerMobile, dbo.[Form_SH.D].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.D].RerfEmp, dbo.[Form_SH.D].Manager, dbo.[Form_SH.D].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.D].GeneralEngnering, dbo.[Form_SH.D].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,  dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax,dbo.Revenue_Tbl.OrderWord FROM dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Certificate_Tbl ON dbo.[Form_SH.D].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.D].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");
                    crpt.SetParameterValue("RecordingNo", RecordingNo);
                    crpt.SetParameterValue("MangerEngneer", DAL.ClassDAL.MangerEngneer);
                    //crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    crpt.SetDataSource(dt);
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;

                }
               
            }
            #endregion


            #region G
            if (lbl_IDForm.Text == "3") // SH_G
            {
                //Reports.Frm_SH_D frm = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
                {

                    DataTable dt = new DataTable();
                    dt = (DataTable)dataGridView1.DataSource;
                    Reports.SH.CrySH_G crpt = new Reports.SH.CrySH_G();

                    dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.G].IDForm, dbo.[Form_SH.G].Code, dbo.[Form_SH.G].CostForm, dbo.[Form_SH.G].TypeForm, dbo.[Form_SH.G].DateForm,   dbo.[Form_SH.G].NumberLicense, dbo.[Form_SH.G].YearLicense, dbo.[Form_SH.G].DateLicense, dbo.[Form_SH.G].TypeLicense, dbo.[Form_SH.G].IssuedFrom,  dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].Department, dbo.[Form_SH.G].City, dbo.[Form_SH.G].Governorate, dbo.[Form_SH.G].BusinessStatement,   dbo.[Form_SH.G].CostWord, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].OtherData, dbo.[Form_SH.G].EngEmail, dbo.[Form_SH.G].EngPhone,   dbo.[Form_SH.G].EngMobile, dbo.[Form_SH.G].EngAdress, dbo.[Form_SH.G].OfficeAdress, dbo.[Form_SH.G].OfficePhone, dbo.[Form_SH.G].OwnerAdrees,   dbo.[Form_SH.G].OwnerEmail, dbo.[Form_SH.G].OwnerPhone, dbo.[Form_SH.G].OwnerMobile, dbo.[Form_SH.G].TaxCardEng, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.G].RerfEmp, dbo.[Form_SH.G].Manager, dbo.[Form_SH.G].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.G].GeneralEngnering, dbo.[Form_SH.G].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax  FROM   dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN    dbo.Certificate_Tbl ON dbo.[Form_SH.G].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN   dbo.Revenue_Tbl ON dbo.[Form_SH.G].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.G].IDForm= '" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "' ");
                    crpt.SetDataSource(dt);
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;

                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;


                }
            }
            #endregion

            #region B
            if (lbl_IDForm.Text == "6") // SH_B
            {
                //Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
                {


                    // To Edit SQL select
                    string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

                    Reports.SH.CrySH_B crpt = new Reports.SH.CrySH_B();
                    DataTable dt = new DataTable();
                    dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.B].IDForm, dbo.[Form_SH.B].Code, dbo.[Form_SH.B].CostForm, dbo.[Form_SH.B].TypeForm, dbo.[Form_SH.B].DateForm, dbo.[Form_SH.B].NumberLicense, dbo.[Form_SH.B].DateLicense, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].TitleProject, dbo.[Form_SH.B].Department, dbo.[Form_SH.B].City, dbo.[Form_SH.B].Governorate, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostWord,   dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].OtherData, dbo.[Form_SH.B].EngEmail, dbo.[Form_SH.B].EngPhone, dbo.[Form_SH.B].EngMobile, dbo.[Form_SH.B].EngAdress, dbo.[Form_SH.B].OfficeAdress,  dbo.[Form_SH.B].OfficePhone, dbo.[Form_SH.B].OwnerAdrees, dbo.[Form_SH.B].OwnerEmail, dbo.[Form_SH.B].OwnerPhone, dbo.[Form_SH.B].OwnerMobile, dbo.[Form_SH.B].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.B].RerfEmp,  dbo.[Form_SH.B].Manager, dbo.[Form_SH.B].GeneralManager, dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.B].GeneralEngnering, dbo.[Form_SH.B].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box,  dbo.Revenue_Tbl.tax, dbo.EngBasicData_Tbl.ConsultantNo, dbo.Revenue_Tbl.OrderWord, dbo.[Form_SH.B].OfficeMobile, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.OfficeNo,  dbo.EngBasicData_Tbl.TaxCardNo  FROM   dbo.[Form_SH.B] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.B].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B].SerailNumber = dbo.Revenue_Tbl.SerailNumber INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.[Form_SH.B].IDOffice = dbo.ConsultingOffice_Tbl.IDOffice where  dbo.[Form_SH.B].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");

                    crpt.SetDataSource(dt);
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;



                }

            }
            #endregion

            #region B2
            if (lbl_IDForm.Text == "10") // SH_B2
            {
                //Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
                {


                    // To Edit SQL select
                    string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

                    Reports.SH.CrySH_B crpt = new Reports.SH.CrySH_B();
                    DataTable dt = new DataTable();
                    dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.B2].IDForm, dbo.[Form_SH.B2].Code, dbo.[Form_SH.B2].CostForm, dbo.[Form_SH.B2].TypeForm, dbo.[Form_SH.B2].DateForm, dbo.[Form_SH.B2].NumberLicense, dbo.[Form_SH.B2].DateLicense, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].TitleProject, dbo.[Form_SH.B2].Department, dbo.[Form_SH.B2].City, dbo.[Form_SH.B2].Governorate, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostWord,   dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].OtherData, dbo.[Form_SH.B2].EngEmail, dbo.[Form_SH.B2].EngPhone, dbo.[Form_SH.B2].EngMobile, dbo.[Form_SH.B2].EngAdress, dbo.[Form_SH.B2].OfficeAdress,  dbo.[Form_SH.B2].OfficePhone, dbo.[Form_SH.B2].OwnerAdrees, dbo.[Form_SH.B2].OwnerEmail, dbo.[Form_SH.B2].OwnerPhone, dbo.[Form_SH.B2].OwnerMobile, dbo.[Form_SH.B2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.B2].RerfEmp,  dbo.[Form_SH.B2].Manager, dbo.[Form_SH.B2].GeneralManager, dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.B2].GeneralEngnering, dbo.[Form_SH.B2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box,  dbo.Revenue_Tbl.tax, dbo.EngBasicData_Tbl.ConsultantNo, dbo.Revenue_Tbl.OrderWord, dbo.[Form_SH.B2].OfficeMobile, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.OfficeNo,  dbo.EngBasicData_Tbl.TaxCardNo  FROM   dbo.[Form_SH.B2] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.B2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B2].SerailNumber = dbo.Revenue_Tbl.SerailNumber INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.[Form_SH.B2].IDOffice = dbo.ConsultingOffice_Tbl.IDOffice where  dbo.[Form_SH.B2].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");

                    crpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;


                }

            }
            #endregion
            
            #region W
            if (lbl_IDForm.Text == "5") // SH_W
            {
                //Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
                {

                    DataTable dt = new DataTable();
                    dt = (DataTable)dataGridView1.DataSource;
                    Reports.SH.CrySH_W crpt = new Reports.SH.CrySH_W();
                    //crpt.Database.Tables["SH_D"].SetDataSource(dt);
                    //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    //     string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

                    crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    crpt.Refresh();

                    crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;

                }

            }
            #endregion

            #region H
            if (lbl_IDForm.Text == "4") // SH_H
            {
                //Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
                {

                    DataTable dt = new DataTable();
                    dt = (DataTable)dataGridView1.DataSource;
                    Reports.SH.CrySH_H crpt = new Reports.SH.CrySH_H();

                    crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    crpt.Refresh();

                    crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;
                }

            }

            #endregion
            #region Print D2
            if (lbl_IDForm.Text == "8") // SH_D2
            {
                Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
                {

                    string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

                    Reports.SH.CrySH_D crpt = new Reports.SH.CrySH_D();
                    DataTable dt = new DataTable();
                    dt = DAL.ClassDAL.Select("SELECT   dbo.[Form_SH.D2].IDForm, dbo.[Form_SH.D2].Code, dbo.[Form_SH.D2].CostForm, dbo.[Form_SH.D2].TypeForm, dbo.[Form_SH.D2].DateForm,   dbo.[Form_SH.D2].NumberLicense, dbo.[Form_SH.D2].YearLicense, dbo.[Form_SH.D2].DateLicense, dbo.[Form_SH.D2].TypeLicense, dbo.[Form_SH.D2].IssuedFrom,  dbo.[Form_SH.D2].TitleProject, dbo.[Form_SH.D2].Department, dbo.[Form_SH.D2].City, dbo.[Form_SH.D2].Governorate, dbo.[Form_SH.D2].BusinessStatement,   dbo.[Form_SH.D2].CostWord, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].OtherData, dbo.[Form_SH.D2].EngEmail, dbo.[Form_SH.D2].EngPhone,  dbo.[Form_SH.D2].EngMobile, dbo.[Form_SH.D2].EngAdress, dbo.[Form_SH.D2].OfficeAdress, dbo.[Form_SH.D2].OfficePhone, dbo.[Form_SH.D2].OwnerAdrees,   dbo.[Form_SH.D2].OwnerEmail, dbo.[Form_SH.D2].OwnerPhone, dbo.[Form_SH.D2].OwnerMobile, dbo.[Form_SH.D2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.D2].RerfEmp, dbo.[Form_SH.D2].Manager, dbo.[Form_SH.D2].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.D2].GeneralEngnering, dbo.[Form_SH.D2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,  dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax,dbo.Revenue_Tbl.OrderWord FROM dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Certificate_Tbl ON dbo.[Form_SH.D2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D2].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.D2].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");
                    crpt.SetParameterValue("RecordingNo", RecordingNo);
                    crpt.SetParameterValue("MangerEngneer", DAL.ClassDAL.MangerEngneer);
                    //crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    crpt.SetDataSource(dt);
                   crystalReportViewer1.ReportSource = null;
                   crystalReportViewer1.ReportSource = crpt;

                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;
                }

            }
            #endregion


            #region SH_G2
            if (lbl_IDForm.Text == "9") // SH_G2
            {
                //Reports.Frm_SH_D frm = new Reports.Frm_SH_D();

                if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
                {

                    DataTable dt = new DataTable();
                    dt = (DataTable)dataGridView1.DataSource;
                    Reports.SH.CrySH_G crpt = new Reports.SH.CrySH_G();

                    dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.G2].IDForm, dbo.[Form_SH.G2].Code, dbo.[Form_SH.G2].CostForm, dbo.[Form_SH.G2].TypeForm, dbo.[Form_SH.G2].DateForm,   dbo.[Form_SH.G2].NumberLicense, dbo.[Form_SH.G2].YearLicense, dbo.[Form_SH.G2].DateLicense, dbo.[Form_SH.G2].TypeLicense, dbo.[Form_SH.G2].IssuedFrom,  dbo.[Form_SH.G2].TitleProject, dbo.[Form_SH.G2].Department, dbo.[Form_SH.G2].City, dbo.[Form_SH.G2].Governorate, dbo.[Form_SH.G2].BusinessStatement,   dbo.[Form_SH.G2].CostWord, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].OtherData, dbo.[Form_SH.G2].EngEmail, dbo.[Form_SH.G2].EngPhone,   dbo.[Form_SH.G2].EngMobile, dbo.[Form_SH.G2].EngAdress, dbo.[Form_SH.G2].OfficeAdress, dbo.[Form_SH.G2].OfficePhone, dbo.[Form_SH.G2].OwnerAdrees,   dbo.[Form_SH.G2].OwnerEmail, dbo.[Form_SH.G2].OwnerPhone, dbo.[Form_SH.G2].OwnerMobile, dbo.[Form_SH.G2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.G2].RerfEmp, dbo.[Form_SH.G2].Manager, dbo.[Form_SH.G2].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.G2].GeneralEngnering, dbo.[Form_SH.G2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax  FROM   dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN    dbo.Certificate_Tbl ON dbo.[Form_SH.G2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN   dbo.Revenue_Tbl ON dbo.[Form_SH.G2].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.G2].IDForm= '" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "' ");
                    crpt.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.ReportSource = crpt;
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.Dock = DockStyle.Fill;

                }
            }
            #endregion



        
            #endregion
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txt_searchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txt_Registration.Text = DAL.ClassDAL.Select("select [RegistrationNo] from [dbo].[EngBasicData_Tbl] where [EngName]='" + txt_searchName.Text.Trim() + "'").Rows[0][0].ToString();
                txt_Registration_Validating(null, null);
            }
        }

        private void combType_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           // #region PrintCode
           // if (dataGridView1.Rows.Count == 0)
           // {
           //     return;
           // }

           // #region Print
           // if (lbl_IDForm.Text == "2") // SH_D
           // {
           //     Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
           //     //{

           //         string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

           //         Reports.SH.CrySH_D crpt = new Reports.SH.CrySH_D();
           //         DataTable dt = new DataTable();
           //         dt = DAL.ClassDAL.Select("SELECT   dbo.[Form_SH.D].IDForm, dbo.[Form_SH.D].Code, dbo.[Form_SH.D].CostForm, dbo.[Form_SH.D].TypeForm, dbo.[Form_SH.D].DateForm,   dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].YearLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].TypeLicense, dbo.[Form_SH.D].IssuedFrom,  dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Department, dbo.[Form_SH.D].City, dbo.[Form_SH.D].Governorate, dbo.[Form_SH.D].BusinessStatement,   dbo.[Form_SH.D].CostWord, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].OtherData, dbo.[Form_SH.D].EngEmail, dbo.[Form_SH.D].EngPhone,  dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].OfficeAdress, dbo.[Form_SH.D].OfficePhone, dbo.[Form_SH.D].OwnerAdrees,   dbo.[Form_SH.D].OwnerEmail, dbo.[Form_SH.D].OwnerPhone, dbo.[Form_SH.D].OwnerMobile, dbo.[Form_SH.D].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.D].RerfEmp, dbo.[Form_SH.D].Manager, dbo.[Form_SH.D].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.D].GeneralEngnering, dbo.[Form_SH.D].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,  dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax,dbo.Revenue_Tbl.OrderWord FROM dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Certificate_Tbl ON dbo.[Form_SH.D].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.D].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");
           //         crpt.SetParameterValue("RecordingNo", RecordingNo);
           //         crpt.SetParameterValue("MangerEngneer", DAL.ClassDAL.MangerEngneer);
           //         //crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         crpt.SetDataSource(dt);
           //         frm.crystalReportViewer1.ReportSource = null;
           //         frm.crystalReportViewer1.ReportSource = crpt;

           //         frmMain.CloseFromOtheFrorm();



           //         frm.ShowDialog();
           //     }
           //     #endregion

           //// }



           // if (lbl_IDForm.Text == "3") // SH_G
           // {
           //     Reports.Frm_SH_D frm = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
           //     //{

           //         DataTable dt = new DataTable();
           //         dt = (DataTable)dataGridView1.DataSource;
           //         Reports.SH.CrySH_G crpt = new Reports.SH.CrySH_G();

           //         dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.G].IDForm, dbo.[Form_SH.G].Code, dbo.[Form_SH.G].CostForm, dbo.[Form_SH.G].TypeForm, dbo.[Form_SH.G].DateForm,   dbo.[Form_SH.G].NumberLicense, dbo.[Form_SH.G].YearLicense, dbo.[Form_SH.G].DateLicense, dbo.[Form_SH.G].TypeLicense, dbo.[Form_SH.G].IssuedFrom,  dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].Department, dbo.[Form_SH.G].City, dbo.[Form_SH.G].Governorate, dbo.[Form_SH.G].BusinessStatement,   dbo.[Form_SH.G].CostWord, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].OtherData, dbo.[Form_SH.G].EngEmail, dbo.[Form_SH.G].EngPhone,   dbo.[Form_SH.G].EngMobile, dbo.[Form_SH.G].EngAdress, dbo.[Form_SH.G].OfficeAdress, dbo.[Form_SH.G].OfficePhone, dbo.[Form_SH.G].OwnerAdrees,   dbo.[Form_SH.G].OwnerEmail, dbo.[Form_SH.G].OwnerPhone, dbo.[Form_SH.G].OwnerMobile, dbo.[Form_SH.G].TaxCardEng, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.G].RerfEmp, dbo.[Form_SH.G].Manager, dbo.[Form_SH.G].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.G].GeneralEngnering, dbo.[Form_SH.G].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax  FROM   dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN    dbo.Certificate_Tbl ON dbo.[Form_SH.G].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN   dbo.Revenue_Tbl ON dbo.[Form_SH.G].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.G].IDForm= '" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "' ");
           //         crpt.SetDataSource(dt);
           //         frm.crystalReportViewer1.ReportSource = null;
           //         frm.crystalReportViewer1.ReportSource = crpt;



           //         frm.ShowDialog();

           //     }
           // //}
           // if (lbl_IDForm.Text == "6") // SH_B
           // {
           //     Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
           //     //{


           //         // To Edit SQL select
           //         string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

           //         Reports.SH.CrySH_B crpt = new Reports.SH.CrySH_B();
           //         DataTable dt = new DataTable();
           //         dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.B].IDForm, dbo.[Form_SH.B].Code, dbo.[Form_SH.B].CostForm, dbo.[Form_SH.B].TypeForm, dbo.[Form_SH.B].DateForm, dbo.[Form_SH.B].NumberLicense, dbo.[Form_SH.B].DateLicense, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].TitleProject, dbo.[Form_SH.B].Department, dbo.[Form_SH.B].City, dbo.[Form_SH.B].Governorate, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostWord,   dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].OtherData, dbo.[Form_SH.B].EngEmail, dbo.[Form_SH.B].EngPhone, dbo.[Form_SH.B].EngMobile, dbo.[Form_SH.B].EngAdress, dbo.[Form_SH.B].OfficeAdress,  dbo.[Form_SH.B].OfficePhone, dbo.[Form_SH.B].OwnerAdrees, dbo.[Form_SH.B].OwnerEmail, dbo.[Form_SH.B].OwnerPhone, dbo.[Form_SH.B].OwnerMobile, dbo.[Form_SH.B].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.B].RerfEmp,  dbo.[Form_SH.B].Manager, dbo.[Form_SH.B].GeneralManager, dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.B].GeneralEngnering, dbo.[Form_SH.B].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box,  dbo.Revenue_Tbl.tax, dbo.EngBasicData_Tbl.ConsultantNo, dbo.Revenue_Tbl.OrderWord, dbo.[Form_SH.B].OfficeMobile, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.OfficeNo,  dbo.EngBasicData_Tbl.TaxCardNo  FROM   dbo.[Form_SH.B] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.B].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B].SerailNumber = dbo.Revenue_Tbl.SerailNumber INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.[Form_SH.B].IDOffice = dbo.ConsultingOffice_Tbl.IDOffice where  dbo.[Form_SH.B].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");

           //         crpt.SetDataSource(dt);
           //         frmd.crystalReportViewer1.ReportSource = null;
           //         frmd.crystalReportViewer1.ReportSource = crpt;




           //         frmd.ShowDialog();
           //         frmMain.CloseFromOtheFrorm();



           //     }

           // //}

           // if (lbl_IDForm.Text == "10") // SH_B2
           // {
           //     Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
           //     //{


           //         // To Edit SQL select
           //         string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

           //         Reports.SH.CrySH_B crpt = new Reports.SH.CrySH_B();
           //         DataTable dt = new DataTable();
           //         dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.B2].IDForm, dbo.[Form_SH.B2].Code, dbo.[Form_SH.B2].CostForm, dbo.[Form_SH.B2].TypeForm, dbo.[Form_SH.B2].DateForm, dbo.[Form_SH.B2].NumberLicense, dbo.[Form_SH.B2].DateLicense, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].TitleProject, dbo.[Form_SH.B2].Department, dbo.[Form_SH.B2].City, dbo.[Form_SH.B2].Governorate, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostWord,   dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].OtherData, dbo.[Form_SH.B2].EngEmail, dbo.[Form_SH.B2].EngPhone, dbo.[Form_SH.B2].EngMobile, dbo.[Form_SH.B2].EngAdress, dbo.[Form_SH.B2].OfficeAdress,  dbo.[Form_SH.B2].OfficePhone, dbo.[Form_SH.B2].OwnerAdrees, dbo.[Form_SH.B2].OwnerEmail, dbo.[Form_SH.B2].OwnerPhone, dbo.[Form_SH.B2].OwnerMobile, dbo.[Form_SH.B2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.B2].RerfEmp,  dbo.[Form_SH.B2].Manager, dbo.[Form_SH.B2].GeneralManager, dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.B2].GeneralEngnering, dbo.[Form_SH.B2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box,  dbo.Revenue_Tbl.tax, dbo.EngBasicData_Tbl.ConsultantNo, dbo.Revenue_Tbl.OrderWord, dbo.[Form_SH.B2].OfficeMobile, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.OfficeNo,  dbo.EngBasicData_Tbl.TaxCardNo  FROM   dbo.[Form_SH.B2] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.B2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B2].SerailNumber = dbo.Revenue_Tbl.SerailNumber INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.[Form_SH.B2].IDOffice = dbo.ConsultingOffice_Tbl.IDOffice where  dbo.[Form_SH.B2].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");

           //         crpt.SetDataSource(dt);
           //         frmd.crystalReportViewer1.ReportSource = null;
           //         frmd.crystalReportViewer1.ReportSource = crpt;




           //         frmd.ShowDialog();
           //         frmMain.CloseFromOtheFrorm();



           //     //}

           // }
            


           // if (lbl_IDForm.Text == "5") // SH_W
           // {
           //     Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
           //     //{

           //         DataTable dt = new DataTable();
           //         dt = (DataTable)dataGridView1.DataSource;
           //         Reports.SH.CrySH_W crpt = new Reports.SH.CrySH_W();
           //         //crpt.Database.Tables["SH_D"].SetDataSource(dt);
           //         //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
           //         //     string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

           //         crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         crpt.Refresh();

           //         crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         frmd.crystalReportViewer1.ReportSource = null;
           //         frmd.crystalReportViewer1.ReportSource = crpt;
           //         frmd.ShowDialog();
           //         frmMain.CloseFromOtheFrorm();

           //     //}

           // }

           // if (lbl_IDForm.Text == "4") // SH_H
           // {
           //     Reports.Frm_SH_D frmd = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(37))
           //     //{

           //         DataTable dt = new DataTable();
           //         dt = (DataTable)dataGridView1.DataSource;
           //         Reports.SH.CrySH_H crpt = new Reports.SH.CrySH_H();

           //         crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         crpt.Refresh();

           //         crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         frmd.crystalReportViewer1.ReportSource = null;
           //         frmd.crystalReportViewer1.ReportSource = crpt;
           //         frmd.ShowDialog();
           //         frmMain.CloseFromOtheFrorm();

           //     //}

           // }


           // #region Print
           // if (lbl_IDForm.Text == "8") // SH_D2
           // {
           //     Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
           //     //{

           //         string RecordingNo = DAL.Cls_EngineersData.RecordingEngNo(txt_Registration.Text);

           //         Reports.SH.CrySH_D crpt = new Reports.SH.CrySH_D();
           //         DataTable dt = new DataTable();
           //         dt = DAL.ClassDAL.Select("SELECT   dbo.[Form_SH.D2].IDForm, dbo.[Form_SH.D2].Code, dbo.[Form_SH.D2].CostForm, dbo.[Form_SH.D2].TypeForm, dbo.[Form_SH.D2].DateForm,   dbo.[Form_SH.D2].NumberLicense, dbo.[Form_SH.D2].YearLicense, dbo.[Form_SH.D2].DateLicense, dbo.[Form_SH.D2].TypeLicense, dbo.[Form_SH.D2].IssuedFrom,  dbo.[Form_SH.D2].TitleProject, dbo.[Form_SH.D2].Department, dbo.[Form_SH.D2].City, dbo.[Form_SH.D2].Governorate, dbo.[Form_SH.D2].BusinessStatement,   dbo.[Form_SH.D2].CostWord, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].OtherData, dbo.[Form_SH.D2].EngEmail, dbo.[Form_SH.D2].EngPhone,  dbo.[Form_SH.D2].EngMobile, dbo.[Form_SH.D2].EngAdress, dbo.[Form_SH.D2].OfficeAdress, dbo.[Form_SH.D2].OfficePhone, dbo.[Form_SH.D2].OwnerAdrees,   dbo.[Form_SH.D2].OwnerEmail, dbo.[Form_SH.D2].OwnerPhone, dbo.[Form_SH.D2].OwnerMobile, dbo.[Form_SH.D2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.D2].RerfEmp, dbo.[Form_SH.D2].Manager, dbo.[Form_SH.D2].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.D2].GeneralEngnering, dbo.[Form_SH.D2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,  dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax,dbo.Revenue_Tbl.OrderWord FROM dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Certificate_Tbl ON dbo.[Form_SH.D2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D2].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.D2].IDForm='" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'");
           //         crpt.SetParameterValue("RecordingNo", RecordingNo);
           //         crpt.SetParameterValue("MangerEngneer", DAL.ClassDAL.MangerEngneer);
           //         //crpt.SetParameterValue("@IDForm", Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
           //         crpt.SetDataSource(dt);
           //         frm.crystalReportViewer1.ReportSource = null;
           //         frm.crystalReportViewer1.ReportSource = crpt;




           //         frm.ShowDialog();
           //         frmMain.CloseFromOtheFrorm();
           //     }
           //     #endregion






           // //}



           // #region SH_G2
           // if (lbl_IDForm.Text == "9") // SH_G2
           // {
           //     Reports.Frm_SH_D frm = new Reports.Frm_SH_D();

           //     //if (dataGridView1.CurrentCell.ColumnIndex.Equals(39))
           //     //{

           //         DataTable dt = new DataTable();
           //         dt = (DataTable)dataGridView1.DataSource;
           //         Reports.SH.CrySH_G crpt = new Reports.SH.CrySH_G();

           //         dt = DAL.ClassDAL.Select("SELECT dbo.[Form_SH.G2].IDForm, dbo.[Form_SH.G2].Code, dbo.[Form_SH.G2].CostForm, dbo.[Form_SH.G2].TypeForm, dbo.[Form_SH.G2].DateForm,   dbo.[Form_SH.G2].NumberLicense, dbo.[Form_SH.G2].YearLicense, dbo.[Form_SH.G2].DateLicense, dbo.[Form_SH.G2].TypeLicense, dbo.[Form_SH.G2].IssuedFrom,  dbo.[Form_SH.G2].TitleProject, dbo.[Form_SH.G2].Department, dbo.[Form_SH.G2].City, dbo.[Form_SH.G2].Governorate, dbo.[Form_SH.G2].BusinessStatement,   dbo.[Form_SH.G2].CostWord, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].OtherData, dbo.[Form_SH.G2].EngEmail, dbo.[Form_SH.G2].EngPhone,   dbo.[Form_SH.G2].EngMobile, dbo.[Form_SH.G2].EngAdress, dbo.[Form_SH.G2].OfficeAdress, dbo.[Form_SH.G2].OfficePhone, dbo.[Form_SH.G2].OwnerAdrees,   dbo.[Form_SH.G2].OwnerEmail, dbo.[Form_SH.G2].OwnerPhone, dbo.[Form_SH.G2].OwnerMobile, dbo.[Form_SH.G2].TaxCardEng, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,   dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.G2].RerfEmp, dbo.[Form_SH.G2].Manager, dbo.[Form_SH.G2].GeneralManager,  dbo.Certificate_Tbl.imgForm, dbo.[Form_SH.G2].GeneralEngnering, dbo.[Form_SH.G2].SerailNumber, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Revenue_Tbl.Area, dbo.Revenue_Tbl.BisnecesCostArea, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied,   dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax  FROM   dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN    dbo.Certificate_Tbl ON dbo.[Form_SH.G2].TypeForm = dbo.Certificate_Tbl.IDCertificate INNER JOIN   dbo.Revenue_Tbl ON dbo.[Form_SH.G2].SerailNumber = dbo.Revenue_Tbl.SerailNumber where  dbo.[Form_SH.G2].IDForm= '" + Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "' ");
           //         crpt.SetDataSource(dt);
           //         frm.crystalReportViewer1.ReportSource = null;
           //         frm.crystalReportViewer1.ReportSource = crpt;



           //         frm.ShowDialog();

           //     }
           // //}
           // #endregion



           // frmMain.CloseFromOtheFrorm();
           // //Frm_PrintForm_Load(null, null);




           // #endregion
        }
    }
}
