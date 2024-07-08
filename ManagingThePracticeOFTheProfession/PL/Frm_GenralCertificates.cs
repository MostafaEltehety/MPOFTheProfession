using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_GenralCertificates : Form
    {
        public DataTable dtIssuedFrom;
        public DataTable dtFilterIssued=new DataTable();
        public Frm_GenralCertificates()
        {
            InitializeComponent();
        }

        private void Frm_GenralCertificates_Load(object sender, EventArgs e)
        {
            DAL.Cls_PrintForms.FillComb(combType,1);
        }

        private void combType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                if (combType.SelectedValue.ToString() == "2")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.D]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "3")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.G]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "4")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.H]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "5")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.W]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "6")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.B]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "8")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.D2]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "9")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.G2]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
                if (combType.SelectedValue.ToString() == "10")
                {
                    dtIssuedFrom = new DataTable();
                    dtIssuedFrom = DAL.ClassDAL.Select("select distinct IssuedFrom from [Form_SH.B2]  where IssuedFrom is not null and IssuedFrom !='' order by IssuedFrom");
                    listBoxAllIssued.DataSource = null;
                    listBoxAllIssued.DataSource = dtIssuedFrom;
                    listBoxAllIssued.DisplayMember = dtIssuedFrom.Columns[0].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection sourceItems = listBoxAllIssued.SelectedItems;

            if (listBoxAllIssued.SelectedItem != null)
                foreach (var item in sourceItems)
                {
                    bool exist = false;
                    DataRowView row = (DataRowView)item;
                    if (dataGridView1.Rows.Count>=0)
                    {
                        foreach (DataGridViewRow dgr in dataGridView1.Rows)
                        {
                            if (row[0].ToString() == dgr.Cells[0].Value.ToString())
                            {
                                exist = true;
                                break;
                            }
                        }
                    }
                    if (exist == true)
                        continue;
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["IssuedFrom"].Value = row[0].ToString();
                    
                }
  
        }

        private void txt_IssuedSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtIssuedFrom);
            dv.RowFilter = $"IssuedFrom LIKE '%{txt_IssuedSearch.Text}%'";
            listBoxAllIssued.DataSource = dv;
        }
    
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count<=0)
            {
                MessageBox.Show("يجب تحديد المركز الصادر منه الشهادة");
                return;
            }
            string where = string.Empty;

            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (where == string.Empty)
                    where = "\'" + dgr.Cells[0].Value.ToString() + "\'";
                else
                    where +=" , "+ "\'" +dgr.Cells[0].Value.ToString() + "\'";
            }
            DataTable dt = new DataTable();
            if (combType.SelectedValue.ToString() == "2")// Form_SH.D
            {
            dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D].SerailNumber, dbo.[Form_SH.D].DateForm, dbo.[Form_SH.D].NumberLicense, dbo.[Form_SH.D].YearLicense, dbo.[Form_SH.D].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.D] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.D].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.D].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.D].DateForm ");

                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.د");
                frm.ShowDialog();
                
            }
            if (combType.SelectedValue.ToString() == "3")// Form_SH.G
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G].SerailNumber, dbo.[Form_SH.G].DateForm, dbo.[Form_SH.G].NumberLicense, dbo.[Form_SH.G].YearLicense, dbo.[Form_SH.G].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.G] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.G].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.G].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.G].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.ج");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "4")// Form_SH.H
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.H].SerailNumber, dbo.[Form_SH.H].DateForm, dbo.[Form_SH.H].NumberLicense, YEAR(dbo.[Form_SH.H].DateLicense) as YearLicense, dbo.[Form_SH.H].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.H] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.H].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.H].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.H].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.H].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.H].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.هـ");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "5")// Form_SH.W
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.W].SerailNumber, dbo.[Form_SH.W].DateForm, dbo.[Form_SH.W].NumberLicense, YEAR(dbo.[Form_SH.W].DateLicense) as YearLicense, dbo.[Form_SH.W].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.W] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.W].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.W].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.W].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.W].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.W].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.و");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "6")// Form_SH.B
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B].SerailNumber, dbo.[Form_SH.B].DateForm, dbo.[Form_SH.B].NumberLicense,  YEAR(dbo.[Form_SH.B].DateLicense) as YearLicense, dbo.[Form_SH.B].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.B] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.B].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.B].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.B].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.ب");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "8")// Form_SH.D2
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.D2].SerailNumber, dbo.[Form_SH.D2].DateForm, dbo.[Form_SH.D2].NumberLicense, dbo.[Form_SH.D2].YearLicense, dbo.[Form_SH.D2].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.D2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.D2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.D2].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.D2].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.D2].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.D2].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.د.ت");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "9")// Form_SH.G2
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.G2].SerailNumber, dbo.[Form_SH.G2].DateForm, dbo.[Form_SH.G2].NumberLicense, dbo.[Form_SH.G2].YearLicense, dbo.[Form_SH.G2].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.G2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.G2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.G2].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.G2].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.G2].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.G2].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.ج.ت");
                frm.ShowDialog();
            }
            if (combType.SelectedValue.ToString() == "10")// Form_SH.B2
            {
                dt = DAL.ClassDAL.Select($" SELECT  dbo.EngBasicData_Tbl.EngName, dbo.OwnerData_Tbl.Name, dbo.[Form_SH.B2].SerailNumber, dbo.[Form_SH.B2].DateForm, dbo.[Form_SH.B2].NumberLicense,  YEAR(dbo.[Form_SH.B2].DateLicense) as YearLicense, dbo.[Form_SH.B2].IssuedFrom ,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS number FROM   dbo.[Form_SH.B2] INNER JOIN dbo.EngBasicData_Tbl ON dbo.[Form_SH.B2].IDEng = dbo.EngBasicData_Tbl.IDEng INNER JOIN dbo.OwnerData_Tbl ON dbo.[Form_SH.B2].IDOwner = dbo.OwnerData_Tbl.IDOwner where(CONVERT(date, dbo.[Form_SH.B2].DateForm) between CONVERT(date, '{dateTimeFrom.Value.ToString("yyyy-MM-dd")}') and CONVERT(date, '{dateTimeTo.Value.ToString("yyyy-MM-dd")}')) and[Form_SH.B2].state != 0 and IssuedFrom in ({ where})  order by[Form_SH.B2].DateForm ");
                PL.Frm_PrintRepor frm = new Frm_PrintRepor(dt, dateTimeFrom.Value.ToString("yyyy-MM-dd"), dateTimeTo.Value.ToString("yyyy-MM-dd"), "نموذج ش.ب.ت");
                frm.ShowDialog();
            }
        }
    }
    }
