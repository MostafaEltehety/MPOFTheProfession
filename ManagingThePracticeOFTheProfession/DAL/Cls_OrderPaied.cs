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
    class Cls_OrderPaied : DAL.ClassDAL
    {
        public static void Save(Int64 IDEng, Int64 IDOwner,string NameOwner,string Adres,string Phone,string Mobile,string Email,string NationalID,string TitleProject,string BusinesStatement,decimal CostProject,string TypeForm,string CostProjectWord,decimal OrderPayed,string OrderPayedWord,string RefEmp,decimal Fess,decimal box,decimal tax,decimal StampEng, decimal StampPrevPaied,string IDOfficeCons,string IssuedFrom,string Resion, string  PostOffice,string Payed,string SerailNumberForm)
        {
            try
            {
                DAL.ClassDAL.RunTransaction("insert into Tbl_OrderPaid (IDEng,IDOwner,NameOwner,Adres,Phone,Mobile,Email,NationalID,TitleProject,BusinesStatement,CostProject,TypeForm,CostProjectWord,OrderPayed,OrderPayedWord,RefEmp,Fess,box,tax,IDUser,StampEng,StampPrevPaied,IDOfficeCons,IssuedFrom,Resion,PostOffice,Payed,SerailNumberForm) values ('" + IDEng + "','" + IDOwner + "','" + NameOwner + "','" + Adres + "','" + Phone + "','" + Mobile + "','" + Email + "','" + NationalID + "','" + TitleProject + "','" + BusinesStatement + "','" + CostProject + "','" + TypeForm + "','" + CostProjectWord + "','" + OrderPayed + "','" + OrderPayedWord + "','" + RefEmp + "','" + Fess + "','" + box + "','" + tax + "','"+DAL.ClassDAL.IDUser+"','"+StampEng+"','"+StampPrevPaied+"','"+ IDOfficeCons + "','"+ IssuedFrom + "','"+ Resion+ "','"+ PostOffice + "','"+ Payed + "','"+ SerailNumberForm + "') ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void Save(Int64 IDEng, Int64 IDOwner, string NameOwner, string TitleProject, string BusinesStatement, string TypeForm,decimal OrderPayed, string OrderPayedWord, string RefEmp, decimal Fess, decimal box, decimal tax,int IDUser, string IssuedFrom,string Governator)
        {
            try
            {
                DAL.ClassDAL.RunTransaction("insert into Tbl_OrderPaid (IDEng,IDOwner,NameOwner,TitleProject,BusinesStatement,TypeForm,OrderPayed,OrderPayedWord,RefEmp,Fess,box,tax,IDUser,IssuedFrom,Governator) values ('" + IDEng + "','"+ IDOwner + "','"+ NameOwner + "','"+ TitleProject + "','"+ BusinesStatement + "','"+ TypeForm + "','"+ OrderPayed + "','"+OrderPayedWord+"','"+ RefEmp + "','"+ Fess + "','"+ box + "','"+ tax + "','"+DAL.ClassDAL.IDUser+"','"+ IssuedFrom + "','"+ Governator + "') ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        public static void AutoCompletIssuedForm(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  [IssuedFrom] from [dbo].[Tbl_OrderPaid] where [IssuedFrom]!=''", con);
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

        public static void AutoCompletGovernator(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct  [Governator] from [dbo].[Tbl_OrderPaid] where [Governator]!=''", con);
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
        public static void AutoCompletBusinesStatement(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("select distinct [BusinesStatement] from [dbo].[Tbl_OrderPaid] where [BusinesStatement]!=''", con);
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


    }
}
