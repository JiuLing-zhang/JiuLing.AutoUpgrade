namespace JiuLing.AutoUpgrade.Test
{
    partial class FmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnCheckUpgrade = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前版本";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(292, 117);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(13, 17);
            this.LblVersion.TabIndex = 1;
            this.LblVersion.Text = "-";
            // 
            // BtnCheckUpgrade
            // 
            this.BtnCheckUpgrade.Location = new System.Drawing.Point(230, 172);
            this.BtnCheckUpgrade.Name = "BtnCheckUpgrade";
            this.BtnCheckUpgrade.Size = new System.Drawing.Size(149, 48);
            this.BtnCheckUpgrade.TabIndex = 2;
            this.BtnCheckUpgrade.Text = "检查更新";
            this.BtnCheckUpgrade.UseVisualStyleBackColor = true;
            this.BtnCheckUpgrade.Click += new System.EventHandler(this.BtnCheckUpgrade_Click);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 391);
            this.Controls.Add(this.BtnCheckUpgrade);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新测试程序";
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label LblVersion;
        private Button BtnCheckUpgrade;
    }
}