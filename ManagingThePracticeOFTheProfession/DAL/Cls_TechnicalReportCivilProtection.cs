using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_TechnicalReportCivilProtection:DAL.ClassDAL
    {

        static SqlTransaction transaction;

        public static void Save(Int64 IDEng , Int64 IDOwner ,string  BusinessStatement  , string AdressBuStatement , string IssuedFrom ,string  Governorate ,Int64  OrderID ,string  ReciptNo ,string OrderPaied ,string Fess,string box ,string tax,string OrderWord ,bool state ) 
        {
            try
            {

            transaction = con.BeginTransaction();
            cmd = new SqlCommand("INSERT INTO [dbo].[TechnicalReportCivilProtection] ([IDEng],[IDOwner],[BusinessStatement] ,[AdressBuStatement],[IssuedFrom],[Governorate],[OrderID],[ReciptNo],IDUser) values ('" + IDEng + "' ,  '" + IDOwner + "' ,  '" + BusinessStatement + "'  ,  '" + AdressBuStatement + "' ,  '" + IssuedFrom + "' ,  '" + Governorate + "' ,  '" + OrderID + "' ,  '" + ReciptNo + "','"+DAL.ClassDAL.IDUser+"')",con,transaction);
            cmd.ExecuteNonQuery();


            cmd = new SqlCommand("select max(IDTecReport) from  [dbo].[TechnicalReportCivilProtection]", con,transaction);
            string id= cmd.ExecuteScalar().ToString();

            cmd = new SqlCommand("INSERT INTO [dbo].[Revenue_Tbl] ([OrderPaied],[Fess],[box] ,[tax],[OrderWord],[state],[IDTecReport]) values ('"+ OrderPaied + "','"+ Fess + "','"+ box + "' ,'"+ tax + "','"+ OrderWord + "','"+ state + "','"+ id + "' )", con, transaction);
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
    }
}
