using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace 便當
{
    public partial class Menu : Form
    {
        // nameof
        public class 便當
        {
            public string 便當名稱 { get; set; }
            public string 價格 { get; set; }
            public int 便當ID { get; set; }
        }

        List<便當> 菜單 = new List<便當>();

        public Menu()
        {
            InitializeComponent();
            SQLconn conn = new SQLconn();
            string selectstr = $"select * from Meals";
            DataTable result = conn.conn(selectstr);
            DataRow[] data = result.Select();
            for (int i = 0; i < data.Length; i++)               
            {
                if (Convert.ToInt32(data[i]["MealID"]) != 998 && Convert.ToInt32(data[i]["MealID"]) != 999)
                    菜單.Add(new 便當() { 便當名稱 = data[i]["MealName"].ToString(), 價格 = data[i]["PricePerMeal"].ToString(),便當ID = Convert.ToInt32(data[i]["MealID"]) }); // 0
            }
            菜單.Add(new 便當() { 便當名稱 = "白飯", 價格 = "10", 便當ID = 998 });
            菜單.Add(new 便當() { 便當名稱 = "飲料", 價格 = "0", 便當ID = 999 });
            for (int i = 0; i <= 8; i++)
            {
                string lbl_name = "lbl" + i.ToString();
                string lbl_price = "item" + i.ToString() + "pricelbl";
                string pic_ = "itempic" + i.ToString();
                var lbl = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_name);
                var lblP = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_price);
                var pic = Controls.OfType<PictureBox>().First(rs => rs.Name.Trim() == pic_);
                lbl.Text = 菜單[i].便當名稱.ToString();
                lblP.Text = 菜單[i].價格.ToString();
                if (lbl.Text == "白飯")
                    pic.ImageLocation = "C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\Rice.jpg";
                else if (lbl.Text == "飲料")
                    pic.ImageLocation = "C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\BlackTea.jpg";
                else
                    pic.ImageLocation = $"C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\{i + 1}.jpg";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
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

        private void BeginOrderButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderInfo order = new OrderInfo();
            GetOrder();
            if (order.ShowDialog() == DialogResult.Yes)
                this.Show();
        }



        private void item0數量控制(object sender, EventArgs e)
        {
            if (item0qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[0].便當名稱, item0qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[9].便當名稱, item0qty.Value);
            }
        }

        private void item1數量控制(object sender, EventArgs e)
        {
            if (item1qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[1].便當名稱, item1qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[10].便當名稱, item1qty.Value);
            }
        }

        private void item2數量控制(object sender, EventArgs e)
        {
            if (item2qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[2].便當名稱, item2qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[11].便當名稱, item2qty.Value);
            }
        }

        private void item3數量控制(object sender, EventArgs e)
        {
            if (item3qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[3].便當名稱, item3qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[12].便當名稱, item3qty.Value);
            }
        }

        private void item4數量控制(object sender, EventArgs e)
        {
            if (item4qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[4].便當名稱, item4qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[13].便當名稱, item4qty.Value);
            }
        }

        private void item5數量控制(object sender, EventArgs e)
        {
            if (item5qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[5].便當名稱, item5qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[14].便當名稱, item5qty.Value);
            }
        }

        private void item6數量控制(object sender, EventArgs e)
        {
            if (item6qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[6].便當名稱, item6qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[15].便當名稱, item6qty.Value);
            }
        }

        private void item7數量控制(object sender, EventArgs e)
        {
            if (item7qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[7].便當名稱, item7qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[16].便當名稱, item7qty.Value);
            }
        }

        private void item8數量控制(object sender, EventArgs e)
        {
            if (item8qty.Enabled == true)
            {
                if (page.Text == "1")
                    表單數量控制(菜單[8].便當名稱, item8qty.Value);
                else if (page.Text == "2")
                    表單數量控制(菜單[17].便當名稱, item8qty.Value);
            }
        }

        private void 表單數量控制(string text, decimal qty)
        {
            // 查找已存在的項目 (傳回第一個找到的項目)
            var item = OrderResult.Items.OfType<ListViewItem>().FirstOrDefault(lvi => lvi.Text.Trim() == text.Trim());
            if (qty != 0)
            {
                if (item == null)
                {
                    // 如果項目不存在，則創建新的項目並添加到 ListView
                    item = new ListViewItem(text);
                    item.SubItems.Add(qty.ToString());
                    OrderResult.Items.Add(item);
                }
                else
                {
                    // 如果項目存在，則更新其數量
                    item.SubItems[1].Text = qty.ToString();
                }
            }
            else
            {
                // 如果數量為 0 且項目存在，則移除該項目
                if (item != null)
                {
                    OrderResult.Items.Remove(item);
                }
            }
        }

        private void page2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 8; i++)
            {
                string lbl_name = "lbl" + i.ToString();
                string lbl_price = "item" + i.ToString() + "pricelbl";
                string pic_ = "itempic" + i.ToString();
                var lbl = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_name);
                var lblP = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_price);
                var pic = Controls.OfType<PictureBox>().First(rs => rs.Name.Trim() == pic_);
                if (i + 9 < 菜單.Count)
                {
                    lbl.Text = 菜單[i + 9].便當名稱.ToString();
                    lblP.Text = 菜單[i + 9].價格.ToString();
                    if (lbl.Text == "白飯")
                        pic.ImageLocation = "C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\Rice.jpg";
                    else if (lbl.Text == "飲料")
                        pic.ImageLocation = "C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\BlackTea.jpg";
                    else
                        pic.ImageLocation = $"C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\{i + 10}.jpg";
                }
                else
                {
                    lbl.Text = "";
                    lblP.Text = "";
                    pic.ImageLocation = "";
                }
                string itemQty = "item" + i.ToString() + "qty";
                var qty = Controls.OfType<NumericUpDown>().First(rs => rs.Name.Trim() == itemQty);
                var item = OrderResult.Items.OfType<ListViewItem>().FirstOrDefault(lvi => lvi.Text.Trim() == lbl.Text.Trim());
                if (lbl.Text == "")
                    qty.Visible = false;
                if (pic.ImageLocation == "")
                    pic.Visible = false;
                else qty.Visible = true;
                qty.Enabled = false;
                if (item != null)
                    qty.Value = Convert.ToDecimal(item.SubItems[1].Text);
                else
                    qty.Value = 0;
                qty.Enabled = true;
            }
            page.Text = 2.ToString();
            page1.Visible = true;
            page2.Visible = false;
        }

        private void page1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 8; i++)
            {
                string lbl_name = "lbl" + i.ToString();
                string lbl_price = "item" + i.ToString() + "pricelbl";
                string pic_ = "itempic" + i.ToString();
                var lbl = Controls.OfType<Label>().FirstOrDefault(rs => rs.Name.Trim() == lbl_name);
                var lblP = Controls.OfType<Label>().FirstOrDefault(rs => rs.Name.Trim() == lbl_price);
                var pic = Controls.OfType<PictureBox>().First(rs => rs.Name.Trim() == pic_);
                lbl.Text = 菜單[i].便當名稱.ToString();
                lblP.Text = 菜單[i].價格.ToString();
                pic.ImageLocation = $"C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\{i + 1}.jpg";
                string itemQty = "item" + i.ToString() + "qty";
                var qty = Controls.OfType<NumericUpDown>().First(rs => rs.Name.Trim() == itemQty);
                var item = OrderResult.Items.OfType<ListViewItem>().FirstOrDefault(lvi => lvi.Text.Trim() == lbl.Text.Trim());
                if (lbl.Text == "")
                    qty.Visible = false;
                else qty.Visible = true;
                qty.Enabled = false;
                if (item != null)
                    qty.Value = Convert.ToDecimal(item.SubItems[1].Text);
                else
                    qty.Value = 0;
                qty.Enabled = true;
                pic.Visible = true;
            }
            page.Text = 1.ToString();
            page1.Visible = false;
            page2.Visible = true;
        }
        private void GetOrder()
        {

            var item = OrderResult.Items.OfType<ListViewItem>();
            orders.Orders.Clear();
            foreach (var i in item)
            {
                String Order_name = i.SubItems[0].Text;
                int Order_count = Convert.ToInt32(i.SubItems[1].Text);
                Decimal price = Convert.ToDecimal(菜單.OfType<便當>().FirstOrDefault(rs => rs.便當名稱 == Order_name).價格);
                int MealID = (菜單.OfType<便當>().FirstOrDefault(rs => rs.便當名稱 == Order_name).便當ID);
                orders.Orders.Add(new order_meal() { 便當ID = MealID, 便當名稱 = Order_name, 數量 = Order_count, 便當價格 = price });
            }
        }
    }
}
