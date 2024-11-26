using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace 便當
{

    public partial class MainControl : Form
    {
        List<int> list = new List<int>();
        DataTable DTbaseMeal = new DataTable();
        DataTable DTbaseUser = new DataTable();
        DataTable DTbaseOrder = new DataTable();
        DataTable DTbaseInfo = new DataTable();
        bool MenuChange = false;

        public MainControl()
        {
            InitializeComponent();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
            SQLconn MealConn = new SQLconn();
            string MealSelect = "select MealID as 品項ID,MealName as 品項,PricePerMeal as 價格,Enabled as 狀態 from Meals;";
            DTbaseMeal = MealConn.conn(MealSelect);
            SQLconn UserConn = new SQLconn();
            string UserSelect = "select CustomerID as 帳號, CustomerName as 名字, Birth as 生日, Carrier as 載具, Admin as 權限 from Customers;";
            DTbaseUser = UserConn.conn(UserSelect);
            SQLconn OrderConn = new SQLconn();
            string OrderSelect = "select OrderID as 訂單編號,Customers.CustomerName as 訂餐者,OrderTime as 訂餐時間,OrderPrice as 訂單總價, " +
                "TableWare as 餐具,PlasticBag as 塑膠袋, GetMeal as 取餐方式, GetMealtime as 取餐時間, Note as 備註 from Orders inner join Customers on Orders.CustomerSeq = Customers.CustomerSeq;";
            DTbaseOrder = OrderConn.conn(OrderSelect);
            SQLconn InfoConn = new SQLconn();
            string InfoSelect = "select OrderID as 訂單編號, Meals.MealName as 品項,MealCount as 餐點數量 from OrderInfo inner join Meals on OrderInfo.MealID = Meals.MealID;";
            DTbaseInfo = InfoConn.conn(InfoSelect);
        }

        private void ChangeUpload_Click(object sender, EventArgs e)
        {
            SortID();
            SQLconn conn = new SQLconn();
            conn.BackupDB();
            string str = "select * from Meals inner join OrderInfo on Meals.MealID = OrderInfo.MealID";
            DataTable dt = conn.conn(str);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(Convert.ToInt32(dt.Rows[i]["MealID"]));
            }
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            string UpdateCmd = "Update Meals set MealName = @Name,PricePerMeal = @Price,Enabled = @Enable where MealID = @ID ;";
            string InsertCmd = "Insert into Meals values (@ID,@Name,@Price,@Enable)";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateCmd, connection))
                {
                    List<int> DataGridViewID = new List<int>();
                    foreach (DataGridViewRow row in MenuDataGridView.Rows)
                        DataGridViewID.Add(Convert.ToInt32(row.Cells["MealID"].Value));
                    bool allOK = list.All(ID => DataGridViewID.Contains(ID));
                    if (allOK)
                    {
                        conn.CleanTable("Meals", "OrderInfo", "MealID");
                        UploadConfirm(cmd, InsertCmd, connection);
                        MessageBox.Show("變更已儲存。");
                    }
                    else
                    {
                        this.Hide();
                        var result = MessageBox.Show("含有訂單中已存在的餐點，是否要刪除？\n" +
                            "是:連同訂單一起刪除\n否:僅更改未在訂單中的餐點。",
                            "警告", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            string Truncate = "truncate table OrderInfo;";
                            conn.conn(Truncate);
                            conn.CleanTable("Meals", "OrderInfo", "MealID");
                            UploadConfirm(cmd, InsertCmd, connection);
                            MessageBox.Show("變更已儲存。");
                            this.Show();
                        }
                        else if (result == DialogResult.No)
                        {
                            conn.CleanTable("Meals", "OrderInfo", "MealID");
                            UploadConfirm(cmd, InsertCmd, connection);
                            MessageBox.Show("變更已儲存。");
                            this.Show();
                        }
                        else
                        {
                            this.Show();
                        }
                    }
                }
                connection.Close();
            }
        }

        private void DeleteRowBtn_Click(object sender, EventArgs e)
        {
            if (MenuDataGridView.CurrentRow != null)
            {
                var ChoseIndex = MenuDataGridView.CurrentRow.Index;
                MenuDataGridView.Rows.RemoveAt(ChoseIndex);
            }
        }

        private void MenuEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl MenuEdit = new FormControl();
            MenuEdit.Form_Close(sender, e);
        }
        private void SortID()
        {
            foreach (DataGridViewRow Row in MenuDataGridView.Rows)
            {
                if (!Row.IsNewRow)
                {
                    if (Row.Cells["MealName"].Value.ToString() == "白飯")
                        Row.Cells["MealID"].Value = 998;
                    else if (Row.Cells["MealName"].Value.ToString() == "飲料")
                        Row.Cells["MealID"].Value = 999;
                }
            }
            var ColumnMealID = MenuDataGridView.Columns.OfType<DataGridViewColumn>().First(rs => rs.HeaderText == "MealID");
            MenuDataGridView.Sort(ColumnMealID, ListSortDirection.Ascending);
        }

        private void MenuDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("數據格式錯誤!");
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
                    case "使用者": Query(DTbaseUser, "名字");UserPanel.Visible = true; MealPanel.Visible = false; OrdersPanel.Visible = false; InfoPanel.Visible = false;
                        UserPanel.Location = new Point(551, 65);  break;
                    case "全部訂單": Query(DTbaseOrder, "訂餐者"); MealPanel.Visible = false; UserPanel.Visible = false; OrdersPanel.Visible = true; InfoPanel.Visible = false;
                        OrdersPanel.Location = new Point(551,65); break;
                    case "餐點詳細": Query(DTbaseInfo, "訂單編號"); MealPanel.Visible = false; UserPanel.Visible = false; OrdersPanel.Visible = false; InfoPanel.Visible = true;
                        InfoPanel.Location = new Point(551, 65); break;
                    default : Query(DTbaseMeal, "品項"); MealPanel.Visible = true; UserPanel.Visible = false; OrdersPanel.Visible = false; InfoPanel.Visible = false;
                        MealPanel.Location = new Point (551,65);  break;
                }
            }
            if (MenuDataGridView.DataSource == null)
            {
                MessageBox.Show("查詢不到結果！");
                MealPanel.Visible = false;
                UserPanel.Visible = false;
                OrdersPanel.Visible = false;
                InfoPanel.Visible = false;
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
            List<string> item = new List<string> {"按Enter查詢使用者名", "按Enter查詢品項", "按Enter查詢訂單者名字", "按Enter查詢訂單編號" };
            NameSearchBox.Text = item[index].ToString();
            NameSearchBox.ForeColor= Color.Silver;
        }
        private void Query(DataTable DTbase,string ColumnName)
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
            if (!MenuChange)
            {
                switch (TableBox.Text)
                {
                    case "使用者":
                        foreach (TextBox box in UserPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, UserPanel);
                        }
                        if (MenuDataGridView.CurrentRow.Cells[Adminlbl.Text].Value.ToString() == "True")
                        { AdminBox.Text = "管理員"; }
                        else { AdminBox.Text = "一般使用者"; }
                        break;
                    case "全部訂單":
                        foreach (TextBox box in OrdersPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, OrdersPanel);
                        }
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
                        break;
                    default:
                        foreach (TextBox box in MealPanel.Controls.OfType<TextBox>())
                        {
                            string name = box.Name.Substring(0, box.Name.Length - 3);
                            SetText(name, MealPanel);
                        }
                        if (MenuDataGridView.CurrentRow.Cells[Enabledlbl.Text].Value.ToString() == "True")
                        { EnabledBox.Text = "啟用"; EnableColorlbl.BackColor = Color.LawnGreen; }
                        else { EnabledBox.Text = "停用"; EnableColorlbl.BackColor = Color.IndianRed; }
                        break;
                }
            }
            else MenuChange = false;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
        }
        private void SetText(string Name,Panel panel)
        {
            string BoxName = Name + "Box";
            string lblName = Name + "lbl";
            var Box = panel.Controls.OfType<TextBox>().FirstOrDefault(rs => rs.Name == BoxName);
            var lbl = panel.Controls.OfType<Label>().FirstOrDefault(rs => rs.Name == lblName);
            if (lbl != null && Box != null)
                Box.Text = MenuDataGridView.CurrentRow.Cells[lbl.Text].Value.ToString();
            if (DateTime.TryParse(Box.Text,out DateTime dateValue))
            {
                if (panel == UserPanel)
                    Box.Text = dateValue.ToString("yyyy-MM-dd");
                else
                    if (BoxName == "OrderTimeBox")
                        Box.Text = dateValue.ToString("yyyy-MM-dd HH:mm");
                    else Box.Text = dateValue.ToString("HH:mm");
            }
        }
    }
}
