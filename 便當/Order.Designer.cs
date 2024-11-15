namespace 便當
{
    partial class OrderInfo
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
            this.components = new System.ComponentModel.Container();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.CompleteOrderButton = new System.Windows.Forms.Button();
            this.Logout1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.plasticBagcheck = new System.Windows.Forms.CheckBox();
            this.carriercheck = new System.Windows.Forms.CheckBox();
            this.tablewarecheck = new System.Windows.Forms.CheckBox();
            this.carrier = new System.Windows.Forms.TextBox();
            this.getMeal_Box = new System.Windows.Forms.ComboBox();
            this.取餐時間 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.carrier_warning = new System.Windows.Forms.Label();
            this.Total_lbl = new System.Windows.Forms.Label();
            this.總價 = new System.Windows.Forms.Label();
            this.元 = new System.Windows.Forms.Label();
            this.getMealTime_box = new System.Windows.Forms.ComboBox();
            this.PS = new System.Windows.Forms.TextBox();
            this.carrierrm_check = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UserNameLabel.Location = new System.Drawing.Point(14, 12);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(114, 27);
            this.UserNameLabel.TabIndex = 5;
            this.UserNameLabel.Text = "Username";
            // 
            // CompleteOrderButton
            // 
            this.CompleteOrderButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CompleteOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CompleteOrderButton.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompleteOrderButton.Location = new System.Drawing.Point(617, 416);
            this.CompleteOrderButton.Margin = new System.Windows.Forms.Padding(4);
            this.CompleteOrderButton.Name = "CompleteOrderButton";
            this.CompleteOrderButton.Size = new System.Drawing.Size(170, 65);
            this.CompleteOrderButton.TabIndex = 6;
            this.CompleteOrderButton.Text = "訂購";
            this.CompleteOrderButton.UseVisualStyleBackColor = false;
            this.CompleteOrderButton.Click += new System.EventHandler(this.CompleteOrderButton_Click);
            // 
            // Logout1
            // 
            this.Logout1.AutoSize = true;
            this.Logout1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout1.ForeColor = System.Drawing.Color.Black;
            this.Logout1.Location = new System.Drawing.Point(759, 18);
            this.Logout1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Logout1.Name = "Logout1";
            this.Logout1.Size = new System.Drawing.Size(31, 16);
            this.Logout1.TabIndex = 7;
            this.Logout1.Text = "登出";
            this.Logout1.Click += new System.EventHandler(this.Logout1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "回上頁";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(456, 350);
            this.dataGridView1.TabIndex = 9;
            // 
            // plasticBagcheck
            // 
            this.plasticBagcheck.AutoSize = true;
            this.plasticBagcheck.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.plasticBagcheck.Location = new System.Drawing.Point(481, 85);
            this.plasticBagcheck.Name = "plasticBagcheck";
            this.plasticBagcheck.Size = new System.Drawing.Size(180, 29);
            this.plasticBagcheck.TabIndex = 10;
            this.plasticBagcheck.Text = "加購塑膠袋 (1元)";
            this.plasticBagcheck.UseVisualStyleBackColor = true;
            this.plasticBagcheck.CheckedChanged += new System.EventHandler(this.plasticBagcheck_CheckedChanged);
            // 
            // carriercheck
            // 
            this.carriercheck.AutoSize = true;
            this.carriercheck.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.carriercheck.Location = new System.Drawing.Point(481, 150);
            this.carriercheck.Name = "carriercheck";
            this.carriercheck.Size = new System.Drawing.Size(111, 29);
            this.carriercheck.TabIndex = 11;
            this.carriercheck.Text = "使用載具";
            this.carriercheck.UseVisualStyleBackColor = true;
            this.carriercheck.CheckedChanged += new System.EventHandler(this.carriercheck_CheckedChanged);
            // 
            // tablewarecheck
            // 
            this.tablewarecheck.AutoSize = true;
            this.tablewarecheck.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.tablewarecheck.Location = new System.Drawing.Point(481, 50);
            this.tablewarecheck.Name = "tablewarecheck";
            this.tablewarecheck.Size = new System.Drawing.Size(111, 29);
            this.tablewarecheck.TabIndex = 12;
            this.tablewarecheck.Text = "提供餐具";
            this.tablewarecheck.UseVisualStyleBackColor = true;
            // 
            // carrier
            // 
            this.carrier.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.carrier.Location = new System.Drawing.Point(481, 185);
            this.carrier.Name = "carrier";
            this.carrier.Size = new System.Drawing.Size(180, 23);
            this.carrier.TabIndex = 13;
            this.carrier.Text = "在此輸入載具條碼";
            this.carrier.Visible = false;
            this.carrier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.carrier_MouseClick);
            this.carrier.TextChanged += new System.EventHandler(this.carrier_TextChanged);
            // 
            // getMeal_Box
            // 
            this.getMeal_Box.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.getMeal_Box.FormattingEnabled = true;
            this.getMeal_Box.Items.AddRange(new object[] {
            "外帶自取",
            "外送"});
            this.getMeal_Box.Location = new System.Drawing.Point(481, 120);
            this.getMeal_Box.Name = "getMeal_Box";
            this.getMeal_Box.Size = new System.Drawing.Size(121, 24);
            this.getMeal_Box.TabIndex = 14;
            this.getMeal_Box.Text = "選擇取餐方式";
            this.getMeal_Box.DropDown += new System.EventHandler(this.getMeal_Box_DropDown);
            // 
            // 取餐時間
            // 
            this.取餐時間.AutoSize = true;
            this.取餐時間.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.取餐時間.Location = new System.Drawing.Point(476, 284);
            this.取餐時間.Name = "取餐時間";
            this.取餐時間.Size = new System.Drawing.Size(299, 25);
            this.取餐時間.TabIndex = 15;
            this.取餐時間.Text = "選擇取餐時間 : (最晚為下午兩點)";
            // 
            // carrier_warning
            // 
            this.carrier_warning.AutoSize = true;
            this.carrier_warning.BackColor = System.Drawing.Color.CadetBlue;
            this.carrier_warning.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.carrier_warning.ForeColor = System.Drawing.Color.OrangeRed;
            this.carrier_warning.Location = new System.Drawing.Point(481, 215);
            this.carrier_warning.Name = "carrier_warning";
            this.carrier_warning.Size = new System.Drawing.Size(98, 13);
            this.carrier_warning.TabIndex = 16;
            this.carrier_warning.Text = "載具格式不符合";
            this.carrier_warning.Visible = false;
            // 
            // Total_lbl
            // 
            this.Total_lbl.AutoSize = true;
            this.Total_lbl.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Total_lbl.Location = new System.Drawing.Point(663, 366);
            this.Total_lbl.Name = "Total_lbl";
            this.Total_lbl.Size = new System.Drawing.Size(79, 34);
            this.Total_lbl.TabIndex = 17;
            this.Total_lbl.Text = "9999";
            // 
            // 總價
            // 
            this.總價.AutoSize = true;
            this.總價.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.總價.Location = new System.Drawing.Point(562, 366);
            this.總價.Name = "總價";
            this.總價.Size = new System.Drawing.Size(89, 34);
            this.總價.TabIndex = 18;
            this.總價.Text = "總價 : ";
            // 
            // 元
            // 
            this.元.AutoSize = true;
            this.元.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.元.Location = new System.Drawing.Point(748, 366);
            this.元.Name = "元";
            this.元.Size = new System.Drawing.Size(42, 34);
            this.元.TabIndex = 19;
            this.元.Text = "元";
            // 
            // getMealTime_box
            // 
            this.getMealTime_box.FormattingEnabled = true;
            this.getMealTime_box.Location = new System.Drawing.Point(481, 313);
            this.getMealTime_box.Name = "getMealTime_box";
            this.getMealTime_box.Size = new System.Drawing.Size(141, 24);
            this.getMealTime_box.TabIndex = 20;
            // 
            // PS
            // 
            this.PS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PS.ForeColor = System.Drawing.Color.Gray;
            this.PS.Location = new System.Drawing.Point(19, 406);
            this.PS.Multiline = true;
            this.PS.Name = "PS";
            this.PS.Size = new System.Drawing.Size(456, 76);
            this.PS.TabIndex = 21;
            this.PS.Text = "在此輸入備註";
            this.PS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PS_MouseClick);
            // 
            // carrierrm_check
            // 
            this.carrierrm_check.AutoSize = true;
            this.carrierrm_check.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.carrierrm_check.Location = new System.Drawing.Point(589, 214);
            this.carrierrm_check.Name = "carrierrm_check";
            this.carrierrm_check.Size = new System.Drawing.Size(72, 16);
            this.carrierrm_check.TabIndex = 22;
            this.carrierrm_check.Text = "記住載具";
            this.carrierrm_check.UseVisualStyleBackColor = true;
            this.carrierrm_check.Visible = false;
            // 
            // OrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.carrierrm_check);
            this.Controls.Add(this.PS);
            this.Controls.Add(this.getMealTime_box);
            this.Controls.Add(this.元);
            this.Controls.Add(this.總價);
            this.Controls.Add(this.Total_lbl);
            this.Controls.Add(this.carrier_warning);
            this.Controls.Add(this.取餐時間);
            this.Controls.Add(this.getMeal_Box);
            this.Controls.Add(this.carrier);
            this.Controls.Add(this.tablewarecheck);
            this.Controls.Add(this.carriercheck);
            this.Controls.Add(this.plasticBagcheck);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Logout1);
            this.Controls.Add(this.CompleteOrderButton);
            this.Controls.Add(this.UserNameLabel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "OrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂單詳細";
            this.Load += new System.EventHandler(this.OrderInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Button CompleteOrderButton;
        private System.Windows.Forms.Label Logout1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox plasticBagcheck;
        private System.Windows.Forms.CheckBox carriercheck;
        private System.Windows.Forms.CheckBox tablewarecheck;
        private System.Windows.Forms.TextBox carrier;
        private System.Windows.Forms.ComboBox getMeal_Box;
        private System.Windows.Forms.Label 取餐時間;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label carrier_warning;
        private System.Windows.Forms.Label Total_lbl;
        private System.Windows.Forms.Label 總價;
        private System.Windows.Forms.Label 元;
        private System.Windows.Forms.ComboBox getMealTime_box;
        private System.Windows.Forms.TextBox PS;
        private System.Windows.Forms.CheckBox carrierrm_check;
    }
}