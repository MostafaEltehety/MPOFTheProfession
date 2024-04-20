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
    public partial class Frm_Login : Form
    {
       
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=DAL.ClassDAL.Select(" SELECT  dbo.Users_Tbl.*  FROM   dbo.Employee_Tbl INNER JOIN  dbo.Users_Tbl ON dbo.Employee_Tbl.IDEmp = dbo.Users_Tbl.IDEmp where UserName='" + txt_Name.Text+ "' and Password='"+txt_Pasword.Text+"'");
           
            if (dt.Rows.Count>0)
            {
                DAL.ClassDAL.IDUser = dt.Rows[0]["UserID"].ToString();
                PL.Frm_Main2 frm = new Frm_Main2();
               
                #region Power
                if (Convert.ToBoolean(dt.Rows[0]["OrderPayed"].ToString())==true)
                {
                    frm.group_OrderPayed.Enabled = true;
                }
                else
                {
                    frm.group_OrderPayed.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Forms"].ToString()) == true)
                {
                    frm.group_Form1.Enabled = frm.group_Form2.Enabled = frm.group_Form3.Enabled = frm.group_Form4.Enabled = frm.group_Form5.Enabled = frm.group_Form6.Enabled = true;
                }
                else
                {
                    frm.group_Form1.Enabled = frm.group_Form2.Enabled = frm.group_Form3.Enabled = frm.group_Form4.Enabled = frm.group_Form5.Enabled = frm.group_Form6.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["StopeForms"].ToString()) == true)
                {
                    frm.group_StopForm.Enabled = true;
                }
                else
                {
                    frm.group_StopForm.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["EngBuisnessStatement"].ToString()) == true)
                {
                    frm.btn_BussinesStatement.Enabled = true;
                }
                else
                {
                    frm.btn_BussinesStatement.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["BakupAndStore"].ToString()) == true)
                {
                    frm.groupSeting.Enabled = frm.btn_Backup.Enabled = frm.btn_Restore.Enabled = true;
                }
                else
                {
                    frm.groupSeting.Enabled = frm.btn_Backup.Enabled = frm.btn_Restore.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Seting"].ToString()) == true)
                {
                  frm.btn_Power.Enabled= true;
                }
                else
                {
                    frm.btn_Power.Enabled  = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["BasicData"].ToString()) == true)
                {
                    frm.group_BasicData.Enabled = true;
                }
                else
                {
                    frm.group_BasicData.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["UserPower"].ToString()) == true)
                {
                    frm.btn_Power.Enabled = true;
                }
                else
                {
                    frm.btn_Power.Enabled = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["DeleteForm"].ToString()) == true)
                {
                   DAL.ClassDAL.DeleteForm = true;
                }
                else
                {
                    DAL.ClassDAL.DeleteForm = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["PrintFromAndStop"].ToString()) == true)
                {
                   frm.groupPrint.Enabled= frm.btn_FormPrint.Enabled = frm.btn_FormPrintStope.Enabled=true;
                }
                else
                {
                    frm.groupPrint.Enabled = frm.btn_FormPrint.Enabled = frm.btn_FormPrintStope.Enabled = false;
                }

                #endregion

                DAL.ClassDAL.OPening();
                frm.lbl_UserName.Text = dt.Rows[0]["UserName"].ToString();

                this.Hide();
                frm.ShowDialog();
            }

            else
            {
                MessageBox.Show("خطأ فى اسم المستخدم أو كلمة المرور");
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PL.Frm_Main2 frm = new Frm_Main2();
            DAL.ClassDAL.OPening();
            frm.ShowDialog();
        }

        private void txt_Pasword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btn_Login_Click(null, null);
            }
        }
    }
}
