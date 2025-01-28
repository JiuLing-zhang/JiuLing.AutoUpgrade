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
            groupBoxSetting = new GroupBox();
            comboBoxVersionFormat = new ComboBox();
            label10 = new Label();
            comboBoxIcon = new ComboBox();
            label9 = new Label();
            comboBoxLang = new ComboBox();
            label8 = new Label();
            numericUpDownTimeoutSecond = new NumericUpDown();
            comboBoxTheme = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            checkBoxSignCheck = new CheckBox();
            checkBoxDefaultConfig = new CheckBox();
            groupBox1 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            label11 = new Label();
            BtnCheckUpgradeUsingGitHub = new Button();
            BtnCheckUpgradeUsingGitHubAsync = new Button();
            TxtUser = new TextBox();
            label12 = new Label();
            TxtAssetName = new TextBox();
            TxtRepo = new TextBox();
            label13 = new Label();
            groupBoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeoutSecond).BeginInit();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
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
            BtnCheckUpgrade.Location = new Point(63, 72);
            BtnCheckUpgrade.Name = "BtnCheckUpgrade";
            BtnCheckUpgrade.Size = new Size(101, 26);
            BtnCheckUpgrade.TabIndex = 2;
            BtnCheckUpgrade.Text = "同步检查更新";
            BtnCheckUpgrade.UseVisualStyleBackColor = true;
            BtnCheckUpgrade.Click += BtnCheckUpgrade_Click;
            // 
            // BtnCheckUpgradeUsingFtp
            // 
            BtnCheckUpgradeUsingFtp.Location = new Point(65, 94);
            BtnCheckUpgradeUsingFtp.Name = "BtnCheckUpgradeUsingFtp";
            BtnCheckUpgradeUsingFtp.Size = new Size(101, 26);
            BtnCheckUpgradeUsingFtp.TabIndex = 3;
            BtnCheckUpgradeUsingFtp.Text = "同步检查更新";
            BtnCheckUpgradeUsingFtp.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingFtp.Click += BtnCheckUpgradeUsingFtp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 4;
            label2.Text = "更新地址";
            // 
            // txtUpgradeUrl
            // 
            txtUpgradeUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUpgradeUrl.Location = new Point(63, 6);
            txtUpgradeUrl.Multiline = true;
            txtUpgradeUrl.Name = "txtUpgradeUrl";
            txtUpgradeUrl.Size = new Size(634, 60);
            txtUpgradeUrl.TabIndex = 5;
            txtUpgradeUrl.Text = "https://raw.githubusercontent.com/JiuLing-zhang/JiuLing.AutoUpgrade/refs/heads/main/src/JiuLing.AutoUpgrade.Test/AppInfo.json";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 6;
            label3.Text = "更新地址";
            // 
            // TxtFtpUpgradePath
            // 
            TxtFtpUpgradePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtFtpUpgradePath.Location = new Point(65, 6);
            TxtFtpUpgradePath.Name = "TxtFtpUpgradePath";
            TxtFtpUpgradePath.Size = new Size(629, 23);
            TxtFtpUpgradePath.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 39);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 8;
            label4.Text = "用户名";
            // 
            // TxtUserName
            // 
            TxtUserName.Location = new Point(65, 36);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(185, 23);
            TxtUserName.TabIndex = 9;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(65, 65);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '♥';
            TxtPassword.Size = new Size(185, 23);
            TxtPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 68);
            label5.Name = "label5";
            label5.Size = new Size(32, 17);
            label5.TabIndex = 10;
            label5.Text = "密码";
            // 
            // BtnCheckUpgradeAsync
            // 
            BtnCheckUpgradeAsync.Location = new Point(170, 72);
            BtnCheckUpgradeAsync.Name = "BtnCheckUpgradeAsync";
            BtnCheckUpgradeAsync.Size = new Size(101, 26);
            BtnCheckUpgradeAsync.TabIndex = 12;
            BtnCheckUpgradeAsync.Text = "异步检查更新";
            BtnCheckUpgradeAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeAsync.Click += BtnCheckUpgradeAsync_Click;
            // 
            // BtnCheckUpgradeUsingFtpAsync
            // 
            BtnCheckUpgradeUsingFtpAsync.Location = new Point(172, 94);
            BtnCheckUpgradeUsingFtpAsync.Name = "BtnCheckUpgradeUsingFtpAsync";
            BtnCheckUpgradeUsingFtpAsync.Size = new Size(101, 26);
            BtnCheckUpgradeUsingFtpAsync.TabIndex = 13;
            BtnCheckUpgradeUsingFtpAsync.Text = "异步检查更新";
            BtnCheckUpgradeUsingFtpAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingFtpAsync.Click += BtnCheckUpgradeUsingFtpAsync_Click;
            // 
            // groupBoxSetting
            // 
            groupBoxSetting.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSetting.Controls.Add(comboBoxVersionFormat);
            groupBoxSetting.Controls.Add(label10);
            groupBoxSetting.Controls.Add(comboBoxIcon);
            groupBoxSetting.Controls.Add(label9);
            groupBoxSetting.Controls.Add(comboBoxLang);
            groupBoxSetting.Controls.Add(label8);
            groupBoxSetting.Controls.Add(numericUpDownTimeoutSecond);
            groupBoxSetting.Controls.Add(comboBoxTheme);
            groupBoxSetting.Controls.Add(label7);
            groupBoxSetting.Controls.Add(label6);
            groupBoxSetting.Controls.Add(checkBoxSignCheck);
            groupBoxSetting.Location = new Point(12, 56);
            groupBoxSetting.Margin = new Padding(2, 3, 2, 3);
            groupBoxSetting.Name = "groupBoxSetting";
            groupBoxSetting.Padding = new Padding(2, 3, 2, 3);
            groupBoxSetting.Size = new Size(717, 197);
            groupBoxSetting.TabIndex = 14;
            groupBoxSetting.TabStop = false;
            groupBoxSetting.Text = "更新选项";
            // 
            // comboBoxVersionFormat
            // 
            comboBoxVersionFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVersionFormat.FormattingEnabled = true;
            comboBoxVersionFormat.Items.AddRange(new object[] { "", "Major", "MajorMinor", "MajorMinorBuild", "MajorMinorBuildRevision" });
            comboBoxVersionFormat.Location = new Point(152, 163);
            comboBoxVersionFormat.Margin = new Padding(2, 3, 2, 3);
            comboBoxVersionFormat.Name = "comboBoxVersionFormat";
            comboBoxVersionFormat.Size = new Size(177, 25);
            comboBoxVersionFormat.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(70, 170);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(80, 17);
            label10.TabIndex = 7;
            label10.Text = "版本展示格式";
            // 
            // comboBoxIcon
            // 
            comboBoxIcon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIcon.FormattingEnabled = true;
            comboBoxIcon.Items.AddRange(new object[] { "", "icon_test_1.ico", "icon_test_2.ico" });
            comboBoxIcon.Location = new Point(152, 134);
            comboBoxIcon.Margin = new Padding(2, 3, 2, 3);
            comboBoxIcon.Name = "comboBoxIcon";
            comboBoxIcon.Size = new Size(177, 25);
            comboBoxIcon.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(117, 141);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(32, 17);
            label9.TabIndex = 7;
            label9.Text = "图标";
            // 
            // comboBoxLang
            // 
            comboBoxLang.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLang.FormattingEnabled = true;
            comboBoxLang.Items.AddRange(new object[] { "", "zh", "en" });
            comboBoxLang.Location = new Point(152, 105);
            comboBoxLang.Margin = new Padding(2, 3, 2, 3);
            comboBoxLang.Name = "comboBoxLang";
            comboBoxLang.Size = new Size(177, 25);
            comboBoxLang.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(117, 112);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(32, 17);
            label8.TabIndex = 7;
            label8.Text = "语言";
            // 
            // numericUpDownTimeoutSecond
            // 
            numericUpDownTimeoutSecond.Location = new Point(152, 45);
            numericUpDownTimeoutSecond.Margin = new Padding(2, 3, 2, 3);
            numericUpDownTimeoutSecond.Name = "numericUpDownTimeoutSecond";
            numericUpDownTimeoutSecond.Size = new Size(97, 23);
            numericUpDownTimeoutSecond.TabIndex = 6;
            numericUpDownTimeoutSecond.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // comboBoxTheme
            // 
            comboBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.Items.AddRange(new object[] { "", "System", "Light", "Dark" });
            comboBoxTheme.Location = new Point(152, 76);
            comboBoxTheme.Margin = new Padding(2, 3, 2, 3);
            comboBoxTheme.Name = "comboBoxTheme";
            comboBoxTheme.Size = new Size(177, 25);
            comboBoxTheme.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(117, 83);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(32, 17);
            label7.TabIndex = 4;
            label7.Text = "主题";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 48);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(140, 17);
            label6.TabIndex = 2;
            label6.Text = "检查更新超时时间（秒）";
            // 
            // checkBoxSignCheck
            // 
            checkBoxSignCheck.AutoSize = true;
            checkBoxSignCheck.Location = new Point(152, 20);
            checkBoxSignCheck.Margin = new Padding(2, 3, 2, 3);
            checkBoxSignCheck.Name = "checkBoxSignCheck";
            checkBoxSignCheck.Size = new Size(99, 21);
            checkBoxSignCheck.TabIndex = 1;
            checkBoxSignCheck.Text = "文件签名校验";
            checkBoxSignCheck.UseVisualStyleBackColor = true;
            // 
            // checkBoxDefaultConfig
            // 
            checkBoxDefaultConfig.AutoSize = true;
            checkBoxDefaultConfig.Location = new Point(12, 31);
            checkBoxDefaultConfig.Margin = new Padding(2, 3, 2, 3);
            checkBoxDefaultConfig.Name = "checkBoxDefaultConfig";
            checkBoxDefaultConfig.Size = new Size(99, 21);
            checkBoxDefaultConfig.TabIndex = 0;
            checkBoxDefaultConfig.Text = "使用默认设置";
            checkBoxDefaultConfig.UseVisualStyleBackColor = true;
            checkBoxDefaultConfig.CheckedChanged += checkBoxDefaultConfig_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Location = new Point(12, 259);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(717, 271);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "更新方式";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 19);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(711, 249);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtUpgradeUrl);
            tabPage1.Controls.Add(BtnCheckUpgrade);
            tabPage1.Controls.Add(BtnCheckUpgradeAsync);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(703, 219);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "HTTP 方式";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(BtnCheckUpgradeUsingFtp);
            tabPage2.Controls.Add(BtnCheckUpgradeUsingFtpAsync);
            tabPage2.Controls.Add(TxtFtpUpgradePath);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(TxtPassword);
            tabPage2.Controls.Add(TxtUserName);
            tabPage2.Controls.Add(label5);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(703, 219);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "FTP 方式";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(BtnCheckUpgradeUsingGitHub);
            tabPage3.Controls.Add(BtnCheckUpgradeUsingGitHubAsync);
            tabPage3.Controls.Add(TxtUser);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(TxtAssetName);
            tabPage3.Controls.Add(TxtRepo);
            tabPage3.Controls.Add(label13);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(703, 219);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "GitHub 方式";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(33, 16);
            label11.Name = "label11";
            label11.Size = new Size(32, 17);
            label11.TabIndex = 15;
            label11.Text = "用户";
            // 
            // BtnCheckUpgradeUsingGitHub
            // 
            BtnCheckUpgradeUsingGitHub.Location = new Point(71, 101);
            BtnCheckUpgradeUsingGitHub.Name = "BtnCheckUpgradeUsingGitHub";
            BtnCheckUpgradeUsingGitHub.Size = new Size(101, 26);
            BtnCheckUpgradeUsingGitHub.TabIndex = 14;
            BtnCheckUpgradeUsingGitHub.Text = "同步检查更新";
            BtnCheckUpgradeUsingGitHub.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingGitHub.Click += BtnCheckUpgradeUsingGitHub_Click;
            // 
            // BtnCheckUpgradeUsingGitHubAsync
            // 
            BtnCheckUpgradeUsingGitHubAsync.Location = new Point(178, 101);
            BtnCheckUpgradeUsingGitHubAsync.Name = "BtnCheckUpgradeUsingGitHubAsync";
            BtnCheckUpgradeUsingGitHubAsync.Size = new Size(101, 26);
            BtnCheckUpgradeUsingGitHubAsync.TabIndex = 21;
            BtnCheckUpgradeUsingGitHubAsync.Text = "异步检查更新";
            BtnCheckUpgradeUsingGitHubAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingGitHubAsync.Click += BtnCheckUpgradeUsingGitHubAsync_Click;
            // 
            // TxtUser
            // 
            TxtUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtUser.Location = new Point(71, 13);
            TxtUser.Name = "TxtUser";
            TxtUser.Size = new Size(629, 23);
            TxtUser.TabIndex = 16;
            TxtUser.Text = "JiuLing-zhang";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(33, 46);
            label12.Name = "label12";
            label12.Size = new Size(32, 17);
            label12.TabIndex = 17;
            label12.Text = "仓库";
            // 
            // TxtAssetName
            // 
            TxtAssetName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtAssetName.Location = new Point(71, 72);
            TxtAssetName.Name = "TxtAssetName";
            TxtAssetName.Size = new Size(629, 23);
            TxtAssetName.TabIndex = 20;
            TxtAssetName.Text = "SignDebugger_v1.2.7_win_x64.zip";
            // 
            // TxtRepo
            // 
            TxtRepo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtRepo.Location = new Point(71, 43);
            TxtRepo.Name = "TxtRepo";
            TxtRepo.Size = new Size(629, 23);
            TxtRepo.TabIndex = 18;
            TxtRepo.Text = "SignDebugger";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(9, 75);
            label13.Name = "label13";
            label13.Size = new Size(56, 17);
            label13.TabIndex = 19;
            label13.Text = "资源名称";
            // 
            // FmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 542);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxSetting);
            Controls.Add(checkBoxDefaultConfig);
            Controls.Add(LblVersion);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "自动更新测试程序";
            Load += FmMain_Load;
            groupBoxSetting.ResumeLayout(false);
            groupBoxSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeoutSecond).EndInit();
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
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
        private GroupBox groupBoxSetting;
        private CheckBox checkBoxDefaultConfig;
        private CheckBox checkBoxSignCheck;
        private Label label6;
        private Label label7;
        private ComboBox comboBoxTheme;
        private NumericUpDown numericUpDownTimeoutSecond;
        private ComboBox comboBoxLang;
        private Label label8;
        private ComboBox comboBoxIcon;
        private Label label9;
        private ComboBox comboBoxVersionFormat;
        private Label label10;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label11;
        private Button BtnCheckUpgradeUsingGitHub;
        private Button BtnCheckUpgradeUsingGitHubAsync;
        private TextBox TxtUser;
        private Label label12;
        private TextBox TxtAssetName;
        private TextBox TxtRepo;
        private Label label13;
    }
}