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
            groupBoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeoutSecond).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "当前版本";
            // 
            // LblVersion
            // 
            LblVersion.AutoSize = true;
            LblVersion.Location = new Point(95, 11);
            LblVersion.Margin = new Padding(4, 0, 4, 0);
            LblVersion.Name = "LblVersion";
            LblVersion.Size = new Size(15, 20);
            LblVersion.TabIndex = 1;
            LblVersion.Text = "-";
            // 
            // BtnCheckUpgrade
            // 
            BtnCheckUpgrade.Location = new Point(15, 344);
            BtnCheckUpgrade.Margin = new Padding(4);
            BtnCheckUpgrade.Name = "BtnCheckUpgrade";
            BtnCheckUpgrade.Size = new Size(192, 56);
            BtnCheckUpgrade.TabIndex = 2;
            BtnCheckUpgrade.Text = "检查更新-HTTP";
            BtnCheckUpgrade.UseVisualStyleBackColor = true;
            BtnCheckUpgrade.Click += BtnCheckUpgrade_Click;
            // 
            // BtnCheckUpgradeUsingFtp
            // 
            BtnCheckUpgradeUsingFtp.Location = new Point(15, 520);
            BtnCheckUpgradeUsingFtp.Margin = new Padding(4);
            BtnCheckUpgradeUsingFtp.Name = "BtnCheckUpgradeUsingFtp";
            BtnCheckUpgradeUsingFtp.Size = new Size(192, 56);
            BtnCheckUpgradeUsingFtp.TabIndex = 3;
            BtnCheckUpgradeUsingFtp.Text = "检查更新-FTP";
            BtnCheckUpgradeUsingFtp.UseVisualStyleBackColor = true;
            BtnCheckUpgradeUsingFtp.Click += BtnCheckUpgradeUsingFtp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 316);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 4;
            label2.Text = "更新地址";
            // 
            // txtUpgradeUrl
            // 
            txtUpgradeUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUpgradeUrl.Location = new Point(95, 313);
            txtUpgradeUrl.Margin = new Padding(4);
            txtUpgradeUrl.Name = "txtUpgradeUrl";
            txtUpgradeUrl.Size = new Size(719, 27);
            txtUpgradeUrl.TabIndex = 5;
            txtUpgradeUrl.Text = "https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 414);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 6;
            label3.Text = "更新地址";
            // 
            // TxtFtpUpgradePath
            // 
            TxtFtpUpgradePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtFtpUpgradePath.Location = new Point(95, 410);
            TxtFtpUpgradePath.Margin = new Padding(4);
            TxtFtpUpgradePath.Name = "TxtFtpUpgradePath";
            TxtFtpUpgradePath.Size = new Size(719, 27);
            TxtFtpUpgradePath.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 449);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 8;
            label4.Text = "用户名";
            // 
            // TxtUserName
            // 
            TxtUserName.Location = new Point(95, 446);
            TxtUserName.Margin = new Padding(4);
            TxtUserName.Name = "TxtUserName";
            TxtUserName.Size = new Size(237, 27);
            TxtUserName.TabIndex = 9;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(95, 486);
            TxtPassword.Margin = new Padding(4);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '♥';
            TxtPassword.Size = new Size(237, 27);
            TxtPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 489);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 10;
            label5.Text = "密码";
            // 
            // BtnCheckUpgradeAsync
            // 
            BtnCheckUpgradeAsync.Location = new Point(215, 344);
            BtnCheckUpgradeAsync.Margin = new Padding(4);
            BtnCheckUpgradeAsync.Name = "BtnCheckUpgradeAsync";
            BtnCheckUpgradeAsync.Size = new Size(192, 56);
            BtnCheckUpgradeAsync.TabIndex = 12;
            BtnCheckUpgradeAsync.Text = "检查更新-异步-HTTP";
            BtnCheckUpgradeAsync.UseVisualStyleBackColor = true;
            BtnCheckUpgradeAsync.Click += BtnCheckUpgradeAsync_Click;
            // 
            // BtnCheckUpgradeUsingFtpAsync
            // 
            BtnCheckUpgradeUsingFtpAsync.Location = new Point(215, 520);
            BtnCheckUpgradeUsingFtpAsync.Margin = new Padding(4);
            BtnCheckUpgradeUsingFtpAsync.Name = "BtnCheckUpgradeUsingFtpAsync";
            BtnCheckUpgradeUsingFtpAsync.Size = new Size(192, 56);
            BtnCheckUpgradeUsingFtpAsync.TabIndex = 13;
            BtnCheckUpgradeUsingFtpAsync.Text = "检查更新-异步-FTP";
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
            groupBoxSetting.Location = new Point(15, 66);
            groupBoxSetting.Name = "groupBoxSetting";
            groupBoxSetting.Size = new Size(691, 232);
            groupBoxSetting.TabIndex = 14;
            groupBoxSetting.TabStop = false;
            groupBoxSetting.Text = "更新选项";
            // 
            // comboBoxVersionFormat
            // 
            comboBoxVersionFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVersionFormat.FormattingEnabled = true;
            comboBoxVersionFormat.Items.AddRange(new object[] { "", "Major", "MajorMinor", "MajorMinorBuild", "MajorMinorBuildRevision" });
            comboBoxVersionFormat.Location = new Point(195, 192);
            comboBoxVersionFormat.Name = "comboBoxVersionFormat";
            comboBoxVersionFormat.Size = new Size(227, 28);
            comboBoxVersionFormat.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(90, 200);
            label10.Name = "label10";
            label10.Size = new Size(99, 20);
            label10.TabIndex = 7;
            label10.Text = "版本展示格式";
            // 
            // comboBoxIcon
            // 
            comboBoxIcon.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIcon.FormattingEnabled = true;
            comboBoxIcon.Items.AddRange(new object[] { "", "icon_test_1.ico", "icon_test_2.ico" });
            comboBoxIcon.Location = new Point(195, 158);
            comboBoxIcon.Name = "comboBoxIcon";
            comboBoxIcon.Size = new Size(227, 28);
            comboBoxIcon.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(150, 166);
            label9.Name = "label9";
            label9.Size = new Size(39, 20);
            label9.TabIndex = 7;
            label9.Text = "图标";
            // 
            // comboBoxLang
            // 
            comboBoxLang.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLang.FormattingEnabled = true;
            comboBoxLang.Items.AddRange(new object[] { "", "zh", "en" });
            comboBoxLang.Location = new Point(195, 124);
            comboBoxLang.Name = "comboBoxLang";
            comboBoxLang.Size = new Size(227, 28);
            comboBoxLang.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(150, 132);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 7;
            label8.Text = "语言";
            // 
            // numericUpDownTimeoutSecond
            // 
            numericUpDownTimeoutSecond.Location = new Point(195, 53);
            numericUpDownTimeoutSecond.Name = "numericUpDownTimeoutSecond";
            numericUpDownTimeoutSecond.Size = new Size(125, 27);
            numericUpDownTimeoutSecond.TabIndex = 6;
            numericUpDownTimeoutSecond.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // comboBoxTheme
            // 
            comboBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.Items.AddRange(new object[] { "", "System", "Light", "Dark" });
            comboBoxTheme.Location = new Point(195, 90);
            comboBoxTheme.Name = "comboBoxTheme";
            comboBoxTheme.Size = new Size(227, 28);
            comboBoxTheme.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(150, 98);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 4;
            label7.Text = "主题";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 56);
            label6.Name = "label6";
            label6.Size = new Size(174, 20);
            label6.TabIndex = 2;
            label6.Text = "检查更新超时时间（秒）";
            // 
            // checkBoxSignCheck
            // 
            checkBoxSignCheck.AutoSize = true;
            checkBoxSignCheck.Location = new Point(195, 23);
            checkBoxSignCheck.Name = "checkBoxSignCheck";
            checkBoxSignCheck.Size = new Size(121, 24);
            checkBoxSignCheck.TabIndex = 1;
            checkBoxSignCheck.Text = "文件签名校验";
            checkBoxSignCheck.UseVisualStyleBackColor = true;
            // 
            // checkBoxDefaultConfig
            // 
            checkBoxDefaultConfig.AutoSize = true;
            checkBoxDefaultConfig.Location = new Point(15, 37);
            checkBoxDefaultConfig.Name = "checkBoxDefaultConfig";
            checkBoxDefaultConfig.Size = new Size(121, 24);
            checkBoxDefaultConfig.TabIndex = 0;
            checkBoxDefaultConfig.Text = "使用默认设置";
            checkBoxDefaultConfig.UseVisualStyleBackColor = true;
            checkBoxDefaultConfig.CheckedChanged += checkBoxDefaultConfig_CheckedChanged;
            // 
            // FmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 583);
            Controls.Add(groupBoxSetting);
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
            Controls.Add(checkBoxDefaultConfig);
            Controls.Add(BtnCheckUpgradeUsingFtp);
            Controls.Add(BtnCheckUpgrade);
            Controls.Add(LblVersion);
            Controls.Add(label1);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "自动更新测试程序";
            Load += FmMain_Load;
            groupBoxSetting.ResumeLayout(false);
            groupBoxSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeoutSecond).EndInit();
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
    }
}