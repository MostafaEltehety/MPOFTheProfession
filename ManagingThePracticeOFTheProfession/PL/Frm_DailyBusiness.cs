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
    public partial class Frm_DailyBusiness : Form
    {
        DataTable table = new DataTable();
        DataTable tableDelete = new DataTable();
        DataTable tableTeqReport = new DataTable();


        public Frm_DailyBusiness()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("SerailNumber", typeof(string));
            table.Columns.Add("EngName", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("IssuedFrom", typeof(string));
            table.Columns.Add("BusinessStatement", typeof(string));
            table.Columns.Add("CostLicense", typeof(decimal));
            table.Columns.Add("date2Form", typeof(DateTime));
            table.Columns.Add("ReciptNo", typeof(string));
            table.Columns.Add("Fess", typeof(decimal));
            table.Columns.Add("box", typeof(decimal));
            table.Columns.Add("tax", typeof(decimal));
            table.Columns.Add("StampEng", typeof(decimal));
            table.Columns.Add("StampPrevPaied", typeof(decimal));
            table.Columns.Add("OrderPaied", typeof(decimal));
            table.Columns.Add("UserName", typeof(string));


            tableDelete = new DataTable();
            tableDelete.Columns.Add("SerialNumber", typeof(string));
            tableDelete.Columns.Add("Resion", typeof(string));
            tableDelete.Columns.Add("PostOffice", typeof(string));
            tableDelete.Columns.Add("dateCanceld", typeof(DateTime));
            tableDelete.Columns.Add("EngName", typeof(string));
            tableDelete.Columns.Add("Name", typeof(string));
            tableDelete.Columns.Add("IssuedFrom", typeof(string));
            tableDelete.Columns.Add("BusinessStatement", typeof(string));
            tableDelete.Columns.Add("UserName", typeof(string));
            tableDelete.Columns.Add("Fess", typeof(decimal));
            tableDelete.Columns.Add("box", typeof(decimal));
            tableDelete.Columns.Add("tax", typeof(decimal));
            tableDelete.Columns.Add("StampEng", typeof(decimal));
            tableDelete.Columns.Add("OrderPaied", typeof(decimal));
            tableDelete.Columns.Add("ReciptNo", typeof(string));



            tableTeqReport = new DataTable();
            tableTeqReport.Columns.Add("EngName", typeof(string));
            tableTeqReport.Columns.Add("Name", typeof(string));
            tableTeqReport.Columns.Add("IssuedFrom", typeof(string));
            tableTeqReport.Columns.Add("ReciptNo", typeof(string));
            tableTeqReport.Columns.Add("DatePaid", typeof(DateTime));
            tableTeqReport.Columns.Add("OrderPaied", typeof(decimal));
            tableTeqReport.Columns.Add("Fess", typeof(decimal));
            tableTeqReport.Columns.Add("box", typeof(decimal));
            tableTeqReport.Columns.Add("tax", typeof(decimal));




            #region COde
            //DataTable dtSH_D = new DataTable();
            //dtSH_D = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.D].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].CostLicense,   format(dbo.[Form_SH.D].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.D].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.D].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.D].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.D].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_D);

            //DataTable dtSH_D2 = new DataTable();
            //dtSH_D2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.D2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].CostLicense,   format(dbo.[Form_SH.D2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.D2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.D2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.D2].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.D2].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_D2);

            //DataTable dtSH_B = new DataTable();
            //dtSH_B = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.B].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostLicense,   format(dbo.[Form_SH.B].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.B].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.B] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.B].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.B].State=1) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.B].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_B);

            //DataTable dtSH_B2 = new DataTable();
            //dtSH_B2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.B2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostLicense,   format(dbo.[Form_SH.B2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.B2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.B2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.B2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.B2].State=1  ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.B2].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_B2);

            //DataTable dtSH_G = new DataTable();
            //dtSH_G = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.G].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].CostLicense,   format(dbo.[Form_SH.G].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.G].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.G].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.G].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.G].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.G].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_G);

            //DataTable dtSH_G2 = new DataTable();
            //dtSH_G2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.G2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].CostLicense,   format(dbo.[Form_SH.G2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.G2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.G2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.G2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.G2].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.G2].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_G2);

            //DataTable dtSH_W = new DataTable();
            //dtSH_W = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.W].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense,   format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.W].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.W].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.W].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.W].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.W].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_W);

            //DataTable dtSH_H = new DataTable();
            //dtSH_H = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.H].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].CostLicense,   format(dbo.[Form_SH.H].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.H].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.H].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.H].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.H].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.H].DateForm,'yyyy-MM-dd') between '" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and '" + dateSecnd.Value.ToString("yyyy-MM-dd") + "' order by date2Form");
            //AddToTable(dtSH_H);


            #endregion

            DataTable dtSH_D = new DataTable();
            dtSH_D = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.D].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].BusinessStatement, dbo.[Form_SH.D].CostLicense,   format(dbo.[Form_SH.D].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.D].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.D].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.D].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.D].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_D);

            DataTable dtSH_D2 = new DataTable();
            dtSH_D2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.D2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].BusinessStatement, dbo.[Form_SH.D2].CostLicense,   format(dbo.[Form_SH.D2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.D2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.D2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.D2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.D2].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.D2].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_D2);

            DataTable dtSH_B = new DataTable();
            dtSH_B = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.B].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].BusinessStatement, dbo.[Form_SH.B].CostLicense,   format(dbo.[Form_SH.B].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.B].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.B] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.B].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.B].State=1) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.B].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'"); 
            AddToTable(dtSH_B);

            DataTable dtSH_B2 = new DataTable();
            dtSH_B2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.B2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].BusinessStatement, dbo.[Form_SH.B2].CostLicense,   format(dbo.[Form_SH.B2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.B2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.B2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.B2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.B2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.B2].State=1  ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.B2].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_B2);

            DataTable dtSH_G = new DataTable();
            dtSH_G = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.G].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].BusinessStatement, dbo.[Form_SH.G].CostLicense,   format(dbo.[Form_SH.G].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.G].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.G].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.G].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.G].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.G].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_G);

            DataTable dtSH_G2 = new DataTable();
            dtSH_G2 = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.G2].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].BusinessStatement, dbo.[Form_SH.G2].CostLicense,   format(dbo.[Form_SH.G2].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.G2].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.G2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.G2].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.G2].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.G2].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_G2);

            DataTable dtSH_W = new DataTable();
            dtSH_W = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.W].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].BusinessStatement, dbo.[Form_SH.W].CostLicense,   format(dbo.[Form_SH.W].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.W].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.W].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.W].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.W].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.W].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_W);

            DataTable dtSH_H = new DataTable();
            dtSH_H = DAL.ClassDAL.Select("SELECT  dbo.[Form_SH.H].SerailNumber, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].BusinessStatement, dbo.[Form_SH.H].CostLicense,   format(dbo.[Form_SH.H].DateForm, 'yyyy-MM-dd') AS date2Form, dbo.[Form_SH.H].ReciptNo, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng,  dbo.Revenue_Tbl.StampPrevPaied, dbo.Revenue_Tbl.OrderPaied , dbo.Users_Tbl.UserName FROM  dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN  dbo.Users_Tbl ON dbo.[Form_SH.H].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.Revenue_Tbl ON dbo.[Form_SH.H].SerailNumber = dbo.Revenue_Tbl.SerailNumber	where(dbo.[Form_SH.H].State=1 ) and dbo.Revenue_Tbl.StampEng!=0 and  format( dbo.[Form_SH.H].DateForm,'yyyy-MM-dd') = '" + DateFirst.Value.ToString("yyyy-MM-dd") + "'");
            AddToTable(dtSH_H);




            #region Canceld
            DataTable dtCanceledSH_D = new DataTable();
            dtCanceledSH_D = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].IssuedFrom, dbo.[Form_SH.D].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied  , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.D] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.D].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_D);

            DataTable dtCanceledSH_D2 = new DataTable();
            dtCanceledSH_D2 = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D2].IssuedFrom, dbo.[Form_SH.D2].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo  FROM  dbo.Stope INNER JOIN dbo.[Form_SH.D2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.D2].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.D2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_D2);

            DataTable dtCanceledSH_B = new DataTable();
            dtCanceledSH_B = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B].IssuedFrom, dbo.[Form_SH.B].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.B] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.B].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_B);

            DataTable dtCanceledSH_B2 = new DataTable();
            dtCanceledSH_B2 = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B2].IssuedFrom, dbo.[Form_SH.B2].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.B2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.B2].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.B2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_B2);

            DataTable dtCanceledSH_G = new DataTable();
            dtCanceledSH_G = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G].IssuedFrom, dbo.[Form_SH.G].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.G] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.G].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_G);

            DataTable dtCanceledSH_G2 = new DataTable();
            dtCanceledSH_G2 = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G2].IssuedFrom, dbo.[Form_SH.G2].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.G2] ON dbo.Stope.SerialNumber = dbo.[Form_SH.G2].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.G2].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_G2);

            DataTable dtCanceledSH_W = new DataTable();
            dtCanceledSH_W = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.W].IssuedFrom, dbo.[Form_SH.W].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.W] ON dbo.Stope.SerialNumber = dbo.[Form_SH.W].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.W].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_W);

            DataTable dtCanceledSH_H = new DataTable();
            dtCanceledSH_H = DAL.ClassDAL.Select("SELECT  dbo.Stope.SerialNumber, dbo.Stope.Resion, dbo.Stope.PostOffice,format( dbo.Stope.Date,'yyyy-MM-dd') as dateCanceld, dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.H].IssuedFrom, dbo.[Form_SH.H].BusinessStatement,  dbo.Users_Tbl.UserName, dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax, dbo.Revenue_Tbl.StampEng, dbo.Revenue_Tbl.OrderPaied , dbo.Stope.ReciptNo FROM  dbo.Stope INNER JOIN dbo.[Form_SH.H] ON dbo.Stope.SerialNumber = dbo.[Form_SH.H].SerailNumber INNER JOIN dbo.Users_Tbl ON dbo.[Form_SH.H].UserID = dbo.Users_Tbl.UserID INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.Stope.SerialNumber = dbo.Revenue_Tbl.SerailNumber  where format( dbo.Stope.Date,'yyyy-MM-dd')='" + DateFirst.Value.ToString("yyyy-MM-dd") + "' and dbo.Revenue_Tbl.StampEng=0");
            AddToTableDelete(dtCanceledSH_H);
            #endregion

            #region TeqReport
            DataTable dtTqReport = new DataTable();
            dtTqReport = DAL.ClassDAL.Select("SELECT   dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.TechnicalReportCivilProtection.IssuedFrom, dbo.TechnicalReportCivilProtection.ReciptNo, dbo.Revenue_Tbl.DatePaid, dbo.Revenue_Tbl.OrderPaied,  dbo.Revenue_Tbl.Fess, dbo.Revenue_Tbl.box, dbo.Revenue_Tbl.tax FROM  dbo.TechnicalReportCivilProtection INNER JOIN dbo.EngBasicData_Tbl ON dbo.TechnicalReportCivilProtection.IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.TechnicalReportCivilProtection.IDOwner = dbo.OwnerData_Tbl.IDOwner INNER JOIN dbo.Revenue_Tbl ON dbo.TechnicalReportCivilProtection.IDTecReport = dbo.Revenue_Tbl.IDTecReport  where FORMAT(dbo.Revenue_Tbl.DatePaid,'yyyy-MM-dd')='"+DateFirst.Value.ToString("yyyy-MM-dd") +"'");
            AddToTableTeqReport(dtTqReport);
            #endregion

            

            Reports.CryDailyBusines3 cry = new Reports.CryDailyBusines3();
            cry.Subreports["CryForms.rpt"].SetDataSource(table);
            cry.Subreports["CryDailyBusinessStope.rpt"].SetDataSource(tableDelete);
            cry.Subreports["CryReportProdaction.rpt"].SetDataSource(tableTeqReport);

            cry.SetParameterValue("datep", DateFirst.Value.ToString("yyyy-MM-dd"), "CryForms.rpt");
            cry.SetParameterValue("datep", DateFirst.Value.ToString("yyyy-MM-dd"), "CryDailyBusinessStope.rpt");
            cry.SetParameterValue("datep", DateFirst.Value.ToString("yyyy-MM-dd"), "CryReportProdaction.rpt");
       
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = cry;
            //MessageBox.Show(table.Rows.Count.ToString());


        }


        void AddToTable(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                DataRow newRow = table.NewRow();
                newRow["SerailNumber"] = item["SerailNumber"].ToString();
                newRow["EngName"] = item["EngName"].ToString();
                newRow["Name"] = item["Name"].ToString();
                newRow["IssuedFrom"] = item["IssuedFrom"].ToString();
                newRow["BusinessStatement"] = item["BusinessStatement"].ToString();
                newRow["CostLicense"] = item["CostLicense"].ToString();
                newRow["date2Form"] = item["date2Form"].ToString();
                newRow["ReciptNo"] = item["ReciptNo"].ToString();
                newRow["Fess"] = item["Fess"].ToString();
                newRow["box"] = item["box"].ToString();
                newRow["tax"] = item["tax"].ToString();
                newRow["StampEng"] = item["StampEng"].ToString();
                newRow["StampPrevPaied"] = item["StampPrevPaied"].ToString();
                newRow["OrderPaied"] = item["OrderPaied"].ToString();
                newRow["UserName"] = item["UserName"].ToString();
                table.Rows.Add(newRow);
            }
        }


        void AddToTableDelete(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                DataRow newRow = tableDelete.NewRow();
                newRow["SerialNumber"] = item["SerialNumber"].ToString();
                newRow["Resion"] = item["Resion"].ToString();
                newRow["PostOffice"] = item["PostOffice"].ToString();
                newRow["dateCanceld"] = item["dateCanceld"].ToString();
                newRow["EngName"] = item["EngName"].ToString();
                newRow["Name"] = item["Name"].ToString();
                newRow["IssuedFrom"] = item["IssuedFrom"].ToString();
                newRow["BusinessStatement"] = item["BusinessStatement"].ToString();
                newRow["UserName"] = item["UserName"].ToString();
                newRow["Fess"] = item["Fess"].ToString();
                newRow["box"] = item["box"].ToString();
                newRow["tax"] = item["tax"].ToString();
                newRow["StampEng"] = item["StampEng"].ToString();
                newRow["OrderPaied"] = item["OrderPaied"].ToString();
                newRow["ReciptNo"] = item["ReciptNo"].ToString();

                tableDelete.Rows.Add(newRow);
            }
        }


        void AddToTableTeqReport(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                DataRow newRow = tableTeqReport.NewRow();
                newRow["EngName"] = item["EngName"].ToString();
                newRow["Name"] = item["Name"].ToString();
                newRow["IssuedFrom"] = item["IssuedFrom"].ToString();
                newRow["ReciptNo"] = item["ReciptNo"].ToString();
                newRow["DatePaid"] = item["DatePaid"].ToString();
                newRow["OrderPaied"] = item["OrderPaied"].ToString();
                newRow["Fess"] = item["Fess"].ToString();
                newRow["box"] = item["box"].ToString();
                newRow["tax"] = item["tax"].ToString();
                

                tableTeqReport.Rows.Add(newRow);
            }
        }

    }
}
