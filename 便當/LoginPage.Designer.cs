namespace 便當
{
    partial class LoginPage
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerIDInput = new System.Windows.Forms.TextBox();
            this.Test = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.NewUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserNameInput
            // 
            this.CustomerIDInput.BackColor = System.Drawing.SystemColors.Window;
            this.CustomerIDInput.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CustomerIDInput.Location = new System.Drawing.Point(211, 237);
            this.CustomerIDInput.Name = "UserNameInput";
            this.CustomerIDInput.Size = new System.Drawing.Size(370, 50);
            this.CustomerIDInput.TabIndex = 0;
            this.CustomerIDInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerIDInput_KeyDown);
            // 
            // Test
            // 
            this.Test.AutoSize = true;
            this.Test.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Test.Location = new System.Drawing.Point(225, 87);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(343, 47);
            this.Test.TabIndex = 1;
            this.Test.Text = "MealOrderSystem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(309, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "請輸入使用者ID :";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.CadetBlue;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loginButton.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loginButton.ForeColor = System.Drawing.Color.Black;
            this.loginButton.Location = new System.Drawing.Point(325, 306);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(153, 59);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "確認";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // NewUser
            // 
            this.NewUser.Location = new System.Drawing.Point(665, 447);
            this.NewUser.Name = "NewUser";
            this.NewUser.Size = new System.Drawing.Size(123, 35);
            this.NewUser.TabIndex = 5;
            this.NewUser.Text = "創建新使用者";
            this.NewUser.UseVisualStyleBackColor = true;
            this.NewUser.Click += new System.EventHandler(this.NewCustomer_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.NewUser);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.CustomerIDInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "便當系統-登入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginPage_FormClosing);
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CustomerIDInput;
        private System.Windows.Forms.Label Test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button NewUser;
    }
}

