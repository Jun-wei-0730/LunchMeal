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
        //SqlConnection conn = new SqlConnection("Data Source = localhost; Initial Catalog = MealDB; Integrated Security = SSPI");
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
                //string selectstr = Login_query(ID);
                //DataTable result = conn.conn(selectstr);
                //DataRow[] data = result.Select();
                List<string> Query_result = conn2(ID);
                //if (data.Length != 0 && data[0]["CustomerID"].ToString() == ID)
                if (conn2(ID) != null)
                {
                    //User.UserName = data[0]["CustomerName"] as string;
                    //User.User_Carrier = data[0]["Carrier"] as string;
                    //User.User_ID = ID;
                    //User.User_Seq = Convert.ToInt32(data[0]["CustomerSeq"]);
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
                //string str = String.Format("declare @ID varchar(50);select @ID = '{0}' select * from Customers where CustomerID = @ID;", ID);
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
                        // Obtain a row from the query result.
                        while (reader.Read())
                        {
                            ResultList.Add(reader.GetInt32(0).ToString());
                            for (int i = 1; i < 4; i++)
                            {
                                ResultList.Add(reader.GetString(i));
                            }
                        }
                        conn.Close();
                        return ResultList;
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                        conn.Close();
                        return null;
                    }
                }
            }
        }

        private void MenuChange_Click(object sender, EventArgs e)
        {
            MenuEdit menuEdit = new MenuEdit();
            this.Hide();
            menuEdit.Show();
        }
    }
}
