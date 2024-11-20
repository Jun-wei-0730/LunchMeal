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
    
    public partial class MenuEdit : Form
    {
        DataTable DTbase = new DataTable();
        DataRow row;
        public MenuEdit()
        {
            InitializeComponent();
        }

        private void MenuEdit_Load(object sender, EventArgs e)
        {
            SQLconn conn = new SQLconn();
            string select = "select * from Meals;";
            DTbase = conn.conn(select);
            dataGridView1.DataSource = DTbase;
            foreach (DataGridViewColumn Column in dataGridView1.Columns)
            {
                if (Column.HeaderCell.Value.ToString() == "MealID")
                {
                    Column.ReadOnly = true;
                }
            }
        }

        private void ChangeUpload_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.RowCount-2; i++)
            {
                row = DTbase.Rows[i];
                row.ItemArray = row.ItemArray.ToArray();
                Console.WriteLine(row.ItemArray[2]);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Chose = dataGridView1.CurrentCell;
            string Location = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
            if (Location == "MealID")
            {
                MessageBox.Show("ID不得更改!");
                Chose.Value = dataGridView1.CurrentCell.Value;
            }
        }
    }
}
