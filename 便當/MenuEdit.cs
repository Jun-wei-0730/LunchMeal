using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace 便當
{

    public partial class MenuEdit : Form
    {
        int MealID = 10;
        DataTable DTbase = new DataTable();
        public MenuEdit()
        {
            InitializeComponent();
        }

        private void MenuEdit_Load(object sender, EventArgs e)
        {
            SQLconn conn = new SQLconn();
            string select = "select * from Meals;";
            DTbase = conn.conn(select);
            MenuDataGridView.DataSource = DTbase;
            foreach (DataGridViewColumn Column in MenuDataGridView.Columns)
            {
                if (Column.HeaderCell.Value.ToString() == "MealID")
                {
                    Column.ReadOnly = true;
                }
            }
        }

        private void ChangeUpload_Click(object sender, EventArgs e)
        {
            SortID();
            SQLconn conn = new SQLconn();
            conn.BackupDB();
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            string UpdateCmd = "Update Meals set MealName = @Name,PricePerMeal = @Price,Enabled = @Enable where MealID = @ID ;";
            string InsertCmd = "Insert into Meals values (@ID,@Name,@Price,@Enable)";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateCmd,connection))
                {
                    foreach (DataGridViewRow Row in MenuDataGridView.Rows)
                    {
                        ParameterAdd(cmd, Row);
                        int rs = cmd.ExecuteNonQuery();
                        if (rs == 0)
                        {
                            using (SqlCommand Insertcmd = new SqlCommand(InsertCmd,connection))
                            {
                                ParameterAdd(Insertcmd, Row);
                                Insertcmd.ExecuteNonQuery();
                            }
                        }
                        
                    }
                }
                connection.Close();
            }
            MessageBox.Show("變更已儲存。");
        }

        private void MenuDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Chose = MenuDataGridView.CurrentCell;
            string Location = MenuDataGridView.Columns[MenuDataGridView.CurrentCell.ColumnIndex].HeaderText;
        }

        private void NewRowBtn_Click(object sender, EventArgs e)
        {
            DTbase.Rows.Add(++MealID, "名稱", "0", 1);
        }

        private void DeleteRowBtn_Click(object sender, EventArgs e)
        {
            if (MenuDataGridView.CurrentRow != null)
            {
                var ChoseIndex = MenuDataGridView.CurrentRow.Index;
                MenuDataGridView.Rows.RemoveAt(ChoseIndex);
            }
        }
        private void SortBtn_Click(object sender, EventArgs e)
        {
            SortID();
        }

        private void MenuEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl MenuEdit = new FormControl();
            MenuEdit.Form_Close(sender, e);
        }
        private void SortID()
        {
            int i = 1;
            foreach (DataGridViewRow Row in MenuDataGridView.Rows)
            {
                if (!Row.IsNewRow)
                {
                    if (Row.Cells["MealName"].Value.ToString() == "白飯")
                        Row.Cells["MealID"].Value = 998;
                    else if (Row.Cells["MealName"].Value.ToString() == "飲料")
                        Row.Cells["MealID"].Value = 999;
                    else Row.Cells["MealID"].Value = i++;
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
    }
}
