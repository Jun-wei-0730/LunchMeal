using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 便當.Menu;

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
        public static string User_ID { get; }
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

        // Decimal
        public Decimal 便當價格 { get; set; }
    }
    public class Data : order_meal
    {

        public string 小計 { get; set; }

        public Data(string 便當名稱, int 數量, Decimal 價格)
        {
            this.便當名稱 = 便當名稱;
            this.數量 = 數量;
            this.便當價格 = 價格;
            小計 = (數量 * 價格).ToString();
        }

    }
}
