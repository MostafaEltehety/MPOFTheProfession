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
    class Cls_ConsultingOffice:DAL.ClassDAL
    {
        public static void Save(DataGridView dgv,string OfficeName,string OfficeNo,string OfficeRecordingNo ,bool state,Int32 UserID,string TaxNo)
        {
            try
            {
                Open();
                RunTransaction(" insert into ConsultingOffice_Tbl (OfficeName,OfficeNo,OfficeRecordingNo,state,UserID,TaxNo) values ('" + OfficeName + "','"+ OfficeNo + "','"+ OfficeRecordingNo + "','"+ state + "','"+ UserID + "','"+ TaxNo + "')");
                string IDOfficeCons = Select("select max(IDOffice) from ConsultingOffice_Tbl").Rows[0][0].ToString();

                //IDContanetOffice,Address,phone,moble,IDOfficeCons

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    //if (item.Cells[0].Value.ToString() == "")
                    //{
                  
                        cmd = new SqlCommand(" insert into ContanetOfficeCons_tbl (Address,phone,moble,IDOfficeCons) values (@Address,@phone,@moble,@IDOfficeCons)    ", con);
                        SqlParameter[] p2 = new SqlParameter[4];
                        p2[0] = new SqlParameter("@Address", item.Cells[1].Value.ToString());
                        p2[1] = new SqlParameter("@phone", item.Cells[2].Value.ToString());
                        p2[2] = new SqlParameter("@moble", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@IDOfficeCons", IDOfficeCons);

                        cmd.Parameters.AddRange(p2);

                        cmd.ExecuteNonQuery();
                    //}
                    //else
                    //{
                    //    cmd = new SqlCommand(" update ContanetOfficeCons_tbl set Address=@Address,phone=@phone,moble=@moble where IDContanetOffice=@IDContanetOffice ", con);
                    //    SqlParameter[] p2 = new SqlParameter[4];

                    //    p2[0] = new SqlParameter("@Address", item.Cells[2].Value.ToString());
                    //    p2[1] = new SqlParameter("@phone", item.Cells[3].Value.ToString());
                    //    p2[2] = new SqlParameter("@moble", item.Cells[4].Value.ToString());
                    //    p2[3] = new SqlParameter("@IDContanetOffice", item.Cells[0].Value.ToString());



                    //    cmd.Parameters.AddRange(p2);
                    //    cmd.ExecuteNonQuery();
                    //}
                 
                }



                Close();

                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.Show();
                //Run("insert into Office_Tbl (Address,Phone,Notes,IDEng,UserID,OFficeName) values ( '" + Address + "', '" + Phone + "', '" + Notes + "','" + IDEng + "','" + IDUser + "','" + OFficeName + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void Update(DataGridView dgv, string OfficeName, string OfficeNo, string OfficeRecordingNo, bool state, Int32 UserID, string TaxNo,string IDOffice)
        {
            try
            {
                Open();
                RunTransaction(" update ConsultingOffice_Tbl set OfficeName='" + OfficeName + "' ,OfficeNo= '" + OfficeNo + "',OfficeRecordingNo= '" + OfficeRecordingNo + "',state= '" + state + "',UserID= '" + UserID + "',TaxNo='" + TaxNo + "' where  IDOffice ='"+ IDOffice + "'");
                string IDOfficeCons = Select("select max(IDOffice) from ConsultingOffice_Tbl").Rows[0][0].ToString();

                //IDContanetOffice,Address,phone,moble,IDOfficeCons

                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (item.Cells[0].Value.ToString() == "")
                    {
                        cmd = new SqlCommand(" insert into ContanetOfficeCons_tbl (Address,phone,moble,IDOfficeCons) values (@Address,@phone,@moble,@IDOfficeCons)    ", con);
                        SqlParameter[] p2 = new SqlParameter[4];
                        p2[0] = new SqlParameter("@Address", item.Cells[1].Value.ToString());
                        p2[1] = new SqlParameter("@phone", item.Cells[2].Value.ToString());
                        p2[2] = new SqlParameter("@moble", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@IDOfficeCons", IDOfficeCons);

                        cmd.Parameters.AddRange(p2);

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand(" update ContanetOfficeCons_tbl set Address=@Address,phone=@phone,moble=@moble where IDContanetOffice=@IDContanetOffice ", con);
                        SqlParameter[] p2 = new SqlParameter[4];

                        p2[0] = new SqlParameter("@Address", item.Cells[1].Value.ToString());
                        p2[1] = new SqlParameter("@phone", item.Cells[2].Value.ToString());
                        p2[2] = new SqlParameter("@moble", item.Cells[3].Value.ToString());
                        p2[3] = new SqlParameter("@IDContanetOffice", item.Cells[0].Value.ToString());



                        cmd.Parameters.AddRange(p2);
                        cmd.ExecuteNonQuery();
                       
                    }

                }



                Close();

                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.Show();

                //Run("insert into Office_Tbl (Address,Phone,Notes,IDEng,UserID,OFficeName) values ( '" + Address + "', '" + Phone + "', '" + Notes + "','" + IDEng + "','" + IDUser + "','" + OFficeName + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        public static void AutoCompletName(TextBox txtBox)
        {
            SqlDataReader dr;
            cmd = new SqlCommand("SELECT [OfficeName] FROM ConsultingOffice_Tbl where state=1 and (OfficeName!='' or OfficeName!='0')", con);
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

        public static DataTable SearchByName( string OfficeName )
        {
            DataTable dt = new DataTable();
            dt=Select("SELECT IDOffice, OfficeName, OfficeNo, OfficeRecordingNo,TaxNo FROM dbo.ConsultingOffice_Tbl where OfficeName='" + OfficeName + "' and state ='1'");
            return dt;
        }

        public static DataTable GetContactOffice (string IDOffice)
        {
            DataTable dt = new DataTable();
            dt = Select(" SELECT  IDContanetOffice, Address, phone, moble, IDOfficeCons FROM  dbo.ContanetOfficeCons_tbl where IDOfficeCons='" + IDOffice + "' and state ='1'");
            return dt;
        }

        public static ComboBox FillComb(ComboBox cmb)
        {
            cmb.DataSource = null;
            DataTable dt = new DataTable();
            dt = Select("SELECT IDOffice, OfficeName FROM dbo.ConsultingOffice_Tbl where state ='1'");
            cmb.DataSource = dt;
            cmb.DisplayMember = dt.Columns["OfficeName"].ToString();
            cmb.ValueMember = dt.Columns["IDOffice"].ToString();
            return cmb;
        }

        public static DataTable GETSomedata(string id)
        {
            DataTable dt = new DataTable();
            dt = Select("SELECT IDOffice, OfficeRecordingNo,TaxNo FROM dbo.ConsultingOffice_Tbl where IDOffice='" + id + "' and state ='1'");
            return dt;
        }

        public static int CheckToSave(string OfficeName,string OfficeNo,string OfficeRecordingNo,string TaxNo)
        {
            DataTable dt = new DataTable();
            dt = Select("SELECT OfficeName, OfficeNo, OfficeRecordingNo, TaxNo  FROM  dbo.ConsultingOffice_Tbl where OfficeName='" + OfficeName + "' or OfficeNo='" + OfficeNo + "' or OfficeRecordingNo='" + OfficeRecordingNo + "' or TaxNo='" + TaxNo + "'");
            if (dt.Rows.Count>0)
            {
                return 1;
            }
            return 0;
        }
        public static int CheckToEdit(string OfficeName, string OfficeNo, string OfficeRecordingNo, string TaxNo,Int32 IdOffi)
        {
            DataTable dt = new DataTable();
            dt = Select("SELECT OfficeName, OfficeNo, OfficeRecordingNo, TaxNo  FROM  dbo.ConsultingOffice_Tbl where (IDOffice!='"+IdOffi+"') and ( OfficeName='" + OfficeName + "' or OfficeNo='" + OfficeNo + "' or OfficeRecordingNo='" + OfficeRecordingNo + "' or TaxNo='" + TaxNo + "')");
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }


    }



}
