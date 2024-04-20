using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_SH_G : DAL.ClassDAL
    {
        static SqlTransaction transaction;
        public static string ID = "";
        public static void Save(string Code, decimal CostForm, int TypeForm, Int64 IDEng, Int64 IDOwner, string NumberLicense, string YearLicense, DateTime DateLicense, string TypeLicense, string IssuedFrom, string TitleProject, string Department, string City,
           string Governorate, string BusinessStatement, string CostWord, string CostLicense, string OtherData,
           string EngEmail, string EngPhone,
           string EngMobile, string EngAdress, string OfficeAdress, string OfficePhone, string OwnerAdrees, string OwnerEmail, string OwnerPhone, string OwnerMobile, Int32 UserID, string TaxCardEng, string RerfEmp, string Manager, string GeneralManager, decimal Area, decimal BisnecesCostArea, decimal StampEng, decimal StampPrevPaied, decimal OrderPaied, string SerailNumber, decimal Fess, decimal box, decimal tax, string GeneralEngnering, Int64 SN, string OrderWord,DateTime DateForm, string ReciptNo, string OrderID)

        {

            //Run("insert into [Form_SH.D] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,YearLicense,DateLicense,TypeLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID ) values ('"+ Code + "','"+ CostForm + "','"+ TypeForm + "','"+ IDEng + "','"+ IDOwner + "','"+ NumberLicense + "','"+ YearLicense + "','"+ DateLicense + "','"+ TypeLicense + "','"+ IssuedFrom + "','"+ TitleProject + "','"+ Department + "','"+ City + "','"+ Governorate + "','"+ BusinessStatement + "','"+ CostWord + "','"+ CostLicense + "','" + OtherData + "','"+ EngEmail + "','"+ EngPhone + "','"+ EngMobile + "','"+ EngAdress + "','"+OfficeAdress+ "','"+OfficePhone+ "','"+OwnerAdrees+ "','" + OwnerEmail + "','" + OwnerPhone + "','" + OwnerMobile+"','"+UserID +"' )");


            //Open();

            try
            {
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("insert into [Form_SH.G] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,YearLicense,DateLicense,TypeLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID,TaxCardEng,RerfEmp,Manager,GeneralManager,SerailNumber,GeneralEngnering,SN,DateForm,ReciptNo,OrderID ) values (@Code,@CostForm,@TypeForm,@IDEng,@IDOwner,@NumberLicense,@YearLicense,@DateLicense,@TypeLicense,@IssuedFrom,@TitleProject,@Department,@City,@Governorate,@BusinessStatement,@CostWord,@CostLicense,@OtherData,@EngEmail,@EngPhone,@EngMobile,@EngAdress,@OfficeAdress,@OfficePhone,@OwnerAdrees,@OwnerEmail,@OwnerPhone,@OwnerMobile,@UserID ,@TaxCardEng, @RerfEmp, @Manager, @GeneralManager ,@SerailNumber,@GeneralEngnering,@SN,@DateForm,'" + ReciptNo + "','" + OrderID + "')", con,transaction);
                SqlParameter[] p2 = new SqlParameter[37];

                p2[0] = new SqlParameter("@Code", Code);
                p2[1] = new SqlParameter("@CostForm", CostForm);
                p2[2] = new SqlParameter("@TypeForm", TypeForm);
                p2[3] = new SqlParameter("@IDEng", IDEng);
                p2[4] = new SqlParameter("@IDOwner", IDOwner);
                p2[5] = new SqlParameter("@NumberLicense", NumberLicense);
                p2[6] = new SqlParameter("@YearLicense", YearLicense);
                p2[7] = new SqlParameter("@DateLicense", DateLicense);
                p2[8] = new SqlParameter("@TypeLicense", TypeLicense);
                p2[9] = new SqlParameter("@IssuedFrom", IssuedFrom);
                p2[10] = new SqlParameter("@TitleProject", TitleProject);
                p2[11] = new SqlParameter("@Department", Department);
                p2[12] = new SqlParameter("@City", City);
                p2[13] = new SqlParameter("@Governorate", Governorate);
                p2[14] = new SqlParameter("@BusinessStatement", BusinessStatement);
                p2[15] = new SqlParameter("@CostWord", CostWord);
                p2[16] = new SqlParameter("@CostLicense", CostLicense);
                p2[17] = new SqlParameter("@OtherData", OtherData);
                p2[18] = new SqlParameter("@EngEmail", EngEmail);
                p2[19] = new SqlParameter("@EngPhone", EngPhone);
                p2[20] = new SqlParameter("@EngMobile", EngMobile);
                p2[21] = new SqlParameter("@EngAdress", EngAdress);
                p2[22] = new SqlParameter("@OfficeAdress", OfficeAdress);
                p2[23] = new SqlParameter("@OfficePhone", OfficePhone);
                p2[24] = new SqlParameter("@OwnerAdrees", OwnerAdrees);
                p2[25] = new SqlParameter("@OwnerEmail", OwnerEmail);
                p2[26] = new SqlParameter("@OwnerPhone", OwnerPhone);
                p2[27] = new SqlParameter("@OwnerMobile", OwnerMobile);
                p2[28] = new SqlParameter("@UserID", UserID);
                p2[29] = new SqlParameter("@TaxCardEng", TaxCardEng);
                p2[30] = new SqlParameter("@RerfEmp", RerfEmp);
                p2[31] = new SqlParameter("@Manager", Manager);
                p2[32] = new SqlParameter("@GeneralManager", GeneralManager);
                p2[33] = new SqlParameter("@SerailNumber", SerailNumber);
                p2[34] = new SqlParameter("@GeneralEngnering", GeneralEngnering);
                p2[35] = new SqlParameter("@SN", SN);
                p2[36] = new SqlParameter("@DateForm", DateForm);
                cmd.Parameters.AddRange(p2);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("insert into Revenue_Tbl (Area,BisnecesCostArea,StampEng,StampPrevPaied,OrderPaied,SerailNumber,Fess,box,tax,OrderWord) values ('" + Area + "','" + BisnecesCostArea + "','" + StampEng + "','" + StampPrevPaied + "','" + OrderPaied + "','" + SerailNumber + "','" + Fess + "','" + box + "','" + tax + "','"+ OrderWord + "')", con, transaction);
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

        //public static DataTable SH()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        return dt = Select("SELECT dbo.[Form_SH.D].IDForm, dbo.[Form_SH.D].Code, dbo.[Form_SH.D].CostForm, dbo.[Form_SH.D].TypeForm, dbo.[Form_SH.D].DateForm,  dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].YearLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].TypeLicense, dbo.[Form_SH.D].IssuedFrom,  dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Department, dbo.[Form_SH.D].City, dbo.[Form_SH.D].Governorate, dbo.[Form_SH.D].BusinessStatement,  dbo.[Form_SH.D].CostWord, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].OtherData, dbo.[Form_SH.D].EngEmail, dbo.[Form_SH.D].EngPhone, dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].OfficeAdress, dbo.[Form_SH.D].OfficePhone, dbo.[Form_SH.D].OwnerAdrees,  dbo.[Form_SH.D].OwnerEmail, dbo.[Form_SH.D].OwnerPhone, dbo.[Form_SH.D].OwnerMobile, dbo.[Form_SH.D].TaxCardEng, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,  dbo.OwnerData_Tbl.NationalID  AS [as Owner]  FROM  dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner  where IDForm ='" + ID + "'");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return dt;
        //    }
        //}

        public static decimal Cost()
        {

            return Convert.ToDecimal(Select("SELECT  dbo.CostForm_Tble.Cost  FROM dbo.CostForm_Tble INNER JOIN  dbo.Certificate_Tbl ON dbo.CostForm_Tble.IDCertificate = dbo.Certificate_Tbl.IDCertificate  WHERE   (dbo.CostForm_Tble.IDCertificate = 3)").Rows[0][0].ToString());
        }

        public static DataGridView SH(string IDOwner, string RegistrationNo, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("SELECT  dbo.[Form_SH.G].IDForm, dbo.[Form_SH.G].Code, dbo.[Form_SH.G].CostForm, dbo.[Form_SH.G].TypeForm, dbo.[Form_SH.G].DateForm,  dbo.[Form_SH.G].NumberLicense, dbo.[Form_SH.G].YearLicense, dbo.[Form_SH.G].DateLicense, dbo.[Form_SH.G].TypeLicense, dbo.[Form_SH.G].IssuedFrom,   dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].Department, dbo.[Form_SH.G].City, dbo.[Form_SH.G].Governorate, dbo.[Form_SH.G].BusinessStatement,  dbo.[Form_SH.G].CostWord, dbo.[Form_SH.G].CostLicense, dbo.[Form_SH.G].OtherData, dbo.[Form_SH.G].EngEmail, dbo.[Form_SH.G].EngPhone,  dbo.[Form_SH.G].EngMobile, dbo.[Form_SH.G].EngAdress, dbo.[Form_SH.G].OfficeAdress, dbo.[Form_SH.G].OfficePhone, dbo.[Form_SH.G].OwnerAdrees,   dbo.[Form_SH.G].OwnerEmail, dbo.[Form_SH.G].OwnerPhone, dbo.[Form_SH.G].OwnerMobile, dbo.[Form_SH.G].TaxCardEng, dbo.EngBasicData_Tbl.EngName,   dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.OwnerData_Tbl.Name,    dbo.OwnerData_Tbl.NationalID AS [as Owner], dbo.[Form_SH.G].RerfEmp, dbo.[Form_SH.G].Manager, dbo.[Form_SH.G].GeneralManager,   dbo.Certificate_Tbl.imgForm  FROM dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.G].TypeForm = dbo.Certificate_Tbl.IDCertificate  where     dbo.[Form_SH.G].State=1 and  dbo.[Form_SH.G].ISActive=1 and  dbo.[Form_SH.G].IDOwner='" + IDOwner + "' and dbo.EngBasicData_Tbl.RegistrationNo='" + RegistrationNo + "'");
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


        public static void AutoCompletIssuedForm(TextBox txtBox)
        {
            //DataTable dtIssuedFrom = new DataTable();
            //dtIssuedFrom = DAL.ClassDAL.Select("");

            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  IssuedFrom from [Form_SH.G] where IssuedFrom!=''", con);
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
            cmd = new SqlCommand(" select distinct  Department from [Form_SH.G] where Department!=''", con);
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
            cmd = new SqlCommand("select distinct  City from [Form_SH.G] where City!=''", con);
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
            cmd = new SqlCommand("select distinct  Governorate from [Form_SH.G] where Governorate!=''", con);
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
            cmd = new SqlCommand("select distinct  BusinessStatement from [Form_SH.G] where BusinessStatement!=''", con);
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
            dt = DAL.ClassDAL.Select("  SELECT   dbo.[Form_SH.G].*, dbo.Revenue_Tbl.IDRevenue, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.EngBasicData_Tbl.NationalID,  dbo.EngBasicData_Tbl.TaxCardNo, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS Expr1, dbo.Revenue_Tbl.OrderWord, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.StampPrevPaied,  dbo.Revenue_Tbl.OrderPaied  FROM  dbo.[Form_SH.G] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Revenue_Tbl ON dbo.[Form_SH.G].SerailNumber = dbo.Revenue_Tbl.SerailNumber where (dbo.[Form_SH.G].State=1 and dbo.[Form_SH.G].ISActive=1) and(dbo.[Form_SH.G].Code='" + code + "'  or dbo.[Form_SH.G].SerailNumber='" + serailNumber + "')");
            return dt;
        }

        public static void Delete(string IDForm, string IDRev, string TypeForm, string IDEng, string IDOwner, string SerailNumber, string userID, string Resion)
        {
            RunTransaction("update [Form_SH.G] set State=0 where IDForm='" + IDForm + "'");
            RunTransaction("update [Revenue_Tbl] set state=0 where IDRevenue='" + IDRev + "'");
            RunTransaction("insert into DeleteForm (IDForm,TypeForm,IDEng,IDOwner,SerailNumber,IDRevenue,userID,Resion) values ('" + IDForm + "','" + TypeForm + "','" + IDEng + "','" + IDOwner + "','" + SerailNumber + "','" + IDRev + "','" + userID + "','" + Resion + "')");
            PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
            frm.ShowDialog();
        }



    }
}
