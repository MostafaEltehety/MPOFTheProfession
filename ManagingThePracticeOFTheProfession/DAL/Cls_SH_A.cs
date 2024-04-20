using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_SH_A:DAL.ClassDAL
    {

        public static void Save(string Code, decimal CostForm, int TypeForm, Int64 IDEng, Int64 IDOwner, string NumberLicense, DateTime DateLicense, string IssuedFrom, string TitleProject, string Department, string City,
   string Governorate, string BusinessStatement, string CostWord, string CostLicense, string OtherData,
   string EngEmail, string EngPhone,
   string EngMobile, string EngAdress, string OfficeAdress, string OfficePhone, string OwnerAdrees, string OwnerEmail, string OwnerPhone, string OwnerMobile, Int32 UserID, string TaxCardEng, string NoExperienceHouse)

        {

            //Run("insert into [Form_SH.D] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,YearLicense,DateLicense,TypeLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID ) values ('"+ Code + "','"+ CostForm + "','"+ TypeForm + "','"+ IDEng + "','"+ IDOwner + "','"+ NumberLicense + "','"+ YearLicense + "','"+ DateLicense + "','"+ TypeLicense + "','"+ IssuedFrom + "','"+ TitleProject + "','"+ Department + "','"+ City + "','"+ Governorate + "','"+ BusinessStatement + "','"+ CostWord + "','"+ CostLicense + "','" + OtherData + "','"+ EngEmail + "','"+ EngPhone + "','"+ EngMobile + "','"+ EngAdress + "','"+OfficeAdress+ "','"+OfficePhone+ "','"+OwnerAdrees+ "','" + OwnerEmail + "','" + OwnerPhone + "','" + OwnerMobile+"','"+UserID +"' )");


            //Open();

            try
            {
                cmd = new SqlCommand("insert into [Form_SH.A] (Code,CostForm,TypeForm,IDEng,IDOwner,NumberLicense,DateLicense,IssuedFrom,TitleProject,Department,City,Governorate,BusinessStatement,CostWord,CostLicense,OtherData,EngEmail,EngPhone,EngMobile,EngAdress,OfficeAdress,OfficePhone,OwnerAdrees,OwnerEmail,OwnerPhone,OwnerMobile,UserID,TaxCardEng ,NoExperienceHouse) values (@Code,@CostForm,@TypeForm,@IDEng,@IDOwner,@NumberLicense,@DateLicense,@IssuedFrom,@TitleProject,@Department,@City,@Governorate,@BusinessStatement,@CostWord,@CostLicense,@OtherData,@EngEmail,@EngPhone,@EngMobile,@EngAdress,@OfficeAdress,@OfficePhone,@OwnerAdrees,@OwnerEmail,@OwnerPhone,@OwnerMobile,@UserID ,@TaxCardEng ,@NoExperienceHouse)", con);
                SqlParameter[] p2 = new SqlParameter[29];

                p2[0] = new SqlParameter("@Code", Code);
                p2[1] = new SqlParameter("@CostForm", CostForm);
                p2[2] = new SqlParameter("@TypeForm", TypeForm);
                p2[3] = new SqlParameter("@IDEng", IDEng);
                p2[4] = new SqlParameter("@IDOwner", IDOwner);
                p2[5] = new SqlParameter("@NumberLicense", NumberLicense);
                p2[6] = new SqlParameter("@DateLicense", DateLicense);
                p2[7] = new SqlParameter("@IssuedFrom", IssuedFrom);
                p2[8] = new SqlParameter("@TitleProject", TitleProject);
                p2[9] = new SqlParameter("@Department", Department);
                p2[10] = new SqlParameter("@City", City);
                p2[11] = new SqlParameter("@Governorate", Governorate);
                p2[12] = new SqlParameter("@BusinessStatement", BusinessStatement);
                p2[13] = new SqlParameter("@CostWord", CostWord);
                p2[14] = new SqlParameter("@CostLicense", CostLicense);
                p2[15] = new SqlParameter("@OtherData", OtherData);
                p2[16] = new SqlParameter("@EngEmail", EngEmail);
                p2[17] = new SqlParameter("@EngPhone", EngPhone);
                p2[18] = new SqlParameter("@EngMobile", EngMobile);
                p2[19] = new SqlParameter("@EngAdress", EngAdress);
                p2[20] = new SqlParameter("@OfficeAdress", OfficeAdress);
                p2[21] = new SqlParameter("@OfficePhone", OfficePhone);
                p2[22] = new SqlParameter("@OwnerAdrees", OwnerAdrees);
                p2[23] = new SqlParameter("@OwnerEmail", OwnerEmail);
                p2[24] = new SqlParameter("@OwnerPhone", OwnerPhone);
                p2[25] = new SqlParameter("@OwnerMobile", OwnerMobile);
                p2[26] = new SqlParameter("@UserID", UserID);
                p2[27] = new SqlParameter("@TaxCardEng", TaxCardEng);
                p2[28] = new SqlParameter("@NoExperienceHouse", NoExperienceHouse);

                
                cmd.Parameters.AddRange(p2);

                cmd.ExecuteNonQuery();
                PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
                frm.ShowDialog();
                //ID = Select("select max(IDForm) from [Form_SH.A]").Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

    }
}
