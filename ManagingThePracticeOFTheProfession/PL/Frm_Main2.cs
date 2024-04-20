using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_Main2 : Form
    {
        bool closeform = false;
        public Frm_Main2()
        {
            InitializeComponent();
        }
     
        public Frm_Main2(string Title,Form f)
        {
            InitializeComponent();
            TabToOpenForm(Title, f);
        }

        public void TabToOpenForm(Button btnName,Form frm)
        {
            TabPage tabpage = new TabPage { Text = toolTip1.GetToolTip(btnName) };
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            frm.TopLevel = false;
            frm.Parent = tabpage;
            //tabpage.Font = new Font("Tahoma", 8);

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabform.SelectedTab = tabpage;
        }


        public void TabToOpenForm(string title, Form frm)
        {
            TabPage tabpage = new TabPage { Text = title };
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            tabform.TabPages.Add(tabpage);
            frm.TopLevel = false;
            frm.Parent =tabpage;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        public void NewTab()
        {
            TabPage tabpage = new TabPage { Text = "Report" };
            tabpage.BorderStyle = BorderStyle.Fixed3D;
            this.tabform.TabPages.Add(tabpage);
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("هل تريد الخروج من البرنامج ؟", "إغلاق البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.No)
            {
                return;
            }
            Application.Exit();
        }

        private void btn_OrderPayed_Click(object sender, EventArgs e)
        {
            //PL.Forms.OrderPaied frm = new Forms.OrderPaied() { Dock=DockStyle.Fill,TopLevel=false,TopMost=false};
            //this.PContainer.Controls.Add(frm);
            //frm.Show();

            PL.Forms.OrderPaied frm = new Forms.OrderPaied();
            TabToOpenForm(btn_OrderPayed, frm);

        }

        private void btn_Owner_Click(object sender, EventArgs e)
        {
            PL.Frm_Owners frm = new Frm_Owners();
            TabToOpenForm(btn_Owner, frm);
        }

        private void btn_FormD_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D frm = new PL.Forms.Frm_SH_D();
            TabToOpenForm(btn_FormD, frm);

        }

        private void btn_FormD2_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D2 frm = new Forms.Frm_SH_D2();
            TabToOpenForm(btn_FormD2, frm);
        }

        private void btn_FormG_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G frm = new Forms.Frm_SH_G();
            TabToOpenForm(btn_FormG, frm);

        }

        private void btn_FormG2_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G2 frm = new Forms.Frm_SH_G2();
            TabToOpenForm(btn_FormG2, frm);
        }

        private void btn_FormB_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_B frm = new Forms.Frm_SH_B();
            TabToOpenForm(btn_FormB, frm);
        }

        private void btn_FormB2_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_B2 frm = new Forms.Frm_SH_B2();
            TabToOpenForm(btn_FormB2, frm);
        }

        private void btn_FormH_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_H frm = new Forms.Frm_SH_H();
            TabToOpenForm(btn_FormH, frm);
        }

        private void btn_FormW_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_W frm = new Forms.Frm_SH_W();
            TabToOpenForm(btn_FormW, frm);
        }

        private void btn_FormStope_Click(object sender, EventArgs e)
        {
            PL.Frm_CanceledForm frm = new PL.Frm_CanceledForm();
            TabToOpenForm(btn_FormStope, frm);
        }

        private void btn_FormPrint_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_PrintForm frm = new Forms.Frm_PrintForm();
            TabToOpenForm(btn_FormPrint, frm);
        }

        private void btn_FormPrintStope_Click(object sender, EventArgs e)
        {
            PL.Frm_PrintCanceldForm frm = new Frm_PrintCanceldForm();
            TabToOpenForm(btn_FormPrintStope, frm);
        }

        private void btn_BussinesStatement_Click(object sender, EventArgs e)
        {
            PL.Frm_BusinessStatementEng frm = new Frm_BusinessStatementEng();
            TabToOpenForm(btn_BussinesStatement, frm);
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            PL.Frm_BackUp frm = new PL.Frm_BackUp();
            TabToOpenForm(btn_Backup, frm);

        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_Restore frm = new PL.Forms.Frm_Restore();
            TabToOpenForm(btn_Restore, frm);
        }

        //public void CloseFromOtheFrorm(TabPage page)
        //{
        //    //closeform = close;
        //    //button2_Click(null, null);
        //    tabform.TabPages.Remove(tabform.);

        //}

        public void IDEngFromBusinesStatement(string IDEn)
        {
           
          
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (closeform == true)
                //{
                //    tabform.TabPages.Remove(tabform.SelectedTab);
                //}
                //else
                //{
                    DialogResult result = MessageBox.Show("هل تريد غلق " + tabform.SelectedTab.Text, "إغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        tabform.TabPages.Remove(tabform.SelectedTab);
                    }
                //}

                //closeform = false;
            }
            catch
            {
                return;
            }

        }

    

        private void btn_Power_Click(object sender, EventArgs e)
        {
            PL.Frm_PowerOfUsers frm = new Frm_PowerOfUsers();
            TabToOpenForm(btn_Power, frm); 
        }

        private void btn_House_Click(object sender, EventArgs e)
        {
           
        }

  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        public void btn_OfficeConslt_Click(object sender, EventArgs e)
        {
            PL.Frm_ConsultingOffice frm = new Frm_ConsultingOffice();
            TabToOpenForm(btn_OfficeConslt, frm);
        }

        private void btn_EnGData_Click(object sender, EventArgs e)
        {
            PL.Frm_EngData2 frm = new PL.Frm_EngData2();
            TabToOpenForm(btn_EnGData, frm);
            
        }

        private void btn_Office_Click(object sender, EventArgs e)
        {
            PL.Frm_OfficeData frm = new PL.Frm_OfficeData();
            TabToOpenForm(btn_Office,frm);
        }

        private void btn_TechnicalReportCivilProtection_Click(object sender, EventArgs e)
        {
            PL.Frm_TechnicalReportCivilProtection frm = new PL.Frm_TechnicalReportCivilProtection();
            TabToOpenForm(btn_TechnicalReportCivilProtection, frm);
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_MAx_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_dailybusiness_Click(object sender, EventArgs e)
        {
            PL.Frm_DailyBusiness frm = new PL.Frm_DailyBusiness();
            TabToOpenForm(btn_dailybusiness, frm);
        }

        private void btn_FormA_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1();
            //f.ShowDialog();
        }
    }
}
