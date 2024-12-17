namespace 便當
{
    partial class MenuController
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MealPic = new System.Windows.Forms.PictureBox();
            this.Meallbl = new System.Windows.Forms.Label();
            this.Pricelbl = new System.Windows.Forms.Label();
            this.QtyNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MealPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // MealPic
            // 
            this.MealPic.Location = new System.Drawing.Point(15, 26);
            this.MealPic.Name = "MealPic";
            this.MealPic.Size = new System.Drawing.Size(150, 85);
            this.MealPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MealPic.TabIndex = 0;
            this.MealPic.TabStop = false;
            // 
            // Meallbl
            // 
            this.Meallbl.AutoSize = true;
            this.Meallbl.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Meallbl.Location = new System.Drawing.Point(12, 6);
            this.Meallbl.Name = "Meallbl";
            this.Meallbl.Size = new System.Drawing.Size(45, 16);
            this.Meallbl.TabIndex = 1;
            this.Meallbl.Text = "label1";
            // 
            // Pricelbl
            // 
            this.Pricelbl.AutoSize = true;
            this.Pricelbl.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Pricelbl.Location = new System.Drawing.Point(138, 3);
            this.Pricelbl.Name = "Pricelbl";
            this.Pricelbl.Size = new System.Drawing.Size(53, 20);
            this.Pricelbl.TabIndex = 2;
            this.Pricelbl.Text = "label2";
            // 
            // QtyNUD
            // 
            this.QtyNUD.Location = new System.Drawing.Point(15, 117);
            this.QtyNUD.Name = "QtyNUD";
            this.QtyNUD.Size = new System.Drawing.Size(149, 22);
            this.QtyNUD.TabIndex = 3;
            // 
            // MenuController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QtyNUD);
            this.Controls.Add(this.Pricelbl);
            this.Controls.Add(this.Meallbl);
            this.Controls.Add(this.MealPic);
            this.Name = "MenuController";
            this.Size = new System.Drawing.Size(180, 150);
            ((System.ComponentModel.ISupportInitialize)(this.MealPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MealPic;
        private System.Windows.Forms.Label Meallbl;
        private System.Windows.Forms.Label Pricelbl;
        private System.Windows.Forms.NumericUpDown QtyNUD;
    }
}
