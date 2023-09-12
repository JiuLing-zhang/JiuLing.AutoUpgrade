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
            label1 = new Label();
            LblVersion = new Label();
            BtnCheckUpgrade = new Button();
            BtnCheckUpgradeUsingFtp = new Button();
            label2 = new Label();
            txtUpgradeUrl = new TextBox();
            label3 = new Label();
            TxtFtpUpgradePath = new TextBox();
            label4 = new Label();
            TxtUserName = new TextBox();
            TxtPassword = new TextBox();
            label5 = new Label();
            BtnCheckUpgradeAsync = new Button();
            BtnCheckUpgradeUsingFtpAsync = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "当前版本";
            // 
            // LblVersion
            // 
            LblVersion.AutoSize = true;
            LblVersion.Location = new Point(74, 9);
            LblVersion.Name = "LblVersion";
            LblVersion.Size = new Size(13, 17);
            LblVersion.TabIndex = 1;
            LblVersion.Text = "-";
            // 
            // BtnCheckUpgrade
            // 
            BtnCheckUpgrade.Location = new Point(12, 81);
            BtnCheckUpgrade.Name = "BtnCheckUpgrade";
            BtnCheckUpgrade.Size = new Size(149, 48);
            BtnCheckUpgrade.TabIndex = 2;
            BtnCheckUpgrade.Text = "检查更新-HTTP";
            BtnCheckUpgrade.UseVisualStyleBackColor = true;
            BtnCheckUpgrade.Click += BtnCheckUpgrade_Click;
            // 
            // BtnCheckUpgradeUsingFtp
            // 
            BtnCheckUpgradeUsingFtp.Location = new Point(12, 236);
            BtnCheckUpgradeUsingFtp.Name = "BtnCheckUpgradeUsingFtp";
            BtnCheckUpgradeUsingFtp.Size = new Size(149, 48);
            BtnCheckUpgradeUsingFtp.TabIndex = 3;
            BtnCheckUpgradeUsingFtp.Text = "检查更新-FTP";
            BtnCheckUpgradeUsingFtp.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingFtp.Click += BtnCheckUpgradeUsingFtp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 4;
            label2.Text = "更新地址";
            // 
            // txtUpgradeUrl
            // 
            txtUpgradeUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUpgradeUrl.Location = new Point(74, 45);
            txtUpgradeUrl.Name = "txtUpgradeUrl";
            txtUpgradeUrl.Size = new Size(613, 23);
            txtUpgradeUrl.TabIndex = 5;
            txtUpgradeUrl.Text = "https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 146);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 6;
            label3.Text = "更新地址";
            // 
            // TxtFtpUpgradePath
            // 
            TxtFtpUpgradePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtFtpUpgradePath.Location = new Point(74, 143);
            TxtFtpUpgradePath.Name = "TxtFtpUpgradePath";
            TxtFtpUpgradePath.Size = new Size(613, 23);
            TxtFtpUpgradePath.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 176);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 8;
            label4.Text = "用户名";
            // 
            // TxtUserName
            // 
            TxtUserName.Location = new Point(74, 173);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(185, 23);
            TxtUserName.TabIndex = 9;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(74, 207);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '♥';
            TxtPassword.Size = new Size(185, 23);
            TxtPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 210);
            label5.Name = "label5";
            label5.Size = new Size(32, 17);
            label5.TabIndex = 10;
            label5.Text = "密码";
            // 
            // BtnCheckUpgradeAsync
            // 
            BtnCheckUpgradeAsync.Location = new Point(167, 81);
            BtnCheckUpgradeAsync.Name = "BtnCheckUpgradeAsync";
            BtnCheckUpgradeAsync.Size = new Size(149, 48);
            BtnCheckUpgradeAsync.TabIndex = 12;
            BtnCheckUpgradeAsync.Text = "检查更新-异步-HTTP";
            BtnCheckUpgradeAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeAsync.Click += BtnCheckUpgradeAsync_Click;
            // 
            // BtnCheckUpgradeUsingFtpAsync
            // 
            BtnCheckUpgradeUsingFtpAsync.Location = new Point(167, 236);
            BtnCheckUpgradeUsingFtpAsync.Name = "BtnCheckUpgradeUsingFtpAsync";
            BtnCheckUpgradeUsingFtpAsync.Size = new Size(149, 48);
            BtnCheckUpgradeUsingFtpAsync.TabIndex = 13;
            BtnCheckUpgradeUsingFtpAsync.Text = "检查更新-异步-FTP";
            BtnCheckUpgradeUsingFtpAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingFtpAsync.Click += BtnCheckUpgradeUsingFtpAsync_Click;
            // 
            // FmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 296);
            Controls.Add(BtnCheckUpgradeUsingFtpAsync);
            Controls.Add(BtnCheckUpgradeAsync);
            Controls.Add(TxtPassword);
            Controls.Add(label5);
            Controls.Add(TxtUserName);
            Controls.Add(label4);
            Controls.Add(TxtFtpUpgradePath);
            Controls.Add(label3);
            Controls.Add(txtUpgradeUrl);
            Controls.Add(label2);
            Controls.Add(BtnCheckUpgradeUsingFtp);
            Controls.Add(BtnCheckUpgrade);
            Controls.Add(LblVersion);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "自动更新测试程序";
            Load += FmMain_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private Button BtnCheckUpgradeAsync;
        private Button BtnCheckUpgradeUsingFtpAsync;
    }
}