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


    class Clss_Owners :DAL.ClassDAL
    {
        static SqlTransaction transaction;

        public static void Save(DataGridView dgv,string name , string NationalID)
        {
            try
            {
                Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("insert into OwnerData_Tbl (Name,NationalID,UserID) values('" + name + "', '" + NationalID + "','"+ DAL.ClassDAL.IDUser + "')",con,transaction);
                cmd.ExecuteNonQuery();
                //RunTransaction("insert into OwnerData_Tbl (Name,NationalID) values('" + name + "', '" + NationalID + "')");
                // Get IDOwner To insert ContactData
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select max(IDOwner) from [dbo].[OwnerData_Tbl] ", con, transaction);
                dt.Load(cmd.ExecuteReader());
                Int64 id = Convert.ToInt64(dt.Rows[0][0].ToString());

                // Insert into ContactOwnerData
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    cmd = new SqlCommand("insert into ContactOwners_Tbl (Phone,Mobile,Email,Address,IDOwner,UserID) values (@Phone, @Mobile, @Email, @Address, @IDOwner,'"+DAL.ClassDAL.IDUser+"')", con, transaction);
                    SqlParameter[] p2 = new SqlParameter[5];
                    p2[0] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                    p2[1] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                    p2[2] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                    p2[3] = new SqlParameter("@Address", item.Cells[4].Value.ToString());
                    p2[4] = new SqlParameter("@IDOwner", id);

                    cmd.Parameters.AddRange(p2);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();

                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.Show();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }

            Close();

        }

        public static void Update   (DataGridView dgv, string name, string NationalID,Int64 IDOwner )
        {
            try
            {
                Open();
                transaction = con.BeginTransaction();
                cmd = new SqlCommand("update  OwnerData_Tbl  set Name= '" + name + "',NationalID= '" + NationalID + "' where   IDOwner= '" + IDOwner + "'", con, transaction);
                cmd.ExecuteNonQuery();
         
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells[0].Value.ToString() == "")
                    {
                        cmd = new SqlCommand("insert into ContactOwners_Tbl (Phone,Mobile,Email,Address,IDOwner,UserID) values (@Phone, @Mobile, @Email, @Address, @IDOwner,'" + DAL.ClassDAL.IDUser + "')", con, transaction);
                        SqlParameter[] p2 = new SqlParameter[5];
                        p2[0] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                        p2[1] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                        p2[2] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@Address", item.Cells[4].Value.ToString());
                        p2[4] = new SqlParameter("@IDOwner", IDOwner);

                        cmd.Parameters.AddRange(p2);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("update  ContactOwners_Tbl  set Phone=@Phone ,Mobile=@Mobile ,Email=@Email ,Address=@Address  where  IDContactOwners ='" + item.Cells[0].Value.ToString() + "'  ", con, transaction);
                        SqlParameter[] p2 = new SqlParameter[4];
                        p2[0] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                        p2[1] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                        p2[2] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@Address", item.Cells[4].Value.ToString());


                        cmd.Parameters.AddRange(p2);
                        cmd.ExecuteNonQuery();
                    }

                   

                   

                }
                transaction.Commit();
                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.Show();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }

            Close();

        }



        public static DataTable LoadName( ComboBox cmb)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("SELECT IDOwner, Name  FROM   dbo.OwnerData_Tbl where state=1 ");
                cmb.DataSource = dt;
                cmb.ValueMember = dt.Columns["IDOwner"].ToString();
                cmb.DisplayMember = dt.Columns["Name"].ToString();
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static void AutoCompletName(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [Name] FROM OwnerData_Tbl where state=1", con);
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

        public static DataTable CheckData(string Name,string NationalID)
        {
            DataTable dt = new DataTable();
            dt = Select("select Name,NationalID from  OwnerData_Tbl  where  (state=1)and ( Name='" + Name+ "' or NationalID='"+ NationalID + "' and NationalID !='')");
            return dt;
        }

        public static DataTable CheckDataToEdit(string Name, string NationalID,Int64 IDOwner)
        {
            DataTable dt = new DataTable();
            dt = Select("select Name,NationalID from  OwnerData_Tbl  where (state=1)and  ( Name='" + Name + "' or NationalID='" + NationalID + "' )    and IDOwner!='" + IDOwner + "'  and NationalID !=''");
            return dt;
        }

        public static void SearchBYNationalID(string NationalID,Label ID,TextBox Name)
        {
            DataTable dt = new DataTable();
            dt= Select("SELECT NationalID, Name, IDOwner FROM  dbo.OwnerData_Tbl where NationalID='" + NationalID + "'");
            if (dt.Rows.Count>0)
            {
                ID.Text = dt.Rows[0]["IDOwner"].ToString();
                Name.Text = dt.Rows[0]["Name"].ToString();
            }
            else
            {
                PL.Frm_Owners frm = new PL.Frm_Owners();
                frm.ShowDialog();
                dt = Select("SELECT NationalID, Name, IDOwner FROM  dbo.OwnerData_Tbl where NationalID='" + NationalID + "'");
                if (dt.Rows.Count > 0)
                {
                    ID.Text = dt.Rows[0]["IDOwner"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                }
            }
          
        }
        public static void SearchBYNationalName(TextBox NationalID,Label ID,TextBox Name)
        {
            DataTable dt = new DataTable();
            dt= Select("SELECT NationalID, Name, IDOwner FROM  dbo.OwnerData_Tbl where Name='" + Name.Text + "'");
            if (dt.Rows.Count>0)
            {
                ID.Text = dt.Rows[0]["IDOwner"].ToString();
                Name.Text = dt.Rows[0]["Name"].ToString();
                NationalID.Text= dt.Rows[0]["NationalID"].ToString();
            }
            else
            {
                PL.Frm_Owners frm = new PL.Frm_Owners(Name.Text);
                frm.ShowDialog();
                dt = Select("SELECT NationalID, Name, IDOwner FROM  dbo.OwnerData_Tbl where  Name='" + Name.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    ID.Text = dt.Rows[0]["IDOwner"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    NationalID.Text = dt.Rows[0]["NationalID"].ToString();

                }
            }
          
        }

        public static DataTable FillCombox( string IDOwner)
        {
            DataTable dt = new DataTable();
           return dt = Select("SELECT  dbo.ContactOwners_Tbl.Phone, dbo.ContactOwners_Tbl.Mobile, dbo.ContactOwners_Tbl.Email, dbo.ContactOwners_Tbl.Address, dbo.ContactOwners_Tbl.IDContactOwners FROM dbo.OwnerData_Tbl INNER JOIN dbo.ContactOwners_Tbl ON dbo.OwnerData_Tbl.IDOwner = dbo.ContactOwners_Tbl.IDOwner where dbo.ContactOwners_Tbl.IDOwner='"+IDOwner+"' and dbo.ContactOwners_Tbl.state=1");
            
        }

        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_D(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.D] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.D].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.D].TypeForm='" + IDForm + "' and dbo.[Form_SH.D].ISActive=1 and dbo.[Form_SH.D].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }
        }

        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_D2(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.D2] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.D2].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.D2].TypeForm='" + IDForm + "' and dbo.[Form_SH.D2].ISActive=1 and dbo.[Form_SH.D2].State=1 ");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }
        }


        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_G(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.G] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.G].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.G].TypeForm='" + IDForm + "' and dbo.[Form_SH.G].ISActive=1 and dbo.[Form_SH.G].State=1 ");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }

        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_G2(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.G2] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.G2].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.G2].TypeForm='" + IDForm + "' and dbo.[Form_SH.G2].ISActive=1 and dbo.[Form_SH.G2].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }


        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_B(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.B] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.B].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.B].TypeForm='" + IDForm + "' and dbo.[Form_SH.B].ISActive=1 and dbo.[Form_SH.B].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }




        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_B2(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.B2] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.B2].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.B2].TypeForm='" + IDForm + "' and dbo.[Form_SH.B2].ISActive=1 and dbo.[Form_SH.B2].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }
        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_W(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.W] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.W].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.W].TypeForm='" + IDForm + "' and dbo.[Form_SH.W].ISActive=1 and dbo.[Form_SH.W].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }

        public static ComboBox FillComboxOwnersNameByRegistrationEngSH_H(ComboBox combox, string ResgitrationNo, string IDForm)
        {
            combox.DataSource = null;
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT distinct dbo.OwnerData_Tbl.Name, dbo.OwnerData_Tbl.IDOwner  FROM  dbo.OwnerData_Tbl INNER JOIN  dbo.[Form_SH.H] ON dbo.OwnerData_Tbl.IDOwner = dbo.[Form_SH.H].IDOwner INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng where  dbo.EngBasicData_Tbl.RegistrationNo='" + ResgitrationNo + "' and dbo.[Form_SH.H].TypeForm='" + IDForm + "' and dbo.[Form_SH.H].ISActive=1 and dbo.[Form_SH.H].State=1");
                combox.DataSource = dt;
                combox.DisplayMember = dt.Columns["Name"].ToString();
                combox.ValueMember = dt.Columns["IDOwner"].ToString();
                return combox;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return combox;
            }

        }

        public static DataTable GetContactData(Int64 IDOwner)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DAL.ClassDAL.Select("SELECT  IDContactOwners,Phone,Mobile,Email,Address FROM   dbo.ContactOwners_Tbl where IDOwner='" + IDOwner + "' and state=1");

            }
            catch
            {
                return dt;
            }
            return dt;
        }

    }
}
