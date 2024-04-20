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
    class Cls_PrintForms:DAL.ClassDAL
    {
        ////public static DataTable dtSH_D(string RegistrationNo,string TypeForm,string OwnerName)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = Select("SELECT dbo.[Form_SH.D].Code, dbo.[Form_SH.D].CostForm, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.[Form_SH.D].TaxCardEng, dbo.[Form_SH.D].OfficeAdress, dbo.[Form_SH.D].OfficePhone, dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.NationalID AS OwnerID, dbo.[Form_SH.D].OwnerAdrees, dbo.[Form_SH.D].OwnerEmail, dbo.[Form_SH.D].OwnerPhone, dbo.[Form_SH.D].OwnerMobile, dbo.[Form_SH.D].EngAdress, dbo.[Form_SH.D].EngMobile, dbo.[Form_SH.D].EngPhone, dbo.[Form_SH.D].EngEmail, dbo.[Form_SH.D].DateForm, dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].DateLicense, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].TitleProject, dbo.[Form_SH.D].Department, dbo.[Form_SH.D].City, dbo.[Form_SH.D].Governorate, dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].CostWord, dbo.[Form_SH.D].CostLicense, dbo.[Form_SH.D].OtherData, dbo.Certificate_Tbl.Certificate FROM  dbo.[Form_SH.D] INNER JOIN  dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Certificate_Tbl ON dbo.[Form_SH.D].TypeForm = dbo.Certificate_Tbl.IDCertificate  where dbo.[Form_SH.D].ISActive=1 and dbo.[Form_SH.D].State=1 and dbo.EngBasicData_Tbl.RegistrationNo='"+RegistrationNo+ "' and dbo.[Form_SH.D].TypeForm='"+ TypeForm + "'and dbo.OwnerData_Tbl.Name='"+OwnerName+"'");
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return dt;
        //    }
        //}

        public static ComboBox FillComb(ComboBox cmbox)
        {
            DataTable dt = new DataTable();
            try
            {
                cmbox.DataSource = null;
                dt = Select("SELECT IDCertificate, Certificate FROM  dbo.Certificate_Tbl");
                cmbox.DisplayMember = dt.Columns["Certificate"].ToString();
                cmbox.ValueMember = dt.Columns["IDCertificate"].ToString();
                cmbox.DataSource = dt;

                return cmbox;
            }
            catch (Exception ex)
            {
                cmbox.DataSource = null;
                return cmbox;
            }
        }


         public static void SaveImgForm(byte[] imgForm, int IDCertificate)
        {
            cmd = new SqlCommand("update Certificate_Tbl set imgForm= @imgForm where IDCertificate=@IDCertificate", con);
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@imgForm", imgForm);
            p[1] = new SqlParameter("@IDCertificate", IDCertificate);
            cmd.Parameters.AddRange(p);
            cmd.ExecuteNonQuery();
            MessageBox.Show("sdfs");

        }
    }
}
