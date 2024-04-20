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
    class Cls_EngineersData:DAL.ClassDAL
    {
        static SqlTransaction transaction;

        public static void Save(DataGridView dgv ,string  EngName,string RegistrationNo,string Division,DateTime GraduationYear,string Syndicate,string Qualification,string University,string NationalID,string ConsultantNo,string Gender,string Notes, byte[] Image ,string EngineeringRecordNo,string Specialization,string TaxCardNo,string IDOfficeCons)
        {
            try
            {
                Open();
                transaction = con.BeginTransaction();

                cmd = new SqlCommand("insert into EngBasicData_Tbl (EngName,RegistrationNo,Division,GraduationYear,Syndicate,Qualification,University,NationalID,ConsultantNo,Gender,Notes,Image,EngineeringRecordNo,UserID,Specialization,TaxCardNo,IDOfficeCons) values (@EngName, @RegistrationNo, @Division, @GraduationYear, @Syndicate, @Qualification, @University, @NationalID, @ConsultantNo, @Gender, @Notes, @Image,@EngineeringRecordNo,'" + DAL.ClassDAL.IDUser+ "',@Specialization,@TaxCardNo,'"+ IDOfficeCons + "') ", con, transaction);
                SqlParameter[] p = new SqlParameter[15];
                p[0] = new SqlParameter("@EngName", EngName);
                p[1] = new SqlParameter("@RegistrationNo", RegistrationNo);
                p[2] = new SqlParameter("@Division", Division);
                p[3] = new SqlParameter("@GraduationYear", GraduationYear);
                p[4] = new SqlParameter("@Syndicate", Syndicate);
                p[5] = new SqlParameter("@Qualification", Qualification);
                p[6] = new SqlParameter("@University", University);
                p[7] = new SqlParameter("@NationalID", NationalID);
                p[8] = new SqlParameter("@ConsultantNo", ConsultantNo);
                p[9] = new SqlParameter("@Gender", Gender);
                p[10] = new SqlParameter("@Notes", Notes);
                p[11] = new SqlParameter("@Image", Image);
                p[12] = new SqlParameter("@EngineeringRecordNo", EngineeringRecordNo);
                p[13] = new SqlParameter("@Specialization", Specialization);
                p[14] = new SqlParameter("@TaxCardNo", TaxCardNo);

                cmd.Parameters.AddRange(p);
                cmd.ExecuteNonQuery();

                // Insert Doc

                cmd = new SqlCommand("INSERT INTO [dbo].[Documant_Tbl] ([image], [Descri],[IDEng]) SELECT[image], Descri,[IDEng] FROM VariableDoc_Tbl", con,transaction);
                cmd.ExecuteNonQuery();

                // GetID ENG to insert ContactData
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select max(IDEng) from [dbo].[EngBasicData_Tbl] ", con, transaction);
                dt.Load(cmd.ExecuteReader());

                Int64 id = Convert.ToInt64(dt.Rows[0][0].ToString());

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    cmd = new SqlCommand(" insert into Contact_Tbl (IDEng,Address,Phone,Email,Mobile,FaceBook,UserID) values ( @IDEng, @Address, @Phone, @Email, @Mobile, @FaceBook,'"+DAL.ClassDAL.IDUser+"')  ", con, transaction);
                    SqlParameter[] p2 = new SqlParameter[6];
                    p2[0] = new SqlParameter("@IDEng", id);
                    p2[1] = new SqlParameter("@Address", item.Cells[5].Value.ToString());
                    p2[2] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                    p2[3] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                    p2[4] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                    p2[5] = new SqlParameter("@FaceBook", item.Cells[4].Value.ToString());

                    cmd.Parameters.AddRange(p2);
                    cmd.ExecuteNonQuery();
                }
       

                // Delete VirableDoc and RESEED
                cmd = new SqlCommand("delete from VariableDoc_Tbl", con, transaction);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DBCC CHECKIDENT (VariableDoc_Tbl, RESEED, 0)",con,transaction);
                cmd.ExecuteNonQuery();

           
                transaction.Commit();

        }
            catch (Exception ex)
            {
                Close();
                MessageBox.Show(ex.Message);
                transaction.Rollback();
                return;
            }
            Close();
            PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
            frm.Show();

        }


        public static DataTable SearchByRegistrationNo(string RegistrationSearch)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where RegistrationNo ='"+RegistrationSearch+ "' and [state]=1");                
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }
        public static DataTable SearchByRegistrationNoToEdit(string RegistrationSearch,Int64 IDEng)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where RegistrationNo ='" + RegistrationSearch + "'  and IDEng!='" + IDEng + "' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }

        public static DataTable SearchByNationalID(string NationalIDSearch)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where NationalID ='" + NationalIDSearch + "' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }

        public static DataTable SearchByNationalIDToEdit(string NationalIDSearch ,Int64 IDEng)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where NationalID ='" + NationalIDSearch + "' and IDEng!='" + IDEng + "'  and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }

        public static DataTable SearchByName(string NameSearch)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where [EngName] ='" + NameSearch + "' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }
        public static DataTable SearchByNameToEdit(string NameSearch,Int64 IDEng)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where [EngName] ='" + NameSearch + "'and IDEng!='"+IDEng+"'  and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }


        public static DataTable SearchByEngineeringRecordNo(string EngineeringRecordNo)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where EngineeringRecordNo ='" + EngineeringRecordNo + "' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }

        public static DataTable SearchByEngineeringRecordNoTOEdit(string EngineeringRecordNo,Int64 IDEng)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where EngineeringRecordNo ='" + EngineeringRecordNo + "'and IDEng!='" + IDEng + "' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }


        public static DataTable SearchByConsultantNo(string ConsultantNo)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where ConsultantNo ='" + ConsultantNo + "' and ConsultantNo !='' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }

        public static DataTable SearchByConsultantNoTOEdit(string ConsultantNo,Int64 IDEng)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = Select("SELECT * FROM  dbo.EngBasicData_Tbl where ConsultantNo ='" + ConsultantNo + "' and ConsultantNo !='' and IDEng!='" + IDEng+"' and [state]=1");
                return dtData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataTable dtData = new DataTable();
                return dtData;
            }
        }


        public static void AutoCompletUniversity(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [University] FROM EngBasicData_Tbl where state=1", con);
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

        public static void AutoCompletName(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [EngName] FROM EngBasicData_Tbl where state=1", con);
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

        public static ComboBox FillCombAllEng(ComboBox cmb)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Select("SELECT IDEng,[EngName] FROM EngBasicData_Tbl where state=1");
                cmb.DataSource = null;
                cmb.DataSource = dt;
                cmb.ValueMember = dt.Columns[0].ToString();
                cmb.DisplayMember = dt.Columns[1].ToString();
                return cmb;
            }
            catch 
            {
                cmb.DataSource = null;
                return cmb;
            }
        }

        public static void AutoCompletNameCon(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [EngName] FROM EngBasicData_Tbl where state=1 and ConsultantNo!=''  and IDOfficeCons ='0' ", con);
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

        public static void AutoCompletNameCon(TextBox txtBox,string typeform)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [EngName] FROM EngBasicData_Tbl where state=1 and ConsultantNo!=''  ", con);
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

        public static void AutoCompletNameConOffice(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [EngName] FROM EngBasicData_Tbl where state=1 and IDOfficeCons!='0'", con);
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

        public static void AutoCompletNameConLarger7Year(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT ConsultantNo,[EngName],IDOfficeCons,datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG FROM EngBasicData_Tbl where state=1 and ConsultantNo!='' or	datediff(MONTH,GraduationYear, getdate() ) / 12 >=7", con);
            Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(1));
            }
            txtBox.AutoCompleteCustomSource = Collection;
            dr.Close();
            Close();
        }



        public static void AutoCompletNameNOTCON(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [EngName] FROM EngBasicData_Tbl where state=1 and ConsultantNo=''", con);
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

        public static DataTable GetContactData(Int64 IDEng)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DAL.ClassDAL.Select("SELECT  IDContact, Address, Phone, Email, Mobile, FaceBook  FROM   dbo.Contact_Tbl where IDEng='"+IDEng+ "' and state=1");

            }
            catch
            {
                return dt;
            }
            return dt;
        }


        public static void Update(DataGridView dgv, string EngName, string RegistrationNo, string Division, DateTime GraduationYear, string Syndicate, string Qualification, string University, string NationalID, string ConsultantNo, string Gender, string Notes, byte[] Image,Int64 IDEng,string EngineeringRecordNo,string Specialization,string TaxCardNo,string IDOfficeCons)
        {
            //    try
            //    {
            DAL.ClassDAL.Open();
                //con.Open();
                //transaction = con.BeginTransaction();


                //cmd = new SqlCommand("insert into EngBasicData_Tbl (EngName,RegistrationNo,Division,GraduationYear,Syndicate,Qualification,University,NationalID,ConsultantNo,Gender,Notes,Image) values (@EngName, @RegistrationNo, @Division, @GraduationYear, @Syndicate, @Qualification, @University, @NationalID, @ConsultantNo, @Gender, @Notes, @Image) ", con, transaction);
                cmd = new SqlCommand("update EngBasicData_Tbl set EngName=@EngName,RegistrationNo=@RegistrationNo,Division=@Division,GraduationYear=@GraduationYear,Syndicate=@Syndicate,Qualification=@Qualification,University=@University,NationalID=@NationalID,ConsultantNo=@ConsultantNo,Gender=@Gender,Notes=@Notes,Image=@Image,EngineeringRecordNo=@EngineeringRecordNo,UserID='"+DAL.ClassDAL.IDUser+ "',Specialization=@Specialization , TaxCardNo=@TaxCardNo , IDOfficeCons='"+ IDOfficeCons + "' where IDEng=@IDEng", con);
                SqlParameter[] p = new SqlParameter[16];
                p[0] = new SqlParameter("@EngName", EngName);
                p[1] = new SqlParameter("@RegistrationNo", RegistrationNo);
                p[2] = new SqlParameter("@Division", Division);
                p[3] = new SqlParameter("@GraduationYear", GraduationYear);
                p[4] = new SqlParameter("@Syndicate", Syndicate);
                p[5] = new SqlParameter("@Qualification", Qualification);
                p[6] = new SqlParameter("@University", University);
                p[7] = new SqlParameter("@NationalID", NationalID);
                p[8] = new SqlParameter("@ConsultantNo", ConsultantNo);
                p[9] = new SqlParameter("@Gender", Gender);
                p[10] = new SqlParameter("@Notes", Notes);
                p[11] = new SqlParameter("@Image", Image);
                p[12] = new SqlParameter("@IDEng", IDEng);
                p[13] = new SqlParameter("@EngineeringRecordNo", EngineeringRecordNo);
                p[14] = new SqlParameter("@Specialization", Specialization);
                p[15] = new SqlParameter("@TaxCardNo", TaxCardNo);
                cmd.Parameters.AddRange(p);
                cmd.ExecuteNonQuery();

                // Updata Doc

                // Select From VariableDoc_Tbl to Update and Insert 
                DataTable dt_VariableDoc_Tbl = new DataTable();
                dt_VariableDoc_Tbl = DAL.ClassDAL.Select("select * from VariableDoc_Tbl");
                if (dt_VariableDoc_Tbl.Rows.Count>0)
                {
                    foreach (DataRow row in dt_VariableDoc_Tbl.Rows)
                    {
                        if (row["ID"].ToString() == "")
                        {
                            // Insert New Doc
                            cmd = new SqlCommand("INSERT INTO [dbo].[Documant_Tbl] ([image], [Descri],[IDEng]) SELECT '" + row["image"] + "', '" + row["Descri"] + "','" + row["IDEng"] + "' FROM VariableDoc_Tbl", con);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Update Old Doc
                            cmd = new SqlCommand("update [dbo].[Documant_Tbl] set image='" + row["image"] + "',Descri='" + row["Descri"] + "' where [IDDouc]='" + row["ID"] + "'", con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //cmd = new SqlCommand("INSERT INTO [dbo].[Documant_Tbl] ([image], [Descri],[IDEng]) SELECT[image], Descri,[IDEng] FROM VariableDoc_Tbl", con, transaction);
                

                }
                // GetID ENG to insert ContactData
                //DataTable dt = new DataTable();
                //cmd = new SqlCommand("select max(IDEng) from [dbo].[EngBasicData_Tbl] ", con, transaction);
                //dt.Load(cmd.ExecuteReader());

                //Int64 id = Convert.ToInt64(dt.Rows[0][0].ToString());

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells[0].Value.ToString()=="")
                    {
                        cmd = new SqlCommand(" insert into Contact_Tbl (IDEng,Address,Phone,Email,Mobile,FaceBook,UserID) values ( @IDEng, @Address, @Phone, @Email, @Mobile, @FaceBook,'"+ClassDAL.IDUser+"')  ", con);
                        SqlParameter[] p2 = new SqlParameter[6];
                        p2[0] = new SqlParameter("@IDEng", IDEng);
                        p2[1] = new SqlParameter("@Address", item.Cells[5].Value.ToString());
                        p2[2] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                        p2[3] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                        p2[4] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                        p2[5] = new SqlParameter("@FaceBook", item.Cells[4].Value.ToString());

                        cmd.Parameters.AddRange(p2);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand(" update  Contact_Tbl set Address=@Address,Phone=@Phone,Email=@Email,Mobile=@Mobile,FaceBook=@FaceBook,UserID='"+DAL.ClassDAL.IDUser+"'   where IDContact=@IDContact", con);
                        SqlParameter[] p2 = new SqlParameter[6];
                       
                        p2[0] = new SqlParameter("@Address", item.Cells[5].Value.ToString());
                        p2[1] = new SqlParameter("@Phone", item.Cells[1].Value.ToString());
                        p2[2] = new SqlParameter("@Email", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@Mobile", item.Cells[2].Value.ToString());
                        p2[4] = new SqlParameter("@FaceBook", item.Cells[4].Value.ToString());
                        p2[5] = new SqlParameter("@IDContact",Convert.ToInt64( item.Cells[0].Value.ToString()));

                        cmd.Parameters.AddRange(p2);
                        cmd.ExecuteNonQuery();
                    }
                }


                // Delete VirableDoc and RESEED
                if (dt_VariableDoc_Tbl.Rows.Count>0)
                {
                    cmd = new SqlCommand("delete from VariableDoc_Tbl", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("DBCC CHECKIDENT (VariableDoc_Tbl, RESEED, 0)", con);
                    cmd.ExecuteNonQuery();
                }


            //transaction.Commit();

        //}
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
                DAL.ClassDAL.Close();

              
            //    return;
            //}


    DAL.ClassDAL.Close();
            //con.Close();
            PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
            frm.Show();

        }

        public static void Delete(Int64 IDEng)
        {
            try
            {
                Run("update EngBasicData_Tbl set state=0 , UserID ='"+IDUser+"'where IDEng='" + IDEng + "' ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static string RecordingEngNo(string registrationNo)
        {
            DataTable dt = new DataTable();
            dt = Select("select EngineeringRecordNo from  EngBasicData_Tbl where RegistrationNo='" + registrationNo + "'");
            return dt.Rows[0][0].ToString();
        }
    }
}
