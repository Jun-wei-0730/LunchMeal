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
            this.MenuDataGridView.Size = new System.Drawing.Size(676, 373);
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
            this.NewRow.Location = new System.Drawing.Point(12, 36);
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
            // MenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}