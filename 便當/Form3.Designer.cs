namespace 便當
{
    partial class ValueChanging
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
            this.NewValueBox = new System.Windows.Forms.TextBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OldValuelbl = new System.Windows.Forms.Label();
            this.NewValuelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewValueBox
            // 
            this.NewValueBox.Location = new System.Drawing.Point(44, 84);
            this.NewValueBox.Name = "NewValueBox";
            this.NewValueBox.Size = new System.Drawing.Size(178, 22);
            this.NewValueBox.TabIndex = 0;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(44, 135);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 1;
            this.ConfirmBtn.Text = "確認";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(149, 135);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OldValuelbl
            // 
            this.OldValuelbl.AutoSize = true;
            this.OldValuelbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OldValuelbl.Location = new System.Drawing.Point(40, 26);
            this.OldValuelbl.Name = "OldValuelbl";
            this.OldValuelbl.Size = new System.Drawing.Size(62, 19);
            this.OldValuelbl.TabIndex = 3;
            this.OldValuelbl.Text = "原為 : ";
            // 
            // NewValuelbl
            // 
            this.NewValuelbl.AutoSize = true;
            this.NewValuelbl.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NewValuelbl.Location = new System.Drawing.Point(71, 60);
            this.NewValuelbl.Name = "NewValuelbl";
            this.NewValuelbl.Size = new System.Drawing.Size(125, 21);
            this.NewValuelbl.TabIndex = 4;
            this.NewValuelbl.Text = "輸入新的值 :";
            // 
            // ValueChanging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(260, 188);
            this.Controls.Add(this.NewValuelbl);
            this.Controls.Add(this.OldValuelbl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.NewValueBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValueChanging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ValueChanging";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label OldValuelbl;
        private System.Windows.Forms.Label NewValuelbl;
        public System.Windows.Forms.TextBox NewValueBox;
    }
}