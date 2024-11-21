using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace 便當
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginPage());
        }
    }
    public static class User
    {
        public static string UserName { get; set; }
        public static string User_ID { get; set; }
        public static string User_Carrier { get; set; }
        public static int User_Seq { get; set; }
    }
    public class orders
    {
        public static List<order_meal> Orders = new List<order_meal>();
    }
    public class order_meal
    {
        public string 便當名稱 { get; set; }

        //int 
        public int 數量 { get; set; }

        // decimal
        public decimal 便當價格 { get; set; }

        public int 便當ID { get; set; }
    }
    public class MealData : order_meal
    {

        public string 小計 { get; set; }

        public MealData(string 便當名稱, int 數量, Decimal 價格)
        {
            this.便當名稱 = 便當名稱;
            this.數量 = 數量;
            this.便當價格 = 價格;
            小計 = (數量 * 價格).ToString();
        }
        public void MealID(int ID)
        {
            this.便當ID = ID;
        }
    }
    public class SQLconn
    {
        DataTable dataTable = new DataTable();
        public string connstr = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
        public DataTable conn(string command)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string selectstr = command;
            SqlCommand commandobj = new SqlCommand(selectstr, conn);
            SqlDataReader reader = commandobj.ExecuteReader();
            dataTable.Load(reader);
            conn.Close();
            return dataTable;
        }
        public void connOrder(string command)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(command, conn))
                {
                    commandobj.ExecuteNonQuery();  // 執行 SQL 命令
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }
        }
        public void BackupDB()
        {
            string BackupLocation = ConfigurationManager.ConnectionStrings["BackUpLocation"].ConnectionString;
            string BackupCommand = $"backup database MealDB to Disk = '{BackupLocation}'";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(BackupCommand, conn))
                {
                    commandobj.ExecuteNonQuery();  // 執行 SQL 命令
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }
        }
        public void CleanTable(string ParentTable ,string ChildTable,string ID)
        {
            string CleanupCommand = $"DELETE FROM {ParentTable} WHERE {ID} NOT IN (SELECT DISTINCT {ID} FROM {ChildTable});";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                Console.WriteLine("已連線");
                using (SqlCommand commandobj = new SqlCommand(CleanupCommand, conn))
                {
                    commandobj.ExecuteNonQuery();  // 執行 SQL 命令
                    Console.WriteLine("執行成功");
                }
                conn.Close();
                Console.WriteLine("關閉連線");
            }

        }
    }
}

    public class FormControl
    {
        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            string message = "是否關閉程式？";
            string caption = "關閉提醒";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }
