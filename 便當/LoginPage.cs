using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            Connection CustomerID = new Connection();
            string ID = CustomerIDInput.Text;
            if (string.IsNullOrEmpty(ID) || !Login_query(ID))
                MessageBox.Show("ID格式不對!");
            else
            {
                List<string> Query_result = CustomerID.CustomerIDConn(ID);
                if (CustomerID.CustomerIDConn(ID) == null)
                    MessageBox.Show("查詢不到該使用者!");
                else
                {
                    User.User_Seq = Convert.ToInt32(Query_result[0]);
                    User.User_ID = Query_result[1];
                    User.UserName = Query_result[2];
                    User.User_Birth = Query_result[3];
                    User.User_Carrier = Query_result[4];
                    User.User_Admin = Convert.ToBoolean(Query_result[5]);
                    if (User.User_Admin)
                    {
                        MainControl MainControl = new MainControl();
                        this.Hide();
                        MainControl.Show();
                    }
                    else
                    {
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                    }
                }
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl Login = new FormControl();
            Login.Form_Close(sender, e);
        }
        private bool Login_query(string ID)
        {
            Regex IDRe = new Regex("^[A-Za-z0-9]{6,8}$");
            Match IDMatch = IDRe.Match(ID);
            return IDMatch.Success;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewCustomer newID = new NewCustomer();
            newID.ShowDialog();
        }

        private void CustomerIDInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}
