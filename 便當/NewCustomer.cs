using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 便當
{
    public partial class NewCustomer : Form
    {
        DataTable IDTable;
        List<string> list;
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void CustomerInfoConfirm_Click(object sender, EventArgs e)
        {
            if (!AllOk())
            {
                MessageBox.Show("資料有誤，請再次檢查!");
                return;
            }

            DateTime Birth = BirthPicker.Value;
            string ConnStr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;

            string SelectIDStr = "select CustomerID from Customers where CustomerID = @ID";
            string SelectNameStr = "select customerName from Customers where CustomerName = @Name";
            string CmdStr = "Insert Into Customers values (Next Value For CustomerSeq, @ID, @Name, @Birth, NULL, 0)";
            string ID = NewCustomerIDInput.Text;
            string Name = NewCustomerNameInput.Text;

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SelectIDStr, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    List<int> result = new List<int>();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("ID重複!");
                        reader.Close();
                        return;
                    }
                    reader.Close();
                }

                // bool any = DbContext.Customer.Any(c =>c.CustomerID = customeID)

                using (SqlCommand cmd = new SqlCommand(SelectNameStr, conn))
                {
                    // nvarchar(4000)
                    cmd.Parameters.AddWithValue("@Name", Name);
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("名稱重複!");
                        reader.Close();
                        return;
                    }
                    reader.Close();
                }

                using (SqlCommand InsertCmd = new SqlCommand(CmdStr, conn))
                {
                    InsertCmd.Parameters.AddWithValue("@ID", ID);
                    InsertCmd.Parameters.AddWithValue("@Name", Name);
                    InsertCmd.Parameters.AddWithValue("@Birth", Birth); //因資料庫資料格式為date 傳入字串會出錯
                    InsertCmd.ExecuteNonQuery();
                    MessageBox.Show("資料已儲存");
                    this.Close();
                }
            }
        }

        private void IDCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void NewCustomerIDInput_TextChanged(object sender, EventArgs e)
        {
            Regex NewIDRe = new Regex("^[A-Za-z0-9]{6,8}$");
            Match NewIDInputMatch = NewIDRe.Match(NewCustomerIDInput.Text);
            if (NewIDInputMatch.Success)
            {
                IDWarning.Visible = false;
                IDCheck.Visible = true;
                return;
            }

            if (NewCustomerIDInput.Text.Length > 8)
            {
                IDWarning.Text = "ID太長!";
                return;
            }

            if (NewCustomerIDInput.Text.Length < 6)
            {
                IDWarning.Text = "ID太短";
                return;
            }

            IDWarning.Text = "ID格式不對!";
            IDWarning.Visible = true;
            IDCheck.Visible = false;
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }

        private void NewCustomerNameInput_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NewCustomerNameInput.Text))
            {
                NameWarning.Visible = false;
                NameCheck.Visible = true;
                return;
            }
            if (String.IsNullOrEmpty(NewCustomerNameInput.Text))
            {
                NameWarning.Text = "名稱不得為空!";
                NameWarning.Visible = true;
                NameCheck.Visible = false;
                return;
            }
        }

        private void BirthPicker_ValueChanged(object sender, EventArgs e)
        {
            var ROCYear = new TaiwanCalendar();
            var info = new CultureInfo("zh-TW");
            info.DateTimeFormat.Calendar = ROCYear;

            ROCYear.GetYear(DateTime.Today);

            ROCYearbox.Text = BirthPicker.Value.ToString("D", info);

            if (BirthPicker.Value < DateTime.Today)
            {
                DateWarning.Visible = false;
                DateCheck.Visible = true;
                return;
            }
            DateWarning.Text = "日期不對!";
            DateWarning.Visible = true;
            DateCheck.Visible = false;
        }
        private bool AllOk()
        {
            if (IDCheck.Visible == true && NameCheck.Visible == true && DateCheck.Visible == true)
                return true;
            return false;
        }
    }
}
