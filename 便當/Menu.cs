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
    public partial class Menu : Form
    {
        ListViewItem 表單_雞腿飯 = new ListViewItem();
        ListViewItem 表單_排骨飯 = new ListViewItem();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;

        }

        private void Logout1_Click(object sender, EventArgs e)
        {
            LogOutCheck CheckWindow = new LogOutCheck();
            if (CheckWindow.ShowDialog() == DialogResult.Yes)
                this.Close();
            LoginPage LoginPage = new LoginPage();
            LoginPage.Show();
        }

        private void BeginOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void 雞腿飯數量控制(object sender, EventArgs e)
        {
            表單數量控制(表單_雞腿飯, 雞腿飯, 雞腿飯數量.Value);
        }

        private void 排骨飯數量控制(object sender, EventArgs e)
        {
            表單數量控制(表單_排骨飯, 排骨飯, 排骨飯數量.Value);
        }
        private void 表單數量控制(ListViewItem 表單 , Label 文字,decimal 數量)
        {
            if (數量 != 0)
            {
                if (!listView1.Items.Contains(表單))
                    listView1.Items.Add(表單);
                表單.Text = 文字.Text;
                表單.SubItems.Add("0");
                表單.SubItems[1].Text = 數量.ToString();
            }
            else
            {
                listView1.Items.Remove(表單);
            }
        }
    }
}
