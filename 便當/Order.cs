using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 便當
{
    public partial class OrderInfo : Form
    {
        Decimal Total;
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
            ;
            Total_lbl.Text = Total.ToString();
            getMealTime_box.Text = (DateTime.Now.AddMinutes(20).ToString("HH:mm"));
            DateTime fixedTime = DateTime.Today.AddHours(14);
            for (int i = 2; i < 8; i++)
            {
                if (DateTime.Now.AddMinutes(i * 20).CompareTo(fixedTime) < 0)
                    getMealTime_box.Items.Add(DateTime.Now.AddMinutes(i*20).ToString("HH:mm"));
            }
            if (!getMealTime_box.Items.Contains(fixedTime))
                getMealTime_box.Items.Add(fixedTime.ToString("HH:mm"));
            if (User.User_Carrier != "")
            {
                carrier.Visible = true;
                carrier.Text = User.User_Carrier.ToString();
                carrier.ForeColor = Color.Black;
                carriercheck.Checked = true;
                carrierrm_check.Visible = true;
                carrierrm_check.Checked = true;
            }
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
                // 2. 資料來源：先把資料來源整理好再塞進去 # 現在用這個
                UnsortdData.Add(new Data(item.便當名稱, Convert.ToInt32(item.數量), Convert.ToInt32(item.便當價格)));
                UnsortdData.Sort((Data D1, Data D2) =>
                    {
                        if (D1.數量 != D2.數量)
                            return D1.數量.CompareTo(D2.數量);
                        else
                            return 0;

                    });
            }

            foreach (var item in UnsortdData)
            {
                Total += Convert.ToDecimal(item.小計);
            }
            bindingSource1.DataSource = UnsortdData;
        }


        private void carriercheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!carriercheck.Checked)
            {
                carrier.Visible = false;
                carrierrm_check.Visible = false;
            }
            else
            {
                carrier.Visible = true;
                carrierrm_check.Visible = true;
                carrierrm_check.Checked = true;
            }
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

        private void plasticBagcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (plasticBagcheck.Checked)
            {
                Total += 1;
                Total_lbl.Text = Total.ToString();
            }
            else
            {
                Total -= 1;
                Total_lbl.Text = Total.ToString();
            }

        }
        private void PS_MouseClick(object sender, MouseEventArgs e)
        {
            if (PS.Text == "在此輸入備註")
                PS.Text = "";
            PS.ForeColor = Color.Black;
        }

        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {

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


