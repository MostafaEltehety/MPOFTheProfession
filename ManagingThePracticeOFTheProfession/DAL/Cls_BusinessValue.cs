using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;


namespace ManagingThePracticeOFTheProfession.DAL
{
    class Cls_BusinessValue:DAL.ClassDAL
    {
        public static decimal FessValue, BoxValue, TaxValue;
       public static string Stamp;
        public static DataTable dt;
       public static void Insert( decimal BusinessValue, decimal Amount, decimal Taxes, decimal box, decimal Stamp)
        {
            Run("insert into BusinessValue_Tbl (BusinessValue,Amount,Taxes,box,Stamp) values ('"+ BusinessValue + "','"+ Amount + "','"+ Taxes + "','"+ box + "','"+Stamp+"')");
        }

        public static DataGridView DGView(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dgv.DataSource = null;
            try
            {
                dt = Select("select * from BusinessValue_Tbl ");
                if (dt.Rows.Count>0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].HeaderText = "قيمة الأعمال";
                    dgv.Columns[2].HeaderText = "المبلغ";
                    dgv.Columns[3].HeaderText = "الضريبة";
                    dgv.Columns[4].HeaderText = "الصندوق";
                    dgv.Columns[5].HeaderText = "الدمغة الهندسية";
                }
                return dgv;
            }
            catch (Exception ex)
            {
                dgv.DataSource = null;
                return dgv;
                MessageBox.Show(ex.Message);
            }
        }

        public static decimal  RevReci(decimal businesValue )
        {
             dt = new DataTable();
            try
            {
                dt = Select("select * from BusinessValue_Tbl where TypePayed='شهادة اشراف' ");
                #region e

                //foreach (DataRow item in dt.Rows)
                //{
                //    if (businesValue<Convert.ToDecimal(item[1].ToString()))
                //    {
                //        decimal nextValue = Convert.ToDecimal(item[1].ToString());
                //        if (businesValue> Convert.ToDecimal(item++[1].ToString()))
                //        {

                //        }
                //    }
                ////}
                //decimal Amount = 0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    DataRow dr = dt.Rows[i];
                //    DataRow drnext = dt.Rows[i++];
                //    DataRow dtLast = dt.Rows[i--];
                //    if (Convert.ToDecimal(dr[i].ToString())<=Convert.ToDecimal(drnext[i].ToString()) && Convert.ToDecimal(dr[i].ToString()) >= Convert.ToDecimal(drnext[i].ToString()))
                //    {
                //        return Amount = Convert.ToDecimal(dr[i].ToString());
                //    }
                //}
                //return Amount;
                #endregion
               
                decimal amount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (i > 0)
                    //{
                    // Compare with previous row using index
                    decimal curentValue = Convert.ToDecimal(dt.Rows[i]["BusinessValue"].ToString());
                    decimal prevValue;
                    try
                    {
                        prevValue = Convert.ToDecimal(dt.Rows[i - 1]["BusinessValue"].ToString());

                    }
                    catch   
                    {
                        prevValue = 0;
                    }

                    if (businesValue>prevValue & businesValue<=curentValue)
                    {
                        //MessageBox.Show("businesVale  "+ businesValue.ToString());
                        //MessageBox.Show("prevValue  " + prevValue.ToString());
                        //MessageBox.Show("curentValue  " + curentValue.ToString());
                        decimal amu = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                        decimal tx = Convert.ToDecimal(dt.Rows[i]["Taxes"].ToString());
                        decimal tax =amu*tx ;
                        FessValue = amu;
                        TaxValue = tax;
                        BoxValue = Convert.ToDecimal(dt.Rows[i]["box"].ToString());
                        amount = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString())+tax+ Convert.ToDecimal(dt.Rows[i]["box"].ToString());
                    }



                    //decimal nextValue = Convert.ToDecimal(dt.Rows[i + 1]["BusinessValue"].ToString());
                    //if (Convert.ToDecimal(dt.Rows[i]["BusinessValue"].ToString()) > Convert.ToDecimal(dt.Rows[i - 1]["BusinessValue"].ToString()) && Convert.ToDecimal(dt.Rows[i]["BusinessValue"].ToString()) < Convert.ToDecimal(dt.Rows[i + 1]["BusinessValue"].ToString()))
                    //{
                    //    amount = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());

                    //    MessageBox.Show(amount.ToString());
                    //    break;
                    //}
                    //    }
                    //    if (i < ds.Tables["Invoices"].Rows.Count - 1)
                    //    {
                    //        if (ds.Tables["Invoices"].Rows[i]["Amount"] > ds.Tables["Invoices"].Rows[i + 1]["Amount"])
                    //        { }
                    //    }
                    //}

                }
       
                return amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static decimal StampEng(decimal CostArea)
        {
            Stamp = dt.Rows[0]["Stamp"].ToString();
            return CostArea *Convert.ToDecimal( Stamp);
        }
        public static decimal TaxOnly()
        {
            return Convert.ToDecimal(dt.Rows[0]["Taxes"].ToString());
        }
        public static decimal BoxOnly()
        {
            return Convert.ToDecimal(dt.Rows[0]["box"].ToString());
        }


        public static decimal RevReci()
        {
            dt = new DataTable();
            try
            {
                dt = Select("select * from BusinessValue_Tbl where TypePayed='تعديل' ");
                #region e

                 
                #endregion

                decimal amount = 0;
                decimal amu = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
                decimal tx = Convert.ToDecimal(dt.Rows[0]["Taxes"].ToString());
                decimal tax = amu*tx;
                FessValue = amu;
                TaxValue = tax;
                BoxValue = Convert.ToDecimal(dt.Rows[0]["box"].ToString());
                amount = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString())+tax+ Convert.ToDecimal(dt.Rows[0]["box"].ToString());
                return amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }


    }
}
