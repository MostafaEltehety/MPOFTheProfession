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
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
          

        }

        private void TitleEngData_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void TileEngRecording_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TitleOfficeData_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void TitleOwnersData_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TitleSH_D_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TitleEngData_Click(object sender, EventArgs e)
        {
            PL.FrmEngData frm = new PL.FrmEngData();
            frm.ShowDialog();
        }

        private void TileEngRecording_Click(object sender, EventArgs e)
        {
            PL.Frm_EngineeringRecord frm = new Frm_EngineeringRecord();
            frm.ShowDialog();
        }

        private void TitleOfficeData_Click(object sender, EventArgs e)
        {
            PL.Frm_OfficeData frm = new Frm_OfficeData();
            frm.ShowDialog();
        }

        private void TitleOwnersData_Click(object sender, EventArgs e)
        {
            PL.Frm_Owners frm = new Frm_Owners();
            frm.ShowDialog();
        }

        private void TitleSH_D_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D frm = new Forms.Frm_SH_D();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TitleSH_H_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_H frm = new Forms.Frm_SH_H();
            frm.ShowDialog();
        }

        private void TitleFormSH_G_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G frm = new Forms.Frm_SH_G();
            frm.ShowDialog();
        }

        private void TitleExperienceHouse_Click(object sender, EventArgs e)
        {
            PL.Frm_ExperienceHouse frm = new PL.Frm_ExperienceHouse();
            frm.ShowDialog();
        }

        private void TitleFormA_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_A frm = new Forms.Frm_SH_A();
            frm.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_W frm = new Forms.Frm_SH_W();
            frm.ShowDialog();
        }

        private void TitleAllowedNumbers_Click(object sender, EventArgs e)
        {
            PL.Frm_AllowedNumbers frm = new PL.Frm_AllowedNumbers();
            frm.ShowDialog();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lbl_GeneralManager.Text = DAL.ClassDAL.GeneralManager;
            lbl_Manager.Text = DAL.ClassDAL.Manager;
            lbl_Refreance.Text = DAL.ClassDAL.ReferentialOfficer;
        }

        private void Title_Employee_Click(object sender, EventArgs e)
        {
            PL.Frm_Employees frm = new PL.Frm_Employees();
            frm.ShowDialog();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TitleFormSH_G_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TitleFormA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TitleSH_H_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanalHead_Paint(object sender, PaintEventArgs e)
        {

        }

        void lbl_MouseEnter(Label lbl)
        {
            //lbl.BackColor = Color.LightGray;
            lbl.BackColor = Color.LightSteelBlue;

        }

        void lbl_MouseLeave(Label lbl)
        {
            lbl.BackColor = Color.Transparent;
        }

        private void lbl_Engnering_Click(object sender, EventArgs e)
        {
            //panel_Customers.Visible = panel_PurshesAndSeales.Visible = panelSuppliers.Visible = false;
            //lbl_ArchitecturalAdjustments.BackgroundImage = lbl_BusinessUnusual.BackgroundImage = lbl_ReinforcementRestoration.BackgroundImage = PanalHead.BackgroundImage;
            //lbl_ArchitecturalAdjustments.ForeColor = lbl_ReinforcementRestoration.ForeColor = lbl_BusinessUnusual.ForeColor = Color.Black;
            if (panel_ListEng.Visible == true)
            {
                panel_ListEng.Visible = false;
            }
            else
            {
                panel_ListEng.Visible = true;
                //lbl_Stores.ForeColor = Color.Navy;

            }
        }

        private void lbl_Engnering_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_Engnering);
        }

        private void lbl_Engnering_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_Engnering);
        }

        private void lbl_EngData_Click(object sender, EventArgs e)
        {
            PL.FrmEngData frm = new PL.FrmEngData();
            panel_ListEng.Visible = false;
            frm.ShowDialog();
        }

        private void lbl_EngData_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_EngData);
        }

        private void lbl_EngData_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_EngData);
        }

        private void lbl_EngRecording_Click(object sender, EventArgs e)
        {
            PL.Frm_EngineeringRecord frm = new Frm_EngineeringRecord();
            panel_ListEng.Visible = false;
            frm.ShowDialog();
        }

        private void lbl_OfficeData_Click(object sender, EventArgs e)
        {
            PL.Frm_OfficeData frm = new Frm_OfficeData();
            panel_ListEng.Visible = false;
            frm.ShowDialog();
        }

        private void lbl_HoseExperance_Click(object sender, EventArgs e)
        {
            PL.Frm_ExperienceHouse frm = new Frm_ExperienceHouse();
            panel_ListEng.Visible = false;
            frm.ShowDialog();
        }

        private void lbl_FormSH_D_Click(object sender, EventArgs e)
        {
             PL.Forms.Frm_SH_D frm = new PL.Forms.Frm_SH_D();
            panel_ListBusinessUnusual.Visible = false;
            frm.ShowDialog();
        }

        private void lbl_BusinessUnusual_Click(object sender, EventArgs e)
        {
            if (panel_ListBusinessUnusual.Visible == true)
            {
                panel_ListBusinessUnusual.Visible = false;
            }
            else
            {
                panel_ListBusinessUnusual.Visible = true;
                //lbl_Stores.ForeColor = Color.Navy;

            }
        }

        private void panel_Print_MouseEnter(object sender, EventArgs e)
        {
            panel_Print.BackColor = Color.Gainsboro;

        }

        private void panel_Print_MouseLeave(object sender, EventArgs e)
        {
            panel_Print.BackColor = Color.White;
        }

        private void panel_Print_MouseEnter_1(object sender, EventArgs e)
        {
            panel_Print.BackColor = Color.Gainsboro;
        }

        private void panel_Print_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Print_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_PrintForm frm = new Forms.Frm_PrintForm();
            frm.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            PL.Form1 frm = new PL.Form1();
            frm.ShowDialog();
        }

        private void lbl_Setting_Click(object sender, EventArgs e)
        {
            PL.Frm_SettingBusinessValue frm = new PL.Frm_SettingBusinessValue();
            frm.ShowDialog();
        }

        private void btn_Gallery_Click(object sender, EventArgs e)
        {
            PL.Frm_Gallery frm = new Frm_Gallery();
            frm.ShowDialog();
        }

        private void lbl_FormSH_D_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_FormSH_D);
        }

        private void lbl_FormSH_D_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_FormSH_D);
        }

        private void lbl_BusinessUnusual_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_BusinessUnusual);
        }

        private void lbl_BusinessUnusual_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_BusinessUnusual);
        }

        private void lbl_FormSH_G_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_FormSH_G);
        }

        private void lbl_FormSH_G_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_FormSH_G);
        }

        private void lbl_FormSH_G_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G frm = new Forms.Frm_SH_G();
            frm.ShowDialog();
        }

        private void lbl_FormSH_B_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_B frm = new Forms.Frm_SH_B();
            frm.Show();
        }

        private void lbl_SH_W_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_W frm = new Forms.Frm_SH_W();
            frm.ShowDialog();
        }

        private void lbl_Demolitions_Click(object sender, EventArgs e)
        {
            if (panel_ListDemolitions.Visible == true)
            {
                panel_ListDemolitions.Visible = false;
            }
            else
            {
                panel_ListDemolitions.Visible = true;
            }
        }

        private void lbl_SH_H_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_H frm = new Forms.Frm_SH_H();
            frm.ShowDialog();
        }

        private void lbl_ReinforcementRestoration_Click(object sender, EventArgs e)
        {
            if (panel_ListReinforcementRestoration.Visible == true)
            {
                panel_ListReinforcementRestoration.Visible = false;
            }
            else
            {
                panel_ListReinforcementRestoration.Visible = true;
            }
        }

        private void lbl_Canced_Click(object sender, EventArgs e)
        {
            PL.Frm_CanceledForm frm = new PL.Frm_CanceledForm();
            frm.ShowDialog();
        }

        private void lbl_FormSH_B_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(lbl_FormSH_B);
        }

        private void lbl_FormSH_B_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(lbl_FormSH_B);
        }

        private void lbl_OwnerData_Click(object sender, EventArgs e)
        {
            PL.Frm_Owners frm = new Frm_Owners();
            frm.ShowDialog();
        }

        private void btn_EngData_Click(object sender, EventArgs e)
        {
            PL.FrmEngData frm = new PL.FrmEngData();
            panel_ListEng.Visible = false;
            frm.ShowDialog();
        }

        private void btn_Office_Click(object sender, EventArgs e)
        {
            PL.Frm_OfficeData frm = new Frm_OfficeData();
            panel_ListEng.Visible = false;
            frm.ShowDialog(); 
        }

        private void btn_SH_D_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D frm = new PL.Forms.Frm_SH_D();
            panel_ListBusinessUnusual.Visible = false;
            frm.ShowDialog();
        }

        private void btn_SH_G_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G frm = new Forms.Frm_SH_G();
            frm.ShowDialog();
        }

        private void btn_SH_B_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_B frm = new Forms.Frm_SH_B();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_H frm = new Forms.Frm_SH_H();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_W frm = new Forms.Frm_SH_W();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PL.Frm_CanceledForm frm = new PL.Frm_CanceledForm();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PL.Frm_Owners frm = new Frm_Owners();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_D2 frm = new Forms.Frm_SH_D2();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PL.Frm_PrintCanceldForm frm = new Frm_PrintCanceldForm();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            PL.Forms.OrderPaied frm = new Forms.OrderPaied();
            frm.ShowDialog();
        }

  

        private void button12_Click(object sender, EventArgs e)
        {
            PL.Frm_BusinessStatementEng frm = new Frm_BusinessStatementEng();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_G2 frm = new Forms.Frm_SH_G2();
            frm.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            PL.Frm_ConsultingOffice frm = new Frm_ConsultingOffice();
            frm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_SH_B2 frm = new Forms.Frm_SH_B2();
            frm.ShowDialog();
        }

        private void btn_Bakup_Click(object sender, EventArgs e)
        {
            PL.Frm_BackUp frm = new PL.Frm_BackUp();
            frm.ShowDialog();
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            PL.Forms.Frm_Restore frm = new PL.Forms.Frm_Restore();
            frm.ShowDialog();
        }

        private void btn_PowersOfUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
