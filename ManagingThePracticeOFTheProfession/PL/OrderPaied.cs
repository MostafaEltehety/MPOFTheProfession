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
    public partial class OrderPaied : Form
    {
        public decimal OrderTOPayied, FeesValue1, TaxValue1, BoxValue1;


        public OrderPaied()
        {
            InitializeComponent();
            restart();
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

        void restart()
        {
            groupData.Enabled = groupOwners.Enabled=groupDataForm.Enabled=groupOfficeCon.Enabled =GroupPayed.Enabled= false;
            groupBox1.Enabled = true;
            DAL.ClassDAL.ClearGroup(groupBox1);
            DAL.ClassDAL.ClearGroup(groupData);
            DAL.ClassDAL.ClearGroup(groupOwners);
            DAL.ClassDAL.ClearGroup(groupDataForm);
            DAL.ClassDAL.ClearGroup(groupOfficeCon);
            IDEng.Text=lblIDOwner.Text= IDOfficeCons.Text = lbl.Text= "";
            DAL.Clss_Owners.AutoCompletName(txt_OwnerName);
            txt_CostArea.Text=txt_Area.Text= txt_StampPayied.Text = txt_EngStamp.Text = txt_Rev.Text = "0";
            groupCanceled.Visible = false;
            label2.Visible = btn_Search.Visible = txt_searchName.Visible = true;
            groupBox4.Enabled = true;

        }



        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

            //try
            //{

           
            if (string.IsNullOrEmpty(txt_searchName.Text.Trim()))
            {
                txt_searchName.Focus();
                return;
            }
            groupData.Enabled=groupOwners.Enabled = groupDataForm.Enabled =GroupPayed.Enabled= true;
            groupBox1.Enabled = false;
           
            if (comboType.Text == "نموذج ش . د")
            {
                DAL.Cls_SH_D.AutoCompletIssuedForm(txt_IssuedFrom);
                #region D
                #region SearchByNameEng

                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date,TaxCardNo,EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        txt_GenrataionYear.Text = dtSearchByNameEng.Rows[0]["date"].ToString();
                    }
                }
                #endregion

                if (IDEng.Text != "")
                {
                    DAL.Cls_SH_D.BussinesStatement(txt_BassinesStatement);
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.D] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) < 7 && Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {

                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }

                    else if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) >= 7 && Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 7)
                    {
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (7 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) < 7)
                        {
                            txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();

                        }
                        else
                        {
                            txt_NoAllowed.Text = (7 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        }
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        groupData.Enabled = groupOwners.Enabled=groupDataForm.Enabled=GroupPayed.Enabled = false;

                    }
                }

                #endregion

            }
            if (comboType.Text == "نموذج ش . د.ت")
            {
                DAL.Cls_SH_D2.AutoCompletIssuedForm(txt_IssuedFrom);

                #region D2
                #region SearchByNameEng

                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date,TaxCardNo,EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        txt_GenrataionYear.Text = dtSearchByNameEng.Rows[0]["date"].ToString();
                    }
                }
                #endregion

                if (IDEng.Text != "")
                {

                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.D2] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) < 7 && Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 3)
                    {
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (3 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }
                    else if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) >= 7 && dtCount.Rows[0]["ConsultantNo"].ToString() == "" && Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)

                    {
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        if (Convert.ToDecimal(dtCount.Rows[0]["YearG"].ToString()) < 7)
                        {
                            txt_NoAllowed.Text = (3 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();

                        }
                        else
                        {
                            txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        }
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                    }
                    
                }

                #endregion
            }
           if (comboType.Text == "نموذج ش . ج")
           {
                DAL.Cls_SH_G.AutoCompletIssuedForm(txt_IssuedFrom);

                #region G
                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date, TaxCardNo , EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        txt_GenrataionYear.Text = dtSearchByNameEng.Rows[0]["date"].ToString();
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    }
                }
                #endregion

                if (IDEng.Text != "")
                {
                    DAL.Cls_SH_G.BussinesStatement(txt_BassinesStatement);
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.G] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 10)
                    {

                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (10 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (10 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                }
                #endregion
           }
            if (comboType.Text == "نموذج ش . ج.ت")
            {
                DAL.Cls_SH_G2.AutoCompletIssuedForm(txt_IssuedFrom);

                #region G2
                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT format(GraduationYear,'yyyy-MM') as date, TaxCardNo , EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        txt_GenrataionYear.Text = dtSearchByNameEng.Rows[0]["date"].ToString();
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    }
                }
                #endregion

                if (IDEng.Text != "")
                {
                    DAL.Cls_SH_G.BussinesStatement(txt_BassinesStatement);
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.G2] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 8)
                    {

                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (8 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (8 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                }
                #endregion
            }

            if (comboType.Text == "نموذج ش . ب")
           {
                DAL.Cls_SH_B.AutoCompletIssuedForm(txt_IssuedFrom);

                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.EngBasicData_Tbl.IDEng, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.TaxCardNo, dbo.ConsultingOffice_Tbl.IDOffice  FROM dbo.EngBasicData_Tbl INNER JOIN  dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice WHERE(EngName = '" + txt_searchName.Text + "')");
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                        IDOfficeCons.Text = dtSearchByNameEng.Rows[0]["IDOffice"].ToString();

                    }
                }
                #endregion
                #region B
                if (IDEng.Text != "")
                {
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select("SELECT  format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName, (SELECT COUNT(IDOffice) AS CountForms FROM   dbo.[Form_SH.B] WHERE (IDOffice = '" + IDOfficeCons.Text + "') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.IDOffice  FROM  dbo.EngBasicData_Tbl INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice  WHERE (dbo.EngBasicData_Tbl.IDEng = '" + IDEng.Text + "')");
                    IDOfficeCons.Text = dtCount.Rows[0]["IDOffice"].ToString();
                    textBox1.Text = dtCount.Rows[0]["OfficeName"].ToString();
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 15)
                    {
                        txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowedOffice.Text = (15 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         groupDataForm.Enabled= groupOwners.Enabled  = GroupPayed.Enabled = false;

                    }
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (15 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                }
                #endregion
            }

            if (comboType.Text== "نموذج ش . ب.ت")
            {
                DAL.Cls_SH_B2.AutoCompletIssuedForm(txt_IssuedFrom);

                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT  dbo.EngBasicData_Tbl.EngName, dbo.EngBasicData_Tbl.RegistrationNo, dbo.EngBasicData_Tbl.Division, dbo.EngBasicData_Tbl.NationalID, dbo.EngBasicData_Tbl.IDEng, dbo.EngBasicData_Tbl.EngineeringRecordNo,   dbo.EngBasicData_Tbl.Specialization, dbo.EngBasicData_Tbl.ConsultantNo, dbo.EngBasicData_Tbl.TaxCardNo, dbo.ConsultingOffice_Tbl.IDOffice  FROM dbo.EngBasicData_Tbl INNER JOIN  dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice WHERE(EngName = '" + txt_searchName.Text + "')");
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                        IDOfficeCons.Text = dtSearchByNameEng.Rows[0]["IDOffice"].ToString();

                    }
                }
                #endregion
                 #region B
                if (IDEng.Text != "")
                {
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select("SELECT  format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName, (SELECT COUNT(IDOffice) AS CountForms FROM   dbo.[Form_SH.B2] WHERE (IDOffice = '" + IDOfficeCons.Text + "') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.IDOffice  FROM  dbo.EngBasicData_Tbl INNER JOIN dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice  WHERE (dbo.EngBasicData_Tbl.IDEng = '" + IDEng.Text + "')");
                    IDOfficeCons.Text = dtCount.Rows[0]["IDOffice"].ToString();
                    textBox1.Text = dtCount.Rows[0]["OfficeName"].ToString();
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 15)
                    {
                        txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowedOffice.Text = (15 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupDataForm.Enabled = groupOwners.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (15 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                }
                #endregion
            }

            if (comboType.Text == "نموذج ش .هـ")
            {
                DAL.Cls_SH_H.AutoCompletIssuedForm(txt_IssuedFrom);

                #region H
                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT EngName, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo,Specialization,ConsultantNo,TaxCardNo , IDOfficeCons FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                        IDOfficeCons.Text = dtSearchByNameEng.Rows[0]["IDOfficeCons"].ToString();
                    }
                }
                #endregion

                #region Office
                if (IDEng.Text != "" && IDOfficeCons.Text!="0")
                {
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" SELECT  format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName, (SELECT COUNT(IDOfficeCon) AS CountForms  FROM  dbo.[Form_SH.H] WHERE  (IDOfficeCon = '"+IDOfficeCons.Text+"') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.IDOffice FROM   dbo.EngBasicData_Tbl INNER JOIN  dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice WHERE (dbo.EngBasicData_Tbl.IDEng = '"+IDEng.Text+"') ");
                    groupOfficeCon.Visible = true;
                    groupData.Visible = false;
                    textBox1.Text= dtCount.Rows[0]["OfficeName"].ToString();
                    DAL.Cls_SH_H.BussinesStatement(txt_BassinesStatement);
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {


                        txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();

                }




                #endregion




                if (IDEng.Text != "" && IDOfficeCons.Text=="0")
                {
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select  format(GraduationYear,'yyyy-MM') as date, ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.H] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");
                    groupOfficeCon.Visible = false;
                    groupData.Visible = true;
                    DAL.Cls_SH_H.BussinesStatement(txt_BassinesStatement);
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {


                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();

                }
                #endregion
            }
           if (comboType.Text == "نموذج ش . و")
           {
                DAL.Cls_SH_W.AutoCompletIssuedForm(txt_IssuedFrom);

                #region W
                #region SearchByNameEng
                if (!string.IsNullOrEmpty(txt_searchName.Text))
                {
                    DAL.Cls_SH_W.BussinesStatement(txt_BassinesStatement);
                    DataTable dtSearchByNameEng = new DataTable();
                    dtSearchByNameEng = DAL.ClassDAL.Select("SELECT IDOfficeCons, EngName,TaxCardNo, RegistrationNo, Division, NationalID , IDEng ,EngineeringRecordNo,Specialization,ConsultantNo FROM  dbo.EngBasicData_Tbl WHERE(EngName = '" + txt_searchName.Text + "')");
                    IDOfficeCons.Text = dtSearchByNameEng.Rows[0]["IDOfficeCons"].ToString();


                    if (dtSearchByNameEng.Rows.Count > 0)
                    {
                        IDEng.Text = dtSearchByNameEng.Rows[0]["IDEng"].ToString();
                    }
                }
                #endregion


                #region Office
                if (IDEng.Text != "" && IDOfficeCons.Text != "0" )
                {
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" SELECT  format(dbo.EngBasicData_Tbl.GraduationYear, 'yyyy-MM') AS date, dbo.EngBasicData_Tbl.ConsultantNo, DATEDIFF(MONTH, dbo.EngBasicData_Tbl.GraduationYear, GETDATE()) / 12 AS YearG, dbo.EngBasicData_Tbl.IDEng,  dbo.EngBasicData_Tbl.EngName, (SELECT COUNT(IDOfficeCon) AS CountForms  FROM  dbo.[Form_SH.W] WHERE  (IDOfficeCon = '" + IDOfficeCons.Text + "') AND (ISActive = 1) AND (State = 1)) AS countD, dbo.ConsultingOffice_Tbl.OfficeName, dbo.ConsultingOffice_Tbl.IDOffice FROM   dbo.EngBasicData_Tbl INNER JOIN  dbo.ConsultingOffice_Tbl ON dbo.EngBasicData_Tbl.IDOfficeCons = dbo.ConsultingOffice_Tbl.IDOffice WHERE (dbo.EngBasicData_Tbl.IDEng = '" + IDEng.Text + "') ");
                    groupOfficeCon.Visible = true;
                    groupData.Visible = false;
                    textBox1.Text = dtCount.Rows[0]["OfficeName"].ToString();// todo ***************************************
                    DAL.Cls_SH_H.BussinesStatement(txt_BassinesStatement);
                    if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                    {


                        txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                    }

                    else
                    {
                        MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                    }
                    txt_NoInOprationOffice.Text = dtCount.Rows[0]["countD"].ToString();
                    txt_NoAllowedOffice.Text = (5 - Convert.ToInt16(txt_NoInOprationOffice.Text)).ToString();
                    txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                    txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();

                }




                #endregion




                if (IDEng.Text != ""& IDOfficeCons.Text=="0")
                {
                    groupOfficeCon.Visible = false;
                    groupData.Visible = true;
                    DataTable dtCount = new DataTable();
                    dtCount = DAL.ClassDAL.Select(" select  format(GraduationYear,'yyyy-MM') as date, ConsultantNo, datediff(MONTH,GraduationYear, getdate() ) / 12 as YearG ,IDEng,EngName ,( select count(IDEng)  from [Form_SH.W] where IDEng='" + IDEng.Text + "' and ISActive=1 and State=1 )as countD from EngBasicData_Tbl  where IDEng ='" + IDEng.Text + "'");

                    if (!string.IsNullOrEmpty(dtCount.Rows[0]["ConsultantNo"].ToString().Trim()))
                    {
                        if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 5)
                        {

                
                            txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                            txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                            txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                        }

                        else
                        {
                            MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                        }
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (5 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                      
                    }
                    else
                    {
                        if (Convert.ToDecimal(dtCount.Rows[0]["countD"].ToString()) < 3)
                        {

                  
                            txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                            txt_NoAllowed.Text = (3 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                            txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();

                        }

                        else
                        {
                            MessageBox.Show("تم اكتمال عدد الشهادات المسموح بها ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            groupData.Enabled = groupOwners.Enabled = groupDataForm.Enabled = GroupPayed.Enabled = false;

                        }
                        txt_NoInOpration.Text = dtCount.Rows[0]["countD"].ToString();
                        txt_NoAllowed.Text = (3 - Convert.ToInt16(txt_NoInOpration.Text)).ToString();
                        txt_NoYearsExperance.Text = dtCount.Rows[0]["YearG"].ToString();
                        txt_GenrataionYear.Text = dtCount.Rows[0]["date"].ToString();
                
                    }
                }


                #endregion
           }
                // if (comboType.Text == "نموذج الغاء")
                //{

                //}


            //}
            //catch
            //{
            //    btn_New_Click(null,null);
            //    txt_searchName.Focus();
            //    return;
            //}
        }

        private void comboType_Validating(object sender, CancelEventArgs e)
        {
            comboType.Text = "";
            groupCanceled.Visible = false;
            label2.Visible = btn_Search.Visible = txt_searchName.Visible = true;

            if (comboType.Text == "نموذج ش . د")
            {
                DAL.Cls_EngineersData.AutoCompletNameNOTCON(txt_searchName);
                groupOfficeCon.Visible = false;
            }
            if (comboType.Text == "نموذج ش . د.ت")
            {
                DAL.Cls_EngineersData.AutoCompletName(txt_searchName);
                groupOfficeCon.Visible = false;
            }
            if (comboType.Text == "نموذج ش . ج")
            {
                DAL.Cls_EngineersData.AutoCompletNameCon(txt_searchName);
                groupOfficeCon.Visible = false;
            }
            if (comboType.Text == "نموذج ش . ج.ت")
            {
                DAL.Cls_EngineersData.AutoCompletNameCon(txt_searchName);
                groupOfficeCon.Visible = false;
            }
            if (comboType.Text == "نموذج ش . ب")
            {
                DAL.Cls_EngineersData.AutoCompletNameConOffice(txt_searchName);
                groupOfficeCon.Visible = true;
            }
            if (comboType.Text == "نموذج ش . ب.ت")
            {
                DAL.Cls_EngineersData.AutoCompletNameConOffice(txt_searchName);
                groupOfficeCon.Visible = true;
            }
            if (comboType.Text == "نموذج ش .هـ")
            {
                DAL.Cls_EngineersData.AutoCompletNameCon(txt_searchName,"H");
                groupOfficeCon.Visible = true;
            }
            if (comboType.Text == "نموذج ش . و")
            {
                DAL.Cls_EngineersData.AutoCompletNameConLarger7Year(txt_searchName);
                groupOfficeCon.Visible = false;
            }
            if (comboType.Text == "نموذج الغاء")
            {
                groupCanceled.Visible = true;
                label2.Visible = btn_Search.Visible = txt_searchName.Visible = false;
                button1.Enabled = false;
                txt_NoForm.Focus();
            }
            if (comboType.Text.Contains("إعتماد تقرير فنى-الحماية المدنية"))
            {
                PL.Frm_TechnicalReportCivilProtection f = new Frm_TechnicalReportCivilProtection("order");
                f.ShowDialog();
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            restart();
                button1.Enabled = true;

            Clear(groupBox2);
            Clear(groupBox1);
            Clear(groupBox3);
            Clear(groupBox4);
            comboType.SelectedIndex = 0;
            if (groupCanceled.Visible==true)
            {
                groupBox1.Enabled = true;
                Clear(groupBox2);
                Clear(groupBox1);
                DAL.Cls_Cancel.AutoCompletPOstOffice(txt_PostOffice);
                DAL.Cls_Cancel.AutoCompletResion(txt_Resion);
              
            }
            comboBox1.SelectedIndex = 0;
            comboType_Validating(null, null);
            label35.Visible=txtFessLargeAmount.Visible=false;

        }

        private void btn_SearchOwner_Click(object sender, EventArgs e)
        {
            //combAdressOwner.DataSource = combEmailOwners.DataSource = combAdressOwner.DataSource = combPhoneOwners.DataSource = null;
         

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

                foreach (DataRow row in dtAdres.Rows)
                {
                    if (row["Address"].ToString().Trim() == "")
                    {
                        row.Delete();
                    }
                 
                }

                    combAdressOwner.DataSource = dtAdres;
                    combAdressOwner.ValueMember = dtAdres.Columns["Address"].ToString();
               

                DataTable dtPhone = new DataTable();
                dtPhone = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                foreach (DataRow row in dtPhone.Rows)
                {
                    if (row["Phone"].ToString().Trim() == "")
                    {
                        row.Delete();
                    }

                }
                combPhoneOwners.DataSource = dtPhone;
                    combPhoneOwners.ValueMember = dtPhone.Columns["Phone"].ToString();
               

                DataTable dtMobile = new DataTable();
                dtMobile = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                foreach (DataRow row in dtMobile.Rows)
                {
                    if (row["Mobile"].ToString().Trim() == "")
                    {
                        row.Delete();
                    }

                }
                comb_MobileOwner.DataSource = dtMobile;
                    comb_MobileOwner.ValueMember = dtMobile.Columns["Mobile"].ToString();
            

                DataTable dtEmail = new DataTable();
                dtEmail = DAL.Clss_Owners.FillCombox(lblIDOwner.Text);
                foreach (DataRow row in dtEmail.Rows)
                {
                    if (row["Email"].ToString().Trim() == "")
                    {
                        row.Delete();
                    }

                }
                combEmailOwners.DataSource = dtEmail;
                    combEmailOwners.ValueMember = dtEmail.Columns["Email"].ToString();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void txt_OwnerName_Validating(object sender, CancelEventArgs e)
        {
            btn_SearchOwner_Click(null, null);
        }

        private void txt_CostProject_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseCurrancy(e, txt_CostProject);
        }

        private void txt_CostProject_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CostProject.Text))
            {
                txt_CostProject.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Payed = "0";
            if (groupCanceled.Visible==true)
            {
                if (string.IsNullOrEmpty(txt_Resion.Text) || string.IsNullOrEmpty(txt_PostOffice.Text))
                {
                    txt_Resion.Focus();
                    return;
                }
                if (comboBox1.SelectedIndex==0)
                {
                    DataTable dt = DAL.ClassDAL.Select("select * from BusinessValue_Tbl where TypePayed='الغاء شهادة اشراف' ");
                    decimal value = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString()) + ((Convert.ToDecimal(dt.Rows[0]["Amount"].ToString()) * (Convert.ToDecimal(dt.Rows[0]["Taxes"].ToString()))) + (Convert.ToDecimal(dt.Rows[0]["box"].ToString())));
                    Payed =txt_Rev.Text= value.ToString("#.##");
                    //lbl.Text = "فقط اثنان وثمانون جنيهاً لاغير ";
                    clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                    txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(value.ToString("#.##")), 2, "جنيهاً", "قرش", true, true);
                    lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(value.ToString("#.##")), 2, "جنيهاً", "قرشاً", true, true);

                }
                else
                {

                    DataTable dt = DAL.ClassDAL.Select("select * from BusinessValue_Tbl where TypePayed='محضر استلام' ");
                    decimal value = Convert.ToDecimal(dt.Rows[0]["box"].ToString());
                    Payed = txt_Rev.Text = value.ToString("#.##");
   
                    clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                    txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(value.ToString("#.##")), 2, "جنيهاً", "قرش", true, true);
                    lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(value.ToString("#.##")), 2, "جنيهاً", "قرشاً", true, true);


                    //Payed = txt_Rev.Text = "50";
                    //lbl .Text = "فقط خمسون جنيهاً لاغير ";
                }
            }
            else
            {

            if (groupOwners.Enabled == false)
            {
                return;
            }
            if (string.IsNullOrEmpty(txt_OwnerName.Text)|| string.IsNullOrEmpty(txt_TilteProject.Text)||string.IsNullOrEmpty(txt_BassinesStatement.Text)|| Convert.ToDecimal(txt_CostProject.Text)==0|| txt_CostProject.Text=="")
            {
                MessageBox.Show("يجب ادخال البيانات الاساسية");
                return;
            }
           
             
            }

            if (groupCanceled.Visible == false)
            {
                DAL.Cls_OrderPaied.Save(Convert.ToInt64(IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_OwnerName.Text, combAdressOwner.Text, combPhoneOwners.Text, comb_MobileOwner.Text, combEmailOwners.Text, txt_NationIDOwner.Text, txt_TilteProject.Text, txt_BassinesStatement.Text, Convert.ToDecimal(txt_CostProject.Text), comboType.Text, txt_CostWord.Text, Convert.ToDecimal(txt_Rev.Text), lbl.Text, DAL.ClassDAL.ReferentialOfficer, Convert.ToDecimal(lbl_Fess.Text), Convert.ToDecimal(lbl_Box.Text), Convert.ToDecimal(lbl_Tax.Text), Convert.ToDecimal(txt_EngStamp.Text), Convert.ToDecimal(txt_StampPayied.Text), IDOfficeCons.Text, txt_IssuedFrom.Text, txt_Resion.Text, txt_PostOffice.Text, Payed, txt_NoForm.Text);

                Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
                Reports.Print.CryOrderPayed crpt = new Reports.Print.CryOrderPayed();
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT dbo.Tbl_OrderPaid.IssuedFrom , dbo.Tbl_OrderPaid.IDOrederPayed,  dbo.EngBasicData_Tbl.EngName, dbo.Tbl_OrderPaid.BusinesStatement, dbo.Tbl_OrderPaid.OrderPayed, dbo.Tbl_OrderPaid.OrderPayedWord, dbo.OwnerData_Tbl.Name,   dbo.Tbl_OrderPaid.RefEmp, dbo.Tbl_OrderPaid.Fess, dbo.Tbl_OrderPaid.box, dbo.Tbl_OrderPaid.tax, dbo.Tbl_OrderPaid.TypeForm , dbo.Tbl_OrderPaid.CostProject,dbo.Tbl_OrderPaid.StampEng,dbo.Tbl_OrderPaid.StampPrevPaied FROM  dbo.Tbl_OrderPaid INNER JOIN dbo.EngBasicData_Tbl ON dbo.Tbl_OrderPaid.IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.Tbl_OrderPaid.IDOwner = dbo.OwnerData_Tbl.IDOwner  where  dbo.Tbl_OrderPaid.IDOrederPayed =(select  max(dbo.Tbl_OrderPaid.IDOrederPayed)as ID  from dbo.Tbl_OrderPaid)");
                crpt.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = crpt;
                btn_New_Click(null, null);
                frm.ShowDialog();
            }
            else   // Canceld
            {
                //MessageBox.Show(comboType.Text);
                //MessageBox.Show(comboType.SelectedText);
                comboType.Text = "نموذج الغاء";
                DAL.Cls_OrderPaied.Save(Convert.ToInt64(IDEng.Text), Convert.ToInt64(lblIDOwner.Text), txt_OwnerName.Text, combAdressOwner.Text, combPhoneOwners.Text, comb_MobileOwner.Text, combEmailOwners.Text, txt_NationIDOwner.Text, txt_TilteProject.Text, "إلغاء شهادة اشراف", Convert.ToDecimal(txt_CostProject.Text), comboType.Text, txt_CostWord.Text, Convert.ToDecimal(txt_Rev.Text), lbl.Text, DAL.ClassDAL.ReferentialOfficer, Convert.ToDecimal(lbl_Fess.Text), Convert.ToDecimal(lbl_Box.Text), Convert.ToDecimal(lbl_Tax.Text), Convert.ToDecimal(txt_EngStamp.Text), Convert.ToDecimal(txt_StampPayied.Text),"0", txt_IssuedFrom.Text, txt_Resion.Text, txt_PostOffice.Text, Payed,txt_NoForm.Text);

                Reports.Frm_SH_D frm = new Reports.Frm_SH_D();
                Reports.Print.CryOrderCanceld crpt = new Reports.Print.CryOrderCanceld();
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("SELECT dbo.Tbl_OrderPaid.IssuedFrom , dbo.Tbl_OrderPaid.IDOrederPayed,  dbo.EngBasicData_Tbl.EngName, dbo.Tbl_OrderPaid.BusinesStatement, dbo.Tbl_OrderPaid.OrderPayed, dbo.Tbl_OrderPaid.OrderPayedWord, dbo.OwnerData_Tbl.Name,   dbo.Tbl_OrderPaid.RefEmp, dbo.Tbl_OrderPaid.Fess, dbo.Tbl_OrderPaid.box, dbo.Tbl_OrderPaid.tax, dbo.Tbl_OrderPaid.TypeForm , dbo.Tbl_OrderPaid.CostProject,dbo.Tbl_OrderPaid.StampEng,dbo.Tbl_OrderPaid.StampPrevPaied , dbo.Tbl_OrderPaid.Payed FROM  dbo.Tbl_OrderPaid INNER JOIN dbo.EngBasicData_Tbl ON dbo.Tbl_OrderPaid.IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.Tbl_OrderPaid.IDOwner = dbo.OwnerData_Tbl.IDOwner  where  dbo.Tbl_OrderPaid.IDOrederPayed =(select  max(dbo.Tbl_OrderPaid.IDOrederPayed)as ID  from dbo.Tbl_OrderPaid)");
                crpt.SetDataSource(dt);
                crpt.SetParameterValue("NoForm", txt_NoForm.Text);
                frm.crystalReportViewer1.ReportSource = null;
                frm.crystalReportViewer1.ReportSource = crpt;
                btn_New_Click(null, null);
                frm.ShowDialog();
            }

            btn_New_Click(null, null);
        }

        private void comboType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_Searsh_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txt_Barcode.Text)&& txt_NoForm.Text!="")
            //{
            //    return;
            //}
            try
            {
                button1.Enabled = true;

                DAL.Cls_Cancel.AutoCompletPOstOffice(txt_PostOffice);
            DAL.Cls_Cancel.AutoCompletResion(txt_Resion);
            txt_Number.Text = txt_date.Text = txt_EngName.Text = txt_OwnerName.Text = txt_Busnies.Text = txt_TitleProject.Text = txt_NumberLicen.Text = txt_DateLicen.Text = txt_IssuedFrom.Text = txt_CostProject.Text = "";
            DataTable dt = new DataTable();

            dt = DAL.Cls_Cancel.getSearshData(txt_NoForm.Text, txt_Barcode.Text);
            DataTable dt2 = new DataTable();
             
            dt2 = DAL.Cls_Cancel.searchInStope(txt_NoForm.Text,txt_Barcode.Text);
            if (dt2.Rows.Count > 0)
            {
                MessageBox.Show("تم الالغاء مسبقاً بتاريخ" + " " + dt2.Rows[0]["Date"].ToString());
                    button1.Enabled = false;
                    return;
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("لاتوجد بيانات ");
                    button1.Enabled = false;

                    return;
            }
            groupBox1.Enabled = false;
            lbl.Text = dt.Rows[0]["IDForm"].ToString();
            txt_Number.Text = dt.Rows[0]["SerailNumber"].ToString();
            txt_date.Text = dt.Rows[0]["Date1"].ToString();
            txt_EngName.Text = dt.Rows[0]["EngName"].ToString();
            txt_OwnerNameCan.Text = dt.Rows[0]["Name"].ToString();
            txt_Busnies.Text = dt.Rows[0]["BusinessStatement"].ToString();
            txt_TitleProject.Text = dt.Rows[0]["TitleProject"].ToString();
            txt_NumberLicen.Text = dt.Rows[0]["NumberLicense"].ToString();
            txt_DateLicen.Text = dt.Rows[0]["Date2"].ToString();
            txt_IssuedFromCan.Text = dt.Rows[0]["IssuedFrom"].ToString();
            txt_CostProjectCan.Text = Convert.ToDecimal(dt.Rows[0]["CostLicense"].ToString()).ToString("#.##");
            txt_NoForm.Text = dt.Rows[0]["SerailNumber"].ToString();
            comboBox1.SelectedIndex = 0;
            groupBox4.Enabled = false;

            IDEng.Text = DAL.ClassDAL.Select("SELECT IDEng FROM dbo.EngBasicData_Tbl where EngName= '"+ dt.Rows[0]["EngName"].ToString() + "'").Rows[0][0].ToString();
            lblIDOwner.Text = DAL.ClassDAL.Select("SELECT IDOwner FROM dbo.OwnerData_Tbl where Name= '" + dt.Rows[0]["Name"].ToString() + "'").Rows[0][0].ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btn_New_Click(null, null);
                return;
            }


        }

        private void txt_Barcode_TextChanged(object sender, EventArgs e)
        {
            txt_NoForm.Text = "";
        }

        private void txt_NoForm_TextChanged(object sender, EventArgs e)
        {
            txt_Barcode.Text = "";
        }

        private void txt_NoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Searsh_Click(null, null);
            }
        }

        private void txt_searchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Search_Click(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //PL.Frm_Main2 main = new PL.Frm_Main2();
            //TabPage Current_tab = main.tabform.SelectedTab;
            //main.tabform.TabPages.Remove(Current_tab);
            //this.Close();
        }

        private void OrderPaied_Load(object sender, EventArgs e)
        {
            btn_New_Click(null, null);
        }

        private void txt_PostOffice_Validating(object sender, CancelEventArgs e)
        {
            if (txt_PostOffice.Text.Contains("محضر")==true)
            {
                comboType.SelectedIndex = 1;
            }
        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Barcode.Text))
            {
                return;
            }
            if (e.KeyCode==Keys.Enter)
            {
                btn_Searsh_Click(null, null);
            }
        }

        private void txtFessLargeAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //lbl_Tax.Visible=lbl_Box.Visible=false;
                txt_Rev.ReadOnly=txt_EngStamp.ReadOnly=true;
                //label35.Visible=txtFessLargeAmount.Visible=false;
                txt_CostArea.Text = txt_CostProject.Text;
                //DataTable dt = DAL.ClassDAL.Select("select MAx([BusinessValue]) from [dbo].[BusinessValue_Tbl] ");
                //if (Convert.ToDecimal(txt_CostArea.Text) > Convert.ToDecimal(dt.Rows[0][0].ToString()))
                //{
                //    //    MessageBox.Show("يتم الرجوع الى رئيس لجنة مزاولة المهنة لحساب مبلغ التوريد والدمغة الهندسية ويتم كتابة ما تم حسابة ");

                //    MessageBox.Show("يتم الرجوع الى رئيس لجنة مزاولة المهنة لحساب الرسوم الاساسية للشهادة ويتم كتابة ما تم حسابة ");

                //    //txt_StampPayied.ReadOnly=txt_Rev.ReadOnly=txt_EngStamp.ReadOnly=false;
                //    label35.Visible= txtFessLargeAmount.Visible=true;
                //    txtFessLargeAmount.Focus();
                //    //lbl_Tax.Visible=lbl_Box.Visible=true;
                //    //return;
                //}
                //txt_Rev.Text = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                decimal fees = 0;
                //if (Convert.ToDecimal(txt_CostArea.Text) > Convert.ToDecimal(dt.Rows[0][0].ToString()))
                //{
                    fees=Convert.ToDecimal(Convert.ToDecimal(txtFessLargeAmount.Text).ToString("#.##"));
                //}
                //else
                //{
                //    fees = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text));
                //}
                decimal amount =fees+ (fees*DAL.Cls_BusinessValue.TaxOnly())+DAL.Cls_BusinessValue.BoxOnly();
                txt_EngStamp.Text = DAL.Cls_BusinessValue.StampEng(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                decimal StampPaied = Convert.ToDecimal(txt_StampPayied.Text);

                OrderTOPayied = ((amount + Convert.ToDecimal(txt_EngStamp.Text)) - StampPaied);
                txt_Rev.Text = OrderTOPayied.ToString("#.##");
                lbl_Tax.Text = (fees*DAL.Cls_BusinessValue.TaxOnly()).ToString("#.##");
                lbl_Fess.Text = Convert.ToDecimal(fees).ToString("#.##");
                lbl_Box.Text = DAL.Cls_BusinessValue.BoxOnly().ToString("#.##");
                if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
                {
                    txt_Rev.Text = "0";
                }
                clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_CostProject.Text), 2, "جنيهاً", "قرش", true, true);
                lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void txt_CostProject_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //lbl_Tax.Visible=lbl_Box.Visible=false;
                txt_Rev.ReadOnly=txt_EngStamp.ReadOnly=true;
                txt_CostArea.Text = txt_CostProject.Text;
                DataTable dt = DAL.ClassDAL.Select("select MAx([BusinessValue]) from [dbo].[BusinessValue_Tbl] ");
                if (Convert.ToDecimal(txt_CostArea.Text) > Convert.ToDecimal(dt.Rows[0][0].ToString()))
                {
                    //    MessageBox.Show("يتم الرجوع الى رئيس لجنة مزاولة المهنة لحساب مبلغ التوريد والدمغة الهندسية ويتم كتابة ما تم حسابة ");

                    MessageBox.Show("يتم الرجوع الى رئيس لجنة مزاولة المهنة لحساب الرسوم الاساسية للشهادة ويتم كتابة ما تم حسابة ");

                    //txt_StampPayied.ReadOnly=txt_Rev.ReadOnly=txt_EngStamp.ReadOnly=false;
                    label35.Visible= txtFessLargeAmount.Visible=true;

                    //lbl_Tax.Visible=lbl_Box.Visible=true;
                    //return;
                }
                //txt_Rev.Text = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                // =0;
                //if (Convert.ToDecimal(txt_CostArea.Text) > Convert.ToDecimal(dt.Rows[0][0].ToString()))
                //{
                //    fees=Convert.ToDecimal(Convert.ToDecimal(txtFessLargeAmount.Text).ToString("#.##"));
                //}
                //else
                //{
                    decimal fees = DAL.Cls_BusinessValue.RevReci(Convert.ToDecimal(txt_CostArea.Text));
                //}
                if (comboType.Text.Contains("ت")) fees=DAL.Cls_BusinessValue.RevReci();
                 txt_EngStamp.Text = DAL.Cls_BusinessValue.StampEng(Convert.ToDecimal(txt_CostArea.Text)).ToString("#.##");
                decimal StampPaied = Convert.ToDecimal(txt_StampPayied.Text);
                OrderTOPayied = ((fees + Convert.ToDecimal(txt_EngStamp.Text)) - StampPaied);
                txt_Rev.Text = OrderTOPayied.ToString("#.##");
                lbl_Tax.Text = DAL.Cls_BusinessValue.TaxValue.ToString("#.##");
                lbl_Fess.Text = DAL.Cls_BusinessValue.FessValue.ToString("#.##");
                if (comboType.Text.Contains("ت")) lbl_Fess.Text=DAL.Cls_BusinessValue.FessValue.ToString("#.##");
                if (comboType.Text.Contains("ت")) lbl_Tax.Text=DAL.Cls_BusinessValue.TaxValue.ToString("#.##");

                lbl_Box.Text = DAL.Cls_BusinessValue.BoxValue.ToString("#.##");
                if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
                {
                    txt_Rev.Text = "0";
                }
                clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
                txt_CostWord.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_CostProject.Text), 2, "جنيهاً", "قرش", true, true);
                lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);
                txtFessLargeAmount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void checkStamp_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkStamp.Checked == true)
            {
                txt_StampPayied.Visible = true;
                txt_StampPayied.Text = txt_EngStamp.Text;
                txt_StampPayied_TextChanged(null, null);
                if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
                {
                    txt_Rev.Text = "0";
                    lbl.Text = "";
                }
                if (string.IsNullOrEmpty(txt_StampPayied.Text))
                {
                    txt_StampPayied.Text = "0";
                }
            }
            else
            {
                txt_StampPayied.Text = "0";
                txt_StampPayied.Visible = false;
            }
        }

        private void txt_StampPayied_TextChanged(object sender, EventArgs e)
        {
            try
            {
        
            if (string.IsNullOrEmpty(txt_StampPayied.Text))
            {
                txt_StampPayied.Text = "0";
            }
            
            decimal stam, EngStamp, StampPayied = 0;
            StampPayied = Convert.ToDecimal(txt_StampPayied.Text);
            EngStamp = Convert.ToDecimal(txt_EngStamp.Text);
            //stam = EngStamp - StampPayied;
            clsHoorofArabic.clsHoorofArabic wrd = new clsHoorofArabic.clsHoorofArabic();
            if (string.IsNullOrEmpty(txt_CostProject.Text) || txt_CostProject.Text == "0")
            {
                txt_Rev.Text = "0";
            }
            txt_Rev.Text = Convert.ToDecimal(OrderTOPayied - StampPayied).ToString("#.##");
            lbl.Text = wrd.تحويل_الأرقام_الى_حروف(Convert.ToDecimal(txt_Rev.Text), 2, "جنيهاً", "قرشاً", true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
