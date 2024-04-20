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
    class Cls_AllowedNumber:DAL.ClassDAL
    {
        public static ComboBox FillTypesForm(ComboBox combox)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("select IDType,Type from TypeCerticate_Tbl");
                combox.DataSource = null;
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Type"].ToString();
                combox.ValueMember = dt.Columns["IDType"].ToString();
                return combox;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                 combox.DataSource = null;
                return combox;
            }

        }
    }
}
