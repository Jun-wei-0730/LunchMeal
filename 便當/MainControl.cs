using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace 便當
{

    public partial class MainControl : Form
    {
        List<int> list = new List<int>();
        DataTable DTbaseMeal = new DataTable();
        DataTable DTbaseUser = new DataTable();
        DataTable DTbaseOrder = new DataTable();
        DataTable DTbaseInfo = new DataTable();
        int MealIDSeq;

        public MainControl()
        {
            InitializeComponent();
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
            SQLconn MealConn = new SQLconn();
            string MealSelect = "select * from Meals;";
            DTbaseMeal = MealConn.conn(MealSelect);
            SQLconn UserConn = new SQLconn();
            string UserSelect = "select * from Customers;";
            DTbaseUser = UserConn.conn(UserSelect);
            SQLconn OrderConn = new SQLconn();
            string OrderSelect = "select * from Orders;";
            DTbaseOrder = OrderConn.conn(OrderSelect);
            SQLconn InfoConn = new SQLconn();
            string InfoSelect = "select * from OrderInfo;";
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

        private void NewRowBtn_Click(object sender, EventArgs e)
        {
            DTbaseMeal.Rows.Add(++MealIDSeq, "名稱", "0", 1);
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
                case "使用者": Query(DTbaseUser, "CustomerName"); break ;
                case "全部訂單": Query(DTbaseOrder, "CustomerSeq"); break;
                case "訂單詳細": Query(DTbaseInfo, "OrderID"); break;
                default : Query(DTbaseMeal, "MealName"); break;
            }
            }
        }

        private void NameSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            NameSearchBox.Text = string.Empty;
            NameSearchBox.ForeColor = Color.Black;
        }

        private void TableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = TableBox.SelectedIndex;
            List<string> item = new List<string> {"按Enter查詢使用者名", "按Enter查詢品名", "按Enter查詢訂單編號", "按Enter查詢使用者編號" };
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

            else MenuDataGridView.DataSource = null;
        }

        private void MenuDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (MenuDataGridView.CurrentRow != null)
            {
                MealIDBox.Text = MenuDataGridView.CurrentRow.Cells[0].Value.ToString();
                MealIDBox.Visible = true;
            }
        }
    }
}
