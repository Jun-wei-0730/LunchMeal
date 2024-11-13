using System;
using System.Collections.Generic;
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
            public int 價格 { get; set; }
        }
        List<便當> 菜單 = new List<便當>();
        public Menu()
        {
            InitializeComponent();
            菜單.Add(new 便當() { 便當名稱 = "雞腿飯", 價格 = 90 }); // 0
            菜單.Add(new 便當() { 便當名稱 = "排骨飯", 價格 = 80 });
            菜單.Add(new 便當() { 便當名稱 = "焢肉飯", 價格 = 80 });
            菜單.Add(new 便當() { 便當名稱 = "三杯雞飯", 價格 = 85 });
            菜單.Add(new 便當() { 便當名稱 = "蝦排飯", 價格 = 80 });
            菜單.Add(new 便當() { 便當名稱 = "雞排飯", 價格 = 100 });
            菜單.Add(new 便當() { 便當名稱 = "香腸飯", 價格 = 80 });
            菜單.Add(new 便當() { 便當名稱 = "燒肉飯", 價格 = 80 });
            菜單.Add(new 便當() { 便當名稱 = "花枝排飯", 價格 = 80 }); // 8
            for (int i = 0; i < 菜單.Count; i++)
            {
                string lbl_name = "lbl" + i.ToString();
                string lbl_price = "item" + i.ToString() + "pricelbl";
                var lbl = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_name );
                var lblP = Controls.OfType<Label>().First(rs => rs.Name.Trim() == lbl_price);
                lbl.Text = 菜單[i].便當名稱.ToString();
                lblP.Text = 菜單[i].價格.ToString();
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
                this.Close();
            LoginPage LoginPage = new LoginPage();
            LoginPage.Show();
        }

        private void BeginOrderButton_Click(object sender, EventArgs e)
        {

        }



        private void item0數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[0].便當名稱, item0qty.Value);
        }

        private void item1數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[1].便當名稱, item1qty.Value);
        }

        private void item2數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[2].便當名稱, item2qty.Value);
        }

        private void item3數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[3].便當名稱, item3qty.Value);
        }

        private void item4數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[4].便當名稱, item4qty.Value);
        }

        private void item5數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[5].便當名稱, item5qty.Value);
        }

        private void item6數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[6].便當名稱, item0qty.Value);
        }

        private void item7數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[7].便當名稱, item7qty.Value);
        }

        private void item8數量控制(object sender, EventArgs e)
        {
            表單數量控制(菜單[8].便當名稱, item8qty.Value);
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
    }
}
