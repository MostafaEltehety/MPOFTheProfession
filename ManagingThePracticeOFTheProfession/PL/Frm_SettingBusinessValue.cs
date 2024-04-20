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
    public partial class Frm_SettingBusinessValue : Form
    {
        public Frm_SettingBusinessValue()
        {
            InitializeComponent();
        }

        void restate()
        {
            DAL.Cls_BusinessValue.DGView(dataGridView1);
            txt_Box.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txt_Taxes.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txt_Stamp.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            txt_Amount.Text =Convert.ToDecimal(( Convert.ToDecimal(txt_Amount.Text)+300)).ToString();
            txt_BusinesValue.Text = Convert.ToDecimal((Convert.ToDecimal(txt_BusinesValue.Text) + 1000000)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_To_Click(object sender, EventArgs e)
        {

        }

        private void txt_BusinesValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);

        }

        private void txt_Taxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void txt_Stamp_KeyPress(object sender, KeyPressEventArgs e)
        {
            DAL.ClassDAL.UseNumbersOnly(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_BusinesValue.Text == "0"|| txt_Amount.Text=="0"||txt_Taxes.Text=="0"||txt_Box.Text=="0"||txt_Stamp.Text=="0")
            {
                return;
            }
            else
            {
                DAL.Cls_BusinessValue.Insert(Convert.ToDecimal(txt_BusinesValue.Text), Convert.ToDecimal(txt_Amount.Text), Convert.ToDecimal(txt_Taxes.Text), Convert.ToDecimal(txt_Box.Text), Convert.ToDecimal(txt_Stamp.Text));
                restate();
            }

        }

        private void Frm_SettingBusinessValue_Load(object sender, EventArgs e)
        {
            restate();
        }

        private void txt_BusinesValue_TextChanged(object sender, EventArgs e)
        {
            ClearNumber(txt_BusinesValue);
        }

        void ClearNumber(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = "0";
            }
        }

        private void txt_Amount_TextChanged(object sender, EventArgs e)
        {
            ClearNumber(txt_Amount);
        }

        private void txt_Taxes_TextChanged(object sender, EventArgs e)
        {
            ClearNumber(txt_Taxes);
        }

        private void txt_Box_TextChanged(object sender, EventArgs e)
        {
            ClearNumber(txt_Box);
        }

        private void txt_Stamp_TextChanged(object sender, EventArgs e)
        {
            ClearNumber(txt_Stamp);
        }
    }
}
