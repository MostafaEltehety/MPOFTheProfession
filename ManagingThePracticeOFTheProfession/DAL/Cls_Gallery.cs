using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_Gallery:DAL.ClassDAL
    {
        public static List<PictureBox> ApplyGallery(Int64 IDENG)
        {
            DataTable dt = new DataTable();
            dt = Select("select image,IDDouc from Documant_Tbl where IDEng = '" + IDENG + "'");
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            List<Label> labelsID = new List<Label>();
            pictureBoxes.Clear();
            foreach (DataRow item in dt.Rows)
            {
                PictureBox pic = new PictureBox();
                MemoryStream ms = new MemoryStream((byte[])item["image"]);
                pic.Image = Image.FromStream(ms);

                pictureBoxes.Add(pic);


            }
            //MessageBox.Show(pictureBoxes.Count.ToString());
            return pictureBoxes;
        }


        //public static KeyValuePair<List<PictureBox>,List<Label>> ApplyGallery(Int64 IDENG)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Select("select image,IDDouc from Documant_Tbl where IDEng = '" + IDENG + "'");
        //    List<PictureBox> pictureBoxes = new List<PictureBox>();
        //    List<Label> labelsID = new List<Label>();
        //    pictureBoxes.Clear();
        //    labelsID.Clear();
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        PictureBox pic = new PictureBox();
        //        Label lblID = new Label();
        //        MemoryStream ms = new MemoryStream((byte[])item["image"]);
        //        pic.Image = Image.FromStream(ms);
        //        lblID.Text = item["IDDouc"].ToString();
        //        pictureBoxes.Add(pic);
        //        labelsID.Add(lblID);

        //    }
            //MessageBox.Show(pictureBoxes.Count.ToString());
        //    return new KeyValuePair<List<PictureBox>, List<Label>>(pictureBoxes, labelsID);
        //}

        public static DataTable DTApplyGallery(Int64 IDENG)
        {
            DataTable dt = new DataTable();
            dt = Select("select image from Documant_Tbl where IDEng = '" + IDENG + "'");           
            return dt;
        }

        public static void SaveImage(byte[] Image, Int64 IDEng)
        {
            cmd = new SqlCommand("insert into Documant_Tbl (image,IDEng,UserID) values (@image,@IDEng,@UserID)",con);
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@image", Image);
            p[1] = new SqlParameter("@IDEng", IDEng);
            p[2] = new SqlParameter("@UserID", DAL.ClassDAL.IDUser);
            cmd.Parameters.AddRange(p);
            cmd.ExecuteNonQuery();
            PL.Frm_MessageSuccess frm = new PL.Frm_MessageSuccess();
            frm.ShowDialog();
        }

    }
}
