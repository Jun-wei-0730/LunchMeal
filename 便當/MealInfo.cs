using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 便當
{
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
    }
}
