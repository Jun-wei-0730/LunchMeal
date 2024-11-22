namespace 便當
{
    partial class NewID
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
            this.NewIDInput = new System.Windows.Forms.TextBox();
            this.NewNamelbl = new System.Windows.Forms.Label();
            this.NewNameInput = new System.Windows.Forms.TextBox();
            this.IDConfirm = new System.Windows.Forms.Button();
            this.IDCancel = new System.Windows.Forms.Button();
            this.IDWarning = new System.Windows.Forms.Label();
            this.NameWarning = new System.Windows.Forms.Label();
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
            // NewIDInput
            // 
            this.NewIDInput.Location = new System.Drawing.Point(49, 44);
            this.NewIDInput.Name = "NewIDInput";
            this.NewIDInput.Size = new System.Drawing.Size(241, 22);
            this.NewIDInput.TabIndex = 1;
            this.NewIDInput.TextChanged += new System.EventHandler(this.NewIDInput_TextChanged);
            // 
            // NewNamelbl
            // 
            this.NewNamelbl.AutoSize = true;
            this.NewNamelbl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NewNamelbl.Location = new System.Drawing.Point(46, 104);
            this.NewNamelbl.Name = "NewNamelbl";
            this.NewNamelbl.Size = new System.Drawing.Size(165, 16);
            this.NewNamelbl.TabIndex = 2;
            this.NewNamelbl.Text = "輸入稱呼 (可使用中文)";
            // 
            // NewNameInput
            // 
            this.NewNameInput.Location = new System.Drawing.Point(49, 123);
            this.NewNameInput.Name = "NewNameInput";
            this.NewNameInput.Size = new System.Drawing.Size(241, 22);
            this.NewNameInput.TabIndex = 3;
            // 
            // IDConfirm
            // 
            this.IDConfirm.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IDConfirm.Location = new System.Drawing.Point(49, 169);
            this.IDConfirm.Name = "IDConfirm";
            this.IDConfirm.Size = new System.Drawing.Size(95, 35);
            this.IDConfirm.TabIndex = 4;
            this.IDConfirm.Text = "確認";
            this.IDConfirm.UseVisualStyleBackColor = true;
            this.IDConfirm.Click += new System.EventHandler(this.IDConfirm_Click);
            // 
            // IDCancel
            // 
            this.IDCancel.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IDCancel.Location = new System.Drawing.Point(195, 169);
            this.IDCancel.Name = "IDCancel";
            this.IDCancel.Size = new System.Drawing.Size(95, 35);
            this.IDCancel.TabIndex = 5;
            this.IDCancel.Text = "取消";
            this.IDCancel.UseVisualStyleBackColor = true;
            this.IDCancel.Click += new System.EventHandler(this.IDCancel_Click);
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
            this.NameWarning.Location = new System.Drawing.Point(47, 148);
            this.NameWarning.Name = "NameWarning";
            this.NameWarning.Size = new System.Drawing.Size(33, 12);
            this.NameWarning.TabIndex = 7;
            this.NameWarning.Text = "label2";
            this.NameWarning.Visible = false;
            // 
            // NewID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(335, 228);
            this.Controls.Add(this.NameWarning);
            this.Controls.Add(this.IDWarning);
            this.Controls.Add(this.IDCancel);
            this.Controls.Add(this.IDConfirm);
            this.Controls.Add(this.NewNameInput);
            this.Controls.Add(this.NewNamelbl);
            this.Controls.Add(this.NewIDInput);
            this.Controls.Add(this.NewIDlbl);
            this.MaximizeBox = false;
            this.Name = "NewID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "創建新使用者";
            this.Load += new System.EventHandler(this.NewID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewIDlbl;
        private System.Windows.Forms.TextBox NewIDInput;
        private System.Windows.Forms.Label NewNamelbl;
        private System.Windows.Forms.TextBox NewNameInput;
        private System.Windows.Forms.Button IDConfirm;
        private System.Windows.Forms.Button IDCancel;
        private System.Windows.Forms.Label IDWarning;
        private System.Windows.Forms.Label NameWarning;
    }
}