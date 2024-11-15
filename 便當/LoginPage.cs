using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            string selectstr = $"select * from Customers where CustomerID = {ID}";
            DataTable result= conn.conn(selectstr);
            //SqlCommand command = new SqlCommand(selectstr, conn);
            //SqlDataReader reader = command.ExecuteReader();
            //Console.WriteLine(result);
            DataRow[] data = result.Select();
            User.User_Carrier = data[0]["Carrier"].ToString();
            if (data.Length != 0)
            {
                User.UserName = data[0]["CustomerName"].ToString();
                this.Hide();
                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("查詢不到該使用者!");
            }

        }
        
            

        private void LoginPage_Load(object sender, EventArgs e)
        {
        }        
    }
}
