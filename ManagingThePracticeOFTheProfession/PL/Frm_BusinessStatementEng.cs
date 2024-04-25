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
    public partial class Frm_BusinessStatementEng : Form
    {
        public Frm_BusinessStatementEng()
        {
            InitializeComponent();
            DAL.Cls_EngineersData.FillCombAllEng(comboBox1);
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex<0)
            {
                comboBox1.Focus();
                return;
            }
            lbl_IDEng.Text = comboBox1.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                comboBox1.Focus();
                return;
            }

            string officeConName = "";

            Reports.Eng.CryEngBassinesStatement cry = new Reports.Eng.CryEngBassinesStatement();
            DataTable dtEngBassinesStatement = new DataTable();
            //dtEngBassinesStatement = DAL.ClassDAL.Select("SELECT IDEng, EngName, RegistrationNo, Division, format(GraduationYear,'yyyy-MM')as GraduationYear, NationalID, ConsultantNo, Gender, EngineeringRecordNo, Specialization, TaxCardNo FROM  dbo.EngBasicData_Tbl where  EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and state=1");
            dtEngBassinesStatement = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS GraduationYear, dbo.EngBasicData_Tbl.NationalID, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.Syndicate, dbo.EngBasicData_Tbl.Qualification, dbo.EngBasicData_Tbl.University, dbo.EngBasicData_Tbl.Notes, dbo.EngBasicData_Tbl.DateOFRegistration, dbo.Users_Tbl.UserName,  dbo.EngBasicData_Tbl.IDOfficeCons  FROM  dbo.EngBasicData_Tbl INNER JOIN dbo.Users_Tbl ON dbo.EngBasicData_Tbl.UserID = dbo.Users_Tbl.UserID CROSS JOIN dbo.ConsultingOffice_Tbl WHERE (dbo.EngBasicData_Tbl.IDEng = '"+lbl_IDEng.Text+"') AND (dbo.EngBasicData_Tbl.state = 1)");
            officeConName = dtEngBassinesStatement.Rows[0]["IDOfficeCons"].ToString();
            if (officeConName!="0")
            {
                officeConName = DAL.ClassDAL.Select("SELECT OfficeName FROM  dbo.ConsultingOffice_Tbl where IDOffice='"+officeConName+"' ").Rows[0][0].ToString();
            }
            if (officeConName=="0")
            {
                officeConName = "";
            }
            cry.SetParameterValue("OfficeName", officeConName);

            cry.SetDataSource(dtEngBassinesStatement);

            // CountacatEngData
            DataTable dtEngContact = new DataTable();
            dtEngContact = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.IDEng, dbo.Contact_Tbl.Address, dbo.Contact_Tbl.Phone, dbo.Contact_Tbl.Email, dbo.Contact_Tbl.Mobile, dbo.Contact_Tbl.FaceBook FROM dbo.Contact_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Contact_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng  where dbo.EngBasicData_Tbl.IDEng ='" + lbl_IDEng.Text + "' and dbo.Contact_Tbl.state=1");
            cry.Subreports["CryContactEng.rpt"].SetDataSource(dtEngContact);


            // OfficeEngData
            DataTable dtOffice = new DataTable();
            dtOffice = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.Office_Tbl.Address, dbo.Office_Tbl.Phone, dbo.Office_Tbl.Notes  FROM dbo.EngBasicData_Tbl INNER JOIN  dbo.Office_Tbl ON dbo.EngBasicData_Tbl.IDEng = dbo.Office_Tbl.IDEng where dbo.EngBasicData_Tbl.IDEng ='" + lbl_IDEng.Text + "' and dbo.Office_Tbl.state=1");
            cry.Subreports["CryOfficeEngData.rpt"].SetDataSource(dtOffice);



            // SH_D Active
            DataTable dtEngSHDActive = new DataTable();
            dtEngSHDActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].OrderID,  dbo.[Form_SH.D].ReciptNo, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].ISActive, dbo.[Form_SH.D].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.D].DataRegistration, dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Code FROM  dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.D].ISActive=1 and  dbo.[Form_SH.D].State=1");
            cry.Subreports["CryEngSHDActive.rpt"].SetDataSource(dtEngSHDActive);
           


            // SH_D Stop
            DataTable dtStopeSHD = new DataTable();
            dtStopeSHD = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.D].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
             cry.Subreports["CryEngSHDStop.rpt"].SetDataSource(dtStopeSHD);

            // SH_D2 Active
            DataTable dtEngSHD2Active = new DataTable();
            dtEngSHD2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].OrderID,  dbo.[Form_SH.D2].ReciptNo, dbo.[Form_SH.D2].SerailNumber, dbo.[Form_SH.D2].ISActive, dbo.[Form_SH.D2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.D2].DataRegistration, dbo.[Form_SH.D2].TitleProject, dbo.[Form_SH.D2].Code FROM  dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.D2].ISActive=1 and  dbo.[Form_SH.D2].State=1");
            cry.Subreports["CryEngSHDActive2.rpt"].SetDataSource(dtEngSHD2Active);
            // SH_D2 Stop
            DataTable dtStopeSHD2 = new DataTable();
            dtStopeSHD2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.D2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.D2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHDStop2.rpt"].SetDataSource(dtStopeSHD2);

            // SH_G Active
            DataTable dtEngSHGActive = new DataTable();
            dtEngSHGActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].OrderID,  dbo.[Form_SH.G].ReciptNo, dbo.[Form_SH.G].SerailNumber, dbo.[Form_SH.G].ISActive, dbo.[Form_SH.G].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.G].DataRegistration, dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].Code FROM  dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.G].ISActive=1 and  dbo.[Form_SH.G].State=1");
            cry.Subreports["CryEngSHGActive.rpt"].SetDataSource(dtEngSHGActive);
            // SH_G Stop
            DataTable dtStopeSHG = new DataTable();
            dtStopeSHG = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.G].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.G] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHGStop.rpt"].SetDataSource(dtStopeSHG);

            // SH_G2 Active
            DataTable dtEngSHG2Active = new DataTable();
            dtEngSHG2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].OrderID,  dbo.[Form_SH.G2].ReciptNo, dbo.[Form_SH.G2].SerailNumber, dbo.[Form_SH.G2].ISActive, dbo.[Form_SH.G2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.G2].DataRegistration, dbo.[Form_SH.G2].TitleProject, dbo.[Form_SH.G2].Code FROM  dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.G2].ISActive=1 and  dbo.[Form_SH.G2].State=1");
            cry.Subreports["CryEngSHGActive2.rpt"].SetDataSource(dtEngSHG2Active);
            // SH_G2 Stop
            DataTable dtStopeSHG2 = new DataTable();
            dtStopeSHG2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.G2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.G2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHGStop2.rpt"].SetDataSource(dtStopeSHG2);

            // SH_B Active
            DataTable dtEngSHBActive = new DataTable();
            dtEngSHBActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].OrderID,  dbo.[Form_SH.B].ReciptNo, dbo.[Form_SH.B].SerailNumber, dbo.[Form_SH.B].ISActive, dbo.[Form_SH.B].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.B].DataRegistration, dbo.[Form_SH.B].TitleProject, dbo.[Form_SH.B].Code FROM  dbo.[Form_SH.B] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.B].ISActive=1 and  dbo.[Form_SH.B].State=1");
            cry.Subreports["CryEngSHBActive.rpt"].SetDataSource(dtEngSHBActive);
            // SH_B Stop
            DataTable dtStopeSHB = new DataTable();
            dtStopeSHB = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.B].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.B] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHBStop.rpt"].SetDataSource(dtStopeSHB);

            // SH_B2 Active
            DataTable dtEngSHB2Active = new DataTable();
            dtEngSHB2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].OrderID,  dbo.[Form_SH.B2].ReciptNo, dbo.[Form_SH.B2].SerailNumber, dbo.[Form_SH.B2].ISActive, dbo.[Form_SH.B2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.B2].DataRegistration, dbo.[Form_SH.B2].TitleProject, dbo.[Form_SH.B2].Code FROM  dbo.[Form_SH.B2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.B2].ISActive=1 and  dbo.[Form_SH.B2].State=1");
            cry.Subreports["CryEngSHBActive2.rpt"].SetDataSource(dtEngSHB2Active);
            // SH_B2 Stop
            DataTable dtStopeSHB2 = new DataTable();
            dtStopeSHB2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.B2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.B2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHBStop2.rpt"].SetDataSource(dtStopeSHB2);

            // SH_W Active
            DataTable dtEngSHWActive = new DataTable();
            dtEngSHWActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].OrderID,  dbo.[Form_SH.W].ReciptNo, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].ISActive, dbo.[Form_SH.W].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.W].DataRegistration, dbo.[Form_SH.W].TitleProject, dbo.[Form_SH.W].Code FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.W].ISActive=1 and  dbo.[Form_SH.W].State=1");
            cry.Subreports["CryEngActiveSHW.rpt"].SetDataSource(dtEngSHWActive);
            // SH_W Stop
            DataTable dtStopeSHW = new DataTable();
            dtStopeSHW = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.W].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngStopSHW.rpt"].SetDataSource(dtStopeSHW);

            // SH_H Active
            DataTable dtEngSHHActive = new DataTable();
            dtEngSHHActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.H].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].CostLicense, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].OrderID,  dbo.[Form_SH.H].ReciptNo, dbo.[Form_SH.H].SerailNumber, dbo.[Form_SH.H].ISActive, dbo.[Form_SH.H].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.H].DataRegistration, dbo.[Form_SH.H].TitleProject, dbo.[Form_SH.H].Code FROM  dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.H].ISActive=1 and  dbo.[Form_SH.H].State=1");
            cry.Subreports["CryEngSHHActive.rpt"].SetDataSource(dtEngSHHActive);
            // SH_H Stop
            DataTable dtStopeSHH = new DataTable();
            dtStopeSHH = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.H].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].CostLicense, dbo.[Form_SH.H].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.H].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.H] ON dbo.Stope.SerialNumber = dbo.[Form_SH.H].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["CryEngSHHStop.rpt"].SetDataSource(dtStopeSHH);


            #region Count 

            #endregion




            //DataTable dtEngSHWActive = new DataTable();
            //dtEngSHWActive = DAL.ClassDAL.Select("   SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].OrderID,  dbo.[Form_SH.W].ReciptNo, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].ISActive, dbo.[Form_SH.W].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.W].DataRegistration, dbo.[Form_SH.W].TitleProject, dbo.[Form_SH.W].Code FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.W].ISActive=1 and  dbo.[Form_SH.W].State=1");

            //DataTable dtStopeSHW = new DataTable();
            //dtStopeSHW = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.W].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "'");

            cry.SetParameterValue("OfficeName", officeConName);

            //Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cry;
            //frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex<0)
            {
                comboBox1.Focus();
                return;
            }
            PL.Frm_progarssBar prog = new Frm_progarssBar();
            groupBox1.Enabled = false;
            prog.Show();
            #region CorrectCode
            string officeConName = "";
            DataTable dtOfficeCons = new DataTable();
            Reports.Eng.CryBusinessStatement2 cry = new Reports.Eng.CryBusinessStatement2();
            DataTable dtEngBassinesStatement = new DataTable();
            //dtEngBassinesStatement = DAL.ClassDAL.Select("SELECT IDEng, EngName, RegistrationNo, Division, format(GraduationYear,'yyyy-MM')as GraduationYear, NationalID, ConsultantNo, Gender, EngineeringRecordNo, Specialization, TaxCardNo FROM  dbo.EngBasicData_Tbl where  EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and state=1");
            //dtEngBassinesStatement = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS GraduationYear, dbo.EngBasicData_Tbl.NationalID, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.Syndicate, dbo.EngBasicData_Tbl.Qualification, dbo.EngBasicData_Tbl.University, dbo.EngBasicData_Tbl.Notes, dbo.EngBasicData_Tbl.DateOFRegistration, dbo.Users_Tbl.UserName,  dbo.EngBasicData_Tbl.IDOfficeCons  FROM  dbo.EngBasicData_Tbl INNER JOIN dbo.Users_Tbl ON dbo.EngBasicData_Tbl.UserID = dbo.Users_Tbl.UserID CROSS JOIN dbo.ConsultingOffice_Tbl WHERE (dbo.EngBasicData_Tbl.IDEng = '" + lbl_IDEng.Text + "') AND (dbo.EngBasicData_Tbl.state = 1)");
            dtEngBassinesStatement = DAL.ClassDAL.Select(" SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS GraduationYear,  dbo.EngBasicData_Tbl.NationalID, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.Syndicate, dbo.EngBasicData_Tbl.Qualification, dbo.EngBasicData_Tbl.University, dbo.EngBasicData_Tbl.Notes, dbo.EngBasicData_Tbl.DateOFRegistration, dbo.Users_Tbl.UserName,   dbo.EngBasicData_Tbl.IDOfficeCons   FROM  dbo.EngBasicData_Tbl INNER JOIN dbo.Users_Tbl ON dbo.EngBasicData_Tbl.UserID = dbo.Users_Tbl.UserID WHERE (dbo.EngBasicData_Tbl.IDEng = '" + lbl_IDEng.Text + "') AND (dbo.EngBasicData_Tbl.state = 1)");
            officeConName = dtEngBassinesStatement.Rows[0]["IDOfficeCons"].ToString();
            if (officeConName != "0")
            {
                dtOfficeCons = DAL.ClassDAL.Select(" SELECT dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.IDOffice, dbo.ConsultingOffice_Tbl.OfficeNo, dbo.ConsultingOffice_Tbl.OfficeRecordingNo, dbo.ConsultingOffice_Tbl.TaxNo, dbo.ContanetOfficeCons_tbl.Address,  dbo.ContanetOfficeCons_tbl.phone, dbo.ContanetOfficeCons_tbl.moble FROM  dbo.ConsultingOffice_Tbl INNER JOIN  dbo.ContanetOfficeCons_tbl ON dbo.ConsultingOffice_Tbl.IDOffice = dbo.ContanetOfficeCons_tbl.IDOfficeCons where  dbo.ConsultingOffice_Tbl.IDOffice='" + officeConName + "' ");
                officeConName = dtOfficeCons.Rows[0]["OfficeName"].ToString();
            }
            if (officeConName == "0")
            {
                officeConName = "";
            }
            cry.SetParameterValue("OfficeName", officeConName);

            cry.SetDataSource(dtEngBassinesStatement);

            // CountacatEngData
            DataTable dtEngContact = new DataTable();
            dtEngContact = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.IDEng, dbo.Contact_Tbl.Address, dbo.Contact_Tbl.Phone, dbo.Contact_Tbl.Email, dbo.Contact_Tbl.Mobile, dbo.Contact_Tbl.FaceBook FROM dbo.Contact_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Contact_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng  where dbo.EngBasicData_Tbl.IDEng ='" + lbl_IDEng.Text + "' and dbo.Contact_Tbl.state=1");
            cry.Subreports["CryContactEng.rpt"].SetDataSource(dtEngContact);


            // OfficeEngData
            DataTable dtOffice = new DataTable();
            dtOffice = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.Office_Tbl.Address, dbo.Office_Tbl.Phone, dbo.Office_Tbl.Notes , dbo.Office_Tbl.OFficeName FROM dbo.EngBasicData_Tbl INNER JOIN  dbo.Office_Tbl ON dbo.EngBasicData_Tbl.IDEng = dbo.Office_Tbl.IDEng where dbo.EngBasicData_Tbl.IDEng ='" + lbl_IDEng.Text + "' and dbo.Office_Tbl.state=1");
            cry.Subreports["CryOfficeEngData.rpt"].SetDataSource(dtOffice);

            //   **************************          //// OfficeCons******************************
            //DataTable dto = new DataTable();
            //dtOffice = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.IDEng, dbo.Office_Tbl.Address, dbo.Office_Tbl.Phone, dbo.Office_Tbl.Notes  FROM dbo.EngBasicData_Tbl INNER JOIN  dbo.Office_Tbl ON dbo.EngBasicData_Tbl.IDEng = dbo.Office_Tbl.IDEng where dbo.EngBasicData_Tbl.IDEng ='" + lbl_IDEng.Text + "' and dbo.Office_Tbl.state=1");
            //cry.Subreports["CryOfficeEngData.rpt"].SetDataSource(dtOffice);


            // SH_D Active
            DataTable dtEngSHDActive = new DataTable();
            dtEngSHDActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].OrderID,  dbo.[Form_SH.D].ReciptNo, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].ISActive, dbo.[Form_SH.D].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.D].DataRegistration, dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Code FROM  dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.D].ISActive=1 and  dbo.[Form_SH.D].State=1");
            cry.Subreports["د_نشط"].SetDataSource(dtEngSHDActive);
            //cry.Subreports["CryEngSHDActive.rpt"].SetDataSource(dtEngSHDActive);



            // SH_D Stop
            DataTable dtStopeSHD = new DataTable();
            dtStopeSHD = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.D].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["د_إلغاء"].SetDataSource(dtStopeSHD);

            // SH_D2 Active
            DataTable dtEngSHD2Active = new DataTable();
            dtEngSHD2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].OrderID,  dbo.[Form_SH.D2].ReciptNo, dbo.[Form_SH.D2].SerailNumber, dbo.[Form_SH.D2].ISActive, dbo.[Form_SH.D2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.D2].DataRegistration, dbo.[Form_SH.D2].TitleProject, dbo.[Form_SH.D2].Code FROM  dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.D2].ISActive=1 and  dbo.[Form_SH.D2].State=1");
            cry.Subreports["د.ت_نشط"].SetDataSource(dtEngSHD2Active);
            // SH_D2 Stop
            DataTable dtStopeSHD2 = new DataTable();
            dtStopeSHD2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.D2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].CostLicense, dbo.[Form_SH.D2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.D2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.D2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["د.ت_إلغاء"].SetDataSource(dtStopeSHD2);

            // SH_G Active
            DataTable dtEngSHGActive = new DataTable();
            dtEngSHGActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].OrderID,  dbo.[Form_SH.G].ReciptNo, dbo.[Form_SH.G].SerailNumber, dbo.[Form_SH.G].ISActive, dbo.[Form_SH.G].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.G].DataRegistration, dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].Code FROM  dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.G].ISActive=1 and  dbo.[Form_SH.G].State=1");
            cry.Subreports["ج_نشط"].SetDataSource(dtEngSHGActive);
            // SH_G Stop
            DataTable dtStopeSHG = new DataTable();
            dtStopeSHG = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.G].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.G] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["ج_إلغاء"].SetDataSource(dtStopeSHG);

            // SH_G2 Active
            DataTable dtEngSHG2Active = new DataTable();
            dtEngSHG2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].OrderID,  dbo.[Form_SH.G2].ReciptNo, dbo.[Form_SH.G2].SerailNumber, dbo.[Form_SH.G2].ISActive, dbo.[Form_SH.G2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.G2].DataRegistration, dbo.[Form_SH.G2].TitleProject, dbo.[Form_SH.G2].Code FROM  dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.G2].ISActive=1 and  dbo.[Form_SH.G2].State=1");
            cry.Subreports["ج.ت_نشط"].SetDataSource(dtEngSHG2Active);
            // SH_G2 Stop
            DataTable dtStopeSHG2 = new DataTable();
            dtStopeSHG2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.G2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].CostLicense, dbo.[Form_SH.G2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.G2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.G2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["ج.ت_إلغاء"].SetDataSource(dtStopeSHG2);

            // SH_B Active
            DataTable dtEngSHBActive = new DataTable();
            dtEngSHBActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].OrderID,  dbo.[Form_SH.B].ReciptNo, dbo.[Form_SH.B].SerailNumber, dbo.[Form_SH.B].ISActive, dbo.[Form_SH.B].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.B].DataRegistration, dbo.[Form_SH.B].TitleProject, dbo.[Form_SH.B].Code FROM  dbo.[Form_SH.B] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.B].ISActive=1 and  dbo.[Form_SH.B].State=1");
            cry.Subreports["ب_نشط"].SetDataSource(dtEngSHBActive);
            // SH_B Stop
            DataTable dtStopeSHB = new DataTable();
            dtStopeSHB = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].CostLicense, dbo.[Form_SH.B].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.B].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.B] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["ب_إلغاء"].SetDataSource(dtStopeSHB);

            // SH_B2 Active
            DataTable dtEngSHB2Active = new DataTable();
            dtEngSHB2Active = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B2].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].OrderID,  dbo.[Form_SH.B2].ReciptNo, dbo.[Form_SH.B2].SerailNumber, dbo.[Form_SH.B2].ISActive, dbo.[Form_SH.B2].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.B2].DataRegistration, dbo.[Form_SH.B2].TitleProject, dbo.[Form_SH.B2].Code FROM  dbo.[Form_SH.B2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.B2].ISActive=1 and  dbo.[Form_SH.B2].State=1");
            cry.Subreports["ب.ت_نشط"].SetDataSource(dtEngSHB2Active);
            // SH_B2 Stop
            DataTable dtStopeSHB2 = new DataTable();
            dtStopeSHB2 = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.B2].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].CostLicense, dbo.[Form_SH.B2].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.B2].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.B2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B2].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["ب.ت_إلغاء"].SetDataSource(dtStopeSHB2);

            // SH_W Active
            DataTable dtEngSHWActive = new DataTable();
            dtEngSHWActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].OrderID,  dbo.[Form_SH.W].ReciptNo, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].ISActive, dbo.[Form_SH.W].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.W].DataRegistration, dbo.[Form_SH.W].TitleProject, dbo.[Form_SH.W].Code FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.W].ISActive=1 and  dbo.[Form_SH.W].State=1");
            cry.Subreports["و_نشط"].SetDataSource(dtEngSHWActive);
            // SH_W Stop
            DataTable dtStopeSHW = new DataTable();
            dtStopeSHW = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.W].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["و_إلغاء"].SetDataSource(dtStopeSHW);

            // SH_H Active
            DataTable dtEngSHHActive = new DataTable();
            dtEngSHHActive = DAL.ClassDAL.Select("SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.H].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].CostLicense, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].OrderID,  dbo.[Form_SH.H].ReciptNo, dbo.[Form_SH.H].SerailNumber, dbo.[Form_SH.H].ISActive, dbo.[Form_SH.H].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.H].DataRegistration, dbo.[Form_SH.H].TitleProject, dbo.[Form_SH.H].Code FROM  dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.H].ISActive=1 and  dbo.[Form_SH.H].State=1");
            cry.Subreports["هـ_نشط"].SetDataSource(dtEngSHHActive);
            // SH_H Stop
            DataTable dtStopeSHH = new DataTable();
            dtStopeSHH = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.H].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].CostLicense, dbo.[Form_SH.H].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.H].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.H] ON dbo.Stope.SerialNumber = dbo.[Form_SH.H].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' ");
            cry.Subreports["هـ_إلغاء"].SetDataSource(dtStopeSHH);


            // REport_TechnicalReportCivilProtection
            DataTable REport_TechnicalReportCivilProtection = new DataTable();
            REport_TechnicalReportCivilProtection = DAL.ClassDAL.Select(" SELECT  dbo.OwnerData_Tbl.Name, dbo.TechnicalReportCivilProtection.BusinessStatement, dbo.TechnicalReportCivilProtection.AdressBuStatement, dbo.TechnicalReportCivilProtection.IssuedFrom,  dbo.TechnicalReportCivilProtection.Governorate, dbo.TechnicalReportCivilProtection.ReciptNo, dbo.EngBasicData_Tbl.IDEng, dbo.Revenue_Tbl.DatePaid, dbo.Users_Tbl.UserName FROM  dbo.TechnicalReportCivilProtection INNER JOIN dbo.EngBasicData_Tbl ON dbo.TechnicalReportCivilProtection.IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.TechnicalReportCivilProtection.IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.TechnicalReportCivilProtection.IDTecReport = dbo.Revenue_Tbl.IDTecReport INNER JOIN dbo.Users_Tbl ON dbo.TechnicalReportCivilProtection.IDUser = dbo.Users_Tbl.UserID where dbo.TechnicalReportCivilProtection.IDEng  ='" + lbl_IDEng.Text + "' ");
            cry.Subreports["إعتماد تقرير فنى-الحماية المدنية"].SetDataSource(REport_TechnicalReportCivilProtection);





            //DataTable dtEngSHWActive = new DataTable();
            //dtEngSHWActive = DAL.ClassDAL.Select("   SELECT dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm,'yyyy-MM-dd')as dateform, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].OrderID,  dbo.[Form_SH.W].ReciptNo, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].ISActive, dbo.[Form_SH.W].State, dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.TaxCardNo,  dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.Gender, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.NationalID,FORMAT( dbo.EngBasicData_Tbl.GraduationYear,'yyyy-MM') as GenderYear, dbo.EngBasicData_Tbl.Division,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.IDEng, dbo.[Form_SH.W].DataRegistration, dbo.[Form_SH.W].TitleProject, dbo.[Form_SH.W].Code FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "' and  dbo.[Form_SH.W].ISActive=1 and  dbo.[Form_SH.W].State=1");

            //DataTable dtStopeSHW = new DataTable();
            //dtStopeSHW = DAL.ClassDAL.Select("SELECT dbo.Stope.SerialNumber, dbo.EngBasicData_Tbl.IDEng, dbo.OwnerData_Tbl.Name, format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS dateform, FORMAT(dbo.Stope.Date, 'yyyy-MM-dd') AS dateCancel,  dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].CostLicense, dbo.[Form_SH.W].TitleProject, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.[Form_SH.W].Code  FROM   dbo.Stope INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where EngBasicData_Tbl.IDEng='" + lbl_IDEng.Text + "'");

            cry.SetParameterValue("OfficeName", officeConName);
            #region Count 
            cry.SetParameterValue("CDA", dtEngSHDActive.Rows.Count.ToString());
            cry.SetParameterValue("CDS", dtStopeSHD.Rows.Count.ToString());
            cry.SetParameterValue("CD2A", dtEngSHD2Active.Rows.Count.ToString());
            cry.SetParameterValue("CD2S", dtStopeSHD2.Rows.Count.ToString());
            cry.SetParameterValue("CGA", dtEngSHGActive.Rows.Count.ToString());
            cry.SetParameterValue("CGS", dtStopeSHG.Rows.Count.ToString());
            cry.SetParameterValue("CG2A", dtEngSHG2Active.Rows.Count.ToString());
            cry.SetParameterValue("CG2S", dtStopeSHG2.Rows.Count.ToString());
            cry.SetParameterValue("CBA", dtEngSHBActive.Rows.Count.ToString());
            cry.SetParameterValue("CBS", dtStopeSHB.Rows.Count.ToString());
            cry.SetParameterValue("CB2A", dtEngSHB2Active.Rows.Count.ToString());
            cry.SetParameterValue("CB2S", dtStopeSHB2.Rows.Count.ToString());
            cry.SetParameterValue("CHA", dtEngSHHActive.Rows.Count.ToString());
            cry.SetParameterValue("CHS", dtStopeSHH.Rows.Count.ToString());
            cry.SetParameterValue("CWA", dtEngSHWActive.Rows.Count.ToString());
            cry.SetParameterValue("CWS", dtStopeSHW.Rows.Count.ToString());
            cry.SetParameterValue("TQReportCivilProdaction", REport_TechnicalReportCivilProtection.Rows.Count.ToString());
            #endregion

            //Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cry;


            #endregion
            prog.timer1.Stop();
            prog.Close();
            groupBox1.Enabled = true;

        }

        private void btnPublicData_Click(object sender, EventArgs e)
        {
            PL.Frm_progarssBar prog = new Frm_progarssBar();
            groupBox1.Enabled = false;
            prog.Show();

            DataTable dt = DAL.Cls_EngineersData.PublicEngData();

            Reports.Eng.CryEngineersData cry = new Reports.Eng.CryEngineersData();
            cry.SetDataSource(dt);
            crystalReportViewer1.Visible = true;
            crystalReportViewer1.ReportSource = cry;


            prog.timer1.Stop();
            prog.Close();
            groupBox1.Enabled = true;
        }
    }
}
