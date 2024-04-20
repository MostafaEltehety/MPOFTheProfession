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
    public partial class Frm_SearchFormToEditORDelete : Form
    {
      public  DataTable dt;

        public Frm_SearchFormToEditORDelete()
        {
            InitializeComponent();
        }

        private void btn_Searsh_Click(object sender, EventArgs e)
        {
            #region SH_D
            if (lbl_TypeForm.Text== "SH_D")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_D.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count>0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion

            #region SH_D2
            if (lbl_TypeForm.Text == "SH_D2")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_D2.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion

            #region SH_G
            if (lbl_TypeForm.Text == "SH_G")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_G.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion

            #region SH_G2
            if (lbl_TypeForm.Text == "SH_G2")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_G2.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion


            #region SH_B
            if (lbl_TypeForm.Text == "SH_B")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_B.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion

            #region SH_B2
            if (lbl_TypeForm.Text == "SH_B2")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_B2.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion


            #region SH_H
            if (lbl_TypeForm.Text == "SH_H")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_H.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion


            #region SH_W
            if (lbl_TypeForm.Text == "SH_W")
            {
                dt = new DataTable();
                dt = DAL.Cls_SH_W.searchToDelete(txt_Barcode.Text, txt_NoForm.Text);
                if (dt.Rows.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لا توجد بيانات ");
                }
            }
            #endregion


        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_NoForm.Text!="")
            {
                txt_NoForm.Text = "";
            }
        }

        private void txt_NoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_Barcode.Text!="")
            {
                txt_Barcode.Text = "";
            }
        }
    }
}
