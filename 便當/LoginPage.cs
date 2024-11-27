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
        public LoginPage()
        {
            InitializeComponent();
        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            CustomerID customerID  = new CustomerID();
            string ID = UserNameInput.Text;
            if (!string.IsNullOrEmpty(ID) && Login_query(ID) != "0")
            {
                List<string> Query_result = customerID.ConnByParameter(ID);
                if (customerID.ConnByParameter(ID) != null)
                {
                    User.User_Seq = Convert.ToInt32(Query_result[0]);
                    User.User_ID = Query_result[1];
                    User.UserName = Query_result[2];
                    User.User_Birth = Query_result[3];
                    User.User_Carrier = Query_result[4].ToString();
                    User.User_Admin = Convert.ToBoolean(Query_result[5]);
                    if (User.User_Admin)
                    {
                        MainControl menuEdit = new MainControl();
                        this.Hide();
                        menuEdit.Show();
                    }
                    else
                    {
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                    }
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
            else return "1";
        }
        

        private void MenuChange_Click(object sender, EventArgs e)
        {
            CustomerID customerID = new CustomerID();
            string ID = UserNameInput.Text;
            if (!string.IsNullOrEmpty(ID) && Login_query(ID) != "0")
            {
                List<string> Query_result = customerID.ConnByParameter(ID);
                if (customerID.ConnByParameter(ID) != null)
                {
                    User.User_Seq = Convert.ToInt32(Query_result[0]);
                    User.User_ID = Query_result[1];
                    User.UserName = Query_result[2];
                    User.User_Birth = Query_result[3];
                    User.User_Carrier = Query_result[4];
                    User.User_Admin = Convert.ToBoolean(Query_result[5]);
                    if (User.User_Admin)
                    {
                        MainControl menuEdit = new MainControl();
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

        private void NewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewCustomer newID = new NewCustomer();
            if (newID.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void UserNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}
