using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class ClassDAL
    {
        //public static SqlConnection con = new SqlConnection(@"Server=.\SQLExpress; database = ManagingThePracticeOFTheProfession; user id =sayed ;  password =123;"); // PC2

        //public static SqlConnection con = new SqlConnection(@"Server=.\SQLExpress; database = ManagingThePracticeOFTheProfession; Integrated Security=true;");
        //public static SqlConnection con = new SqlConnection(@"Server=PC1\SQLExpress,1433; database = ManagingThePracticeOFTheProfession; user id =PC1 ;  password =123;"); // PC2
        public static SqlConnection con = new SqlConnection(@"Server=sayed\SQLExpress,1433; database = ManagingThePracticeOFTheProfession; user id =PC1 ;  password =123;"); // PC2 
        //public static SqlConnection con = new SqlConnection(@"Server=sayed\SQLExpress; database = ManagingThePracticeOFTheProfession; user id =PC1 ;  password =123;"); // PC1 
        //public static SqlConnection con = new SqlConnection(@"Server=.\SQLExpress; database = ManagingThePracticeOFTheProfession; user id =PC1 ;  password =123;"); // server

        public static SqlCommand cmd = new SqlCommand("", con);
        public static string IDUser, MangerEngneer, ReferentialOfficer, Manager,GeneralManager;
        public static bool DeleteForm;
        public static void OPening()
        {
            ReferentialOfficer = Select("SELECT   EmployeeName FROM   dbo.Employee_Tbl   WHERE (Active = 'نشط') and EmployeeJob = 'مراجع إدارة مزاولة المهنة'").Rows[0][0].ToString();
            Manager = Select("SELECT   EmployeeName FROM   dbo.Employee_Tbl   WHERE (Active = 'نشط') and EmployeeJob = 'مدير إدارة مزاولة المهنة'").Rows[0][0].ToString();
            GeneralManager = Select("SELECT   EmployeeName FROM   dbo.Employee_Tbl   WHERE (Active = 'نشط') and EmployeeJob = 'مدير إدارة الخدمات النقابية'").Rows[0][0].ToString();
            MangerEngneer= Select("SELECT   EmployeeName FROM   dbo.Employee_Tbl   WHERE (Active = 'نشط') and EmployeeJob = 'نقيب المهندسين بأسيوط'").Rows[0][0].ToString();

        }



        public static void Open()
        {
            if (con.State == ConnectionState.Closed) con.Open();
        }
        public static void Close()
        {
            if (con.State == ConnectionState.Open) con.Close();
        }
        public static DataTable Select(string sqlSelect)
        {
            Close();
            Open();
            DataTable dt = new DataTable();
            cmd.CommandText = sqlSelect;

            dt.Load(cmd.ExecuteReader());
            return dt;
            Close();
        }
        public static void Run(string sqlText)
        {
            cmd.CommandText = sqlText;
            cmd.ExecuteNonQuery();
            PL.Frm_MessageSuccess from = new PL.Frm_MessageSuccess();
            from.Show();
        }
        public static void RunTransaction(string sqlText)
        {
            cmd.CommandText = sqlText;
            cmd.ExecuteNonQuery();
            //PL.Frm_MessageSuccess from = new PL.Frm_MessageSuccess();
            //from.Show();
        }
        #region language
        public static InputLanguage getlanguage(string inputname)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().Contains(inputname))
                {
                    return lang;
                }
            }
            return null;
        }
        public static void switchInput(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }
        public static void English()
        {
            switchInput(getlanguage("english"));
        }
        public static void Arabic()
        {
            switchInput(getlanguage("arabic"));
        }
        #endregion

        public static void UseCurrancy(KeyPressEventArgs e, TextBox txt)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                case (char)Keys.Back:
                case (char)Keys.Enter:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;

            }
            if (e.KeyChar == 46 && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        public static void ClearPrice(TextBox txtBox)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Text = "0";
            }
        }

        public static byte[] SaveImage(PictureBox pictuer)
        {
            MemoryStream ms = new MemoryStream();
            pictuer.Image.Save(ms, pictuer.Image.RawFormat);
            byte[] pic = ms.ToArray();
            return pic;
        }

        public static void OpenImage(PictureBox pictuer,Button btn)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "ملفات الصور | *.JPG; *.PNG; *.GIF; *.BMP; *.jfif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictuer.Image = Image.FromFile(opf.FileName);
                btn.Enabled = true;
            }
            if (opf.FileName == "")
            {
                btn.Enabled = false;

            } 
        }

        public static void OpenImage(PictureBox pictuer)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "ملفات الصور | *.JPG; *.PNG; *.GIF; *.BMP; *.jfif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictuer.Image = Image.FromFile(opf.FileName);
            }
            if (opf.FileName == "")
            {
                return;
            }
        }


        public static void EnglishNumInText(KeyPressEventArgs e)
        {
            English();
            switch (e.KeyChar)
            {

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                case '\\':
                    English();
                    break;
                default:
                    Arabic();
                    break;

            }

        }
        public static void ClearTextWithOutCombbox(Form frm)
        {
            foreach (Control item in frm.Controls)
            {

                if (item is TextBox)
                {
                    item.Text = "";
                }

                if (item is NumericUpDown)
                {
                    item.Text = "0";
                }
                if (item is DateTimePicker)
                {
                    item.Text = DateTime.Now.ToString();
                }

            }
        }


        public static void UseNumbersOnly(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                case '\\':
                case (char)Keys.Back:
                case (char)Keys.Enter:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;

            }

        }
        public static void Dot_Refused(KeyPressEventArgs e, TextBox txt)
        {
            if (e.KeyChar == 46)
            {
                e.Handled = true;
            }
        }


        public static void ClearGroup(GroupBox group)
        {
            foreach (Control itemGroup in group.Controls)
            {
                if (itemGroup is TextBox)
                {
                    itemGroup.Text = "";
                }

                if (itemGroup is NumericUpDown)
                {
                    itemGroup.Text = "0";
                }
                if (itemGroup is DateTimePicker)
                {
                    itemGroup.Text = DateTime.Now.ToString();
                }
              
            }

        }

        public static void ClearText(Form frm, GroupBox group)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control itemGroup in group.Controls)
                    {
                        if (itemGroup is TextBox)
                        {
                            itemGroup.Text = "";
                        }

                        if (itemGroup is NumericUpDown)
                        {
                            itemGroup.Text = "0";
                        }
                        if (itemGroup is DateTimePicker)
                        {
                            itemGroup.Text = DateTime.Now.ToString();
                        }
                        if (item is MaskedTextBox)
                        {
                            item.Text = string.Empty;
                        }
                    }

                }

            }

        }

        public static void ClearText(Form frm, Panel panel)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is Panel)
                {
                    foreach (Control itemGroup in panel.Controls)
                    {
                        if (itemGroup is TextBox)
                        {
                            itemGroup.Text = "";
                        }
                        if (itemGroup is ComboBox)
                        {
                            itemGroup.Text = "";
                        }
                        if (itemGroup is NumericUpDown)
                        {
                            itemGroup.Text = "0";
                        }
                        if (itemGroup is DateTimePicker)
                        {
                            itemGroup.Text = DateTime.Now.ToString();
                        }
                        if (item is MaskedTextBox)
                        {
                            item.Text = string.Empty;
                        }
                    }

                }

            }

        }

        public static void ClearText(Form frm)
        {
            foreach (Control item in frm.Controls)
            {

                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is NumericUpDown)
                {
                    item.Text = "0";
                }
                if (item is DateTimePicker)
                {
                    item.Text = DateTime.Now.ToString();
                }
                if (item is MaskedTextBox)
                {
                    item.Text = "";
                }
            }
        }

        #region SaveImage
        public static void image_InsertOrUpdate(string tbl_name, string columnImg_name, string Columnname_ID, string ID, byte[] Image)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update " + tbl_name + " set " + columnImg_name + " = @Image where " + Columnname_ID + "= " + ID + " ";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@Image", Image);
            cmd.Parameters.AddRange(p);
            int after = cmd.ExecuteNonQuery();

        }
        #endregion

        public static string GetID(string TableName, string OrderField)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select max(" + OrderField + ")+1 from " + TableName + "";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        public static string GetID(string TableName, string OrderField,string y)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select max(" + OrderField + ")+1 from " + TableName + " where year(DateForm)="+y+" ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                return "0";
            }
            return dt.Rows[0][0].ToString();
        }


        public static void BackUp(string filename)
        {


            string Quary = "backup database ManagingThePracticeOFTheProfession to disk ='" + filename + "'";
            SqlCommand cmd = new SqlCommand(Quary, con);
            Open();
            cmd.ExecuteNonQuery();
            Close();


        }
        public static void Restore(string filename)
        {

            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS ; database=master ; integrated security= true ");
            string Quary = "ALTER Database ManagingThePracticeOFTheProfession SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore database ManagingThePracticeOFTheProfession from disk ='" + filename + "'";
            SqlCommand cmd = new SqlCommand(Quary, conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }

    }
}
