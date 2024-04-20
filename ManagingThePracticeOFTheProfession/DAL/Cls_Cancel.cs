using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_Cancel:DAL.ClassDAL
    {
        static SqlTransaction transaction;
        public static string tblname;
        public static DataTable getSearshData(string Serial ,string Code)
        {
            DataTable dt = new DataTable();
            try
            {
                DataTable dtB = new DataTable();
                dtB = Select(" SELECT  dbo.[Form_SH.B].IDForm, dbo.[Form_SH.B].SerailNumber, format( dbo.[Form_SH.B].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.B].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.B].BusinessStatement,  dbo.[Form_SH.B].TitleProject, dbo.[Form_SH.B].NumberLicense, format( dbo.[Form_SH.B].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].CostLicense FROM  dbo.[Form_SH.B] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1 and dbo.[Form_SH.B].State=1 and dbo.[Form_SH.B].Code ='" + Code + "' or dbo.[Form_SH.B].SerailNumber='" + Serial + "'");
                if (dtB.Rows.Count > 0)
                {
                    dt = dtB;
                   tblname = "Form_SH.B";
                    return dt;
                }
                DataTable dtB2 = new DataTable();
                dtB2 = Select(" SELECT  dbo.[Form_SH.B2].IDForm, dbo.[Form_SH.B2].SerailNumber, format( dbo.[Form_SH.B2].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.B2].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.B2].BusinessStatement,  dbo.[Form_SH.B2].TitleProject, dbo.[Form_SH.B2].NumberLicense, format( dbo.[Form_SH.B2].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].CostLicense FROM  dbo.[Form_SH.B2] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1 and dbo.[Form_SH.B2].State=1 and dbo.[Form_SH.B2].Code ='" + Code + "' or dbo.[Form_SH.B2].SerailNumber='" + Serial + "'");
                if (dtB2.Rows.Count > 0)
                {
                    dt = dtB2;
                    tblname = "Form_SH.B2";
                    return dt;
                }
                DataTable dtD = new DataTable();
                dtD = Select("  SELECT  dbo.[Form_SH.D].IDForm, dbo.[Form_SH.D].SerailNumber,format( dbo.[Form_SH.D].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.D].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.D].BusinessStatement,  dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].NumberLicense,format( dbo.[Form_SH.D].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].CostLicense FROM  dbo.[Form_SH.D] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where  ISActive=1 and dbo.[Form_SH.D].State=1  and dbo.[Form_SH.D].Code ='" + Code + "' or dbo.[Form_SH.D].SerailNumber='" + Serial + "'");
                 if (dtD.Rows.Count > 0)
                {
                    dt = dtD;
                    tblname = "Form_SH.D";
                    return dt;
                }
                DataTable dtD2 = new DataTable();
                dtD2 = Select("  SELECT  dbo.[Form_SH.D2].IDForm, dbo.[Form_SH.D2].SerailNumber,format( dbo.[Form_SH.D2].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.D2].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.D2].BusinessStatement,  dbo.[Form_SH.D2].TitleProject, dbo.[Form_SH.D2].NumberLicense,format( dbo.[Form_SH.D2].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].CostLicense FROM  dbo.[Form_SH.D2] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where  ISActive=1  and dbo.[Form_SH.D2].State=1 and dbo.[Form_SH.D2].Code ='" + Code + "' or dbo.[Form_SH.D2].SerailNumber='" + Serial + "'");
                if (dtD2.Rows.Count > 0)
                {
                    dt = dtD2;
                    tblname = "Form_SH.D2";
                    return dt;
                }
                DataTable dtG = new DataTable();
                dtG = Select(" SELECT  dbo.[Form_SH.G].IDForm, dbo.[Form_SH.G].SerailNumber,format( dbo.[Form_SH.G].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.G].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.G].BusinessStatement,  dbo.[Form_SH.G].TitleProject, dbo.[Form_SH.G].NumberLicense,format( dbo.[Form_SH.G].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].CostLicense FROM  dbo.[Form_SH.G] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1  and dbo.[Form_SH.G].State=1 and dbo.[Form_SH.G].Code ='" + Code + "' or dbo.[Form_SH.G].SerailNumber='" + Serial + "'");
                if (dtG.Rows.Count > 0)
                {
                    dt = dtG;
                    tblname = "Form_SH.G";
                    return dt;
                }
                DataTable dtG2 = new DataTable();
                dtG2 = Select(" SELECT  dbo.[Form_SH.G2].IDForm, dbo.[Form_SH.G2].SerailNumber,format( dbo.[Form_SH.G2].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.G2].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.G2].BusinessStatement,  dbo.[Form_SH.G2].TitleProject, dbo.[Form_SH.G2].NumberLicense,format( dbo.[Form_SH.G2].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].CostLicense FROM  dbo.[Form_SH.G2] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1 and dbo.[Form_SH.G2].State=1 and dbo.[Form_SH.G2].Code ='" + Code + "' or dbo.[Form_SH.G2].SerailNumber='" + Serial + "'");
                if (dtG2.Rows.Count > 0)
                {
                    dt = dtG2;
                    tblname = "Form_SH.G2";
                    return dt;
                }
                DataTable dtW = new DataTable();
                dtW = Select(" SELECT  dbo.[Form_SH.W].IDForm, dbo.[Form_SH.W].SerailNumber, format( dbo.[Form_SH.W].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.W].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.W].BusinessStatement,  dbo.[Form_SH.W].TitleProject, dbo.[Form_SH.W].NumberLicense,format( dbo.[Form_SH.W].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].CostLicense FROM  dbo.[Form_SH.W] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1 and dbo.[Form_SH.W].State=1 and dbo.[Form_SH.W].Code ='" + Code + "' or dbo.[Form_SH.W].SerailNumber='" + Serial + "'");
                if (dtW.Rows.Count > 0)
                {
                    dt = dtW;
                    tblname = "Form_SH.W";
                    return dt;
                }
                DataTable dtH = new DataTable();
                dtH = Select("  SELECT  dbo.[Form_SH.H].IDForm, dbo.[Form_SH.H].SerailNumber, format( dbo.[Form_SH.H].DateForm,'yyyy-MM-dd') as Date1, dbo.[Form_SH.H].Code, dbo.OwnerData_Tbl.Name, dbo.EngBasicData_Tbl.EngName, dbo.[Form_SH.H].BusinessStatement,  dbo.[Form_SH.H].TitleProject, dbo.[Form_SH.H].NumberLicense, format( dbo.[Form_SH.H].DateLicense,'yyyy-MM-dd') as Date2, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].CostLicense FROM  dbo.[Form_SH.H] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where ISActive=1 and dbo.[Form_SH.H].State=1 and dbo.[Form_SH.H].Code ='" + Code + "' or dbo.[Form_SH.H].SerailNumber='" + Serial + "'");
                if (dtH.Rows.Count > 0)
                {
                    dt = dtH;
                    tblname = "Form_SH.H";
                    return dt;
                }
            }
            catch  
            {
              
                return dt;
            }
            return dt;
        }

        public static void save(string  IDForm,string SerialNumber,int IDUSER,string Resion,string PostOffice,decimal OrderPaied,string tblNameEdite,string Code,string ReciptNo)
        {
            try
            {
                transaction = con.BeginTransaction();
                // insert into stope
                cmd = new SqlCommand("insert into Stope (SerialNumber,IDUSER,Resion,PostOffice,Code,ReciptNo) values ('" + SerialNumber+"','"+IDUSER+"','"+Resion+"','"+ PostOffice + "','"+ Code + "','"+ ReciptNo + "')", con, transaction);
          
                cmd.ExecuteNonQuery();
                // Update ISACTIVE
                if (tblNameEdite == "Form_SH.D") // D
                {
                    cmd = new SqlCommand("update  [Form_SH.D] set ISActive=0 where IDForm='"+IDForm+"'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.D2") // D2
                {
                    cmd = new SqlCommand("update  [Form_SH.D2] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.B")// B
                {
                    cmd = new SqlCommand("update  [Form_SH.B] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.B2")// B2
                {
                    cmd = new SqlCommand("update  [Form_SH.B2] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.G") // G
                {
                    cmd = new SqlCommand("update  [Form_SH.G] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.G2") // G2
                {
                    cmd = new SqlCommand("update  [Form_SH.G2] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite == "Form_SH.W") // W
                {
                    cmd = new SqlCommand("update  [Form_SH.W] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                if (tblNameEdite== "Form_SH.H") // H
                {
                    cmd = new SqlCommand("update  [Form_SH.H] set ISActive=0 where IDForm='" + IDForm + "'", con, transaction);
                    cmd.ExecuteNonQuery();
                }


                // Insert into Revenue
                if (OrderPaied==139)
                {
                    cmd = new SqlCommand("insert into Revenue_Tbl (Area,BisnecesCostArea,StampEng,StampPrevPaied,OrderPaied,SerailNumber,Fess,box,tax,OrderWord) values ('0','0','0','0','139','" + SerialNumber + "','100','25','14','فقط مائة وتسعة وثلاثون جنيهاً لاغير')", con, transaction);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("insert into Revenue_Tbl (Area,BisnecesCostArea,StampEng,StampPrevPaied,OrderPaied,SerailNumber,Fess,box,tax,OrderWord) values ('0','0','0','0','50','" + SerialNumber + "','0','50','0','فقط خمسون جنيهاً لاغير')", con, transaction);
                    cmd.ExecuteNonQuery();
                }
              

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

        public static DataTable searchInStope(string SerialNumber ,string Code)
        {
            try
            {     
            DataTable dt = new DataTable();
            dt = Select("SELECT  SerialNumber,Date FROM  dbo.Stope where (SerialNumber='" + SerialNumber + "') or (Code='"+ Code + "' and Code!='')");
                if (dt.Rows.Count==0)
                {
                    return dt;
                }
              //  dateCancelled = dt.Rows[0]["Date"].ToString();

                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public static void AutoCompletResion(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  Resion from [Stope] where Resion!=''", con);
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

        public static void AutoCompletPOstOffice(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  PostOffice from [Stope] where PostOffice!=''", con);
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

        public static DataTable PrintCanceld(string Serial, string Code)
        {
            DataTable dt = new DataTable();
            try
            {

                DataTable dtB = new DataTable();
                //dtB = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.D].EngPhone, dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].DateForm,  dbo.[Form_SH.D].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '"+Serial+ "') or dbo.[Form_SH.D].Code='"+Code+"' ");
                dtB = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.B].SerailNumber, dbo.[Form_SH.B].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B].NumberLicense, dbo.[Form_SH.B].DateLicense, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.B].EngPhone, dbo.[Form_SH.B].EngMobile, dbo.[Form_SH.B].EngAdress, dbo.[Form_SH.B].DateForm,  dbo.[Form_SH.B].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.B] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.B].Code='" + Code + "' ");

                if (dtB.Rows.Count > 0)
                {
                    // Print 
                    dt = dtB;
                    return dt;
                }
                DataTable dtB2 = new DataTable();
                dtB2 = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.B2].SerailNumber, dbo.[Form_SH.B2].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B2].NumberLicense, dbo.[Form_SH.B2].DateLicense, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.B2].EngPhone, dbo.[Form_SH.B2].EngMobile, dbo.[Form_SH.B2].EngAdress, dbo.[Form_SH.B2].DateForm,  dbo.[Form_SH.B2].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.B2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B2].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.B2].Code='" + Code + "' ");
                if (dtB2.Rows.Count > 0)
                {
                    dt = dtB2;
                    return dt;

                }
                DataTable dtD = new DataTable();
                dtD = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.D].EngPhone, dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].DateForm,  dbo.[Form_SH.D].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.D].Code='" + Code + "' ");
                if (dtD.Rows.Count > 0)
                {
                    dt = dtD;
                    return dt;
                }
                DataTable dtD2 = new DataTable();
                dtD2 = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.D2].SerailNumber, dbo.[Form_SH.D2].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D2].NumberLicense, dbo.[Form_SH.D2].DateLicense, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.D2].EngPhone, dbo.[Form_SH.D2].EngMobile, dbo.[Form_SH.D2].EngAdress, dbo.[Form_SH.D2].DateForm,  dbo.[Form_SH.D2].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.D2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D2].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.D2].Code='" + Code + "' ");
                if (dtD2.Rows.Count > 0)
                {
                    dt = dtD2;
                    return dt;

                }
                DataTable dtG = new DataTable();
                dtG = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.G].SerailNumber, dbo.[Form_SH.G].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G].NumberLicense, dbo.[Form_SH.G].DateLicense, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.G].EngPhone, dbo.[Form_SH.G].EngMobile, dbo.[Form_SH.G].EngAdress, dbo.[Form_SH.G].DateForm,  dbo.[Form_SH.G].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.G] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.G].Code='" + Code + "' ");
                if (dtG.Rows.Count > 0)
                {
                    dt = dtG;
                    return dt;

                }
                DataTable dtG2 = new DataTable();
                dtG2 = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.G2].SerailNumber, dbo.[Form_SH.G2].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G2].NumberLicense, dbo.[Form_SH.G2].DateLicense, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.G2].EngPhone, dbo.[Form_SH.G2].EngMobile, dbo.[Form_SH.G2].EngAdress, dbo.[Form_SH.G2].DateForm,  dbo.[Form_SH.G2].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.G2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G2].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.G2].Code='" + Code + "' ");

                if (dtG2.Rows.Count > 0)
                {
                    dt = dtG2;
                    return dt;

                }
                DataTable dtW = new DataTable();
                dtW = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.W].NumberLicense, dbo.[Form_SH.W].DateLicense, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.W].EngPhone, dbo.[Form_SH.W].EngMobile, dbo.[Form_SH.W].EngAdress, dbo.[Form_SH.W].DateForm,  dbo.[Form_SH.W].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.W].Code='" + Code + "' ");
                if (dtW.Rows.Count > 0)
                {
                    dt = dtW;
                    return dt;

                }
                DataTable dtH = new DataTable();
                dtH = Select(" SELECT dbo.Stope.IDStope, dbo.Certificate_Tbl.imgForm, dbo.Stope.Resion, dbo.Stope.PostOffice, dbo.Stope.Date, dbo.Users_Tbl.UserName, dbo.[Form_SH.H].SerailNumber, dbo.[Form_SH.H].BusinessStatement,  dbo.OwnerData_Tbl.Name, dbo.[Form_SH.H].NumberLicense, dbo.[Form_SH.H].DateLicense, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].OwnerAdrees, dbo.EngBasicData_Tbl.EngName,  dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngineeringRecordNo, dbo.[Form_SH.H].EngPhone, dbo.[Form_SH.H].EngMobile, dbo.[Form_SH.H].EngAdress, dbo.[Form_SH.H].DateForm,  dbo.[Form_SH.H].TitleProject, dbo.EngBasicData_Tbl.Division FROM   dbo.Certificate_Tbl INNER JOIN dbo.Stope ON dbo.Certificate_Tbl.IDCertificate = dbo.Stope.BackImage INNER JOIN  dbo.Users_Tbl ON dbo.Stope.IDUSER = dbo.Users_Tbl.UserID INNER JOIN dbo.[Form_SH.H] ON dbo.Stope.SerialNumber = dbo.[Form_SH.H].SerailNumber INNER JOIN  dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng WHERE(dbo.Stope.SerialNumber = '" + Serial + "') or dbo.[Form_SH.H].Code='" + Code + "' ");
                if (dtH.Rows.Count > 0)
                {
                    dt = dtH;
                    return dt;

                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dt = new DataTable();
                return dt;
               
            }
          
        }

    }
}
