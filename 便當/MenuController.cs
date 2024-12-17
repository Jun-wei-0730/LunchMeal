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
    [DefaultEvent(nameof(TextChanged))]
    public partial class MenuController : UserControl
    {
        public MenuController()
        {
            InitializeComponent();
        }
        public NumericUpDown ControllerQtyNUD
        {
            get { return QtyNUD; }
        }
        [Browsable(true)] // 顯示在屬性
        public string MealText
        {
            get => Meallbl.Text;
            set => Meallbl.Text = value;
        }
        public string PriceText
        {
            get => Pricelbl.Text;
            set => Pricelbl.Text = value;
        }
        public string PicLocation
        {
            get => MealPic.ImageLocation;
            set => MealPic.ImageLocation = value;
        }
        public int Qty
        {
            get => (int)QtyNUD.Value;
            set => QtyNUD.Value = value;
        }
    }
}
    
