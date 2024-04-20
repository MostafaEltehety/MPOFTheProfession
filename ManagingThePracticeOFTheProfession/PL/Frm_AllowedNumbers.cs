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
    public partial class Frm_AllowedNumbers : Form
    {
        public Frm_AllowedNumbers()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Frm_AllowedNumbers_Load(object sender, EventArgs e)
        {
            DAL.Cls_AllowedNumber.FillTypesForm(combFormType);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow  item in dataGridView1.Rows)
            //{
            //    DataGridViewRow row = new DataGridViewRow();
            //    DataGridViewCell id = new DataGridViewTextBoxCell();
            //    DataGridViewCell phone = new DataGridViewTextBoxCell();
            //    DataGridViewCell mobile = new DataGridViewTextBoxCell();
            //    DataGridViewCell email = new DataGridViewTextBoxCell();
            //    DataGridViewCell facebook = new DataGridViewTextBoxCell();
            //    DataGridViewCell address = new DataGridViewTextBoxCell();


            //    row.Cells.Add(id);
            //    row.Cells.Add(phone);
            //    row.Cells.Add(mobile);
            //    row.Cells.Add(email);
            //    row.Cells.Add(facebook);
            //    row.Cells.Add(address);


            //    row.Cells[0].Value = "";
            //    row.Cells[1].Value = txt_Phone.Text;
            //    row.Cells[2].Value = txt_Mobile.Text;
            //    row.Cells[3].Value = txt_Email.Text;
            //    row.Cells[4].Value = txt_FaceBook.Text;
            //    row.Cells[5].Value = txt_Address.Text;

            //    dgv.Rows.Add(row);
            //}
        }
    }
}
