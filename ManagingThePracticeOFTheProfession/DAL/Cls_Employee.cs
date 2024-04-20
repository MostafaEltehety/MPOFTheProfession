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
    class Cls_Employee : DAL.ClassDAL
    {
        public static DataGridView dgv(DataGridView dg)
        {
            try
            {
                dg.DataSource = null;
                DataTable dt = new DataTable();
                dt = Select("select IDEmp,EmployeeName,EmployeeJob,Active  from Employee_Tbl  ");
                dg.DataSource = dt;
                dg.Columns["IDEmp"].Visible = false;
                dg.Columns["EmployeeName"].HeaderText = "الاسم";
                dg.Columns["EmployeeJob"].HeaderText = "الوظيفة";
                dg.Columns["Active"].HeaderText = "الحالة";
                return dg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dg.DataSource = null;
                return dg;
            }
        }


        public static void Save(string EmployeeName,string EmployeeJob,string Active)
        {
            try
            {
                Run("insert into Employee_Tbl (EmployeeName,EmployeeJob,Active) values ('"+ EmployeeName + "', '"+ EmployeeJob + "', '"+ Active + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void Edit(string EmployeeName, string EmployeeJob, string Active,int ID )
        {
            try
            {
                Run("update Employee_Tbl  set EmployeeName ='" + EmployeeName + "' ,EmployeeJob=  '" + EmployeeJob + "', Active= '" + Active + "' where   [IDEmp] ='"+ID+"'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


    }
}
