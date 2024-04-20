using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_DocumentEng : Form
    {

        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;
        DataTable dt;
        Int64 id;

        public Frm_DocumentEng(Int64 ideng)
        {
            InitializeComponent();
            id = ideng;
            Navigation();
        }

        void Navigation()
        {

            //dt = new DataTable();
            //dt = DAL.ClassDAL.Select("select IDDouc,image,Descri from VariableDoc_Tbl");
            ////lbl_Count.Text = dt.Rows.Count.ToString();
            //metroComboBox1.SelectedIndex = 0;
            //metroComboBox1.DataBindings.Add("text", dt, "Descri");
            //pictureBox1.DataBindings.Add("image", dt, "image", true);
            //bmb = this.BindingContext[dt];

            //bmb.Position = 0;
            //lblPosition.Text = (bmb.Position + 1 + " / " + bmb.Count);
        }

        private void Frm_DocumentEng_Load(object sender, EventArgs e)
        {
           

        }

        private void lbl_Last_MouseHover(object sender, EventArgs e)
        {
            lbl_Next.BackColor = Color.Gray;
        }

        private void lbl_Next_MouseHover(object sender, EventArgs e)
        {
            lbl_Last.BackColor = Color.Gray;
        }

        private void lbl_Last_MouseLeave(object sender, EventArgs e)
        {
            lbl_Next.BackColor = Color.Transparent;
        }

        private void lbl_Next_MouseLeave(object sender, EventArgs e)
        {
            lbl_Last.BackColor = Color.Transparent;
        }

        private void lbl_Last_Click(object sender, EventArgs e)
        {
            lbl_Next.BackColor = Color.DimGray;
        }

        private void lbl_Next_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPosition.Text = (bmb.Position + 1 + " / " + bmb.Count);
            lbl_Last.BackColor = Color.DimGray;
          

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox1.BackgroundImage;
            btn_Save.Enabled = false;
  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
            DAL.ClassDAL.OpenImage(pictureBox1,btn_Save);
            //if (pictureBox1.Image!=pictureBox1.BackgroundImage)
            //{
            //    btn_Save.Enabled = true;
            //}
            //else
            //{
            //    btn_Save.Enabled = false;
            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //MemoryStream ms = new MemoryStream();
                //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                //byte[] pictuer = ms.ToArray();
                //DAL.ClassDAL.cmd = new SqlCommand("insert into VariableDoc_Tbl (image,Descri,IDEng) values (@image,@Descri,@IDEng) ", DAL.ClassDAL. con);
                //DAL.ClassDAL.cmd.Connection = DAL.ClassDAL.con;
                //DAL.ClassDAL.Open();
                //SqlParameter[] p = new SqlParameter[3];
                //p[0] = new SqlParameter("@image", pictuer);
                //p[1] = new SqlParameter("@Descri", metroComboBox1.Text);
                //p[2] = new SqlParameter("@IDEng",id);
                //DAL.ClassDAL.cmd.Parameters.AddRange(p);
                //DAL.ClassDAL.cmd.ExecuteNonQuery();
                //DAL.ClassDAL.Close();
                //pictureBox1.Image = pictureBox1.BackgroundImage;
                //btn_New_Click(null, null);
              
                //Navigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
         

        }

        private void lbl_Next_Click_1(object sender, EventArgs e)
        {
            try
            {
                bmb.Position += 1;
                lblPosition.Text = (bmb.Position + 1 + " / " + bmb.Count);
            }
            catch
            {
                return;
            }
        }

      
    }
}
