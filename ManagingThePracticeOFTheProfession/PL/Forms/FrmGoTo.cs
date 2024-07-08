using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.PL.Forms
{
    public partial class FrmGoTo : Form
    {
        string _issuedFrom;
        public FrmGoTo(string IssuedFrom)
        {
            _issuedFrom = IssuedFrom;
            InitializeComponent();
        }
    }
}
