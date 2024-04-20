using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Frm_Gallery : Form
    {


        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;
        DataTable dt;
        Int64 id;


        public Frm_Gallery()
        {
            InitializeComponent();

        }


        void Navigation()
        {
            try
            {
            dt = new DataTable();
            dt =DAL.Cls_Gallery.DTApplyGallery(Convert.ToInt64(lbl_IDEng.Text));
           
            pictureView.DataBindings.Add("image", dt, "image", true);
            bmb = this.BindingContext[dt];

            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1 + " / " + bmb.Count);

            }
            catch (Exception)
            {
                return;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void Frm_Gallery_Load(object sender, EventArgs e)
        {
            //DAL.Cls_Gallery.ApplyGallery();
            
            panelGallery.Controls.Clear();
            foreach (PictureBox item in DAL.Cls_Gallery.ApplyGallery(Convert.ToInt64(lbl_IDEng.Text)))
            {
               
                PictureBox temp = new PictureBox();
                //Add the Event handler to the click event
                temp.Click += pictureBox_Click;

                //temp.MouseHover += pictureBox_MouseHover;
                panelGallery.Controls.Add(temp);
                temp.Image = item.Image;
                temp.Width =122;
                temp.Height =122;
                temp.SizeMode = PictureBoxSizeMode.Zoom;
                temp.Dock = DockStyle.Left;
                //temp.Margin = new Padding(20,0,20,0);
                //temp.BorderStyle = BorderStyle.FixedSingle;

            }

            Navigation();

        }

        public void setPicture(Image img)
        {
            pictureView.Image = img;
            MemoryStream ms = new MemoryStream();
            byte[] pictuer = ms.ToArray();
           lbl_IDDOC.Text= DAL.ClassDAL.Select("select IDDouc from Documant_Tbl where image='"+pictuer+"'").Rows[0][0].ToString();
        }

        public void setPictureHover(PictureBox img)
        {
            Size size = new Size(244, 244);
            img.Size = size;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

            //This is supposing that you have created a custom constructor of your FormtoOpen that can take the Image
            //You could also create a Property to do the same thing.

            setPicture(((PictureBox)sender).Image);
           
        }
        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            //setPictureHover(((PictureBox)sender));

            //setPicture(((PictureBox)sender).Image);

        }
        private void lbl_Last_MouseHover(object sender, EventArgs e)
        {
            lbl_Last.BackColor = Color.Gray;
        }

        private void lbl_Last_MouseLeave(object sender, EventArgs e)
        {
            lbl_Last.BackColor = Color.Transparent;
        }

        private void lbl_Next_MouseHover(object sender, EventArgs e)
        {
            lbl_Next.BackColor = Color.Gray;
        }

        private void lbl_Next_MouseLeave(object sender, EventArgs e)
        {
            lbl_Next.BackColor = Color.Transparent;
        }

        private void lbl_Last_Click(object sender, EventArgs e)
        {
            try
            {
                bmb.Position -= 1;
            lblPosition.Text = (bmb.Position + 1 + " / " + bmb.Count);
            lbl_Last.BackColor = Color.DimGray;
            }
            catch
            {
                return;
            }
        }

        private void lbl_Next_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.OpenImage(pictureView);
            btn_Save.Enabled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureView.Image.Save(ms, pictureView.Image.RawFormat);
            byte[] pictuer = ms.ToArray();
            DAL.Cls_Gallery.SaveImage(pictuer,Convert.ToInt64(lbl_IDEng.Text));
            Frm_Gallery_Load(null, null);
            btn_Save.Enabled = false;

        }
    }
}
