using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] pictuer = ms.ToArray();
            DAL.Cls_PrintForms.SaveImgForm(pictuer,Convert.ToInt16( textBox1.Text));


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DAL.ClassDAL.OpenImage(pictureBox1);
        }
    }
}
