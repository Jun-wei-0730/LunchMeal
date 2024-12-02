using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 便當
{
    public partial class OrderInfo : Form
    {
        decimal Total;
        private readonly BindingSource bindingSource1 = new BindingSource();
        bool programclose = false;
        public OrderInfo()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogOutCheck CheckWindow = new LogOutCheck();
            if (CheckWindow.ShowDialog() == DialogResult.Yes)
            {
                this.Hide();
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
            OrderData(orders.Orders);
            dataGridView1.DataSource = bindingSource1;
            if (dataGridView1.Columns["便當名稱"] != null)
            {
                dataGridView1.Columns["便當名稱"].DisplayIndex = 0;
                dataGridView1.Columns["便當價格"].DisplayIndex = 1;
                dataGridView1.Columns["數量"].DisplayIndex = 2;
                dataGridView1.Columns["小計"].DisplayIndex = 3;
                dataGridView1.Columns["便當ID"].Visible = false;
            };
            Total_lbl.Text = Total.ToString();
            getMealTime_box.Text = (DateTime.Now.AddMinutes(20).ToString("HH:mm"));
            DateTime fixedTime = DateTime.Today.AddHours(14);
            for (int i = 2; i < 8; i++)
            {
                if (DateTime.Now.AddMinutes(i * 20).CompareTo(fixedTime) < 0)
                    getMealTime_box.Items.Add(DateTime.Now.AddMinutes(i * 20).ToString("HH:mm"));
            }
            if (!getMealTime_box.Items.Contains(fixedTime))
                getMealTime_box.Items.Add(fixedTime.ToString("HH:mm"));
            if (!string.IsNullOrWhiteSpace(User.User_Carrier))
            {
                carrier.Visible = true;
                carrier.Text = User.User_Carrier as string;
                carrier.ForeColor = Color.Black;
                carriercheck.Checked = true;
                carrierrm_check.Visible = true;
                carrierrm_check.Checked = true;
            }
        }

        private void backtomenu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Hide();
        }
        private void OrderData(List<order_meal> order_Meals)
        {
            List<MealData> UnsortedData = new List<MealData>();
            foreach (var item in order_Meals)
            {
                // DataTable
                // IComparer
                // 1. DataGridView 排序
                // 2. 資料來源：先把資料來源整理好再塞進去 <= 現在用這個
                UnsortedData.Add(new MealData(item.便當名稱, Convert.ToInt32(item.數量), Convert.ToInt32(item.便當價格)));
                UnsortedData.Sort((MealData D1, MealData D2) =>
                    {
                        if (D1.數量 != D2.數量)
                            return D1.數量.CompareTo(D2.數量);
                        else
                            return 0;
                    });
            }

            foreach (var item in UnsortedData)
            {
                Total += Convert.ToDecimal(item.小計);
            }
            bindingSource1.DataSource = UnsortedData;
        }


        private void carriercheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!carriercheck.Checked)
            {
                carrier.Visible = false;
                carrierrm_check.Visible = false;
                carrier_warning.Visible = false;
            }
            else
            {
                carrier.Visible = true;
                carrierrm_check.Visible = true;
                carrierrm_check.Checked = true;
                Regex carrierRe = new Regex("^\\/[A-Za-z0-9]{7}$");
                Match carrierMatch = carrierRe.Match(carrier.Text);
                carrier_warning.Visible = (!carrierMatch.Success);
            }
        }
        private void carrier_TextChanged(object sender, EventArgs e)
        {
            Regex carrierRe = new Regex("^\\/[A-Za-z0-9]{7}$");
            Match carrierMatch = carrierRe.Match(carrier.Text);
            carrier_warning.Visible = (!carrierMatch.Success);
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
            Total_lbl.Text = (plasticBagcheck.Checked ? Total += 1 : Total -= 1).ToString();
        }
        private void PS_MouseClick(object sender, MouseEventArgs e)
        {
            if (note.Text == "在此輸入備註(限制50字)")
                note.Text = "";
            note.ForeColor = Color.Black;
        }

        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            if (carrier_warning.Visible)
            {
                MessageBox.Show("載具格式不對!");
            }
            else if (getMeal_Box.Text == "選擇取餐方式")
            {
                MessageBox.Show("請選擇取餐方式!");
            }
            else
            {
                SQLconn Orderconn = new SQLconn();
                DateTime UnsortedOrderTime = DateTime.Now;
                string UserID_fixed = User.User_ID.Substring(User.User_ID.Length - 4);
                string OrderTime_fixed = UnsortedOrderTime.ToString("yyMMddHHmms");
                string OrderID = UserID_fixed + "-" + OrderTime_fixed;
                string OrderTime = UnsortedOrderTime.ToString("yy-MM-dd HH:mm");
                int Total = Convert.ToInt32(Total_lbl.Text);
                int tableware = check(tablewarecheck);
                int plasticbag = check(plasticBagcheck);
                string getMeal = getMeal_Box.Text;
                string getMealTime = getMealTime_box.Text;
                string _note = note.Text;
                string str = "";
                string insertstrOrder = $"Insert into Orders values('{OrderID}','{User.User_Seq}','{OrderTime}',{Total},{tableware},{plasticbag},'{getMeal}','{getMealTime}','{_note}');";
                Orderconn.connOrder(insertstrOrder);
                for (int i = 0; i <= orders.Orders.Count - 1; i++)
                {
                    str += $"('{OrderID}',{orders.Orders[i].便當ID}, {orders.Orders[i].數量})";
                    if (i != orders.Orders.Count - 1)
                        str += ",";
                }
                string insertstrInfo = $"Insert into OrderInfo values{str};";
                Orderconn.connOrder(insertstrInfo);
                if (carrier.Text != User.User_Carrier && carrierrm_check.Checked)
                {
                    string UpdateUsercarrier = $"Update Customers set Carrier ='{carrier.Text}' where CustomerID = '{User.User_ID}'";
                    Orderconn.connOrder(UpdateUsercarrier);
                }
                MessageBox.Show("訂單儲存完成。");
                programclose = true;
                this.Close();
            }
        }

        private void OrderInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing && programclose == false)
            {
                FormControl Order = new FormControl();
                Order.Form_Close(sender, e);
            }
        }
        public int check(CheckBox Box)
        {
            if (!Box.Checked)
                return 0;
            else return 1;
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


