using System.Windows.Forms;

namespace 便當
{
    public class FormControl
    {
        public bool ClosingCheck = false;
        public void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (!ClosingCheck)
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
    }
}
