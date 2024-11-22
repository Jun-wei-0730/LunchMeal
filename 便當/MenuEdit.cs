using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace 便當
{

    public partial class MenuEdit : Form
    {
        List<int> list = new List<int>();
        DataTable DTbase = new DataTable();
        int MealIDSeq;
        public MenuEdit()
        {
            InitializeComponent();
        }

        private void MenuEdit_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
            SQLconn conn = new SQLconn();
            string select = "select * from Meals;";
            DTbase = conn.conn(select);
            MenuDataGridView.DataSource = DTbase;
            MealIDSeq = DTbase.Rows.Count - 2;
            foreach (DataGridViewColumn Column in MenuDataGridView.Columns)
            {
                if (Column.HeaderText == "MealID")
                {
                    Column.ReadOnly = true;
                    Column.Width = 50;
                }
                if (Column.HeaderText == "PricePerMeal")
                {
                    Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Column.Width = 70;
                }
                if (Column.HeaderText == "Enabled")
                {
                    Column.Width = 70;
                }
            }
        }
        private void ChangeUpload_Click(object sender, EventArgs e)
        {
            SortID();
            SQLconn conn = new SQLconn();
            conn.BackupDB();
            FKColumn("Meals", "OrderInfo", "MealID");
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            string UpdateCmd = "Update Meals set MealName = @Name,PricePerMeal = @Price,Enabled = @Enable where MealID = @ID ;";
            string InsertCmd = "Insert into Meals values (@ID,@Name,@Price,@Enable)";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateCmd,connection))
                {
                    List<int> DataGridViewID = new List<int>();
                    foreach (DataGridViewRow row in MenuDataGridView.Rows)
                        DataGridViewID.Add(Convert.ToInt32(row.Cells["MealID"].Value));
                    bool allOK = list.All(ID => DataGridViewID.Contains(ID));
                    if (allOK)
                    {
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
                            // TODO TSQL Delete 和 Truncate 差異
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

        private void MenuDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Chose = MenuDataGridView.CurrentCell;
            string Location = MenuDataGridView.Columns[MenuDataGridView.CurrentCell.ColumnIndex].HeaderText;
        }

        private void NewRowBtn_Click(object sender, EventArgs e)
        {
            DTbase.Rows.Add(++MealIDSeq, "名稱", "0", 1);
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
        public void FKColumn(string ParentTable ,string ChildTable, string ID)
        {
            DataTable dt ;
            SQLconn conn = new SQLconn();
            string str = $"SELECT {ID} FROM {ParentTable} WHERE {ID} IN (SELECT DISTINCT {ID} FROM {ChildTable})"; 
            dt = conn.conn(str);
            foreach (DataRow dr in dt.Rows)
                list.Add(Convert.ToInt32(dr[0]));
        }
        public void UploadConfirm(SqlCommand cmd,string InsertCmd,SqlConnection connection)
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
    }
}
