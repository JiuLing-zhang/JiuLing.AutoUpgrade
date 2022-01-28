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
            this.BtnCheckUpgradeUsingFtp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUpgradeUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFtpUpgradePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前版本";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(74, 9);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(13, 17);
            this.LblVersion.TabIndex = 1;
            this.LblVersion.Text = "-";
            // 
            // BtnCheckUpgrade
            // 
            this.BtnCheckUpgrade.Location = new System.Drawing.Point(12, 81);
            this.BtnCheckUpgrade.Name = "BtnCheckUpgrade";
            this.BtnCheckUpgrade.Size = new System.Drawing.Size(149, 48);
            this.BtnCheckUpgrade.TabIndex = 2;
            this.BtnCheckUpgrade.Text = "检查更新-HTTP";
            this.BtnCheckUpgrade.UseVisualStyleBackColor = true;
            this.BtnCheckUpgrade.Click += new System.EventHandler(this.BtnCheckUpgrade_Click);
            // 
            // BtnCheckUpgradeUsingFtp
            // 
            this.BtnCheckUpgradeUsingFtp.Location = new System.Drawing.Point(12, 236);
            this.BtnCheckUpgradeUsingFtp.Name = "BtnCheckUpgradeUsingFtp";
            this.BtnCheckUpgradeUsingFtp.Size = new System.Drawing.Size(149, 48);
            this.BtnCheckUpgradeUsingFtp.TabIndex = 3;
            this.BtnCheckUpgradeUsingFtp.Text = "检查更新-FTP";
            this.BtnCheckUpgradeUsingFtp.UseVisualStyleBackColor = true;
            this.BtnCheckUpgradeUsingFtp.Click += new System.EventHandler(this.BtnCheckUpgradeUsingFtp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "更新地址";
            // 
            // txtUpgradeUrl
            // 
            this.txtUpgradeUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpgradeUrl.Location = new System.Drawing.Point(74, 45);
            this.txtUpgradeUrl.Name = "txtUpgradeUrl";
            this.txtUpgradeUrl.Size = new System.Drawing.Size(613, 23);
            this.txtUpgradeUrl.TabIndex = 5;
            this.txtUpgradeUrl.Text = "https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.jso" +
    "n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "更新地址";
            // 
            // TxtFtpUpgradePath
            // 
            this.TxtFtpUpgradePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFtpUpgradePath.Location = new System.Drawing.Point(74, 143);
            this.TxtFtpUpgradePath.Name = "TxtFtpUpgradePath";
            this.TxtFtpUpgradePath.Size = new System.Drawing.Size(613, 23);
            this.TxtFtpUpgradePath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "用户名";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(74, 173);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(185, 23);
            this.TxtUserName.TabIndex = 9;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(74, 207);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '♥';
            this.TxtPassword.Size = new System.Drawing.Size(185, 23);
            this.TxtPassword.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "密码";
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 296);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtFtpUpgradePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUpgradeUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCheckUpgradeUsingFtp);
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
        private Button BtnCheckUpgradeUsingFtp;
        private Label label2;
        private TextBox txtUpgradeUrl;
        private Label label3;
        private TextBox TxtFtpUpgradePath;
        private Label label4;
        private TextBox TxtUserName;
        private TextBox TxtPassword;
        private Label label5;
    }
}