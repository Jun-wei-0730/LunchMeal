using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace 便當
{
    public partial class LoginPage : Form
    {
        SQLconn conn;
        public LoginPage()
        {
            InitializeComponent();
        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            conn = new SQLconn();
            string ID = UserNameInput.Text;
            if (!string.IsNullOrEmpty(ID) && Login_query(ID) != "0")
            {
                List<string> Query_result = conn2(ID);
                if (conn2(ID) != null)
                {
                    User.User_Seq = Convert.ToInt32(Query_result[0]);
                    User.User_ID = Query_result[1];
                    User.UserName = Query_result[2];
                    User.User_Carrier = Query_result[3];
                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
                else
                    MessageBox.Show("查詢不到該使用者!");
            }
            else
                MessageBox.Show("ID格式不對!");
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl Login = new FormControl();
            Login.Form_Close(sender, e);
        }
        private string Login_query(string ID)
        {
            
            Regex IDRe = new Regex("\\s$");
            Match IDMatch = IDRe.Match(ID);
            if (IDMatch.Success)
                return "0";

            else
            {
                return "1";
            }
        }
        private List<string> conn2(string ID)
        {
            List<string> ResultList = new List<string>();
            string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Customers where CustomerID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ResultList.Add(reader.GetInt32(0).ToString());
                            for (int i = 1; i < 5; i++)
                            {
                                ResultList.Add(reader.GetValue(i).ToString());
                            }
                        }
                        conn.Close();
                        return ResultList;
                    }
                    else
                    {
                        conn.Close();
                        return null;
                    }
                }
            }
        }

        private void MenuChange_Click(object sender, EventArgs e)
        {
            conn = new SQLconn();
            string ID = UserNameInput.Text;
            if (!string.IsNullOrEmpty(ID) && Login_query(ID) != "0")
            {
                List<string> Query_result = conn2(ID);
                if (conn2(ID) != null)
                {
                    User.User_Seq = Convert.ToInt32(Query_result[0]);
                    User.User_ID = Query_result[1];
                    User.UserName = Query_result[2];
                    User.User_Carrier = Query_result[3];
                    User.User_Admin = Convert.ToBoolean(Query_result[4]);
                    if (User.User_Admin)
                    {
                        MenuEdit menuEdit = new MenuEdit();
                        this.Hide();
                        menuEdit.Show();
                    }
                    else MessageBox.Show("只有管理員可以修改菜單!");
                }
                else
                    MessageBox.Show("查詢不到該使用者!");
            }
            else
                MessageBox.Show("ID格式不對!");
        }
    }
}
