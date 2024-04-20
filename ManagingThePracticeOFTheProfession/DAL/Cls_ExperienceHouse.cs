using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_ExperienceHouse:DAL.ClassDAL
    {
      public static  void Save(string ExpNo)
        {
            try
            {
                Run("insert into ExperienceHouse_Tbl (NoExperienceHouse) values ('" + ExpNo + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
