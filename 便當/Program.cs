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
        public string 數量 { get; set; }
        public string 便當價格 { get; set; }
    }
    public class Data : order_meal
    {

        public string 小計 { get; set; }
        public Data(string n, int num, int p)
        {
            便當名稱 = n;
            數量 = num.ToString();
            便當價格 = p.ToString();
            小計 = (num * p).ToString();
        }

    }
}
