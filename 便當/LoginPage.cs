using System;
using System.Data;
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
            if (!string.IsNullOrEmpty(UserNameInput.Text))
            {
                string selectstr = "";
                string ID = UserNameInput.Text;
                if (Login_query(ID) != "0")
                {
                    selectstr = Login_query(ID);
                    DataTable result = conn.conn(selectstr);
                    DataRow[] data = result.Select();
                    if (data.Length != 0 && data[0]["CustomerID"].ToString() == ID)
                    {
                        User.UserName = data[0]["CustomerName"] as string;
                        User.User_Carrier = data[0]["Carrier"] as string;
                        User.User_ID = ID;
                        User.User_Seq = Convert.ToInt32(data[0]["CustomerSeq"]);
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("查詢不到該使用者!");
                    }
                }
                else MessageBox.Show("ID不得包含空白!"); 
            }
            else
                MessageBox.Show("名稱不得為空!");

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
            else return $"select * from Customers where CustomerID = {ID}";
        }
    }
}
