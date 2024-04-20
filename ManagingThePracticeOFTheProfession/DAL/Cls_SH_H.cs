using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_SH_H:DAL.ClassDAL
    {

        static SqlTransaction transaction;

        public static void Save(string Code, decimal CostForm, int TypeForm, Int64 IDEng, Int64 IDOwner, string NumberLicense, DateTime DateLicense, string IssuedFrom, string TitleProject, string Department, string City,
string Governorate, string BusinessStatement, string CostWord, string CostLicense, string OtherData,
string EngEmail, string EngPhone,
string EngMobile, string EngAdress, string OfficeAdress, string OfficePhone, string OwnerAdrees, string OwnerEmail, string OwnerPhone, string OwnerMobile, Int32 UserID, string TaxCardEng, string TechnicalReport, string TechnicalReportNo, string HouseNumber, string ConsultantEngineer, string ConsultantRegist, string ConsultantDivaion, string ConsultantNo, string ConsultantSpecializt, string ConsultantOfficeAddres, string ConsultantOfficePhone, string RerfEmp, string Manager, string GeneralManager, string SerailNumber, string GeneralEngnering, Int64 SN, decimal Area, decimal BisnecesCostArea, decimal StampEng, decimal StampPrevPaied, decimal OrderPaied, decimal Fess, decimal box, decimal tax,string OrderWord, DateTime DateForm, string ReciptNo, string OrderID,string IDOfficeCon)

        {

            //Run("insert into [Form_SH.D] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,YearLicense,DateLicense,TypeLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID ) values ('"+ Code + "','"+ CostForm + "','"+ TypeForm + "','"+ IDEng + "','"+ IDOwner + "','"+ NumberLicense + "','"+ YearLicense + "','"+ DateLicense + "','"+ TypeLicense + "','"+ IssuedFrom + "','"+ TitleProject + "','"+ Department + "','"+ City + "','"+ Governorate + "','"+ BusinessStatement + "','"+ CostWord + "','"+ CostLicense + "','" + OtherData + "','"+ EngEmail + "','"+ EngPhone + "','"+ EngMobile + "','"+ EngAdress + "','"+OfficeAdress+ "','"+OfficePhone+ "','"+OwnerAdrees+ "','" + OwnerEmail + "','" + OwnerPhone + "','" + OwnerMobile+"','"+UserID +"' )");


            //Open();

            try
            {
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("insert into [Form_SH.H] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,DateLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID,TaxCardEng ,TechnicalReport,TechnicalReportNo,HouseNumber,ConsultantEngineer,ConsultantRegist,ConsultantDivaion,ConsultantNo,ConsultantSpecializt,ConsultantOfficeAddres,ConsultantOfficePhone,RerfEmp,Manager,GeneralManager,SerailNumber,GeneralEngnering,SN,DateForm,ReciptNo,OrderID,IDOfficeCon) values (@Code,@CostForm,@TypeForm,@IDEng,@IDOwner,@NumberLicense,@DateLicense,@IssuedFrom,@TitleProject,@Department,@City,@Governorate,@BusinessStatement,@CostWord,@CostLicense,@OtherData,@EngEmail,@EngPhone,@EngMobile,@EngAdress,@OfficeAdress,@OfficePhone,@OwnerAdrees,@OwnerEmail,@OwnerPhone,@OwnerMobile,@UserID ,@TaxCardEng ,@TechnicalReport,@TechnicalReportNo, @HouseNumber, @ConsultantEngineer, @ConsultantRegist, @ConsultantDivaion, @ConsultantNo, @ConsultantSpecializt, @ConsultantOfficeAddres, @ConsultantOfficePhone, @RerfEmp, @Manager, @GeneralManager, @SerailNumber, @GeneralEngnering, @SN,@DateForm,'" + ReciptNo + "','" + OrderID + "','"+ IDOfficeCon + "')", con, transaction);
                SqlParameter[] p2 = new SqlParameter[45];

                p2[0] = new SqlParameter("@Code", Code);
                p2[1] = new SqlParameter("@CostForm", CostForm);
                p2[2] = new SqlParameter("@TypeForm", TypeForm);
                p2[3] = new SqlParameter("@IDEng", IDEng);
                p2[4] = new SqlParameter("@IDOwner", IDOwner);
                p2[5] = new SqlParameter("@NumberLicense", NumberLicense);
                p2[6] = new SqlParameter("@DateLicense", DateLicense);
                p2[7] = new SqlParameter("@IssuedFrom", IssuedFrom);
                p2[8] = new SqlParameter("@TitleProject", TitleProject);
                p2[9] = new SqlParameter("@Department", Department);
                p2[10] = new SqlParameter("@City", City);
                p2[11] = new SqlParameter("@Governorate", Governorate);
                p2[12] = new SqlParameter("@BusinessStatement", BusinessStatement);
                p2[13] = new SqlParameter("@CostWord", CostWord);
                p2[14] = new SqlParameter("@CostLicense", CostLicense);
                p2[15] = new SqlParameter("@OtherData", OtherData);
                p2[16] = new SqlParameter("@EngEmail", EngEmail);
                p2[17] = new SqlParameter("@EngPhone", EngPhone);
                p2[18] = new SqlParameter("@EngMobile", EngMobile);
                p2[19] = new SqlParameter("@EngAdress", EngAdress);
                p2[20] = new SqlParameter("@OfficeAdress", OfficeAdress);
                p2[21] = new SqlParameter("@OfficePhone", OfficePhone);
                p2[22] = new SqlParameter("@OwnerAdrees", OwnerAdrees);
                p2[23] = new SqlParameter("@OwnerEmail", OwnerEmail);
                p2[24] = new SqlParameter("@OwnerPhone", OwnerPhone);
                p2[25] = new SqlParameter("@OwnerMobile", OwnerMobile);
                p2[26] = new SqlParameter("@UserID", UserID);
                p2[27] = new SqlParameter("@TaxCardEng", TaxCardEng);
                p2[28] = new SqlParameter("@TechnicalReport", TechnicalReport);
                p2[29] = new SqlParameter("@TechnicalReportNo", TechnicalReportNo);
                p2[30] = new SqlParameter("@HouseNumber", HouseNumber);
                p2[31] = new SqlParameter("@ConsultantEngineer", ConsultantEngineer);
                p2[32] = new SqlParameter("@ConsultantRegist", ConsultantRegist);
                p2[33] = new SqlParameter("@ConsultantDivaion", ConsultantDivaion);
                p2[34] = new SqlParameter("@ConsultantNo", ConsultantNo);
                p2[35] = new SqlParameter("@ConsultantSpecializt", ConsultantSpecializt);
                p2[36] = new SqlParameter("@ConsultantOfficeAddres", ConsultantOfficeAddres);
                p2[37] = new SqlParameter("@ConsultantOfficePhone", ConsultantOfficePhone);
                p2[38] = new SqlParameter("@RerfEmp", RerfEmp);
                p2[39] = new SqlParameter("@Manager", Manager);
                p2[40] = new SqlParameter("@GeneralManager", GeneralManager);
                p2[41] = new SqlParameter("@SerailNumber", SerailNumber);
                p2[42] = new SqlParameter("@GeneralEngnering", GeneralEngnering);
                p2[43] = new SqlParameter("@SN", SN);
                p2[44] = new SqlParameter("@DateForm", DateForm);
                cmd.Parameters.AddRange(p2);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("insert into Revenue_Tbl (Area,BisnecesCostArea,StampEng,StampPrevPaied,OrderPaied,SerailNumber,Fess,box,tax,OrderWord) values ('" + Area + "','" + BisnecesCostArea + "','" + StampEng + "','" + StampPrevPaied + "','" + OrderPaied + "','" + SerailNumber + "','" + Fess + "','" + box + "','" + tax + "','" + OrderWord + "')", con, transaction);
                cmd.ExecuteNonQuery();

                transaction.Commit();

                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public static DataGridView SH(string IDOwner, string RegistrationNo, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select(" SELECT  dbo.[Form_SH.H].IDForm, dbo.[Form_SH.H].Code, dbo.[Form_SH.H].CostForm, dbo.[Form_SH.H].TypeForm, dbo.[Form_SH.H].DateForm,  dbo.[Form_SH.H].NumberLicense, dbo.[Form_SH.H].DateLicense, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].TitleProject, dbo.[Form_SH.H].Department,   dbo.[Form_SH.H].City, dbo.[Form_SH.H].Governorate, dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].CostWord, dbo.[Form_SH.H].CostLicense,   dbo.[Form_SH.H].OtherData, dbo.[Form_SH.H].EngEmail, dbo.[Form_SH.H].EngPhone, dbo.[Form_SH.H].EngMobile, dbo.[Form_SH.H].EngAdress,  dbo.[Form_SH.H].OfficeAdress, dbo.[Form_SH.H].OfficePhone, dbo.[Form_SH.H].OwnerAdrees, dbo.[Form_SH.H].OwnerEmail, dbo.[Form_SH.H].OwnerPhone,   dbo.[Form_SH.H].OwnerMobile, dbo.[Form_SH.H].TaxCardEng, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo,  dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS [as Owner],   dbo.[Form_SH.H].RerfEmp, dbo.[Form_SH.H].Manager, dbo.[Form_SH.H].GeneralManager, dbo.Certificate_Tbl.imgForm FROM dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.H].TypeForm = dbo.Certificate_Tbl.IDCertificate  where     dbo.[Form_SH.H].State=1 and  dbo.[Form_SH.H].ISActive=1 and  dbo.[Form_SH.H].IDOwner='" + IDOwner + "' and dbo.EngBasicData_Tbl.RegistrationNo='" + RegistrationNo + "'");
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = dt;
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.HeaderText != "EngName" && col.HeaderText != "Name" && col.HeaderText != "DateForm")
                        {
                            col.Visible = false;
                        }
                    }

                    dgv.Columns["EngName"].HeaderText = "اسم المهندس";
                    dgv.Columns["Name"].HeaderText = "اسم المالك";
                    dgv.Columns["DateForm"].HeaderText = "تاريخ الشهادة";

                    DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
                    dgv.Columns.Add(lnk);
                    lnk.HeaderText = "طباعة";
                    lnk.Name = "طباعة";
                    lnk.Text = "طباعة";
                    lnk.UseColumnTextForLinkValue = true;

                    return dgv;
                }
                else
                {
                    dgv.DataSource = null;
                    dgv.Columns.Add("", "لاتوجد بيانات");
                    return dgv;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dgv.DataSource = null;
                return dgv;
            }
        }


        //     public static void Save(string Code, decimal CostForm, int TypeForm, Int64 IDEng, Int64 IDOwner, string NumberLicense,  DateTime DateLicense, string IssuedFrom, string TitleProject, string Department, string City,
        //string Governorate, string BusinessStatement, string CostWord, string CostLicense, string OtherData,
        //string EngEmail, string EngPhone,
        //string EngMobile, string EngAdress, string OfficeAdress, string OfficePhone, string OwnerAdrees, string OwnerEmail, string OwnerPhone, string OwnerMobile, Int32 UserID, string TaxCardEng, string TechnicalReport, string TechnicalReportNo)

        //     {

        //         //Run("insert into [Form_SH.D] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,YearLicense,DateLicense,TypeLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID ) values ('"+ Code + "','"+ CostForm + "','"+ TypeForm + "','"+ IDEng + "','"+ IDOwner + "','"+ NumberLicense + "','"+ YearLicense + "','"+ DateLicense + "','"+ TypeLicense + "','"+ IssuedFrom + "','"+ TitleProject + "','"+ Department + "','"+ City + "','"+ Governorate + "','"+ BusinessStatement + "','"+ CostWord + "','"+ CostLicense + "','" + OtherData + "','"+ EngEmail + "','"+ EngPhone + "','"+ EngMobile + "','"+ EngAdress + "','"+OfficeAdress+ "','"+OfficePhone+ "','"+OwnerAdrees+ "','" + OwnerEmail + "','" + OwnerPhone + "','" + OwnerMobile+"','"+UserID +"' )");


        //         //Open();

        //         try
        //         {
        //             cmd = new SqlCommand("insert into [Form_SH.H] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,DateLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID,TaxCardEng ,TechnicalReport,TechnicalReportNo) values (@Code,@CostForm,@TypeForm,@IDEng,@IDOwner,@NumberLicense,@DateLicense,@IssuedFrom,@TitleProject,@Department,@City,@Governorate,@BusinessStatement,@CostWord,@CostLicense,@OtherData,@EngEmail,@EngPhone,@EngMobile,@EngAdress,@OfficeAdress,@OfficePhone,@OwnerAdrees,@OwnerEmail,@OwnerPhone,@OwnerMobile,@UserID ,@TaxCardEng ,@TechnicalReport,@TechnicalReportNo)", con);
        //             SqlParameter[] p2 = new SqlParameter[30];

        //             p2[0] = new SqlParameter("@Code", Code);
        //             p2[1] = new SqlParameter("@CostForm", CostForm);
        //             p2[2] = new SqlParameter("@TypeForm", TypeForm);
        //             p2[3] = new SqlParameter("@IDEng", IDEng);
        //             p2[4] = new SqlParameter("@IDOwner", IDOwner);
        //             p2[5] = new SqlParameter("@NumberLicense", NumberLicense);
        //             p2[6] = new SqlParameter("@DateLicense", DateLicense);
        //             p2[7] = new SqlParameter("@IssuedFrom", IssuedFrom);
        //             p2[8] = new SqlParameter("@TitleProject", TitleProject);
        //             p2[9] = new SqlParameter("@Department", Department);
        //             p2[10] = new SqlParameter("@City", City);
        //             p2[11] = new SqlParameter("@Governorate", Governorate);
        //             p2[12] = new SqlParameter("@BusinessStatement", BusinessStatement);
        //             p2[13] = new SqlParameter("@CostWord", CostWord);
        //             p2[14] = new SqlParameter("@CostLicense", CostLicense);
        //             p2[15] = new SqlParameter("@OtherData", OtherData);
        //             p2[16] = new SqlParameter("@EngEmail", EngEmail);
        //             p2[17] = new SqlParameter("@EngPhone", EngPhone);
        //             p2[18] = new SqlParameter("@EngMobile", EngMobile);
        //             p2[19] = new SqlParameter("@EngAdress", EngAdress);
        //             p2[20] = new SqlParameter("@OfficeAdress", OfficeAdress);
        //             p2[21] = new SqlParameter("@OfficePhone", OfficePhone);
        //             p2[22] = new SqlParameter("@OwnerAdrees", OwnerAdrees);
        //             p2[23] = new SqlParameter("@OwnerEmail", OwnerEmail);
        //             p2[24] = new SqlParameter("@OwnerPhone", OwnerPhone);
        //             p2[25] = new SqlParameter("@OwnerMobile", OwnerMobile);
        //             p2[26] = new SqlParameter("@UserID", UserID);
        //             p2[27] = new SqlParameter("@TaxCardEng", TaxCardEng);
        //             p2[28] = new SqlParameter("@TechnicalReport", TechnicalReport);
        //             p2[29] = new SqlParameter("@TechnicalReportNo", TechnicalReportNo);

        //             cmd.Parameters.AddRange(p2);
        //             cmd.ExecuteNonQuery();
        //             PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
        //             frm.ShowDialog();
        //             //ID = Select("select max(IDForm) from [Form_SH.H]").Rows[0][0].ToString();
        //         }
        //         catch (Exception ex)
        //         {
        //             return;
        //         }

        //     }

        public static decimal Cost()
        {

            return Convert.ToDecimal(Select("SELECT  dbo.CostForm_Tble.Cost  FROM dbo.CostForm_Tble INNER JOIN  dbo.Certificate_Tbl ON dbo.CostForm_Tble.IDCertificate = dbo.Certificate_Tbl.IDCertificate  WHERE   (dbo.CostForm_Tble.IDCertificate = 4)").Rows[0][0].ToString());
        }

        public static void AutoCompletIssuedForm(TextBox txtBox)
        {
            //DataTable dtIssuedFrom = new DataTable();
            //dtIssuedFrom = DAL.ClassDAL.Select("");

            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  IssuedFrom from [Form_SH.H] where IssuedFrom!=''", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }

        public static void AutoCompletIssuedDepartment(TextBox txtBox)
        {

            SqlDataReader dr;
            cmd = new SqlCommand(" select distinct  Department from [Form_SH.H] where Department!=''", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }


        public static void AutoCompletIssuedCity(TextBox txtBox)
        {

            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  City from [Form_SH.H] where City!=''", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }

        public static void AutoCompletIssuedGovernorate(TextBox txtBox)
        {

            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  Governorate from [Form_SH.H] where Governorate!=''", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }

        public static void BussinesStatement(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  BusinessStatement from [Form_SH.H] where IssuedFrom!=''", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }


        public static DataTable searchToDelete(string code, string serailNumber)
        {
            DataTable dt = new DataTable();
            dt = DAL.ClassDAL.Select("  SELECT   dbo.[Form_SH.H].*, dbo.Revenue_Tbl.IDRevenue, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.NationalID,  dbo.EngBasicData_Tbl.TaxCardNo, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS Expr1, dbo.Revenue_Tbl.OrderWord, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied,  dbo.Revenue_Tbl.OrderPaied  FROM  dbo.[Form_SH.H] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Revenue_Tbl ON dbo.[Form_SH.H].SerailNumber = dbo.Revenue_Tbl.SerailNumber where (dbo.[Form_SH.H].State=1 and dbo.[Form_SH.H].ISActive=1) and(dbo.[Form_SH.H].Code='" + code + "'  or dbo.[Form_SH.H].SerailNumber='" + serailNumber + "')");
            return dt;
        }

        public static void Delete(string IDForm, string IDRev, string TypeForm, string IDEng, string IDOwner, string SerailNumber, string userID, string Resion)
        {
            RunTransaction("update [Form_SH.H] set State=0 where IDForm='" + IDForm + "'");
            RunTransaction("update [Revenue_Tbl] set state=0 where IDRevenue='" + IDRev + "'");
            RunTransaction("insert into DeleteForm (IDForm,TypeForm,IDEng,IDOwner,SerailNumber,IDRevenue,userID,Resion) values ('" + IDForm + "','" + TypeForm + "','" + IDEng + "','" + IDOwner + "','" + SerailNumber + "','" + IDRev + "','" + userID + "','" + Resion + "')");
            PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
            frm.ShowDialog();
        }




    }
}
