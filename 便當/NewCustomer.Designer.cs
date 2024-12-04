namespace 便當
{
    partial class NewCustomer
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
            this.NewIDlbl = new System.Windows.Forms.Label();
            this.NewCustomerIDInput = new System.Windows.Forms.TextBox();
            this.NewNamelbl = new System.Windows.Forms.Label();
            this.NewCustomerNameInput = new System.Windows.Forms.TextBox();
            this.CustomerIDConfirm = new System.Windows.Forms.Button();
            this.CustomerIDCancel = new System.Windows.Forms.Button();
            this.IDWarning = new System.Windows.Forms.Label();
            this.NameWarning = new System.Windows.Forms.Label();
            this.BirthPicker = new System.Windows.Forms.DateTimePicker();
            this.Birthdaylbl = new System.Windows.Forms.Label();
            this.DateWarning = new System.Windows.Forms.Label();
            this.IDCheck = new System.Windows.Forms.Label();
            this.NameCheck = new System.Windows.Forms.Label();
            this.DateCheck = new System.Windows.Forms.Label();
            this.ROCYearbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NewIDlbl
            // 
            this.NewIDlbl.AutoSize = true;
            this.NewIDlbl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NewIDlbl.Location = new System.Drawing.Point(46, 25);
            this.NewIDlbl.Name = "NewIDlbl";
            this.NewIDlbl.Size = new System.Drawing.Size(225, 16);
            this.NewIDlbl.TabIndex = 0;
            this.NewIDlbl.Text = "輸入新ID ( 6到8碼內英文+數字)";
            // 
            // NewCustomerIDInput
            // 
            this.NewCustomerIDInput.Location = new System.Drawing.Point(49, 44);
            this.NewCustomerIDInput.Name = "NewCustomerIDInput";
            this.NewCustomerIDInput.Size = new System.Drawing.Size(241, 22);
            this.NewCustomerIDInput.TabIndex = 1;
            this.NewCustomerIDInput.TextChanged += new System.EventHandler(this.NewCustomerIDInput_TextChanged);
            // 
            // NewNamelbl
            // 
            this.NewNamelbl.AutoSize = true;
            this.NewNamelbl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NewNamelbl.Location = new System.Drawing.Point(46, 86);
            this.NewNamelbl.Name = "NewNamelbl";
            this.NewNamelbl.Size = new System.Drawing.Size(165, 16);
            this.NewNamelbl.TabIndex = 2;
            this.NewNamelbl.Text = "輸入稱呼 (可使用中文)";
            // 
            // NewCustomerNameInput
            // 
            this.NewCustomerNameInput.Location = new System.Drawing.Point(49, 105);
            this.NewCustomerNameInput.Name = "NewCustomerNameInput";
            this.NewCustomerNameInput.Size = new System.Drawing.Size(241, 22);
            this.NewCustomerNameInput.TabIndex = 3;
            this.NewCustomerNameInput.TextChanged += new System.EventHandler(this.NewCustomerNameInput_TextChanged);
            // 
            // CustomerIDConfirm
            // 
            this.CustomerIDConfirm.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CustomerIDConfirm.Location = new System.Drawing.Point(49, 211);
            this.CustomerIDConfirm.Name = "CustomerIDConfirm";
            this.CustomerIDConfirm.Size = new System.Drawing.Size(95, 35);
            this.CustomerIDConfirm.TabIndex = 4;
            this.CustomerIDConfirm.Text = "確認";
            this.CustomerIDConfirm.UseVisualStyleBackColor = true;
            this.CustomerIDConfirm.Click += new System.EventHandler(this.CustomerInfoConfirm_Click);
            // 
            // CustomerIDCancel
            // 
            this.CustomerIDCancel.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CustomerIDCancel.Location = new System.Drawing.Point(195, 211);
            this.CustomerIDCancel.Name = "CustomerIDCancel";
            this.CustomerIDCancel.Size = new System.Drawing.Size(95, 35);
            this.CustomerIDCancel.TabIndex = 5;
            this.CustomerIDCancel.Text = "取消";
            this.CustomerIDCancel.UseVisualStyleBackColor = true;
            this.CustomerIDCancel.Click += new System.EventHandler(this.IDCancel_Click);
            // 
            // IDWarning
            // 
            this.IDWarning.AutoSize = true;
            this.IDWarning.ForeColor = System.Drawing.Color.Red;
            this.IDWarning.Location = new System.Drawing.Point(47, 69);
            this.IDWarning.Name = "IDWarning";
            this.IDWarning.Size = new System.Drawing.Size(33, 12);
            this.IDWarning.TabIndex = 6;
            this.IDWarning.Text = "label1";
            this.IDWarning.Visible = false;
            // 
            // NameWarning
            // 
            this.NameWarning.AutoSize = true;
            this.NameWarning.ForeColor = System.Drawing.Color.Red;
            this.NameWarning.Location = new System.Drawing.Point(47, 130);
            this.NameWarning.Name = "NameWarning";
            this.NameWarning.Size = new System.Drawing.Size(33, 12);
            this.NameWarning.TabIndex = 7;
            this.NameWarning.Text = "label2";
            this.NameWarning.Visible = false;
            // 
            // BirthPicker
            // 
            this.BirthPicker.Location = new System.Drawing.Point(49, 168);
            this.BirthPicker.Name = "BirthPicker";
            this.BirthPicker.Size = new System.Drawing.Size(241, 22);
            this.BirthPicker.TabIndex = 8;
            this.BirthPicker.ValueChanged += new System.EventHandler(this.BirthPicker_ValueChanged);
            // 
            // Birthdaylbl
            // 
            this.Birthdaylbl.AutoSize = true;
            this.Birthdaylbl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Birthdaylbl.Location = new System.Drawing.Point(46, 149);
            this.Birthdaylbl.Name = "Birthdaylbl";
            this.Birthdaylbl.Size = new System.Drawing.Size(71, 16);
            this.Birthdaylbl.TabIndex = 9;
            this.Birthdaylbl.Text = "選擇生日";
            // 
            // DateWarning
            // 
            this.DateWarning.AutoSize = true;
            this.DateWarning.ForeColor = System.Drawing.Color.Red;
            this.DateWarning.Location = new System.Drawing.Point(47, 193);
            this.DateWarning.Name = "DateWarning";
            this.DateWarning.Size = new System.Drawing.Size(33, 12);
            this.DateWarning.TabIndex = 10;
            this.DateWarning.Text = "label2";
            this.DateWarning.Visible = false;
            // 
            // IDCheck
            // 
            this.IDCheck.AutoSize = true;
            this.IDCheck.BackColor = System.Drawing.Color.CadetBlue;
            this.IDCheck.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IDCheck.ForeColor = System.Drawing.Color.Chartreuse;
            this.IDCheck.Location = new System.Drawing.Point(26, 50);
            this.IDCheck.Name = "IDCheck";
            this.IDCheck.Size = new System.Drawing.Size(17, 16);
            this.IDCheck.TabIndex = 11;
            this.IDCheck.Text = "✓";
            this.IDCheck.Visible = false;
            // 
            // NameCheck
            // 
            this.NameCheck.AutoSize = true;
            this.NameCheck.BackColor = System.Drawing.Color.CadetBlue;
            this.NameCheck.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NameCheck.ForeColor = System.Drawing.Color.Chartreuse;
            this.NameCheck.Location = new System.Drawing.Point(26, 111);
            this.NameCheck.Name = "NameCheck";
            this.NameCheck.Size = new System.Drawing.Size(17, 16);
            this.NameCheck.TabIndex = 12;
            this.NameCheck.Text = "✓";
            this.NameCheck.Visible = false;
            // 
            // DateCheck
            // 
            this.DateCheck.AutoSize = true;
            this.DateCheck.BackColor = System.Drawing.Color.CadetBlue;
            this.DateCheck.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DateCheck.ForeColor = System.Drawing.Color.Chartreuse;
            this.DateCheck.Location = new System.Drawing.Point(26, 172);
            this.DateCheck.Name = "DateCheck";
            this.DateCheck.Size = new System.Drawing.Size(17, 16);
            this.DateCheck.TabIndex = 13;
            this.DateCheck.Text = "✓";
            this.DateCheck.Visible = false;
            // 
            // ROCYearbox
            // 
            this.ROCYearbox.Location = new System.Drawing.Point(297, 168);
            this.ROCYearbox.Name = "ROCYearbox";
            this.ROCYearbox.Size = new System.Drawing.Size(100, 22);
            this.ROCYearbox.TabIndex = 14;
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(417, 267);
            this.Controls.Add(this.ROCYearbox);
            this.Controls.Add(this.DateCheck);
            this.Controls.Add(this.NameCheck);
            this.Controls.Add(this.IDCheck);
            this.Controls.Add(this.DateWarning);
            this.Controls.Add(this.Birthdaylbl);
            this.Controls.Add(this.BirthPicker);
            this.Controls.Add(this.NameWarning);
            this.Controls.Add(this.IDWarning);
            this.Controls.Add(this.CustomerIDCancel);
            this.Controls.Add(this.CustomerIDConfirm);
            this.Controls.Add(this.NewCustomerNameInput);
            this.Controls.Add(this.NewNamelbl);
            this.Controls.Add(this.NewCustomerIDInput);
            this.Controls.Add(this.NewIDlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "NewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "創建新使用者";
            this.Load += new System.EventHandler(this.NewCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewIDlbl;
        private System.Windows.Forms.TextBox NewCustomerIDInput;
        private System.Windows.Forms.Label NewNamelbl;
        private System.Windows.Forms.TextBox NewCustomerNameInput;
        private System.Windows.Forms.Button CustomerIDConfirm;
        private System.Windows.Forms.Button CustomerIDCancel;
        private System.Windows.Forms.Label IDWarning;
        private System.Windows.Forms.Label NameWarning;
        private System.Windows.Forms.DateTimePicker BirthPicker;
        private System.Windows.Forms.Label Birthdaylbl;
        private System.Windows.Forms.Label DateWarning;
        private System.Windows.Forms.Label IDCheck;
        private System.Windows.Forms.Label NameCheck;
        private System.Windows.Forms.Label DateCheck;
        private System.Windows.Forms.TextBox ROCYearbox;
    }
}