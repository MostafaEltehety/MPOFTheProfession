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
    class Cls_OfficeData:ClassDAL
    {
        //public static void Save(string Address,string Phone,string Notes,Int64 IDEng,string OFficeName)
        //{
        //    try
        //    {
        //        Run("insert into Office_Tbl (Address,Phone,Notes,IDEng,UserID,OFficeName) values ( '" + Address + "', '" + Phone + "', '" + Notes + "','"+ IDEng + "','"+IDUser+"','"+ OFficeName + "')");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return;
        //    }
        //}

        public static void Save(DataGridView dgv,Int64 Ideng)
        {
            try
            {
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells[0].Value.ToString() == "")
                    {
                        cmd = new SqlCommand(" insert into Office_Tbl (Address,Phone,Notes,IDEng,UserID,OFficeName) values (@Address,@Phone,@Notes,@IDEng,@UserID,@OFficeName)  ", con);
                        SqlParameter[] p2 = new SqlParameter[6];
                        p2[0] = new SqlParameter("@Address", item.Cells[2].Value.ToString());
                        p2[1] = new SqlParameter("@Phone", item.Cells[3].Value.ToString());
                        p2[2] = new SqlParameter("@Notes", item.Cells[4].Value.ToString());
                        p2[3] = new SqlParameter("@IDEng", Ideng);
                        p2[4] = new SqlParameter("@UserID", DAL.ClassDAL.IDUser);
                        p2[5] = new SqlParameter("@OFficeName", item.Cells[1].Value.ToString());

                        cmd.Parameters.AddRange(p2);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand(" update Office_Tbl set Address=@Address,Phone=@Phone,Notes=@Notes,OFficeName=@OFficeName where IDOffice=@IDOffice ", con);
                        SqlParameter[] p2 = new SqlParameter[5];

                        p2[0] = new SqlParameter("@Address", item.Cells[2].Value.ToString());
                        p2[1] = new SqlParameter("@Phone", item.Cells[3].Value.ToString());
                        p2[2] = new SqlParameter("@Notes", item.Cells[4].Value.ToString());
                        p2[3] = new SqlParameter("@IDOffice", item.Cells[0].Value.ToString());
                     
                        p2[4] = new SqlParameter("@OFficeName", item.Cells[1].Value.ToString());

                        cmd.Parameters.AddRange(p2);
                        cmd.ExecuteNonQuery();
                    }
                }

                PL.Frm_MessageSuccess msg = new PL.Frm_MessageSuccess();
                msg.Show();


                //Run("insert into Office_Tbl (Address,Phone,Notes,IDEng,UserID,OFficeName) values ( '" + Address + "', '" + Phone + "', '" + Notes + "','" + IDEng + "','" + IDUser + "','" + OFficeName + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        public static DataTable TaxCad(string TaxCardNo)
        {
            DataTable dt = new DataTable(); 
            try
            {
              return dt= Select("select TaxCardNo from Office_Tbl where TaxCardNo='" + TaxCardNo + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }


        public static void Delete(Int64 IDOffice)
        {
            try
            {
                Run("update Office_Tbl set state=0,UserID='"+IDUser+"' where [IDOffice]='" + IDOffice+ "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        public static void Update(  string Address, string Phone, string Notes,Int64 IDOfice,Int64 IDEng,string OFficeName)
        {
            try
            {
                Run("update  Office_Tbl  set Address= '" + Address + "',Phone= '" + Phone + "',Notes= '" + Notes + "',IDEng= '"+ IDEng + "',UserID='"+IDUser+ "' ,OFficeName='"+ OFficeName + "' where IDOffice='"+ IDOfice + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        public static DataTable SearchByNameEng(string EngName)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("  SELECT dbo.Office_Tbl.IDEng, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Office_Tbl.Address, dbo.EngBasicData_Tbl.TaxCardNo, dbo.Office_Tbl.Notes, dbo.Office_Tbl.Phone, dbo.EngBasicData_Tbl.ConsultantNo,  dbo.Office_Tbl.IDOffice , dbo.Office_Tbl.OFficeName FROM  dbo.Office_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Office_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng where EngName= '" + EngName+ "' and dbo.Office_Tbl.state=1 ");
                return dt; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }

        public static DataTable SearchByIDEng(Int64 IDEng)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("  SELECT dbo.Office_Tbl.IDEng, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Office_Tbl.Address, dbo.EngBasicData_Tbl.TaxCardNo, dbo.Office_Tbl.Notes, dbo.Office_Tbl.Phone, dbo.EngBasicData_Tbl.ConsultantNo,  dbo.Office_Tbl.IDOffice FROM  dbo.Office_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Office_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng where EngName= '" + IDEng + "'");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }


        public static DataTable SearchByRegistrationNo(string RegistrationNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("  SELECT dbo.Office_Tbl.IDEng, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Office_Tbl.Address, dbo.EngBasicData_Tbl.TaxCardNo, dbo.Office_Tbl.Notes, dbo.Office_Tbl.Phone, dbo.EngBasicData_Tbl.ConsultantNo,  dbo.Office_Tbl.IDOffice FROM  dbo.Office_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Office_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng where RegistrationNo= '" + RegistrationNo + "'");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }

        public static DataTable SearchByEngineeringRecordNo(string EngineeringRecordNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("  SELECT dbo.Office_Tbl.IDEng, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Office_Tbl.Address, dbo.EngBasicData_Tbl.TaxCardNo, dbo.Office_Tbl.Notes, dbo.Office_Tbl.Phone, dbo.EngBasicData_Tbl.ConsultantNo,  dbo.Office_Tbl.IDOffice FROM  dbo.Office_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Office_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng where EngineeringRecordNo= '" + EngineeringRecordNo + "'");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }
        public static DataTable SearchByNationalID(string NationalID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Select("  SELECT dbo.Office_Tbl.IDEng, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.Office_Tbl.Address, dbo.EngBasicData_Tbl.TaxCardNo, dbo.Office_Tbl.Notes, dbo.Office_Tbl.Phone, dbo.EngBasicData_Tbl.ConsultantNo,  dbo.Office_Tbl.IDOffice FROM  dbo.Office_Tbl INNER JOIN dbo.EngBasicData_Tbl ON dbo.Office_Tbl.IDEng = dbo.EngBasicData_Tbl.IDEng where NationalID= '" + NationalID + "'");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }


    }
}
