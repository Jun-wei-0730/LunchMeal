using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 便當
{
    public partial class Menu : Form
    {
        public class 便當
        {
            public string 便當名稱 { get; set; }
            public string 價格 { get; set; }
            public int 便當ID { get; set; }

        }

        readonly List<便當> 菜單 = new List<便當>();

        public Menu()
        {
            InitializeComponent();
            Connection conn = new Connection();
            string selectstr = $"select * from Meals";
            DataTable result = conn.conn(selectstr);
            DataRow[] data = result.Select();
            for (int i = 0; i < data.Length; i++)
            {
                if (Convert.ToInt32(data[i]["Enabled"]) == 1)
                    {
                    switch (Convert.ToInt32(data[i]["MealID"]))
                    {
                        case 998:
                            菜單.Add(new 便當() { 便當名稱 = "白飯", 價格 = "10", 便當ID = 998 }); break;
                        case 999:
                            菜單.Add(new 便當() { 便當名稱 = "飲料", 價格 = "0", 便當ID = 999 }); break;
                        default:
                            菜單.Add(new 便當()
                            {
                                便當名稱 = data[i]["MealName"].ToString(),
                                價格 = data[i]["PricePerMeal"].ToString(),
                                便當ID = Convert.ToInt32(data[i]["MealID"])
                            }); break;
                    }
                    }
            }
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
                pic.ImageLocation = ImgUrlGet(lbl.Text, 菜單[i].便當ID);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
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

        private void BeginOrderButton_Click(object sender, EventArgs e)
        {
            DrinkCount(); // 將飲料數量設定為便當總數
            OrderInfo order = new OrderInfo();
            GetOrder();
            if (OrderResult.Items.Count != 0)
            {
                this.Hide();
                if (order.ShowDialog() == DialogResult.Yes) // 綁在Order表單的回上頁按鈕上
                    this.Show();
            }
            else { MessageBox.Show("訂單是空的!"); }
        }



        private void item0數量控制(object sender, EventArgs e)
        {
            NumericControl(item0qty, 0);
        }

        private void item1數量控制(object sender, EventArgs e)
        {
            NumericControl(item1qty, 1);
        }

        private void item2數量控制(object sender, EventArgs e)
        {
            NumericControl(item2qty, 2);
        }

        private void item3數量控制(object sender, EventArgs e)
        {
            NumericControl(item3qty, 3);
        }

        private void item4數量控制(object sender, EventArgs e)
        {
            NumericControl(item4qty, 4);
        }

        private void item5數量控制(object sender, EventArgs e)
        {
            NumericControl(item5qty, 5);
        }

        private void item6數量控制(object sender, EventArgs e)
        {
            NumericControl(item6qty, 6);
        }

        private void item7數量控制(object sender, EventArgs e)
        {
            NumericControl(item7qty, 7);
        }

        private void item8數量控制(object sender, EventArgs e)
        {
            NumericControl(item8qty, 8);
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

        private void NextPageBtn(object sender, EventArgs e)
        {
            int _page = Convert.ToInt32(page.Text);
            page.Text = (_page + 1).ToString();
            PageMenuGet(_page + 1);
            PrePage.Visible = true;
        }

        private void PrePageBtn(object sender, EventArgs e)
        {

            int _page = Convert.ToInt32(page.Text);
            page.Text = (_page - 1).ToString();
            PageMenuGet(_page - 1);
            if (_page == 2)
            {
                PrePage.Visible = false;
            }
            NextPage.Visible = true;
        }
        private void GetOrder()
        {
            var item = OrderResult.Items.OfType<ListViewItem>();
            orders.Orders.Clear();
            foreach (var i in item)
            {
                string Order_name = i.SubItems[0].Text;
                int Order_count = Convert.ToInt32(i.SubItems[1].Text);
                decimal price = Convert.ToDecimal(菜單.OfType<便當>().FirstOrDefault(rs => rs.便當名稱 == Order_name).價格);
                int MealID = (菜單.OfType<便當>().FirstOrDefault(rs => rs.便當名稱 == Order_name).便當ID);
                orders.Orders.Add(new order_meal() { 便當ID = MealID, 便當名稱 = Order_name, 數量 = Order_count, 便當價格 = price });
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormControl Menu = new FormControl();
                Menu.Form_Close(sender, e);
            }
        }
        private string ImgUrlGet(string lbl_Text, int num)
        {
            string Key;
            if (lbl_Text == "白飯")
                Key = "998";
            else if (lbl_Text == "飲料")
                Key = "999";
            else
                Key = num.ToString();
            string Location = $"C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic\\{Key}";
            List<string> ImageList = new List<string> { ".jpg", ".png" };
            string result = "";
            foreach (string img in ImageList)
            {
                result = Location + img;
                if (File.Exists(Location + img)) break;
            }
            return result;
        }

        private void PageMenuGet(int page)
        {
            int Menu_index = (page - 1) * 9;
            for (int i = 0; i <= 8; i++)
            {
                string lbl_name = "lbl" + i.ToString();
                string lbl_price = "item" + i.ToString() + "pricelbl";
                string pic_ = "itempic" + i.ToString();
                var lbl = Controls.OfType<Label>().FirstOrDefault(rs => rs.Name.Trim() == lbl_name);
                var lblP = Controls.OfType<Label>().FirstOrDefault(rs => rs.Name.Trim() == lbl_price);
                var pic = Controls.OfType<PictureBox>().First(rs => rs.Name.Trim() == pic_);
                if (i + Menu_index < 菜單.Count)
                {
                    lbl.Text = 菜單[i + Menu_index].便當名稱.ToString();
                    lblP.Text = 菜單[i + Menu_index].價格.ToString();
                    pic.ImageLocation = ImgUrlGet(lbl.Text, 菜單[i + Menu_index].便當ID);
                    pic.Visible = true;
                }
                else
                {
                    lbl.Text = "";
                    lblP.Text = "";
                    pic.ImageLocation = "";
                    pic.Visible = false;
                }
                string itemQty = "item" + i.ToString() + "qty";
                var qty = Controls.OfType<NumericUpDown>().First(rs => rs.Name.Trim() == itemQty);
                var item = OrderResult.Items.OfType<ListViewItem>().FirstOrDefault(lvi => lvi.Text.Trim() == lbl.Text.Trim());
                if (lbl.Text == "")
                {
                    qty.Visible = false;
                    NextPage.Visible = false;
                }
                else
                    qty.Visible = true;
                
                qty.Enabled = false;
                if (item != null)
                    qty.Value = Convert.ToDecimal(item.SubItems[1].Text);
                else
                    qty.Value = 0;
                qty.Enabled = true;
            }
        }
        private void NumericControl(NumericUpDown NUD, int NUDnum)
        {
            if (NUD.Enabled == true)
            {
                int MenuNum = (Convert.ToInt32(page.Text) - 1) * 9;
                表單數量控制(菜單[NUDnum + MenuNum].便當名稱, NUD.Value);
            }
        }
        public void DrinkCount()
        {
            var item = OrderResult.Items.OfType<ListViewItem>();
            int Drink_count = 0;
            foreach (var i in item)
            {
                string Order_name = i.SubItems[0].Text;
                int Order_count = Convert.ToInt32(i.SubItems[1].Text);
                if (Order_name != "白飯" && Order_name != "飲料")
                    Drink_count += Order_count;
            }
            var Drink = OrderResult.Items.OfType<ListViewItem>().FirstOrDefault(rs => rs.SubItems[0].Text == "飲料");
            if (Drink != null)
                Drink.SubItems[1].Text = Drink_count.ToString();
            else
            {
                Drink = new ListViewItem("飲料");
                Drink.SubItems.Add(Drink_count.ToString());
                OrderResult.Items.Add(Drink);
            }
        }
    }
}
