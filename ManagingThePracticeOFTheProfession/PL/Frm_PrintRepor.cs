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
    public partial class Frm_PrintRepor : Form
    {
        DataTable dt=new DataTable();
        string TypeHD, FromDate, ToDate;
        public Frm_PrintRepor(DataTable _dt,string _FromDate, string _ToDate,string _TypeHD)
        {
            InitializeComponent();
            dt = _dt;
            FromDate = _FromDate;
            ToDate = _ToDate;
            TypeHD = _TypeHD;
        }

        private void Frm_PrintRepor_Load(object sender, EventArgs e)
        {
            Reports.CryGeneralSH cry = new Reports.CryGeneralSH();
            cry.SetDataSource(dt);
             
            cry.SetParameterValue("TypeSH",TypeHD);
            cry.SetParameterValue("FromDate", FromDate);
            cry.SetParameterValue("ToDate", ToDate);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
