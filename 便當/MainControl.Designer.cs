namespace 便當
{
    partial class MainControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuDataGridView = new System.Windows.Forms.DataGridView();
            this.ChangeUpload = new System.Windows.Forms.Button();
            this.DeleteRowBtn = new System.Windows.Forms.Button();
            this.Logout1 = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.MealIDBox = new System.Windows.Forms.TextBox();
            this.MealNameBox = new System.Windows.Forms.TextBox();
            this.PricePerMealBox = new System.Windows.Forms.TextBox();
            this.EnabledBox = new System.Windows.Forms.ComboBox();
            this.MealIDlbl = new System.Windows.Forms.Label();
            this.MealNamelbl = new System.Windows.Forms.Label();
            this.PricePerMeallbl = new System.Windows.Forms.Label();
            this.Enabledlbl = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.Menubtn = new System.Windows.Forms.Button();
            this.NameSearchBox = new System.Windows.Forms.TextBox();
            this.TableBox = new System.Windows.Forms.ComboBox();
            this.MealPanel = new System.Windows.Forms.Panel();
            this.EnableColorlbl = new System.Windows.Forms.Label();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.BirthBox = new System.Windows.Forms.TextBox();
            this.AdminBox = new System.Windows.Forms.TextBox();
            this.CarrierBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.AccountBox = new System.Windows.Forms.TextBox();
            this.Adminlbl = new System.Windows.Forms.Label();
            this.Carrierlbl = new System.Windows.Forms.Label();
            this.Birthlbl = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.Accountlbl = new System.Windows.Forms.Label();
            this.OrdersPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.MenuDataGridView)).BeginInit();
            this.MealPanel.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuDataGridView
            // 
            this.MenuDataGridView.AllowUserToAddRows = false;
            this.MenuDataGridView.AllowUserToDeleteRows = false;
            this.MenuDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MenuDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.MenuDataGridView.BackgroundColor = System.Drawing.Color.Teal;
            this.MenuDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MenuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MenuDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MenuDataGridView.Location = new System.Drawing.Point(12, 65);
            this.MenuDataGridView.Name = "MenuDataGridView";
            this.MenuDataGridView.ReadOnly = true;
            this.MenuDataGridView.RowTemplate.Height = 24;
            this.MenuDataGridView.Size = new System.Drawing.Size(533, 373);
            this.MenuDataGridView.TabIndex = 0;
            this.MenuDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MenuDataGridView_DataError);
            this.MenuDataGridView.SelectionChanged += new System.EventHandler(this.MenuDataGridView_SelectionChanged);
            // 
            // ChangeUpload
            // 
            this.ChangeUpload.Location = new System.Drawing.Point(700, 398);
            this.ChangeUpload.Name = "ChangeUpload";
            this.ChangeUpload.Size = new System.Drawing.Size(94, 40);
            this.ChangeUpload.TabIndex = 2;
            this.ChangeUpload.Text = "確認修改";
            this.ChangeUpload.UseVisualStyleBackColor = true;
            this.ChangeUpload.Click += new System.EventHandler(this.ChangeUpload_Click);
            // 
            // DeleteRowBtn
            // 
            this.DeleteRowBtn.Location = new System.Drawing.Point(17, 36);
            this.DeleteRowBtn.Name = "DeleteRowBtn";
            this.DeleteRowBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteRowBtn.TabIndex = 4;
            this.DeleteRowBtn.Text = "刪除資料";
            this.DeleteRowBtn.UseVisualStyleBackColor = true;
            this.DeleteRowBtn.Click += new System.EventHandler(this.DeleteRowBtn_Click);
            // 
            // Logout1
            // 
            this.Logout1.AutoSize = true;
            this.Logout1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout1.ForeColor = System.Drawing.Color.Black;
            this.Logout1.Location = new System.Drawing.Point(759, 9);
            this.Logout1.Name = "Logout1";
            this.Logout1.Size = new System.Drawing.Size(29, 12);
            this.Logout1.TabIndex = 6;
            this.Logout1.Text = "登出";
            this.Logout1.Click += new System.EventHandler(this.Logout1_Click);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UserNameLabel.Location = new System.Drawing.Point(12, 6);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(114, 27);
            this.UserNameLabel.TabIndex = 7;
            this.UserNameLabel.Text = "Username";
            // 
            // MealIDBox
            // 
            this.MealIDBox.BackColor = System.Drawing.Color.LightGray;
            this.MealIDBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MealIDBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealIDBox.Location = new System.Drawing.Point(89, 19);
            this.MealIDBox.Name = "MealIDBox";
            this.MealIDBox.Size = new System.Drawing.Size(150, 29);
            this.MealIDBox.TabIndex = 8;
            this.MealIDBox.Text = "MealID";
            // 
            // MealNameBox
            // 
            this.MealNameBox.BackColor = System.Drawing.Color.LightGray;
            this.MealNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MealNameBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealNameBox.Location = new System.Drawing.Point(89, 54);
            this.MealNameBox.Name = "MealNameBox";
            this.MealNameBox.Size = new System.Drawing.Size(150, 29);
            this.MealNameBox.TabIndex = 9;
            this.MealNameBox.Text = "MealName";
            // 
            // PricePerMealBox
            // 
            this.PricePerMealBox.BackColor = System.Drawing.Color.LightGray;
            this.PricePerMealBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PricePerMealBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PricePerMealBox.Location = new System.Drawing.Point(89, 89);
            this.PricePerMealBox.Name = "PricePerMealBox";
            this.PricePerMealBox.Size = new System.Drawing.Size(150, 29);
            this.PricePerMealBox.TabIndex = 11;
            this.PricePerMealBox.Text = "PricePerMeal";
            // 
            // EnabledBox
            // 
            this.EnabledBox.BackColor = System.Drawing.Color.LightGray;
            this.EnabledBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EnabledBox.FormattingEnabled = true;
            this.EnabledBox.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.EnabledBox.Location = new System.Drawing.Point(147, 124);
            this.EnabledBox.Name = "EnabledBox";
            this.EnabledBox.Size = new System.Drawing.Size(92, 32);
            this.EnabledBox.TabIndex = 12;
            // 
            // MealIDlbl
            // 
            this.MealIDlbl.AutoSize = true;
            this.MealIDlbl.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealIDlbl.Location = new System.Drawing.Point(1, 24);
            this.MealIDlbl.Name = "MealIDlbl";
            this.MealIDlbl.Size = new System.Drawing.Size(82, 24);
            this.MealIDlbl.TabIndex = 13;
            this.MealIDlbl.Text = "品項ID";
            // 
            // MealNamelbl
            // 
            this.MealNamelbl.AutoSize = true;
            this.MealNamelbl.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealNamelbl.Location = new System.Drawing.Point(11, 54);
            this.MealNamelbl.Name = "MealNamelbl";
            this.MealNamelbl.Size = new System.Drawing.Size(58, 24);
            this.MealNamelbl.TabIndex = 14;
            this.MealNamelbl.Text = "品名";
            // 
            // PricePerMeallbl
            // 
            this.PricePerMeallbl.AutoSize = true;
            this.PricePerMeallbl.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PricePerMeallbl.Location = new System.Drawing.Point(11, 89);
            this.PricePerMeallbl.Name = "PricePerMeallbl";
            this.PricePerMeallbl.Size = new System.Drawing.Size(58, 24);
            this.PricePerMeallbl.TabIndex = 15;
            this.PricePerMeallbl.Text = "價格";
            // 
            // Enabledlbl
            // 
            this.Enabledlbl.AutoSize = true;
            this.Enabledlbl.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Enabledlbl.Location = new System.Drawing.Point(11, 124);
            this.Enabledlbl.Name = "Enabledlbl";
            this.Enabledlbl.Size = new System.Drawing.Size(58, 24);
            this.Enabledlbl.TabIndex = 16;
            this.Enabledlbl.Text = "狀態";
            // 
            // Addbtn
            // 
            this.Addbtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Addbtn.Location = new System.Drawing.Point(551, 332);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(110, 60);
            this.Addbtn.TabIndex = 17;
            this.Addbtn.Text = "新增";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EditBtn.Location = new System.Drawing.Point(684, 332);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(110, 60);
            this.EditBtn.TabIndex = 18;
            this.EditBtn.Text = "修改";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // Menubtn
            // 
            this.Menubtn.Location = new System.Drawing.Point(729, 36);
            this.Menubtn.Name = "Menubtn";
            this.Menubtn.Size = new System.Drawing.Size(59, 23);
            this.Menubtn.TabIndex = 20;
            this.Menubtn.Text = "訂餐";
            this.Menubtn.UseVisualStyleBackColor = true;
            this.Menubtn.Click += new System.EventHandler(this.Menubtn_Click);
            // 
            // NameSearchBox
            // 
            this.NameSearchBox.ForeColor = System.Drawing.Color.Silver;
            this.NameSearchBox.Location = new System.Drawing.Point(225, 36);
            this.NameSearchBox.Name = "NameSearchBox";
            this.NameSearchBox.Size = new System.Drawing.Size(151, 22);
            this.NameSearchBox.TabIndex = 21;
            this.NameSearchBox.Text = "按Enter查詢品名";
            this.NameSearchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameSearchBox_MouseClick);
            this.NameSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameSearchBox_KeyDown);
            // 
            // TableBox
            // 
            this.TableBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableBox.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TableBox.FormattingEnabled = true;
            this.TableBox.Items.AddRange(new object[] {
            "使用者",
            "菜單",
            "全部訂單",
            "訂單詳細"});
            this.TableBox.Location = new System.Drawing.Point(98, 36);
            this.TableBox.Name = "TableBox";
            this.TableBox.Size = new System.Drawing.Size(121, 21);
            this.TableBox.TabIndex = 22;
            this.TableBox.SelectedIndexChanged += new System.EventHandler(this.TableBox_SelectedIndexChanged);
            // 
            // MealPanel
            // 
            this.MealPanel.BackColor = System.Drawing.Color.CadetBlue;
            this.MealPanel.Controls.Add(this.EnableColorlbl);
            this.MealPanel.Controls.Add(this.MealIDlbl);
            this.MealPanel.Controls.Add(this.MealIDBox);
            this.MealPanel.Controls.Add(this.MealNameBox);
            this.MealPanel.Controls.Add(this.PricePerMealBox);
            this.MealPanel.Controls.Add(this.EnabledBox);
            this.MealPanel.Controls.Add(this.MealNamelbl);
            this.MealPanel.Controls.Add(this.Enabledlbl);
            this.MealPanel.Controls.Add(this.PricePerMeallbl);
            this.MealPanel.Enabled = false;
            this.MealPanel.Location = new System.Drawing.Point(17, 268);
            this.MealPanel.Name = "MealPanel";
            this.MealPanel.Size = new System.Drawing.Size(247, 170);
            this.MealPanel.TabIndex = 23;
            this.MealPanel.Visible = false;
            // 
            // EnableColorlbl
            // 
            this.EnableColorlbl.AutoSize = true;
            this.EnableColorlbl.BackColor = System.Drawing.Color.IndianRed;
            this.EnableColorlbl.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EnableColorlbl.Location = new System.Drawing.Point(89, 129);
            this.EnableColorlbl.Name = "EnableColorlbl";
            this.EnableColorlbl.Size = new System.Drawing.Size(52, 21);
            this.EnableColorlbl.TabIndex = 17;
            this.EnableColorlbl.Text = "　　";
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.BirthBox);
            this.UserPanel.Controls.Add(this.AdminBox);
            this.UserPanel.Controls.Add(this.CarrierBox);
            this.UserPanel.Controls.Add(this.NameBox);
            this.UserPanel.Controls.Add(this.AccountBox);
            this.UserPanel.Controls.Add(this.Adminlbl);
            this.UserPanel.Controls.Add(this.Carrierlbl);
            this.UserPanel.Controls.Add(this.Birthlbl);
            this.UserPanel.Controls.Add(this.Namelbl);
            this.UserPanel.Controls.Add(this.Accountlbl);
            this.UserPanel.Location = new System.Drawing.Point(270, 215);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(236, 223);
            this.UserPanel.TabIndex = 24;
            this.UserPanel.Visible = false;
            // 
            // BirthBox
            // 
            this.BirthBox.BackColor = System.Drawing.Color.LightGray;
            this.BirthBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BirthBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BirthBox.Location = new System.Drawing.Point(65, 100);
            this.BirthBox.Name = "BirthBox";
            this.BirthBox.Size = new System.Drawing.Size(150, 29);
            this.BirthBox.TabIndex = 24;
            this.BirthBox.Text = "Birth";
            // 
            // AdminBox
            // 
            this.AdminBox.BackColor = System.Drawing.Color.LightGray;
            this.AdminBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdminBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AdminBox.Location = new System.Drawing.Point(65, 180);
            this.AdminBox.Name = "AdminBox";
            this.AdminBox.Size = new System.Drawing.Size(150, 29);
            this.AdminBox.TabIndex = 22;
            this.AdminBox.Text = "Admin";
            // 
            // CarrierBox
            // 
            this.CarrierBox.BackColor = System.Drawing.Color.LightGray;
            this.CarrierBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarrierBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CarrierBox.Location = new System.Drawing.Point(65, 140);
            this.CarrierBox.Name = "CarrierBox";
            this.CarrierBox.Size = new System.Drawing.Size(150, 29);
            this.CarrierBox.TabIndex = 21;
            this.CarrierBox.Text = "Carrier";
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.LightGray;
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NameBox.Location = new System.Drawing.Point(65, 60);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(150, 29);
            this.NameBox.TabIndex = 19;
            this.NameBox.Text = "Name";
            // 
            // AccountBox
            // 
            this.AccountBox.BackColor = System.Drawing.Color.LightGray;
            this.AccountBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AccountBox.Location = new System.Drawing.Point(65, 20);
            this.AccountBox.Name = "AccountBox";
            this.AccountBox.Size = new System.Drawing.Size(150, 29);
            this.AccountBox.TabIndex = 18;
            this.AccountBox.Text = "Account";
            // 
            // Adminlbl
            // 
            this.Adminlbl.AutoSize = true;
            this.Adminlbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Adminlbl.Location = new System.Drawing.Point(12, 180);
            this.Adminlbl.Name = "Adminlbl";
            this.Adminlbl.Size = new System.Drawing.Size(47, 19);
            this.Adminlbl.TabIndex = 5;
            this.Adminlbl.Text = "權限";
            // 
            // Carrierlbl
            // 
            this.Carrierlbl.AutoSize = true;
            this.Carrierlbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Carrierlbl.Location = new System.Drawing.Point(12, 140);
            this.Carrierlbl.Name = "Carrierlbl";
            this.Carrierlbl.Size = new System.Drawing.Size(47, 19);
            this.Carrierlbl.TabIndex = 4;
            this.Carrierlbl.Text = "載具";
            // 
            // Birthlbl
            // 
            this.Birthlbl.AutoSize = true;
            this.Birthlbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Birthlbl.Location = new System.Drawing.Point(12, 100);
            this.Birthlbl.Name = "Birthlbl";
            this.Birthlbl.Size = new System.Drawing.Size(47, 19);
            this.Birthlbl.TabIndex = 3;
            this.Birthlbl.Text = "生日";
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Namelbl.Location = new System.Drawing.Point(12, 60);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(47, 19);
            this.Namelbl.TabIndex = 2;
            this.Namelbl.Text = "名字";
            // 
            // Accountlbl
            // 
            this.Accountlbl.AutoSize = true;
            this.Accountlbl.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Accountlbl.Location = new System.Drawing.Point(12, 20);
            this.Accountlbl.Name = "Accountlbl";
            this.Accountlbl.Size = new System.Drawing.Size(47, 19);
            this.Accountlbl.TabIndex = 1;
            this.Accountlbl.Text = "帳號";
            // 
            // OrdersPanel
            // 
            this.OrdersPanel.Location = new System.Drawing.Point(270, 109);
            this.OrdersPanel.Name = "OrdersPanel";
            this.OrdersPanel.Size = new System.Drawing.Size(200, 100);
            this.OrdersPanel.TabIndex = 25;
            this.OrdersPanel.Visible = false;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrdersPanel);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.TableBox);
            this.Controls.Add(this.NameSearchBox);
            this.Controls.Add(this.Menubtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.Logout1);
            this.Controls.Add(this.DeleteRowBtn);
            this.Controls.Add(this.ChangeUpload);
            this.Controls.Add(this.MealPanel);
            this.Controls.Add(this.MenuDataGridView);
            this.Name = "MainControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主控台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuEdit_FormClosing);
            this.Load += new System.EventHandler(this.MainControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MenuDataGridView)).EndInit();
            this.MealPanel.ResumeLayout(false);
            this.MealPanel.PerformLayout();
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MenuDataGridView;
        private System.Windows.Forms.Button ChangeUpload;
        private System.Windows.Forms.Button DeleteRowBtn;
        private System.Windows.Forms.Label Logout1;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox MealIDBox;
        private System.Windows.Forms.TextBox MealNameBox;
        private System.Windows.Forms.TextBox PricePerMealBox;
        private System.Windows.Forms.ComboBox EnabledBox;
        private System.Windows.Forms.Label MealIDlbl;
        private System.Windows.Forms.Label MealNamelbl;
        private System.Windows.Forms.Label PricePerMeallbl;
        private System.Windows.Forms.Label Enabledlbl;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button Menubtn;
        private System.Windows.Forms.TextBox NameSearchBox;
        private System.Windows.Forms.ComboBox TableBox;
        private System.Windows.Forms.Panel MealPanel;
        private System.Windows.Forms.Label EnableColorlbl;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label Adminlbl;
        private System.Windows.Forms.Label Carrierlbl;
        private System.Windows.Forms.Label Birthlbl;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Label Accountlbl;
        private System.Windows.Forms.TextBox BirthBox;
        private System.Windows.Forms.TextBox AdminBox;
        private System.Windows.Forms.TextBox CarrierBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox AccountBox;
        private System.Windows.Forms.Panel OrdersPanel;
    }
}