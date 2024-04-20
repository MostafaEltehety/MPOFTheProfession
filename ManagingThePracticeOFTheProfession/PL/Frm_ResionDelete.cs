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
    public partial class Frm_ResionDelete : Form
    {
        string type ,FormID,RevID,IDEng,IDOwner,SeraialNumber= "";
        public Frm_ResionDelete(string TypeForm,string IDFrom,string IDrev,string ideng,string idowner,string serial)
        {
            InitializeComponent();
            type = TypeForm;
            FormID = IDFrom;
            RevID = IDrev;
            IDEng = ideng;
            IDOwner = idowner;
            SeraialNumber = serial;

        }

        private void bt_SearchOffice_Click(object sender, EventArgs e)
        {
            if (type== "SH_D")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_D.Delete(FormID, RevID,type,IDEng,IDOwner,SeraialNumber,DAL.ClassDAL.IDUser.ToString(),textBox1.Text);
                }

            }

            if (type == "SH_D2")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_D2.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_G")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_G.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_G2")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_G2.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_B")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_B.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_B2")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_B2.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_H")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_H.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            if (type == "SH_W")
            {
                if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    DAL.Cls_SH_W.Delete(FormID, RevID, type, IDEng, IDOwner, SeraialNumber, DAL.ClassDAL.IDUser.ToString(), textBox1.Text);
                }

            }

            this.Close();
        }
    }
}
