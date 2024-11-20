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
    public partial class ValueChanging : Form
    {
        public ValueChanging()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {    
            DialogResult = DialogResult.OK;
        }
    }
}
