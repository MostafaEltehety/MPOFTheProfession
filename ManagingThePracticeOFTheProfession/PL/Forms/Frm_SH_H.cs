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
    public partial class Frm_SH_H : Form
    {
        public Frm_SH_H()
        {
            InitializeComponent();
        }

        public decimal OrderTOPayied, FeesValue1, TaxValue1, BoxValue1;
        public Int64 sn;


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
            CombAdressEng.DropDownStyle=combCONOFFICEPHONE.DropDownStyle=combCONOFFICEADRES.DropDownStyle =combEng2.DropDownStyle= combMobileEng.DropDownStyle = combPhoneEng.DropDownStyle = combEmailEng.DropDownStyle = combAdressOffice.DropDownStyle = combPhoneOffice.DropDownStyle = combAdressOwner.DropDownStyle = combEmailOwners.DropDownStyle = combPhoneOwners.DropDownStyle = comb_MobileOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            btn_Save.Enabled = true;
            Clear(groupLisence);
            Clear(groupEng);
            Clear(groupOwners);
            Clear(groupSerchEng);
            Clear(GroupPayed);
            Clear(groupData);
            Clear(groupReport);
            Clear(groupOfficeCon);
            groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = btn_Edit.Enabled = GroupPayed.Enabled = false;
            txt_FessForm.Text = "0";
            groupSerchEng.Enabled = true;
            DAL.Cls_EngineersData.AutoCompletNameCon(txt_searchName, "H");

            txt_OtherData.Text =IDOfficeCons.Text= "";
            txt_IssuedFrom.Enabled = true;

            //txt_Code.Text = DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + "SH_H:" + string.Format("{0:0000000}", Convert.ToInt64(DAL.ClassDAL.GetID("[Form_SH.H]", "[IDForm]")));

            //string now = DateTime.Now.Date.ToString("yy");
            //sn = Convert.ToInt64(DAL.ClassDAL.GetID("[Form_SH.H]", "[SN]"));
            //if (DAL.ClassDAL.Select("select FORMAT( max([DateForm]),'yy' ) from [Form_SH.H] ").Rows[0][0].ToString() == now)
            //{
            //    txt_SerailNumbers.Text = "هـ" + now + string.Format("{0:0000000}", sn);

            //}
            //else
            //{
            //    sn = 1;
            //    txt_SerailNumbers.Text = "هـ" + now + string.Format("{0:0000000}", sn);

            //}


            #region Cons
            DataTable dt = new DataTable();
            dt = DAL.ClassDAL.Select(" SELECT  IDEng, EngName FROM dbo.EngBasicData_Tbl  where ConsultantNo!='' ");
            combEng2.DataSource = dt;
            combEng2.ValueMember = dt.Columns["IDEng"].ToString();
            combEng2.DisplayMember = dt.Columns["EngName"].ToString();
            #endregion
            GroupPayed.Enabled = groupReport.Enabled = false;

            txt_OtherData.Text = "";
            txt_Refrance.Text = DAL.ClassDAL.ReferentialOfficer;
            txt_Manger.Text = DAL.ClassDAL.Manager;
            txt_GeneralManager.Text = DAL.ClassDAL.GeneralManager;



            //  groupSerchEng.Enabled =GroupPayed.Enabled=groupReport.Enabled= true;


            txt_OtherData.Text = "";

            lbl.Text = "";

            DAL.Cls_SH_H.AutoCompletIssuedForm(txt_IssuedFrom);
            DAL.Cls_SH_H.AutoCompletIssuedDepartment(txt_Department);
            DAL.Cls_SH_H.AutoCompletIssuedCity(txt_City);
            DAL.Cls_SH_H.AutoCompletIssuedGovernorate(txt_Governator);

            dateTimePicker1.Value = DateTime.Now;
            DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
            DAL.Cls_SH_H.BussinesStatement(txt_BassinesStatement);
            txt_Area.Text = txt_StampPayied.Text = txt_EngStamp.Text = txt_Rev.Text = "0";


        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SearchOrderPaied.Text != "")
                {
                    if (string.IsNullOrEmpty(txt_ReciptNo.Text))
                    {
                        MessageBox.Show("يجب ادخال رقم الايصال");
                        return;
                    }
                }
                if (string.IsNullOrEmpty(txt_OwnerName.Text))
                {
                    MessageBox.Show("يجب إدخال بيانات المالك");
                    return;
                }
                if (string.IsNullOrEmpty(txt_BassinesStatement.Text) || txt_CostProject.Text == "" || Convert.ToDecimal(txt_CostProject.Text) == 0)
                {
                    MessageBox.Show("يجب إدخال بيانات الرخصة");
                    return;
                }
                //if (string.IsNullOrEmpty(txt_NumberLicense.Text) || string.IsNullOrEmpty(txt_IssuedFrom.Text) || string.IsNullOrEmpty(txt_TilteProject.Text) || string.IsNullOrEmpty(txt_Department.Text) || string.IsNullOrEmpty(txt_City.Text) || string.IsNullOrEmpty(txt_Governator.Text) || string.IsNullOrEmpty(txt_BassinesStatement.Text) || string.IsNullOrEmpty(txt_CostProject.Text) || string.IsNullOrEmpty(txt_CostWord.Text))
                //{
                //    MessageBox.Show("يجب إدخال بيانات الرخصة");
                //    return;
                //}

                string PhoneEng, CONOFFICEPHONE, MobileEng, EmailEng, AdressEng, AdressOffice, PhoneOffice, AdressOwner, PhoneOwners, EmailOwner, MobileOwner, CONOFFICEADRES = "";
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
                // taxCard
                if (TaxCardEng.Text == "")
                {
                    TaxCardEng.Text = "---";
                }

                // CONOFFICEADRES
                if (combCONOFFICEADRES.Text == "")
                {
                    CONOFFICEADRES = "---";
                }
                else
                {
                    CONOFFICEADRES = combCONOFFICEADRES.Text;
                }

                // CONOFFICEPHONE
                if (combCONOFFICEPHONE.Text == "")
                {
                    CONOFFICEPHONE = "---";
                }
                else
                {
                    CONOFFICEPHONE = combCONOFFICEPHONE.Text;
                }
                #endregion

                //DAL.Cls_SH_H.Save(txt_Code.Text, Convert.ToDecimal(txt_FessForm.Text), 4, Convert.ToInt64(IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_NumberLicense.Text, dateDateLicense.Value,   txt_IssuedFrom.Text, txt_TilteProject.Text, txt_Department.Text, txt_City.Text, txt_Governator.Text, txt_BassinesStatement.Text, txt_CostWord.Text, txt_CostProject.Text, txt_OtherData.Text, EmailEng, PhoneEng, MobileEng, AdressEng, AdressOffice, PhoneOffice, AdressOwner, EmailOwner, PhoneOwners, MobileOwner, Convert.ToInt32(DAL.ClassDAL.IDUser), TaxCardEng.Text,txt_TechnicalReport.Text,txt_TechnicalReportNo.Text);
                if (string.IsNullOrEmpty(txtConRegistrationNO.Text))
                {
                    MessageBox.Show("يجب إدخال بيانات التقرير");
                    return;
                }
                txt_FessForm.Text = DAL.Cls_SH_H.Cost().ToString();

                DialogResult re = MessageBox.Show("هل تريد حفظ الشهادة ", "تأكيد حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (re == DialogResult.No)
                {
                    return;
                }
                txt_Code.Text = DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + "SH_H:" + string.Format("{0:0000000}", Convert.ToInt64(DAL.ClassDAL.GetID("[Form_SH.H]", "[IDForm]")));

                string now = DateTime.Now.Date.ToString("yy");
                sn = Convert.ToInt64(DAL.ClassDAL.GetID("[Form_SH.H]", "[SN]"));
                if (DAL.ClassDAL.Select("select FORMAT( max([DateForm]),'yy' ) from [Form_SH.H] ").Rows[0][0].ToString() == now)
                {
                    txt_SerailNumbers.Text = "هـ" + now + string.Format("{0:0000000}", sn);

                }
                else
                {
                    sn = 1;
                    txt_SerailNumbers.Text = "هـ" + now + string.Format("{0:0000000}", sn);

                }
                DAL.Cls_SH_H.Save(txt_Code.Text, Convert.ToDecimal(txt_FessForm.Text), 4, Convert.ToInt64(IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_NumberLicense.Text, dateDateLicense.Value, txt_IssuedFrom.Text, txt_TilteProject.Text, txt_Department.Text, txt_City.Text, txt_Governator.Text, txt_BassinesStatement.Text, txt_CostWord.Text, txt_CostProject.Text, txt_OtherData.Text, EmailEng, PhoneEng, MobileEng, AdressEng, AdressOffice, PhoneOffice, AdressOwner, EmailOwner, PhoneOwners, MobileOwner, Convert.ToInt32(DAL.ClassDAL.IDUser), TaxCardEng.Text, txt_TechnicalReport.Text, txt_TechnicalReportNo.Text, txt_HouseNumber.Text, combEng2.Text, txtConRegistrationNO.Text, txt_ConDivision.Text, txt_conNO.Text, txt_CONSpic.Text, CONOFFICEADRES, CONOFFICEPHONE, txt_Refrance.Text, txt_Manger.Text, txt_GeneralManager.Text, txt_SerailNumbers.Text, DAL.ClassDAL.MangerEngneer, sn, Convert.ToDecimal(txt_Area.Text), Convert.ToDecimal(txt_CostArea.Text), Convert.ToDecimal(txt_EngStamp.Text), Convert.ToDecimal(txt_StampPayied.Text), Convert.ToDecimal(txt_Rev.Text), Convert.ToDecimal(lbl_Fess.Text), Convert.ToDecimal(lbl_Box.Text), Convert.ToDecimal(lbl_Tax.Text), lbl.Text, dateTimePicker1.Value, txt_ReciptNo.Text, txt_SearchOrderPaied.Text,IDOfficeCons.Text);
                btn_New_Click(null, null);


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
                dtSearchByRegistrationNo = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID, IDEng ,EngineeringRecordNo , Specialization,ConsultantNo,TaxCardNo FROM  dbo.EngBasicData_Tbl WHERE(RegistrationNo = '" + txt_SearRegistrationNo.Text + "')");
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
                    TaxCardEng.Text = dtSearchByRegistrationNo.Rows[0]["TaxCardNo"].ToString();
                }
            }
            #endregion

            #region SearchByNationalID
            if (!string.IsNullOrEmpty(txt_NationalID.Text))
            {
                DataTable dtSearchByNationalID = new DataTable();
                dtSearchByNationalID = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID , IDEng,EngineeringRecordNo,Specialization ,ConsultantNo,TaxCardNo FROM  dbo.EngBasicData_Tbl WHERE(NationalID = '" + txt_NationalID.Text + "')");
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
                    TaxCardEng.Text = dtSearchByNationalID.Rows[0]["TaxCardNo"].ToString();
                }
            }
            #endregion

            #region SearchByNameEng
            if (!string.IsNullOrEmpty(txt_searchName.Text))
            {
                DataTable dtSearchByNameEng = new DataTable();
                dtSearchByNameEng = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo,Specialization,ConsultantNo,TaxCardNo,IDOfficeCons FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
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
                    TaxCardEng.Text = dtSearchByNameEng.Rows[0]["TaxCardNo"].ToString();
                    IDOfficeCons.Text = dtSearchByNameEng.Rows[0]["IDOfficeCons"].ToString();
                }
            }
            #endregion

            if (IDEng.Text != "" && IDOfficeCons.Text == "0")
            {
                DataTable dtCount = new DataTable();
                dtCount = DAL.ClassDAL.Select(" SELECT format(GraduationYear, 'yyyy-MM') AS date, ConsultantNo, DATEDIFF(MONTH, GraduationYear, GETDATE()) / 12 AS YearG, IDEng, EngName, (SELECT  COUNT(IDEng) AS Expr1 FROM  dbo.[Form_SH.H] WHERE (IDEng ='" + IDEng.Text + "') AND (ISActive = 1) AND (State = 1)) AS countD, IDOfficeCons FROM  dbo.EngBasicData_Tbl  WHERE (IDEng ='" + IDEng.Text + "')");
                groupOfficeCon.Visible = false;
                #region Eng
                if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {

                        #region Done
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
                        dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDOffice, Address FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                        combAdressOffice.DataSource = null;
                        if (dtOfficeAdre.Rows.Count > 0)
                        {
                            combAdressOffice.DataSource = dtOfficeAdre;
                            combAdressOffice.ValueMember = dtOfficeAdre.Columns[0].ToString();
                            combAdressOffice.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                            //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

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


                            groupSerchEng.Enabled = false;
                        }
                        if (IDEng.Text != "")
                        {
                            groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = true;
                        }

                        #endregion
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = true;

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                    groupSerchEng.Enabled = false;

                    #endregion
            }

            #region Office
            if (IDEng.Text != "" && IDOfficeCons.Text != "0")
            {
                DataTable dtCount = new DataTable();
                dtCount = DAL.ClassDAL.Select(" SELECT format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName,(SELECT  COUNT(IDOfficeCon) AS Expr1 FROM  dbo.[Form_SH.H]  WHERE   (IDOfficeCon = '"+IDOfficeCons.Text+ "') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.EngBasicData_Tbl.IDOfficeCons, dbo.ConsultingOffice_Tbl.OfficeName , dbo.ConsultingOffice_Tbl.OfficeNo FROM   dbo.EngBasicData_Tbl INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice  WHERE (dbo.EngBasicData_Tbl.IDEng = '" + IDEng.Text+"') ");
                groupOfficeCon.Visible = true;
                textBox1.Text = dtCount.Rows[0]["OfficeName"].ToString();
                #region Eng
                if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                {

                    #region Done
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

                //   To do 

                DataTable dtOfficeAdre = new DataTable();
                dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDContanetOffice, Address FROM   dbo.ContanetOfficeCons_tbl where state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
                combAdressOffice.DataSource = null;
                if (dtOfficeAdre.Rows.Count > 0)
                {
                    combAdressOffice.DataSource = dtOfficeAdre;
                    combAdressOffice.ValueMember = dtOfficeAdre.Columns[0].ToString();
                    combAdressOffice.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                    //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                    // Select LindexAdressOffice
                    int LindexAdressOffice = combAdressOffice.Items.Count - 1;
                    combAdressOffice.SelectedIndex = LindexAdressOffice;
                }


                // OFFice Names 
                //DataTable dtOfficeName = new DataTable();
                //dtOfficeName = DAL.ClassDAL.Select("SELECT  IDOffice, OFficeName FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                //combOFFiceName.DataSource = null;
                //if (dtOfficeName.Rows.Count > 0)
                //{
                //    combOFFiceName.DataSource = dtOfficeName;
                //    combOFFiceName.ValueMember = dtOfficeName.Columns[0].ToString();
                //    combOFFiceName.DisplayMember = dtOfficeName.Columns[1].ToString();
                //    //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                //    // Select LindexAdressOffice
                //    int LindexNameOffice = combOFFiceName.Items.Count - 1;
                //    combOFFiceName.SelectedIndex = LindexNameOffice;
                //}




                DataTable dtOfficePhone = new DataTable();
                dtOfficePhone = DAL.ClassDAL.Select("SELECT IDContanetOffice , phone FROM  dbo.ContanetOfficeCons_tbl where  state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
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

                    DataTable dtOfficeMobile = new DataTable();
                    dtOfficeMobile = DAL.ClassDAL.Select("SELECT IDContanetOffice , moble FROM  dbo.ContanetOfficeCons_tbl where  state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
                    combOfficeMobile.DataSource = null;
                    if (dtOfficeMobile.Rows.Count > 0)
                    {
                        combOfficeMobile.DataSource = dtOfficeMobile;
                        combOfficeMobile.ValueMember = dtOfficeMobile.Columns[0].ToString();
                        combOfficeMobile.DisplayMember = dtOfficeMobile.Columns[1].ToString();
                        // Select LindexAdressOffice
                        int LindexPhoneOffice = combOfficeMobile.Items.Count - 1;
                        combOfficeMobile.SelectedIndex = LindexPhoneOffice;
                    }

                    groupSerchEng.Enabled = false;
            
            if (IDEng.Text != "")
            {
                groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = true;
            }

            if (string.IsNullOrEmpty(TaxCardEng.Text))
            {
                TaxCardEng.Text = "---";
            }


                    #endregion
                    txt_OFFiceName.Text = textBox1.Text;
                    txt_OfficeNo.Text= dtCount.Rows[0]["OfficeNo"].ToString();
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = true;

                }

                else
                {
                    MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = false;

                }
                txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                groupSerchEng.Enabled = false;

                #endregion
            }
            #endregion


            txt_Area.Text = txt_StampPayied.Text = txt_EngStamp.Text = txt_Rev.Text = "0";

            combEng2.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void Frm_SH_H_Load(object sender, EventArgs e)
        {
            btn_New_Click(null, null);
        }

        private void combEng2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                lbl_IDCONENG.Text = combEng2.SelectedValue.ToString();
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT   ConsultantNo, EngName, RegistrationNo, Division, Specialization,IDOfficeCons FROM  dbo.EngBasicData_Tbl where IDEng = '" + lbl_IDCONENG.Text + "'");
                txt_conNO.Text = dt.Rows[0]["ConsultantNo"].ToString();
                txtConRegistrationNO.Text = dt.Rows[0]["RegistrationNo"].ToString();
                txt_ConDivision.Text = dt.Rows[0]["Division"].ToString();
                txt_CONSpic.Text = dt.Rows[0]["Specialization"].ToString();
                string IDOfficeCons= dt.Rows[0]["IDOfficeCons"].ToString();
                if (IDOfficeCons!="0")
                {
                    DataTable dtOfficeAdre = new DataTable();
                    dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDContanetOffice, Address FROM   dbo.ContanetOfficeCons_tbl where state  =1 and IDOfficeCons='" + IDOfficeCons+ "' ");
                    combCONOFFICEADRES.DataSource = null;
                    if (dtOfficeAdre.Rows.Count > 0)
                    {
                        combCONOFFICEADRES.DataSource = dtOfficeAdre;
                        combCONOFFICEADRES.ValueMember = dtOfficeAdre.Columns[0].ToString();
                        combCONOFFICEADRES.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                        //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                        // Select LindexAdressOffice
                        int LindexAdressOffice = combCONOFFICEADRES.Items.Count - 1;
                        combCONOFFICEADRES.SelectedIndex = LindexAdressOffice;
                    }
                    DataTable dtCONOFFICEPHONE = new DataTable();
                    dtCONOFFICEPHONE = DAL.ClassDAL.Select("SELECT IDContanetOffice , phone FROM  dbo.ContanetOfficeCons_tbl where  state  =1 and IDOfficeCons='" + IDOfficeCons+ "' ");
                    combPhoneOffice.DataSource = null;
                    if (dtCONOFFICEPHONE.Rows.Count > 0)
                    {
                        combCONOFFICEPHONE.DataSource = dtCONOFFICEPHONE;
                        combCONOFFICEPHONE.ValueMember = dtCONOFFICEPHONE.Columns[0].ToString();
                        combCONOFFICEPHONE.DisplayMember = dtCONOFFICEPHONE.Columns[1].ToString();
                        // Select LindexAdressOffice
                        int LindexPhoneOffice = combCONOFFICEPHONE.Items.Count - 1;
                        combCONOFFICEPHONE.SelectedIndex = LindexPhoneOffice;
                    }
                }
                else
                {
                    #region Office
                    DataTable dt_Adrs = new DataTable();
                    dt_Adrs = DAL.ClassDAL.Select("SELECT Address, Phone, IDEng, IDOffice FROM dbo.Office_Tbl where IDEng = '" + lbl_IDCONENG.Text + "' and state='1' ");
                    if (dt_Adrs.Rows.Count > 0)
                    {
                        combCONOFFICEADRES.DataSource = dt_Adrs;
                        combCONOFFICEADRES.ValueMember = dt_Adrs.Columns["IDOffice"].ToString();
                        combCONOFFICEADRES.DisplayMember = dt_Adrs.Columns["Address"].ToString();

                        combCONOFFICEPHONE.DataSource = dt_Adrs;
                        combCONOFFICEPHONE.ValueMember = dt_Adrs.Columns["IDOffice"].ToString();
                        combCONOFFICEPHONE.DisplayMember = dt_Adrs.Columns["Phone"].ToString();

                    }
                    #endregion
                }




            }
            catch
            {
                return;
            }

        }

        private void txt_CostProject_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                txt_CostArea.Text = txt_CostProject.Text;
                DataTable dt = DAL.ClassDAL.Select("select MAx([BusinessValue]) from [dbo].[BusinessValue_Tbl] ");
                if (Convert.ToDecimal(txt_CostArea.Text) > Convert.ToDecimal(dt.Rows[0][0].ToString()))
                {
                    MessageBox.Show("يتم الرجوع الى رئيس لجنة مزاولة المهنة لحساب مبلغ التوريد والدمغة الهندسية ويتم كتابة ما تم حسابة ");
                    return;
                }
                //txt_Rev.Text = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                decimal fees = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text));
                txt_EngStamp.Text = DAL.Cls_BusinessValue.StampEng(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                decimal StampPaied = Convert.ToDecimal(txt_StampPayied.Text);
                OrderTOPayied = ((fees + Convert.ToDecimal(txt_EngStamp.Text)) - StampPaied);
                txt_Rev.Text = OrderTOPayied.ToString("#.##");
                lbl_Tax.Text = DAL.Cls_BusinessValue.TaxValue.ToString("#.##");
                lbl_Fess.Text = DAL.Cls_BusinessValue.FessValue.ToString("#.##");
                lbl_Box.Text = DAL.Cls_BusinessValue.BoxValue.ToString("#.##");
                if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
                {
                    txt_Rev.Text = "0";
                }
                clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_CostProject.Text), 2, "جنيهاً", "قرش", true, true);
                lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);

            }
            catch
            {
                txt_Rev.Text = "0";
                clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_CostProject.Text), 2, "جنيهاً", "قرش", true, true);
                lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);

                //MessageBox.Show(ex.Message);
                return;
            }

        }

        private void txt_StampPayied_TextChanged(object sender, EventArgs e)
        {
            try
            {

           
            if (txt_SearchOrderPaied.Text != "")
            {
                return;
            }
            if (string.IsNullOrEmpty(txt_StampPayied.Text))
            {
                txt_StampPayied.Text = "0";
            }
            decimal stam, EngStamp, StampPayied = 0;
            StampPayied = Convert.ToDecimal(txt_StampPayied.Text);
            EngStamp = Convert.ToDecimal(txt_EngStamp.Text);
            //stam = EngStamp - StampPayied;
            clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
          
            txt_Rev.Text = Convert.ToDecimal(OrderTOPayied - StampPayied).ToString("#.##");
            if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
            {
                txt_Rev.Text = "0";
            }
            lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);
            }
            catch 
            {
                return;
            }
        }

        private void checkStamp_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_SearchOrderPaied.Text != "")
            {
                return;
            }

            if (checkStamp.Checked == true)
            {
                txt_StampPayied.Visible = true;
                txt_StampPayied.Text = txt_EngStamp.Text;
                txt_StampPayied_TextChanged(null, null);
            }
            else
            {
                txt_StampPayied.Text = "0";
                txt_StampPayied.Visible = false;
            }
        }

        private void txt_OwnerName_Validating(object sender, CancelEventArgs e)
        {
            btn_SearchOwner_Click(null, null);
            txt_TilteProject.Text = combAdressOwner.Text;

        }

        private void txt_CostArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SearchOrderPaied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT * FROM  dbo.Tbl_OrderPaid  where IDOrederPayed ='" + txt_SearchOrderPaied.Text + "' and TypeForm ='نموذج ش .هـ'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("رقم إذن التوريد غير صحيح");
                    groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = GroupPayed.Enabled = false;
                    return;
                }
                DataTable dt2 = new DataTable();
                dt2 = DAL.ClassDAL.Select("select OrderID from [Form_SH.H] where OrderID='" + txt_SearchOrderPaied.Text + "' and State=1 ");
                if (dt2.Rows.Count > 0)
                {
                    MessageBox.Show("تم عمل الشهادة لهذا الاذن ");
                    groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = GroupPayed.Enabled = false;
                    return;
                }
                IDEng.Text = dt.Rows[0]["IDEng"].ToString();
                lblIDOwner.Text = dt.Rows[0]["IDOwner"].ToString();
                IDOfficeCons.Text = dt.Rows[0]["IDOfficeCons"].ToString();

                #region Office
                if (IDEng.Text != "" && IDOfficeCons.Text != "0")
                {
                    DataTable dtSearchByIDEng = new DataTable();
                    dtSearchByIDEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date,TaxCardNo,EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo, ConsultantNo FROM  dbo.EngBasicData_Tbl WHERE(IDEng = '" + IDEng.Text + "')");
                    if (dtSearchByIDEng.Rows.Count > 0)
                    {
                        EngName.Text = dtSearchByIDEng.Rows[0]["EngName"].ToString();
                        NationalIDEng.Text = dtSearchByIDEng.Rows[0]["NationalID"].ToString();
                        RegistrationNoEng.Text = dtSearchByIDEng.Rows[0]["RegistrationNo"].ToString();
                        DivisionEng.Text = dtSearchByIDEng.Rows[0]["Division"].ToString();
                        // IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                        lbl_EngineeringRecordNo.Text = dtSearchByIDEng.Rows[0]["EngineeringRecordNo"].ToString();
                        TaxCardEng.Text = dtSearchByIDEng.Rows[0]["TaxCardNo"].ToString();
                        txt_GenrataionYear.Text = dtSearchByIDEng.Rows[0]["date"].ToString();
                        txt_ConsultantNo.Text = dtSearchByIDEng.Rows[0]["ConsultantNo"].ToString();
                    }
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" SELECT format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName,(SELECT  COUNT(IDOfficeCon) AS Expr1 FROM  dbo.[Form_SH.H]  WHERE   (IDOfficeCon = '" + IDOfficeCons.Text + "') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.EngBasicData_Tbl.IDOfficeCons, dbo.ConsultingOffice_Tbl.OfficeName , dbo.ConsultingOffice_Tbl.OfficeNo FROM   dbo.EngBasicData_Tbl INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice  WHERE (dbo.EngBasicData_Tbl.IDEng = '" + IDEng.Text + "') ");
                    groupOfficeCon.Visible = true;
                    textBox1.Text = dtCount.Rows[0]["OfficeName"].ToString();
                    #region Eng
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {

                        #region Done
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

                        //   To do 

                        DataTable dtOfficeAdre = new DataTable();
                        dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDContanetOffice, Address FROM   dbo.ContanetOfficeCons_tbl where state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
                        combAdressOffice.DataSource = null;
                        if (dtOfficeAdre.Rows.Count > 0)
                        {
                            combAdressOffice.DataSource = dtOfficeAdre;
                            combAdressOffice.ValueMember = dtOfficeAdre.Columns[0].ToString();
                            combAdressOffice.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                            //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                            // Select LindexAdressOffice
                            int LindexAdressOffice = combAdressOffice.Items.Count - 1;
                            combAdressOffice.SelectedIndex = LindexAdressOffice;
                        }


                        // OFFice Names 
                        //DataTable dtOfficeName = new DataTable();
                        //dtOfficeName = DAL.ClassDAL.Select("SELECT  IDOffice, OFficeName FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                        //combOFFiceName.DataSource = null;
                        //if (dtOfficeName.Rows.Count > 0)
                        //{
                        //    combOFFiceName.DataSource = dtOfficeName;
                        //    combOFFiceName.ValueMember = dtOfficeName.Columns[0].ToString();
                        //    combOFFiceName.DisplayMember = dtOfficeName.Columns[1].ToString();
                        //    //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

                        //    // Select LindexAdressOffice
                        //    int LindexNameOffice = combOFFiceName.Items.Count - 1;
                        //    combOFFiceName.SelectedIndex = LindexNameOffice;
                        //}




                        DataTable dtOfficePhone = new DataTable();
                        dtOfficePhone = DAL.ClassDAL.Select("SELECT IDContanetOffice , phone FROM  dbo.ContanetOfficeCons_tbl where  state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
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

                        DataTable dtOfficeMobile = new DataTable();
                        dtOfficeMobile = DAL.ClassDAL.Select("SELECT IDContanetOffice , moble FROM  dbo.ContanetOfficeCons_tbl where  state  =1 and IDOfficeCons='" + IDOfficeCons.Text + "' ");
                        combOfficeMobile.DataSource = null;
                        if (dtOfficeMobile.Rows.Count > 0)
                        {
                            combOfficeMobile.DataSource = dtOfficeMobile;
                            combOfficeMobile.ValueMember = dtOfficeMobile.Columns[0].ToString();
                            combOfficeMobile.DisplayMember = dtOfficeMobile.Columns[1].ToString();
                            // Select LindexAdressOffice
                            int LindexPhoneOffice = combOfficeMobile.Items.Count - 1;
                            combOfficeMobile.SelectedIndex = LindexPhoneOffice;
                        }

                        groupSerchEng.Enabled = false;

                        if (IDEng.Text != "")
                        {
                            groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = true;
                        }

                        if (string.IsNullOrEmpty(TaxCardEng.Text))
                        {
                            TaxCardEng.Text = "---";
                        }


                        #endregion
                        txt_OFFiceName.Text = textBox1.Text;
                        txt_OfficeNo.Text = dtCount.Rows[0]["OfficeNo"].ToString();
                        txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = true;

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = groupReport.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                    groupSerchEng.Enabled = false;

                    #endregion
                }
                #endregion


                if (IDEng.Text != "" && IDOfficeCons.Text == "0")
                {
                    DataTable dtSearchByIDEng = new DataTable();
                    dtSearchByIDEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date,TaxCardNo,EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo, ConsultantNo FROM  dbo.EngBasicData_Tbl WHERE(IDEng = '" + IDEng.Text + "')");
                    if (dtSearchByIDEng.Rows.Count > 0)
                    {
                        EngName.Text = dtSearchByIDEng.Rows[0]["EngName"].ToString();
                        NationalIDEng.Text = dtSearchByIDEng.Rows[0]["NationalID"].ToString();
                        RegistrationNoEng.Text = dtSearchByIDEng.Rows[0]["RegistrationNo"].ToString();
                        DivisionEng.Text = dtSearchByIDEng.Rows[0]["Division"].ToString();
                        // IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                        lbl_EngineeringRecordNo.Text = dtSearchByIDEng.Rows[0]["EngineeringRecordNo"].ToString();
                        TaxCardEng.Text = dtSearchByIDEng.Rows[0]["TaxCardNo"].ToString();
                        txt_GenrataionYear.Text = dtSearchByIDEng.Rows[0]["date"].ToString();
                        txt_ConsultantNo.Text = dtSearchByIDEng.Rows[0]["ConsultantNo"].ToString();
                    }


                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select  format(GraduationYear,'yyyy-MM') as date, ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.H] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {
                        // done
                        #region Done
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
                        dtOfficeAdre = DAL.ClassDAL.Select("SELECT  IDOffice, Address FROM   dbo.Office_Tbl where state  =1 and IDEng='" + IDEng.Text + "' ");
                        combAdressOffice.DataSource = null;
                        if (dtOfficeAdre.Rows.Count > 0)
                        {
                            combAdressOffice.DataSource = dtOfficeAdre;
                            combAdressOffice.ValueMember = dtOfficeAdre.Columns[0].ToString();
                            combAdressOffice.DisplayMember = dtOfficeAdre.Columns[1].ToString();
                            //TaxCardEng.Text = dtOfficeAdre.Rows[0]["TaxCardNo"].ToString();

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


                            groupSerchEng.Enabled = false;
                        }
                        if (IDEng.Text != "")
                        {
                            groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = true;
                        }

                        #endregion
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                    groupSerchEng.Enabled = false;
                }


                groupEng.Enabled = groupOwners.Enabled = groupLisence.Enabled  =groupReport.Enabled= GroupPayed.Enabled = true;

                txt_CostProject.Text = txt_CostArea.Text = dt.Rows[0]["CostProject"].ToString();
                txt_CostWord.Text = dt.Rows[0]["CostProjectWord"].ToString();
                txt_Rev.Text = dt.Rows[0]["OrderPayed"].ToString();
                lbl.Text = dt.Rows[0]["OrderPayedWord"].ToString();
                lbl_Fess.Text = dt.Rows[0]["Fess"].ToString();
                lbl_Box.Text = dt.Rows[0]["box"].ToString();
                lbl_Tax.Text = dt.Rows[0]["tax"].ToString();
                txt_EngStamp.Text = dt.Rows[0]["StampEng"].ToString();
                txt_StampPayied.Text = dt.Rows[0]["StampPrevPaied"].ToString();
                txt_OwnerName.Text = dt.Rows[0]["NameOwner"].ToString();
                combAdressOwner.DropDownStyle = combPhoneOwners.DropDownStyle = comb_MobileOwner.DropDownStyle = ComboBoxStyle.DropDown;
                combAdressOwner.Text = dt.Rows[0]["Adres"].ToString();
                combPhoneOwners.Text = dt.Rows[0]["Phone"].ToString();
                comb_MobileOwner.Text = dt.Rows[0]["Mobile"].ToString();
                combEmailOwners.Text = dt.Rows[0]["Email"].ToString();
                txt_NationIDOwner.Text = dt.Rows[0]["NationalID"].ToString();
                txt_TilteProject.Text = dt.Rows[0]["TitleProject"].ToString();
                txt_BassinesStatement.Text = dt.Rows[0]["BusinesStatement"].ToString();
                txt_IssuedFrom.Text = dt.Rows[0]["IssuedFrom"].ToString();
                txt_IssuedFrom.Enabled = false;
                txt_OwnerName.Enabled = combAdressOwner.Enabled = combPhoneOwners.Enabled = comb_MobileOwner.Enabled =
                  combEmailOwners.Enabled = txt_NationIDOwner.Enabled = txt_TilteProject.Enabled =
                  txt_BassinesStatement.Enabled = txt_CostProject.Enabled = txt_CostArea.Enabled =
                  txt_Rev.Enabled = txt_EngStamp.Enabled = txt_StampPayied.Enabled = txt_CostWord.Enabled = btn_SearchOwner.Enabled = checkStamp.Enabled = false;


            }

        }

        private void txt_searchName_Enter(object sender, EventArgs e)
        {
            txt_SearchOrderPaied.Text = "";
        }

        private void txt_SearchOrderPaied_Enter(object sender, EventArgs e)
        {
            DAL.ClassDAL.ClearGroup(groupSerchEng);
        }

        private void txt_EngStamp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_CostProject_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseCurrancy(e, txt_CostProject);

        }

        private void bt_SearchOffice_Click(object sender, EventArgs e)
        {

            try
            {


                PL.Frm_SearchFormToEditORDelete frm = new Frm_SearchFormToEditORDelete();
                frm.lbl_TypeForm.Text = "SH_H";
                frm.ShowDialog();
                if (frm.dt.Rows.Count > 0)
                {
                    CombAdressEng.DropDownStyle=combCONOFFICEADRES.DropDownStyle=combCONOFFICEPHONE.DropDownStyle =combEng2.DropDownStyle= combMobileEng.DropDownStyle = combPhoneEng.DropDownStyle = combEmailEng.DropDownStyle = combAdressOffice.DropDownStyle = combPhoneOffice.DropDownStyle = combAdressOwner.DropDownStyle = combEmailOwners.DropDownStyle = combPhoneOwners.DropDownStyle = comb_MobileOwner.DropDownStyle = ComboBoxStyle.Simple;

                    EngName.Text = frm.dt.Rows[0]["EngName"].ToString();
                    RegistrationNoEng.Text = frm.dt.Rows[0]["RegistrationNo"].ToString();
                    DivisionEng.Text = frm.dt.Rows[0]["Division"].ToString();
                    lbl_EngineeringRecordNo.Text = frm.dt.Rows[0]["EngineeringRecordNo"].ToString();
                    NationalIDEng.Text = frm.dt.Rows[0]["NationalID"].ToString();
                    CombAdressEng.Text = frm.dt.Rows[0]["EngAdress"].ToString();
                    combPhoneEng.Text = frm.dt.Rows[0]["EngPhone"].ToString();
                    combMobileEng.Text = frm.dt.Rows[0]["EngMobile"].ToString();
                    combEmailEng.Text = frm.dt.Rows[0]["EngEmail"].ToString();
                    TaxCardEng.Text = frm.dt.Rows[0]["TaxCardNo"].ToString();
                    combAdressOffice.Text = frm.dt.Rows[0]["OfficeAdress"].ToString();
                    combPhoneOffice.Text = frm.dt.Rows[0]["OfficePhone"].ToString();

                    txt_OwnerName.Text = frm.dt.Rows[0]["Name"].ToString();
                    txt_NationIDOwner.Text = frm.dt.Rows[0]["Expr1"].ToString();
                    combAdressOwner.Text = frm.dt.Rows[0]["OwnerAdrees"].ToString();
                    combEmailOwners.Text = frm.dt.Rows[0]["OwnerEmail"].ToString();
                    combPhoneOwners.Text = frm.dt.Rows[0]["OwnerPhone"].ToString();
                    comb_MobileOwner.Text = frm.dt.Rows[0]["OwnerMobile"].ToString();

                    txt_NumberLicense.Text = frm.dt.Rows[0]["NumberLicense"].ToString();
                    txt_IssuedFrom.Text = frm.dt.Rows[0]["IssuedFrom"].ToString();
                    dateDateLicense.Value = Convert.ToDateTime(frm.dt.Rows[0]["DateLicense"].ToString());
                    txt_TilteProject.Text = frm.dt.Rows[0]["TitleProject"].ToString();
                    txt_Department.Text = frm.dt.Rows[0]["Department"].ToString();
                    txt_City.Text = frm.dt.Rows[0]["City"].ToString();
                    txt_Governator.Text = frm.dt.Rows[0]["Governorate"].ToString();
                    txt_BassinesStatement.Text = frm.dt.Rows[0]["BusinessStatement"].ToString();
                    txt_CostProject.Text = frm.dt.Rows[0]["CostLicense"].ToString();
                    txt_CostWord.Text = frm.dt.Rows[0]["CostWord"].ToString();
                    txt_OtherData.Text = frm.dt.Rows[0]["OtherData"].ToString();

                    txt_Refrance.Text = frm.dt.Rows[0]["RerfEmp"].ToString();
                    txt_Manger.Text = frm.dt.Rows[0]["Manager"].ToString();
                    txt_GeneralManager.Text = frm.dt.Rows[0]["GeneralManager"].ToString();


                    checkStamp.Checked = false;
                    txt_ReciptNo.Text = frm.dt.Rows[0]["ReciptNo"].ToString();
                    txt_CostArea.Text = frm.dt.Rows[0]["CostLicense"].ToString();
                    txt_EngStamp.Text = frm.dt.Rows[0]["StampEng"].ToString();
                    txt_StampPayied.Text = frm.dt.Rows[0]["StampPrevPaied"].ToString();
                    txt_Rev.Text = frm.dt.Rows[0]["OrderPaied"].ToString();
                    lbl.Text = frm.dt.Rows[0]["OrderWord"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(frm.dt.Rows[0]["DateForm"].ToString());

                    lbl_IDForm.Text = frm.dt.Rows[0]["IDForm"].ToString();
                    lbl_IDRev.Text = frm.dt.Rows[0]["IDRevenue"].ToString();
                    //
                    txt_TechnicalReport.Text= frm.dt.Rows[0]["TechnicalReport"].ToString();
                    txt_TechnicalReportNo.Text= frm.dt.Rows[0]["TechnicalReportNo"].ToString();

                    combEng2.Text = frm.dt.Rows[0]["ConsultantEngineer"].ToString();

                    txtConRegistrationNO.Text = frm.dt.Rows[0]["ConsultantRegist"].ToString();
                    txt_conNO.Text = frm.dt.Rows[0]["ConsultantNo"].ToString();
                    txt_ConDivision.Text= frm.dt.Rows[0]["ConsultantDivaion"].ToString();
                    txt_CONSpic.Text= frm.dt.Rows[0]["ConsultantSpecializt"].ToString();
                    combCONOFFICEPHONE.Text= frm.dt.Rows[0]["ConsultantOfficePhone"].ToString();
                    combCONOFFICEADRES.Text= frm.dt.Rows[0]["ConsultantOfficeAddres"].ToString();
                    IDEng.Text = frm.dt.Rows[0]["IDEng"].ToString();
                    lblIDOwner.Text = frm.dt.Rows[0]["IDOwner"].ToString();
                    txt_SerailNumbers.Text = frm.dt.Rows[0]["SerailNumber"].ToString();
                    groupData.Enabled = groupEng.Enabled = groupLisence.Enabled = groupOwners.Enabled = GroupPayed.Enabled = groupSerchEng.Enabled = groupReport.Enabled = false;
                    btn_Save.Enabled = false;
                    btn_Edit.Enabled = true;

                }
                else
                {
                    btn_New_Click(null, null);
                }

            }
            catch
            {
                btn_New_Click(null, null);

                return;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            PL.Frm_ResionDelete frm = new PL.Frm_ResionDelete("SH_H", lbl_IDForm.Text, lbl_IDRev.Text, IDEng.Text, lblIDOwner.Text, txt_SerailNumbers.Text);
            frm.ShowDialog();
            btn_New_Click(null, null);
        }

        private void txt_CostProject_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CostProject.Text))
            {
                txt_CostProject.Text = "0";
            }
        }

        private void txt_searchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = groupData.Enabled = groupEng.Enabled = groupLisence.Enabled = groupOwners.Enabled = GroupPayed.Enabled = groupSerchEng.Enabled = groupReport.Enabled = true;

            Restart();
            txt_CostProject.Text = "0";
            #region deletePower
            if (DAL.ClassDAL.DeleteForm == true)
            {
                bt_SearchOffice.Enabled = true;
            }
            else
            {
                bt_SearchOffice.Enabled = false;
            }
            #endregion
        }

        private void btn_SearchOwner_Click(object sender, EventArgs e)
        {
            lblIDOwner.Text = "";
            //DAL.Clss_Owners.SearchBYNationalID(txt_NationIDOwner.Text, lblIDOwner, txt_OwnerName);
            DAL.Clss_Owners.SearchBYNationalName(txt_NationIDOwner, lblIDOwner, txt_OwnerName);
            DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
            if (lblIDOwner.Text == "")
            {
                DAL.Clss_Owners.SearchBYNationalName(txt_NationIDOwner, lblIDOwner, txt_OwnerName);
                DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
                txt_OwnerName.Focus();
            }
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
            
        }
    }
}
