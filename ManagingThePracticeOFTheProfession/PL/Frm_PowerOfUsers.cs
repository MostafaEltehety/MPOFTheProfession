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
    public partial class Frm_PowerOfUsers : Form
    {
        bool OrderPayed, Forms, StopeForms, EngBuisnessStatement, BakupAndStore, Seting, BasicData, UserPower, DeleteForm, PrintFromAndStop = false;

        private void btn_Search_Click(object sender, EventArgs e)
        {
            PL.Frm_PowerOfUserSearch frm = new PL.Frm_PowerOfUserSearch();
            frm.ShowDialog();
            IDUser.Text = frm.lbl_ID.Text;
            DataTable dt = new DataTable();
            dt = DAL.ClassDAL.Select("select* from Users_Tbl where UserID ='" + IDUser.Text + "'");
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("لاتوجد بيانات");
                return;
            }
            txt_Name.Text = dt.Rows[0]["FullName"].ToString();
            txt_User.Text = dt.Rows[0]["UserName"].ToString();
            txt_Password.Text = dt.Rows[0]["Password"].ToString();
            txt_Password2.Text = dt.Rows[0]["Password"].ToString();

            if (Convert.ToBoolean(dt.Rows[0]["OrderPayed"].ToString()) == true)
            {
                DataGridViewRow row2 = new DataGridViewRow();
                DataGridViewCell Power2 = new DataGridViewTextBoxCell();
                row2.Cells.Add(Power2);
                row2.Cells[0].Value = "إذن توريد";
                    dataGridView1.Rows.Add(row2);
                }
            if (Convert.ToBoolean(dt.Rows[0]["Forms"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "عمل شهادات اشراف";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["StopeForms"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "إيقاف شهادات اشراف";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["EngBuisnessStatement"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "بيان اعمال المهندس";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["BakupAndStore"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "النسخ الإحتياطى";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["Seting"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "الإعدادات";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["BasicData"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "البيانات الاساسية";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["UserPower"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "صلاحيات المستخدمين";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["DeleteForm"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "حذف شهادات اشراف";
                dataGridView1.Rows.Add(row);
            }
            if (Convert.ToBoolean(dt.Rows[0]["PrintFromAndStop"].ToString()) == true)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = "طباعة نماذج";
                dataGridView1.Rows.Add(row);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_User_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void IDUser_Click(object sender, EventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_PowerOfUsers_Load(object sender, EventArgs e)
        {
            Restart();
        }

        int idEmp = Convert.ToInt32(DAL.ClassDAL.Select("SELECT IDEmp, EmployeeName, Active, EmployeeJob FROM dbo.Employee_Tbl where EmployeeJob='مراجع إدارة مزاولة المهنة' and Active='نشط' ").Rows[0]["IDEmp"].ToString());

        void Restart()
        {
            OrderPayed= Forms= StopeForms= EngBuisnessStatement= BakupAndStore= Seting= BasicData= UserPower= DeleteForm = PrintFromAndStop = false;
            IDUser.Text= txt_Name.Text = txt_Password.Text = txt_Password2.Text = txt_User.Text = "";
            comboBox1.SelectedIndex = 0;
            int idEmp=Convert.ToInt32( DAL.ClassDAL.Select("SELECT IDEmp, EmployeeName, Active, EmployeeJob FROM dbo.Employee_Tbl where EmployeeJob='مراجع إدارة مزاولة المهنة' and Active='نشط' ").Rows[0]["IDEmp"].ToString());
            dataGridView1.Rows.Clear();
        }

         private void btn_New_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // Check Exists
            #region Check Exists
            foreach (DataGridViewRow  row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString()==comboBox1.SelectedItem.ToString())
                {
                    row.Selected = true;
                    return;
                }
            }
            #endregion
            // Admin
            #region Admin
            if (comboBox1.SelectedItem.ToString() == "مدير النظام بالكامل") 
            {
                dataGridView1.Rows.Clear();
                foreach (var item in comboBox1.Items)
                {
                    DataGridViewRow row2 = new DataGridViewRow();
                    DataGridViewCell Power2 = new DataGridViewTextBoxCell();

                    row2.Cells.Add(Power2);

                   

                    if (item.ToString() == "مدير النظام بالكامل")
                    {
                        continue;
                    }
                    row2.Cells[0].Value = item.ToString();

                    dataGridView1.Rows.Add(row2);
                }
            }
            #endregion
            // User
            #region User
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell Power = new DataGridViewTextBoxCell();
                row.Cells.Add(Power);
                row.Cells[0].Value = comboBox1.SelectedItem;
                dataGridView1.Rows.Add(row);
            }

            #endregion
        }

        public Frm_PowerOfUsers()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text.Trim()==""||txt_User.Text.Trim()=="")
            {
                MessageBox.Show("يجب إدخال البيانات الاساسية  ", "بيانات أساسية");
                return;
            }
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("يجب اضافة صلاحيات للمستخدم");
                return;
            }
            if (txt_Password.Text == "" || txt_Password2.Text == "")
            {
                txt_Password.Focus();
                return;
            }
            if (txt_Password.Text != txt_Password2.Text)
            {
                MessageBox.Show("كلمتا المرور غير متطابقين ");
                txt_Password2.Focus();
                return;
            }

            // GetValue
            OrderPayed = Forms = StopeForms = EngBuisnessStatement = BakupAndStore = Seting = BasicData = UserPower = DeleteForm = PrintFromAndStop = false;

            #region GetValue
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                switch (item.Cells[0].Value.ToString().Trim())
                {
                    case "مدير النظام بالكامل":
                        OrderPayed = Forms = StopeForms = EngBuisnessStatement = BakupAndStore = Seting = BasicData = UserPower = DeleteForm = true;

                        break;
                    case "البيانات الاساسية":
                        BasicData = true;
                        break;
                    case "إذن توريد":
                        OrderPayed = true;
                        break;
                    case "عمل شهادات اشراف":
                        Forms = true;
                        break;
                    case "إيقاف شهادات اشراف":
                        StopeForms = true;
                        break;
                    case "حذف شهادات اشراف":
                        DeleteForm = true;
                        break;
                    case "بيان اعمال المهندس":
                        EngBuisnessStatement = true;
                        break;
                    case "النسخ الإحتياطى":
                        BakupAndStore = true;
                        break;
                    case "صلاحيات المستخدمين":
                        UserPower = true;
                        break;
                    case "الإعدادات":
                        Seting = true;
                        break;
                    case "طباعة نماذج":
                        PrintFromAndStop = true;
                        break;
                }
            }
            #endregion
            // Save
            if (IDUser.Text=="")
            {
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("select* from Users_Tbl where FullName='" + txt_Name.Text + "' or UserName='" + txt_User.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("الاسم او اسم المستخدم لايمكن تكراره");
                    return;
                }
                DAL.ClassDAL.Run("INSERT INTO [dbo].[Users_Tbl] ([UserName],[Password],[IDEmp],[OrderPayed],[Forms] ,[StopeForms],[EngBuisnessStatement],[BakupAndStore],[Seting],[BasicData],[UserPower],[DeleteForm],[FullName],[PrintFromAndStop]) values('" + txt_User.Text + "','" + txt_Password.Text + "','" + idEmp + "','" + OrderPayed + "','" + Forms + "' ,'" + StopeForms + "','" + EngBuisnessStatement + "','" + BakupAndStore + "','" + Seting + "','" + BasicData + "','" + UserPower + "','" + DeleteForm + "','" + txt_Name.Text + "','"+PrintFromAndStop+"')");
            }
            // Update
            else
            {
                DataTable dt = new DataTable();
                dt = DAL.ClassDAL.Select("select* from Users_Tbl where (UserID!='"+Convert.ToInt32(IDUser.Text) +"') and  (FullName='" + txt_Name.Text + "' or UserName='" + txt_User.Text + "')");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("الاسم او اسم المستخدم لايمكن تكراره");
                    return;
                }
                DAL.ClassDAL.Run("UPDATE [dbo].[Users_Tbl] SET [UserName] = '"+txt_User.Text+"' ,[Password] = '"+txt_Password.Text+"',[IDEmp] = '"+idEmp+"' ,[OrderPayed] = '"+OrderPayed+"' ,[Forms] = '"+Forms+"' ,[StopeForms] = '"+ StopeForms + "',[EngBuisnessStatement] = '"+ EngBuisnessStatement + "' ,[BakupAndStore] ='"+ BakupAndStore + "' ,[Seting] = '"+ Seting + "'  ,[BasicData] = '"+ BasicData + "' ,[UserPower] = '"+ UserPower + "',[DeleteForm] ='"+ DeleteForm + "' ,[FullName] ='"+txt_Name.Text+ "' ,[PrintFromAndStop]='"+ PrintFromAndStop + "' WHERE [UserID]='" + IDUser.Text+"' ");
            }

            Restart();

        }
    }
}
