using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 便當
{   

    public partial class OrderInfo : Form
    {
        private DataGridView dataGridView;
        private BindingSource bindingSource1 = new BindingSource();
        public OrderInfo()
        {
            InitializeComponent();
        }

        private void Logout1_Click(object sender, EventArgs e)
        {
            LogOutCheck CheckWindow = new LogOutCheck();
            if (CheckWindow.ShowDialog() == DialogResult.Yes)
            {
                this.Close();
                LoginPage LoginPage = new LoginPage();
                LoginPage.Show();
            }
        }
        private void OrderInfo_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "使用者 : " + User.UserName;
            bindingSource1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            OrderData(orders.Orders);
            dataGridView1.DataSource = bindingSource1;
            if (dataGridView1.Columns["便當名稱"] != null)
            {
                dataGridView1.Columns["便當名稱"].DisplayIndex = 0;
                dataGridView1.Columns["便當價格"].DisplayIndex = 1;
                dataGridView1.Columns["數量"].DisplayIndex = 2;
                dataGridView1.Columns["小計"].DisplayIndex = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void OrderData(List<order_meal> o)
        {
            foreach (var item in o)
            {
                order_meal order = item;
                bindingSource1.Add(new Data(item.便當名稱, Convert.ToInt32(item.數量),Convert.ToInt32(item.便當價格)));
            }         
        }
    }
}
