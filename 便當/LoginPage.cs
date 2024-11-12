using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public LoginPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            User.UserName = UserNameInput.Text;
            this.Hide();
            Menu menu = new Menu();
            menu.Show();

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
