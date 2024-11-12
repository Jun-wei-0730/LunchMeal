namespace 便當
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BeginOrderButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BeginOrderButton
            // 
            this.BeginOrderButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BeginOrderButton.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BeginOrderButton.Location = new System.Drawing.Point(642, 398);
            this.BeginOrderButton.Name = "BeginOrderButton";
            this.BeginOrderButton.Size = new System.Drawing.Size(146, 49);
            this.BeginOrderButton.TabIndex = 0;
            this.BeginOrderButton.Text = "開始訂購";
            this.BeginOrderButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Location = new System.Drawing.Point(747, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "登出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BeginOrderButton);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BeginOrderButton;
        private System.Windows.Forms.Button button1;
    }
}