using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 便當
{

    public partial class MainControl : Form
    {
        DataTable DTbaseMeal = new DataTable();
        DataTable DTbaseUser = new DataTable();
        DataTable DTbaseOrders = new DataTable();
        DataTable DTbaseInfo = new DataTable();
        bool MenuChange = false;
        bool BoxEvent = false; // 判斷是否是手動輸入修改變更欄位文字

        public MainControl()
        {
            InitializeComponent();
        }
        private void MainControl_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            TableBox.Text = "菜單";
            UserNameLabel.Text = "使用者 : " + User.UserName;
            GetSQL();
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                foreach (Control control in panel.Controls)
                {
                    control.TextChanged += AllowSaveChange; //當手動輸入修改變更(不是切換資料行時的變更)開啟保存變更按鈕
                }
                foreach (CheckBox box in panel.Controls.OfType<CheckBox>())
                {
                    box.CheckedChanged += AllowSaveChange;
                }
                foreach (Button button in panel.Controls.OfType<Button>())
                {
                    button.Click += AllowSaveChange;
                }
            }
        }
        private void MenuEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmChangebtn.Visible)
            {
                FormControl MenuEdit = new FormControl();
                MenuEdit.Form_Close(sender, e);
            }
            else
            {
                if (MessageBox.Show("還有更改未保存，確定要關閉嗎？", "警告", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    FormControl MenuEdit = new FormControl
                    {
                        ClosingCheck = true
                    };
                    MenuEdit.Form_Close(sender, e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void MenuDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("數據格式錯誤!");
            MessageBox.Show(e.Exception.ToString());
        }
        private void ParameterAdd(SqlCommand cmd, DataGridViewRow Row)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", Row.Cells["MealID"].Value.ToString());
            cmd.Parameters.AddWithValue("@Name", Row.Cells["MealName"].Value.ToString());
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(Row.Cells["PricePerMeal"].Value));
            cmd.Parameters.AddWithValue("@Enable", Convert.ToBoolean(Row.Cells["Enabled"].Value));
        }

        private void Logout1_Click(object sender, EventArgs e)
        {
            LogOutCheck CheckWindow = new LogOutCheck();
            if (CheckWindow.ShowDialog() == DialogResult.Yes)
            {
                this.Hide();
                LoginPage LoginPage = new LoginPage();
                LoginPage.Show();
            }
        }
        public void UploadConfirm(SqlCommand cmd, string InsertCmd, SqlConnection connection)
        {
            foreach (DataGridViewRow Row in MenuDataGridView.Rows)
            {

                ParameterAdd(cmd, Row);
                int rs = cmd.ExecuteNonQuery();
                if (rs == 0)
                {
                    using (SqlCommand Insertcmd = new SqlCommand(InsertCmd, connection))
                    {
                        ParameterAdd(Insertcmd, Row);
                        Insertcmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void Menubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void NameSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (TableBox.Text)
                {
                    case "使用者":
                        Query(DTbaseUser, "名字"); NowPanellbl.Text = "User"; Addbtn.Visible = false; UploadPanel.Visible = false; DeleteThisOrderbtn.Visible = false;
                        UserPanel.Location = new Point(551, 65); PanelControl(NowPanellbl.Text); EditBtn.Visible = true; DeleteThisMealbtn.Visible = false; break;
                    case "全部訂單":
                        Query(DTbaseOrders, "訂餐者"); NowPanellbl.Text = "Orders"; Addbtn.Visible = false; UploadPanel.Visible = false; DeleteThisOrderbtn.Visible = true;
                        OrdersPanel.Location = new Point(551, 65); PanelControl(NowPanellbl.Text); EditBtn.Visible = true; DeleteThisMealbtn.Visible = false; break;
                    case "餐點詳細":
                        Query(DTbaseInfo, "訂單編號"); NowPanellbl.Text = "Info"; Addbtn.Visible = false; UploadPanel.Visible = false; DeleteThisOrderbtn.Visible = false;
                        InfoPanel.Location = new Point(551, 65); PanelControl(NowPanellbl.Text); EditBtn.Visible = true; DeleteThisMealbtn.Visible = false; break;
                    default:
                        Query(DTbaseMeal, "品項"); NowPanellbl.Text = "Meal"; Addbtn.Visible = true; UploadPanel.Visible = true; DeleteThisOrderbtn.Visible = false;
                        MealPanel.Location = new Point(551, 65); PanelControl(NowPanellbl.Text); EditBtn.Visible = true; DeleteThisMealbtn.Visible = true; break;
                }
                Addbtn.Enabled = true;
                EditBtn.Enabled = true;

                if (MenuDataGridView.DataSource == null)
                {
                    MealPanel.Visible = false;
                    UserPanel.Visible = false;
                    OrdersPanel.Visible = false;
                    InfoPanel.Visible = false;
                    Addbtn.Enabled = false;
                    EditBtn.Enabled = false;
                    MessageBox.Show("查詢不到結果！");
                }
            }
        }

        private void NameSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            NameSearchBox.Text = string.Empty;
            NameSearchBox.ForeColor = Color.Black;
            MenuChange = true;
        }

        private void TableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = TableBox.SelectedIndex;
            List<string> item = new List<string> { "按Enter查詢使用者名", "按Enter查詢品項", "按Enter查詢訂單者名字", "按Enter查詢訂單編號" };
            NameSearchBox.Text = item[index].ToString();
            NameSearchBox.ForeColor = Color.Silver;
        }
        private void Query(DataTable DTbase, string ColumnName)
        {
            MenuDataGridView.DataSource = DTbase;
            DataTable dt = new DataTable();
            string SearchStr = NameSearchBox.Text;
            var query = from rows in DTbase.AsEnumerable()
                        where rows[ColumnName].ToString().Contains(SearchStr)
                        select rows;

            if (query.Count() > 0)
                MenuDataGridView.DataSource = query.CopyToDataTable();

            else
            {
                MenuDataGridView.DataSource = null;
            }
        }

        private void MenuDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            BoxEvent = false;
            ConfirmChangebtn.Enabled = false;
            ConfirmChangebtn.Visible = false;
            EditBtn.Enabled = true;
            ConfirmAddbtn.Visible = false;
            UploadPanel.Visible = false;
            if (!MenuChange && MenuDataGridView.CurrentRow != null)
            {
                switch (TableBox.Text)
                {
                    case "使用者":
                        foreach (TextBox box in UserPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, UserPanel);
                        }
                        UserPanel.Enabled = false;
                        if (MenuDataGridView.CurrentRow.Cells[Adminlbl.Text].Value.ToString() == "True")
                        { AdminBox.Text = "管理員"; }
                        else { AdminBox.Text = "一般用戶"; }
                        break;
                    case "全部訂單":
                        foreach (TextBox box in OrdersPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, OrdersPanel);
                        }
                        OrdersPanel.Enabled = false;
                        if (MenuDataGridView.CurrentRow.Cells[TableWarelbl.Text].Value.ToString() == "True")
                            TableWareBox.Checked = true;
                        else TableWareBox.Checked = false;
                        if (MenuDataGridView.CurrentRow.Cells[PlasticBaglbl.Text].Value.ToString() == "True")
                            PlasticBagBox.Checked = true;
                        else PlasticBagBox.Checked = false;
                        GetMealBox.Text = MenuDataGridView.CurrentRow.Cells[GetMeallbl.Text].Value.ToString();
                        break;
                    case "餐點詳細":
                        foreach (TextBox box in InfoPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, InfoPanel);
                        }
                        InfoPanel.Enabled = false;
                        break;
                    default:
                        foreach (TextBox box in MealPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, MealPanel);
                        }
                        MealPanel.Enabled = false;
                        if (MenuDataGridView.CurrentRow.Cells[Enabledlbl.Text].Value.ToString() == "True")
                        { EnabledBox.Text = "啟用"; EnableColorlbl.BackColor = Color.LawnGreen; }
                        else { EnabledBox.Text = "停用"; EnableColorlbl.BackColor = Color.IndianRed; }
                        break;
                }
            }
            else MenuChange = false;
        }
        private void SetText(string Name, Panel panel)
        {
            string BoxName = Name + "Box";
            string lblName = Name + "lbl";
            var Box = panel.Controls.OfType<TextBox>().FirstOrDefault(rs => rs.Name == BoxName);
            var lbl = panel.Controls.OfType<Label>().FirstOrDefault(rs => rs.Name == lblName);
            if (lbl != null && Box != null && MenuDataGridView.CurrentRow != null)
                Box.Text = MenuDataGridView.CurrentRow.Cells[lbl.Text].Value.ToString().Trim();
            if (DateTime.TryParse(Box.Text, out DateTime dateValue))
            {
                if (panel == UserPanel)
                    Box.Text = dateValue.ToString("yyyy-MM-dd").Trim();
                else
                    if (BoxName == "OrderTimeBox")
                    Box.Text = dateValue.ToString("yyyy-MM-dd HH:mm").Trim();
                else Box.Text = dateValue.ToString("HH:mm").Trim();
            }
        }
        private void GetText(string Name, Panel panel)
        {
            string BoxName = Name + "Box";
            string lblName = Name + "lbl";
            var Box = panel.Controls.OfType<TextBox>().FirstOrDefault(rs => rs.Name == BoxName);
            var Combo = panel.Controls.OfType<ComboBox>().FirstOrDefault(rs => rs.Name == BoxName);
            var Check = panel.Controls.OfType<CheckBox>().FirstOrDefault(rs => rs.Name == BoxName);
            var lbl = panel.Controls.OfType<Label>().FirstOrDefault(rs => rs.Name == lblName);
            if (lbl != null && Box != null)
                MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = Box.Text;
            if (lbl != null && Combo != null)
            {
                switch (Combo.Text)
                {
                    case "啟用":
                        MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = true; EnableColorlbl.BackColor = Color.LawnGreen; break;
                    case "停用":
                        MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = false; EnableColorlbl.BackColor = Color.IndianRed; break;
                    case "管理員":
                        MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = true; break;
                    case "一般用戶":
                        MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = false; break;
                    default:
                        MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = Combo.Text; break;
                }
            }
            if (lbl != null && Check != null)
                MenuDataGridView.CurrentRow.Cells[lbl.Text].Value = Check.Checked;
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            var panel = Controls.OfType<Panel>().First(rs => rs.Name == NowPanellbl.Text + "Panel");
            panel.Enabled = true;
            ConfirmAddbtn.Visible = true;
            ConfirmAddbtn.Enabled = false;
            foreach (TextBox Box in panel.Controls.OfType<TextBox>())
            {
                Box.Text = "";
            }
            int NewSeq = Convert.ToInt32(MenuDataGridView.Rows[MenuDataGridView.Rows.Count - 3].Cells["品項ID"].Value);
            MealIDBox.Text = (NewSeq + 1).ToString();
            ConfirmAddbtn.Enabled = true;
            UploadPanel.Visible = true;
            UploadPanel.Enabled = true;
            Uploadbtn.Enabled = true;
            UploadBox.Visible = true;
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            var panel = Controls.OfType<Panel>().First(rs => rs.Name == NowPanellbl.Text + "Panel");
            panel.Enabled = true;
            BoxEvent = true;
            EditBtn.Enabled = false;
            ConfirmChangebtn.Visible = true;
            if (panel.Name == "MealPanel")
            {
                UploadPanel.Visible = true;
                UploadPanel.Enabled = true;
            }
        }
        private void PanelControl(string NowPanelName)
        {
            // 判斷現在顯示的資料面板並關閉其他
            string PanelName = NowPanelName + "Panel";
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.Name != PanelName)
                { panel.Enabled = false; panel.Visible = false; }
                else
                { panel.Visible = true; }
            }
        }
        private void ConfirmChangebtn_Click(object sender, EventArgs e)
        {
            ConfirmChangebtn.Visible = false;
            ConfirmChangebtn.Enabled = false;
            string PanelName = NowPanellbl.Text + "Panel";
            Panel panel = Controls.OfType<Panel>().FirstOrDefault(rs => rs.Name == PanelName);
            foreach (TextBox item in panel.Controls.OfType<TextBox>())
            {
                string name = item.Name.Substring(0, item.Name.Length - 3);
                GetText(name, panel);
                Update(panel);
            }
            foreach (ComboBox item in panel.Controls.OfType<ComboBox>())
            {
                string name = item.Name.Substring(0, item.Name.Length - 3);
                GetText(name, panel);
                Update(panel);
            }
            foreach (CheckBox item in panel.Controls.OfType<CheckBox>())
            {
                string name = item.Name.Substring(0, item.Name.Length - 3);
                GetText(name, panel);
                Update(panel);
            }

            if (UploadDialog.FileName != null)
            {
                string TargetPath = Path.Combine("C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic", $"{MealIDBox.Text}.png");
                if (File.Exists(UploadDialog.FileName))
                    File.Copy(UploadDialog.FileName, TargetPath, true);
            }
            panel.Enabled = false;
            EditBtn.Enabled = true;
            GetSQL();
            MessageBox.Show("更改已保存！");
        }

        private void AllowSaveChange(object sender, EventArgs e)
        {
            if (BoxEvent)
                ConfirmChangebtn.Enabled = true;
        }
        private void Update(Panel panel)
        {
            switch (panel.Name)
            {
                case "UserPanel":
                    {
                        string UpdateStr = "Update Customers set CustomerName = @CustomerName" +
                            ",Birth = @Birth,Carrier = @Carrier,Admin = @Admin where CustomerID = @CustomerID";
                        List<string> ParaList = new List<string> { "@CustomerID", "@CustomerName", "@Birth", "@Carrier", "@Admin" };
                        List<string> ValueList = new List<string>();
                        for (int i = 0; i < MenuDataGridView.Columns.Count; i++)
                        {
                            string item = MenuDataGridView.CurrentRow.Cells[i].Value.ToString();
                            if (DateTime.TryParse(item, out DateTime dateValue))
                                item = dateValue.ToString("yyyy-MM-dd");
                            ValueList.Add(item);
                        }
                        ConnectionWithParameter conn = new ConnectionWithParameter();
                        conn.ParameterByList(UpdateStr, ParaList, ValueList);
                        break;
                    }
                case "MealPanel":
                    {
                        string UpdateStr = "Update Meals set MealName = @MealName, PricePerMeal = @PricePerMeal, Enabled = @Enabled " +
                            "where MealID = @MealID";
                        List<string> ParaList = new List<string> { "@MealID", "@MealName", "@PricePerMeal", "@Enabled" };
                        List<string> ValueList = new List<string>();
                        for (int i = 0; i < MenuDataGridView.Columns.Count; i++)
                        {
                            string item = MenuDataGridView.CurrentRow.Cells[i].Value.ToString();
                            ValueList.Add(item);
                        }
                        ConnectionWithParameter conn = new ConnectionWithParameter();
                        conn.ParameterByList(UpdateStr, ParaList, ValueList);
                        break;
                    }
                case "OrdersPanel":
                    {
                        string UpdateStr = "declare @CustomerSeq int;" +
                            "select @CustomerSeq = CustomerSeq from Customers where CustomerName = @CustomerName;" +
                            "Update Orders set CustomerSeq = @CustomerSeq, OrderTime = @OrderTime, OrderPrice = @OrderPrice" +
                            ",TableWare = @TableWare, PlasticBag = @PlasticBag, GetMeal = @GetMeal , GetMealTime = @GetMealTime" +
                            ",note = @note where OrderID = @OrderID";
                        List<string> ParaList = new List<string> { "@OrderID", "@CustomerName", "@OrderTime", "@OrderPrice", "@TableWare", "@PlasticBag", "@GetMeal", "@GetMealTime", "@note" };
                        List<string> ValueList = new List<string>();
                        for (int i = 0; i < MenuDataGridView.Columns.Count; i++)
                        {
                            string item = MenuDataGridView.CurrentRow.Cells[i].Value.ToString();
                            Console.WriteLine(item);
                            if (DateTime.TryParse(item, out DateTime dateValue))
                                item = dateValue.ToString("yyyy-MM-dd HH:mm");
                            ValueList.Add(item);
                        }
                        ConnectionWithParameter conn = new ConnectionWithParameter();
                        conn.ParameterByList(UpdateStr, ParaList, ValueList);
                        break;
                    }
                case "InfoPanel":
                    {
                        string UpdateStr = "declare @MealID int;" +
                            "select @MealID = MealID from Meals where MealName = @MealName;" +
                            "Update OrderInfo set MealCount = @MealCount where MealID = @MealID and OrderID = @OrderID";
                        List<string> ParaList = new List<string> { "@OrderID", "@MealName", "@MealCount" };
                        List<string> ValueList = new List<string>();
                        for (int i = 0; i < MenuDataGridView.Columns.Count; i++)
                        {
                            string item = MenuDataGridView.CurrentRow.Cells[i].Value.ToString();
                            ValueList.Add(item);
                        }
                        ConnectionWithParameter conn = new ConnectionWithParameter();
                        conn.ParameterByList(UpdateStr, ParaList, ValueList);
                        break;
                    }
            }

        }

        private void ConfirmAddbtn_Click(object sender, EventArgs e)
        {
            if (UploadDialog.FileName != null)
            {
                string TargetPath = Path.Combine("C:\\Users\\junwei\\source\\repos\\便當\\便當\\便當\\pic", $"{MealIDBox.Text}.png");
                if (File.Exists(UploadDialog.FileName))
                    File.Copy(UploadDialog.FileName, TargetPath, true);
            }
            string InsertStr = "Insert into Meals (MealID, MealName, PricePerMeal, Enabled) values" +
                "(@MealID, @MealName, @PricePerMeal, @Enabled)";
            List<string> ParaList = new List<string> { "@MealID", "@MealName", "@PricePerMeal", "@Enabled" };
            bool Enable;
            if (EnabledBox.Text == "啟用") Enable = true; else Enable = false;
            List<string> ValueList = new List<string> { MealIDBox.Text, MealNameBox.Text, PricePerMealBox.Text, Enable.ToString() };
            ConnectionWithParameter conn = new ConnectionWithParameter();
            conn.ParameterByList(InsertStr, ParaList, ValueList);
            GetSQL();
            Query(DTbaseMeal, "品項");

        }

        private void EnabledBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnabledBox.Text == "啟用") EnableColorlbl.BackColor = Color.LawnGreen;
            else EnableColorlbl.BackColor = Color.IndianRed;
        }

        private void Uploadbtn_Click(object sender, EventArgs e)
        {
            UploadDialog.AddExtension = true;
            UploadDialog.Filter = "Image Files(*.PNG;*.JPG;*)|*.PNG;*.JPG;*|All files (*.*)|*.*";
            if (UploadDialog.ShowDialog() == DialogResult.OK && UploadDialog.FileName != null)
            {
                UploadBox.ImageLocation = UploadDialog.FileName;
            }
        }

        private void DeleteThisOrderbtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("刪除後無法復原！真的要刪除嗎？", "警告", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                SQLconn conn = new SQLconn();
                conn.BackupDB();
                ConnectionWithParameter CWPconn = new ConnectionWithParameter();
                string command = "Delete from OrderInfo where OrderID = @OrderID;";
                string OrderID = OrderIDBox.Text;
                Console.WriteLine(OrderID);
                CWPconn.ParameterCommandByOne(command, "@OrderID", OrderID);
                command = "Delete from Orders where OrderID = @OrderID;";
                CWPconn.ParameterCommandByOne(command, "@OrderID", OrderID);
                MessageBox.Show("訂單已刪除");
                GetSQL();
                Query(DTbaseOrders, "訂餐者");
            }

        }
        private void GetSQL()
        {
            SQLconn MealConn = new SQLconn();
            string MealSelect = "select MealID as 品項ID,MealName as 品項,PricePerMeal as 價格,Enabled as 狀態 from Meals;";
            DTbaseMeal = MealConn.conn(MealSelect);
            SQLconn UserConn = new SQLconn();
            string UserSelect = "select CustomerID as 帳號, CustomerName as 名字, Birth as 生日, Carrier as 載具, Admin as 權限 from Customers;";
            DTbaseUser = UserConn.conn(UserSelect);
            SQLconn OrderConn = new SQLconn();
            string OrderSelect = "select OrderID as 訂單編號,Customers.CustomerName as 訂餐者,OrderTime as 訂餐時間,OrderPrice as 訂單總價, " +
                "TableWare as 餐具,PlasticBag as 塑膠袋, GetMeal as 取餐方式, GetMealtime as 取餐時間, Note as 備註 from Orders inner join Customers on Orders.CustomerSeq = Customers.CustomerSeq;";
            DTbaseOrders = OrderConn.conn(OrderSelect);
            SQLconn InfoConn = new SQLconn();
            string InfoSelect = "select OrderID as 訂單編號, Meals.MealName as 品項,MealCount as 餐點數量 from OrderInfo inner join Meals on OrderInfo.MealID = Meals.MealID;";
            DTbaseInfo = InfoConn.conn(InfoSelect);
        }

        private void DeleteThisMealbtn_Click(object sender, EventArgs e)
        {
            string CheckCommand = "select OrderID from OrderInfo where MealID in (select MealID from OrderInfo) and MealID = @MealID;";
            ConnectionWithParameter CWPconn = new ConnectionWithParameter();
            string MealID = MealIDBox.Text;
            var reader = CWPconn.ParameterSelectByOne(CheckCommand, "@MealID", MealID);
            int result = reader.Count;
            if (result != 0)
            {
                var rs = MessageBox.Show("此品項尚有訂單，要全部一起刪除嗎？", "警告", MessageBoxButtons.OKCancel);
                if (rs == DialogResult.OK)
                {
                    var Warning = MessageBox.Show("刪除後無法復原！真的要刪除嗎？", "警告", MessageBoxButtons.OKCancel);
                    if (Warning == DialogResult.OK)
                    {
                        SQLconn conn = new SQLconn();
                        conn.BackupDB();
                        for (int i = 0; i < reader.Count; i++)
                        {
                            string OrderID = reader[i];
                            string command = "Delete from OrderInfo where OrderID = @OrderID;";
                            CWPconn.ParameterCommandByOne(command, "@OrderID", OrderID);
                            command = "Delete from Orders where OrderID = @OrderID;";
                            CWPconn.ParameterCommandByOne(command, "@OrderID", OrderID);
                        }
                        string DeleteCommand = "Delete from Meals where MealID = @MealID;";
                        CWPconn.ParameterCommandByOne(DeleteCommand, "@MealID", MealID);
                        MessageBox.Show("品項已刪除");
                        GetSQL();
                        Query(DTbaseMeal, "品項");
                    }

                }
            }
            else
            {
                var Warning = MessageBox.Show("刪除後無法復原！真的要刪除嗎？", "警告", MessageBoxButtons.OKCancel);
                if (Warning == DialogResult.OK)
                {
                    string DeleteCommand = "Delete from Meals where MealID = @MealID;";
                    CWPconn.ParameterCommandByOne(DeleteCommand, "@MealID", MealID);
                    MessageBox.Show("品項已刪除");
                    GetSQL();
                    Query(DTbaseMeal, "品項");
                }
            }
        }
    }
}
