namespace 便當
{
    partial class MenuEdit
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
            this.NewRow = new System.Windows.Forms.Button();
            this.DeleteRowBtn = new System.Windows.Forms.Button();
            this.Logout1 = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.MealIDBox = new System.Windows.Forms.TextBox();
            this.MealNameBox = new System.Windows.Forms.TextBox();
            this.PricePerMealBox = new System.Windows.Forms.TextBox();
            this.EnabledBox = new System.Windows.Forms.ComboBox();
            this.MealIDlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.DisableBtn = new System.Windows.Forms.Button();
            this.Menubtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MenuDataGridView)).BeginInit();
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
            this.MenuDataGridView.RowTemplate.Height = 24;
            this.MenuDataGridView.Size = new System.Drawing.Size(533, 373);
            this.MenuDataGridView.TabIndex = 0;
            this.MenuDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MenuDataGridView_DataError);
            // 
            // ChangeUpload
            // 
            this.ChangeUpload.Location = new System.Drawing.Point(694, 398);
            this.ChangeUpload.Name = "ChangeUpload";
            this.ChangeUpload.Size = new System.Drawing.Size(94, 40);
            this.ChangeUpload.TabIndex = 2;
            this.ChangeUpload.Text = "確認修改";
            this.ChangeUpload.UseVisualStyleBackColor = true;
            this.ChangeUpload.Click += new System.EventHandler(this.ChangeUpload_Click);
            // 
            // NewRow
            // 
            this.NewRow.Location = new System.Drawing.Point(17, 36);
            this.NewRow.Name = "NewRow";
            this.NewRow.Size = new System.Drawing.Size(75, 23);
            this.NewRow.TabIndex = 3;
            this.NewRow.Text = "加入新資料";
            this.NewRow.UseVisualStyleBackColor = true;
            this.NewRow.Click += new System.EventHandler(this.NewRowBtn_Click);
            // 
            // DeleteRowBtn
            // 
            this.DeleteRowBtn.Location = new System.Drawing.Point(93, 36);
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
            this.MealIDBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MealIDBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MealIDBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealIDBox.Location = new System.Drawing.Point(638, 75);
            this.MealIDBox.Name = "MealIDBox";
            this.MealIDBox.Size = new System.Drawing.Size(150, 29);
            this.MealIDBox.TabIndex = 8;
            this.MealIDBox.Text = "MealID";
            this.MealIDBox.Visible = false;
            // 
            // MealNameBox
            // 
            this.MealNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MealNameBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealNameBox.Location = new System.Drawing.Point(638, 110);
            this.MealNameBox.Name = "MealNameBox";
            this.MealNameBox.Size = new System.Drawing.Size(150, 29);
            this.MealNameBox.TabIndex = 9;
            this.MealNameBox.Text = "MealName";
            this.MealNameBox.Visible = false;
            // 
            // PricePerMealBox
            // 
            this.PricePerMealBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PricePerMealBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PricePerMealBox.Location = new System.Drawing.Point(638, 145);
            this.PricePerMealBox.Name = "PricePerMealBox";
            this.PricePerMealBox.Size = new System.Drawing.Size(150, 29);
            this.PricePerMealBox.TabIndex = 11;
            this.PricePerMealBox.Text = "PricePerMeal";
            this.PricePerMealBox.Visible = false;
            // 
            // EnabledBox
            // 
            this.EnabledBox.BackColor = System.Drawing.Color.PaleGreen;
            this.EnabledBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EnabledBox.FormattingEnabled = true;
            this.EnabledBox.Location = new System.Drawing.Point(638, 180);
            this.EnabledBox.Name = "EnabledBox";
            this.EnabledBox.Size = new System.Drawing.Size(120, 32);
            this.EnabledBox.TabIndex = 12;
            this.EnabledBox.Text = "Enabled";
            this.EnabledBox.Visible = false;
            // 
            // MealIDlbl
            // 
            this.MealIDlbl.AutoSize = true;
            this.MealIDlbl.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MealIDlbl.Location = new System.Drawing.Point(551, 75);
            this.MealIDlbl.Name = "MealIDlbl";
            this.MealIDlbl.Size = new System.Drawing.Size(82, 24);
            this.MealIDlbl.TabIndex = 13;
            this.MealIDlbl.Text = "品項ID";
            this.MealIDlbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(574, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "品名";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(575, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "價格";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(575, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "狀態";
            this.label3.Visible = false;
            // 
            // Addbtn
            // 
            this.Addbtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Addbtn.Location = new System.Drawing.Point(551, 331);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(77, 59);
            this.Addbtn.TabIndex = 17;
            this.Addbtn.Text = "新增";
            this.Addbtn.UseVisualStyleBackColor = true;
            // 
            // EditBtn
            // 
            this.EditBtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EditBtn.Location = new System.Drawing.Point(634, 331);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(77, 59);
            this.EditBtn.TabIndex = 18;
            this.EditBtn.Text = "修改";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // DisableBtn
            // 
            this.DisableBtn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DisableBtn.Location = new System.Drawing.Point(717, 331);
            this.DisableBtn.Name = "DisableBtn";
            this.DisableBtn.Size = new System.Drawing.Size(77, 59);
            this.DisableBtn.TabIndex = 19;
            this.DisableBtn.Text = "封存";
            this.DisableBtn.UseVisualStyleBackColor = true;
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
            // MenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Menubtn);
            this.Controls.Add(this.DisableBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MealIDlbl);
            this.Controls.Add(this.EnabledBox);
            this.Controls.Add(this.PricePerMealBox);
            this.Controls.Add(this.MealNameBox);
            this.Controls.Add(this.MealIDBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.Logout1);
            this.Controls.Add(this.DeleteRowBtn);
            this.Controls.Add(this.NewRow);
            this.Controls.Add(this.ChangeUpload);
            this.Controls.Add(this.MenuDataGridView);
            this.Name = "MenuEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuEdit_FormClosing);
            this.Load += new System.EventHandler(this.MenuEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MenuDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MenuDataGridView;
        private System.Windows.Forms.Button ChangeUpload;
        private System.Windows.Forms.Button NewRow;
        private System.Windows.Forms.Button DeleteRowBtn;
        private System.Windows.Forms.Label Logout1;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox MealIDBox;
        private System.Windows.Forms.TextBox MealNameBox;
        private System.Windows.Forms.TextBox PricePerMealBox;
        private System.Windows.Forms.ComboBox EnabledBox;
        private System.Windows.Forms.Label MealIDlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button DisableBtn;
        private System.Windows.Forms.Button Menubtn;
    }
}