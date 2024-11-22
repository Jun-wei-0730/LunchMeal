using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 便當
{
    public partial class NewID : Form
    {
        DataTable IDTable;
        List<string> list;
        public NewID()
        {
            InitializeComponent();
        }

        private void IDConfirm_Click(object sender, EventArgs e)
        {

        }

        private void IDCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void NewIDInput_TextChanged(object sender, EventArgs e)
        {
            Regex NewIDRe = new Regex("^[A-Za-z0-9]{6,8}$");
            Match NewIDInputMatch = NewIDRe.Match(NewIDInput.Text);
            if (!NewIDInputMatch.Success)
            {
                if (NewIDInput.Text.Length > 8)
                    IDWarning.Text = "ID太長!";
                else if (NewIDInput.Text.Length < 8)
                    IDWarning.Text = "ID太短";
                else
                    IDWarning.Text = "ID格式不對!";
                IDWarning.Visible = true;
            }
            else if (list.Contains(NewIDInput.Text))
            {
                IDWarning.Text = "ID重複!";
                IDWarning.Visible = true;
            }
            else IDWarning.Visible = false;
        }

        private void NewID_Load(object sender, EventArgs e)
        {
            SQLconn conn = new SQLconn();
            list = new List<string>();
            string SelectStr = "select * from Customers";
            IDTable = conn.conn(SelectStr);
            foreach (DataRow row in IDTable.Rows)
            {
                list.Add(row["CustomerID"].ToString());
            }
        }
    }
}
