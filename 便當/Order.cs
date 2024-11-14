using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 便當
{
    public partial class OrderInfo : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public OrderInfo()
        {
            InitializeComponent();
        }

        private void Logout1_Click(object sender, EventArgs e)
        {
            LogOutCheck CheckWindow = new LogOutCheck();
            if (CheckWindow.ShowDialog() == DialogResult.Yes)
            {
                this.Close();
                LoginPage LoginPage = new LoginPage();
                LoginPage.Show();
            }
        }
        private void OrderInfo_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
            bindingSource1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            // 排序未生效
            //dataGridView1.Sort(new RowComparer(SortOrder.Descending));
            OrderData(orders.Orders);
            dataGridView1.DataSource = bindingSource1;
            if (dataGridView1.Columns["便當名稱"] != null)
            {
                dataGridView1.Columns["便當名稱"].DisplayIndex = 0;
                dataGridView1.Columns["便當價格"].DisplayIndex = 1;
                dataGridView1.Columns["數量"].DisplayIndex = 2;
                dataGridView1.Columns["小計"].DisplayIndex = 3;
            }

            //dataGridView1.Columns["數量"].SortMode = DataGridViewColumnSortMode.Automatic;
            //dataGridView1.Sort(dataGridView1.Columns["數量"], ListSortDirection.Descending);
            ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void OrderData(List<order_meal> order_Meals)
        {
            List<Data> UnsortdData = new List<Data>();
            foreach (var item in order_Meals)
            {
                order_meal order = item;
                // DataTable
                // IComparer


                // 1. DataGridView 排序
                // 2. 資料來源：先把資料來源整理好再塞進去
                UnsortdData.Add(new Data(item.便當名稱, Convert.ToInt32(item.數量), Convert.ToInt32(item.便當價格)));
                UnsortdData.Sort((Data D1, Data D2) =>
                    {
                        if (D1.數量 != D2.數量)
                            return D1.數量.CompareTo(D2.數量);
                        else
                            return 0;

                    });
            }
            bindingSource1.DataSource = UnsortdData;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void carriercheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!carriercheck.Checked) 
                carrier.Visible = false;
            else
                carrier.Visible = true;
        }
        private void carrier_TextChanged(object sender, EventArgs e)
        {
            Regex carrierRe = new Regex("^\\/[A-Za-z0-9]{7}$");
            Match carrierMatch = carrierRe.Match(carrier.Text);
            if (!carrierMatch.Success)
               carrier_warning.Visible = true;
            else carrier_warning.Visible = false;
        }

        private void carrier_MouseClick(object sender, MouseEventArgs e)
        {
            if (carrier.Text == "在此輸入載具條碼")
                carrier.Text = "";
            carrier.ForeColor = Color.Black;
        }
        private void getMeal_Box_DropDown(object sender, EventArgs e)
        {
            getMeal_Box.ForeColor = Color.Black;
        }
        // IComparer 做了發現沒有排序，先換別的方法

        //private class RowComparer : System.Collections.IComparer
        //{
        //    private static int sortOrderModifier = 1;

        //    public RowComparer(System.Windows.Forms.SortOrder sortOrder)
        //    {
        //        if (sortOrder == System.Windows.Forms.SortOrder.Descending)
        //        {
        //            sortOrderModifier = -1;
        //        }
        //        else if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
        //        {
        //            sortOrderModifier = 1;
        //        }
        //    }

        //    public int Compare(object x, object y)
        //    {
        //        DataGridViewRow dataGridViewRow1 = (DataGridViewRow)x;
        //        DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
        //        int CompareResult = System.String.Compare(
        //            dataGridViewRow1.Cells[1].Value.ToString(),
        //            dataGridViewRow2.Cells[1].Value.ToString());
        //        return CompareResult * sortOrderModifier;
        //    }
        //}               
    }
}

