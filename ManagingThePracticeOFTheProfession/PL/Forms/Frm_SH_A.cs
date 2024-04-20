using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    public partial class Frm_SH_A : Form
    {
        public Frm_SH_A()
        {
            InitializeComponent();
            Restart();
        }

        void Clear(GroupBox GB)
        {
            foreach (Control ctr in GB.Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
                if (ctr is ComboBox)
                {
                    ctr.Text = "";
                }

            }
        }

        void Restart()
        {
            Clear(groupLisence);
            Clear(groupEng);
            Clear(groupOwners);
            Clear(groupSerchEng);
            groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = btn_Edit.Enabled = false;
            txt_Code.Text = DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + "SH_A:" + string.Format("{0:0000000}", Convert.ToInt64(DAL.ClassDAL.GetID("[Form_SH.A]", "[IDForm]")));
            txt_FessForm.Text = "0";
            groupSerchEng.Enabled = true;
            DAL.Cls_EngineersData.AutoCompletName(txt_searchName);

            txt_OtherData.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txt_NationIDOwner.Text))
                {
                    MessageBox.Show("يجب إدخال بيانات المالك");
                    return;
                }
                if (string.IsNullOrEmpty(txt_NumberLicense.Text) || string.IsNullOrEmpty(txt_IssuedFrom.Text) || string.IsNullOrEmpty(txt_TilteProject.Text) || string.IsNullOrEmpty(txt_Department.Text) || string.IsNullOrEmpty(txt_City.Text) || string.IsNullOrEmpty(txt_Governator.Text) || string.IsNullOrEmpty(txt_BassinesStatement.Text) || string.IsNullOrEmpty(txt_CostProject.Text) || string.IsNullOrEmpty(txt_CostWord.Text))
                {
                    MessageBox.Show("يجب إدخال بيانات الرخصة");
                    return;
                }

                string PhoneEng, MobileEng, EmailEng, AdressEng, AdressOffice, PhoneOffice, AdressOwner, PhoneOwners, EmailOwner, MobileOwner = "";
                #region Null
                // PhoneEng
                if (combPhoneEng.Text == "")
                {
                    PhoneEng = "---";
                }
                else
                {
                    PhoneEng = combPhoneEng.Text;
                }
                // MobileEng
                if (combMobileEng.Text == "")
                {
                    MobileEng = "---";
                }
                else
                {
                    MobileEng = combMobileEng.Text;
                }
                // EmailEng
                if (combEmailEng.Text == "")
                {
                    EmailEng = "---";
                }
                else
                {
                    EmailEng = combEmailEng.Text;
                }
                // AdressEng
                if (CombAdressEng.Text == "")
                {
                    AdressEng = "---";
                }
                else
                {
                    AdressEng = CombAdressEng.Text;
                }
                // AdressOffice
                if (combAdressOffice.Text == "")
                {
                    AdressOffice = "---";
                }
                else
                {
                    AdressOffice = combAdressOffice.Text;
                }
                // PhoneOffice
                if (combPhoneOffice.Text == "")
                {
                    PhoneOffice = "---";
                }
                else
                {
                    PhoneOffice = combPhoneOffice.Text;
                }
                // AdressOwner
                if (combAdressOwner.Text == "")
                {
                    AdressOwner = "---";
                }
                else
                {
                    AdressOwner = combAdressOwner.Text;
                }
                //PhoneOwners
                if (combPhoneOwners.Text == "")
                {
                    PhoneOwners = "---";
                }
                else
                {
                    PhoneOwners = combPhoneOwners.Text;
                }
                // EmailOwner
                if (combEmailOwners.Text == "")
                {
                    EmailOwner = "---";
                }
                else
                {
                    EmailOwner = combEmailOwners.Text;
                }
                // MobileOwner
                if (comb_MobileOwner.Text == "")
                {
                    MobileOwner = "---";
                }
                else
                {
                    MobileOwner = combEmailOwners.Text;
                }
                if (String.IsNullOrEmpty(txt_HouseNo.Text))
                {
                    txt_HouseNo.Text = "---";
                }
                #endregion

                DAL.Cls_SH_A.Save(txt_Code.Text, Convert.ToDecimal(txt_FessForm.Text), 1, Convert.ToInt64(IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_NumberLicense.Text, dateDateLicense.Value, txt_IssuedFrom.Text, txt_TilteProject.Text, txt_Department.Text, txt_City.Text, txt_Governator.Text, txt_BassinesStatement.Text, txt_CostWord.Text, txt_CostProject.Text, txt_OtherData.Text, EmailEng, PhoneEng, MobileEng, AdressEng, AdressOffice, PhoneOffice, AdressOwner, EmailOwner, PhoneOwners, MobileOwner, Convert.ToInt32(DAL.ClassDAL.IDUser), TaxCardEng.Text, txt_HouseNo.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            IDEng.Text = "";
            #region SearchByRegistrationNo
            if (!string.IsNullOrEmpty(txt_SearRegistrationNo.Text))
            {
                DataTable dtSearchByRegistrationNo = new DataTable();
                dtSearchByRegistrationNo = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID, IDEng ,EngineeringRecordNo , Specialization,ConsultantNo ,GraduationYear FROM  dbo.EngBasicData_Tbl WHERE(RegistrationNo = '" + txt_SearRegistrationNo.Text + "')");
                if (dtSearchByRegistrationNo.Rows.Count > 0)
                {
                    EngName.Text = dtSearchByRegistrationNo.Rows[0]["EngName"].ToString();
                    NationalIDEng.Text = dtSearchByRegistrationNo.Rows[0]["NationalID"].ToString();
                    RegistrationNoEng.Text = dtSearchByRegistrationNo.Rows[0]["RegistrationNo"].ToString();
                    DivisionEng.Text = dtSearchByRegistrationNo.Rows[0]["Division"].ToString();
                    IDEng.Text = dtSearchByRegistrationNo.Rows[0]["IDEng"].ToString();
                    lbl_EngineeringRecordNo.Text = dtSearchByRegistrationNo.Rows[0]["EngineeringRecordNo"].ToString();
                    txt_Specialization.Text = dtSearchByRegistrationNo.Rows[0]["Specialization"].ToString();
                    txt_ConsultantNo.Text = dtSearchByRegistrationNo.Rows[0]["ConsultantNo"].ToString();
                    txt_GenrataionYear.Text = Convert.ToDateTime(dtSearchByRegistrationNo.Rows[0]["GraduationYear"].ToString()).ToString("yyyy");
                }
            }
            #endregion

            #region SearchByNationalID
            if (!string.IsNullOrEmpty(txt_NationalID.Text))
            {
                DataTable dtSearchByNationalID = new DataTable();
                dtSearchByNationalID = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID , IDEng,EngineeringRecordNo,Specialization ,ConsultantNo , GraduationYear FROM  dbo.EngBasicData_Tbl WHERE(NationalID = '" + txt_NationalID.Text + "')");
                if (dtSearchByNationalID.Rows.Count > 0)
                {
                    EngName.Text = dtSearchByNationalID.Rows[0]["EngName"].ToString();
                    NationalIDEng.Text = dtSearchByNationalID.Rows[0]["NationalID"].ToString();
                    RegistrationNoEng.Text = dtSearchByNationalID.Rows[0]["RegistrationNo"].ToString();
                    DivisionEng.Text = dtSearchByNationalID.Rows[0]["Division"].ToString();
                    IDEng.Text = dtSearchByNationalID.Rows[0]["IDEng"].ToString();
                    lbl_EngineeringRecordNo.Text = dtSearchByNationalID.Rows[0]["EngineeringRecordNo"].ToString();
                    txt_Specialization.Text = dtSearchByNationalID.Rows[0]["Specialization"].ToString();
                    txt_ConsultantNo.Text = dtSearchByNationalID.Rows[0]["ConsultantNo"].ToString();
                    txt_GenrataionYear.Text = Convert.ToDateTime(dtSearchByNationalID.Rows[0]["GraduationYear"].ToString()).ToString("yyyy");

                }
            }
            #endregion

            #region SearchByNameEng
            if (!string.IsNullOrEmpty(txt_searchName.Text))
            {
                DataTable dtSearchByNameEng = new DataTable();
                dtSearchByNameEng = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo,Specialization,ConsultantNo,GraduationYear FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                if (dtSearchByNameEng.Rows.Count > 0)
                {
                    EngName.Text = dtSearchByNameEng.Rows[0]["EngName"].ToString();
                    NationalIDEng.Text = dtSearchByNameEng.Rows[0]["NationalID"].ToString();
                    RegistrationNoEng.Text = dtSearchByNameEng.Rows[0]["RegistrationNo"].ToString();
                    DivisionEng.Text = dtSearchByNameEng.Rows[0]["Division"].ToString();
                    IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    lbl_EngineeringRecordNo.Text = dtSearchByNameEng.Rows[0]["EngineeringRecordNo"].ToString();
                    txt_Specialization.Text = dtSearchByNameEng.Rows[0]["Specialization"].ToString();
                    txt_ConsultantNo.Text = dtSearchByNameEng.Rows[0]["ConsultantNo"].ToString();
                    txt_GenrataionYear.Text = Convert.ToDateTime(dtSearchByNameEng.Rows[0]["GraduationYear"].ToString()).ToString("yyyy");

                }
            }
            #endregion

            if (IDEng.Text != "")
            {
                DataTable dtAdressData = new DataTable();
                dtAdressData = DAL.ClassDAL.Select("SELECT  IDContact, Address  FROM  dbo.Contact_Tbl  WHERE   (state = 1) and IDEng='" + IDEng.Text + "'");
                CombAdressEng.DataSource = null;
                if (dtAdressData.Rows.Count > 0)
                {
                    CombAdressEng.DataSource = dtAdressData;
                    CombAdressEng.ValueMember = dtAdressData.Columns["IDContact"].ToString();
                    CombAdressEng.DisplayMember = dtAdressData.Columns["Address"].ToString();
                    // Select LindexAdresEng
                    int LindexAdresEng = CombAdressEng.Items.Count - 1;
                    CombAdressEng.SelectedIndex = LindexAdresEng;
                }


                DataTable dtPhoneData = new DataTable();
                combPhoneEng.DataSource = null;
                dtPhoneData = DAL.ClassDAL.Select("SELECT  IDContact, Phone  FROM  dbo.Contact_Tbl  WHERE   (state = 1) and IDEng='" + IDEng.Text + "'");
                if (dtPhoneData.Rows.Count > 0)
                {
                    combPhoneEng.DataSource = dtPhoneData;
                    combPhoneEng.ValueMember = dtPhoneData.Columns["IDContact"].ToString();
                    combPhoneEng.DisplayMember = dtPhoneData.Columns["Phone"].ToString();
                    // Select LindexPhone
                    int LindexPhone = combPhoneEng.Items.Count - 1;
                    combPhoneEng.SelectedIndex = LindexPhone;
                }



                DataTable dtMobileData = new DataTable();
                dtMobileData = DAL.ClassDAL.Select("SELECT  IDContact, Mobile  FROM  dbo.Contact_Tbl  WHERE   (state = 1) and IDEng='" + IDEng.Text + "'");
                combMobileEng.DataSource = null;
                if (dtMobileData.Rows.Count > 0)
                {
                    combMobileEng.DataSource = dtMobileData;
                    combMobileEng.ValueMember = dtMobileData.Columns["IDContact"].ToString();
                    combMobileEng.DisplayMember = dtMobileData.Columns["Mobile"].ToString();
                    // Select LindexMobile
                    int LindexMobile = combMobileEng.Items.Count - 1;
                    combMobileEng.SelectedIndex = LindexMobile;
                }



                DataTable dtEmailData = new DataTable();
                dtEmailData = DAL.ClassDAL.Select("SELECT  IDContact, Email  FROM  dbo.Contact_Tbl  WHERE   (state = 1) and IDEng='" + IDEng.Text + "'");
                combEmailEng.DataSource = null;
                if (dtEmailData.Rows.Count > 0)
                {
                    combEmailEng.DataSource = dtEmailData;
                    combEmailEng.ValueMember = dtEmailData.Columns["IDContact"].ToString();
                    combEmailEng.DisplayMember = dtEmailData.Columns["Email"].ToString();
                    // Select LindexEmail
                    int LindexEmail = combEmailEng.Items.Count - 1;
                    combEmailEng.SelectedIndex = LindexEmail;

                }



                DataTable dtOfficeAdre = new DataTable();
                dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDOffice, Address,TaxCardNo FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                combAdressOffice.DataSource = null;
                if (dtOfficeAdre.Rows.Count > 0)
                {
                    combAdressOffice.DataSource = dtOfficeAdre;
                    combAdressOffice.ValueMember = dtOfficeAdre.Columns[0].ToString();
                    combAdressOffice.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                    TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                    // Select LindexAdressOffice
                    int LindexAdressOffice = combAdressOffice.Items.Count - 1;
                    combAdressOffice.SelectedIndex = LindexAdressOffice;
                }
                else
                {
                    TaxCardEng.Text = "---";
                }

                DataTable dtOfficePhone = new DataTable();
                dtOfficePhone = DAL.ClassDAL.Select("SELECT IDOffice , Phone FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                combPhoneOffice.DataSource = null;
                if (dtOfficePhone.Rows.Count > 0)
                {
                    combPhoneOffice.DataSource = dtOfficePhone;
                    combPhoneOffice.ValueMember = dtOfficePhone.Columns[0].ToString();
                    combPhoneOffice.DisplayMember = dtOfficePhone.Columns[1].ToString();
                    // Select LindexAdressOffice
                    int LindexPhoneOffice = combPhoneOffice.Items.Count - 1;
                    combPhoneOffice.SelectedIndex = LindexPhoneOffice;
                }

                groupSerchEng.Enabled = false;
            }
            if (IDEng.Text != "")
            {
                groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = true;
            }


            txt_NoYearsExperance.Text = Convert.ToInt32((DateTime.Now.Year) - Convert.ToInt32(txt_GenrataionYear.Text)).ToString();
            int CountSH_A= Convert.ToInt32(DAL.ClassDAL.Select("select count(IDEng)  from [Form_SH.A] where IDEng='"+IDEng.Text+"' and ISActive=1 and State=1").Rows[0][0].ToString());
            int CountSH_D = Convert.ToInt32(DAL.ClassDAL.Select("select count(IDEng)  from [Form_SH.D] where IDEng='"+IDEng.Text+"' and ISActive=1 and State=1").Rows[0][0].ToString());
            int CountSH_G = Convert.ToInt32(DAL.ClassDAL.Select("select count(IDEng)  from [Form_SH.G] where IDEng='"+IDEng.Text+"' and ISActive=1 and State=1").Rows[0][0].ToString());
            int CountSH_H = Convert.ToInt32(DAL.ClassDAL.Select("select count(IDEng)  from [Form_SH.H] where IDEng='"+IDEng.Text+"' and ISActive=1 and State=1").Rows[0][0].ToString());
            int CountSH_W = Convert.ToInt32(DAL.ClassDAL.Select("select count(IDEng)  from [Form_SH.W] where IDEng='"+IDEng.Text+"' and ISActive=1 and State=1").Rows[0][0].ToString());

            txt_NoInOpration.Text = (CountSH_A + CountSH_D + CountSH_G + CountSH_H + CountSH_W).ToString();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void btn_SearchOwner_Click(object sender, EventArgs e)
        {
            lblIDOwner.Text = "";
            DAL.Clss_Owners.SearchBYNationalID(txt_NationIDOwner.Text, lblIDOwner, txt_OwnerName);
            try
            {
                DataTable dtAdres = new DataTable();
                dtAdres = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                if (dtAdres.Rows.Count > 0)
                {
                    combAdressOwner.DataSource = dtAdres;
                    combAdressOwner.ValueMember = dtAdres.Columns["Address"].ToString();
                }

                DataTable dtPhone = new DataTable();
                dtPhone = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                if (dtPhone.Rows.Count > 0)
                {
                    combPhoneOwners.DataSource = dtPhone;
                    combPhoneOwners.ValueMember = dtPhone.Columns["Phone"].ToString();
                }

                DataTable dtMobile = new DataTable();
                dtMobile = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                if (dtPhone.Rows.Count > 0)
                {
                    comb_MobileOwner.DataSource = dtMobile;
                    comb_MobileOwner.ValueMember = dtMobile.Columns["Mobile"].ToString();
                }

                DataTable dtEmail = new DataTable();
                dtEmail = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                if (dtEmail.Rows.Count > 0)
                {
                    combEmailOwners.DataSource = dtEmail;
                    combEmailOwners.ValueMember = dtEmail.Columns["Email"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txt_NationIDOwner_Validating(object sender, CancelEventArgs e)
        {
            btn_SearchOwner_Click(null, null);
        }
    }
}
