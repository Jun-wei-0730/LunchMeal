using System;
using System.Windows.Forms;

namespace 便當
{
    public partial class LogOutCheck : Form
    {
        public LogOutCheck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void LogOutCheck_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = User.UserName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
