using System.Windows.Forms;

namespace JiuLing.AutoUpgrade
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
            this.LblCurrentVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNewVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUpgrade = new System.Windows.Forms.Button();
            this.TxtLog = new System.Windows.Forms.RichTextBox();
            this.LblVersionOverdue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前版本";
            // 
            // LblCurrentVersion
            // 
            this.LblCurrentVersion.AutoSize = true;
            this.LblCurrentVersion.Location = new System.Drawing.Point(63, 6);
            this.LblCurrentVersion.Name = "LblCurrentVersion";
            this.LblCurrentVersion.Size = new System.Drawing.Size(11, 12);
            this.LblCurrentVersion.TabIndex = 1;
            this.LblCurrentVersion.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(117, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "新版本";
            // 
            // LblNewVersion
            // 
            this.LblNewVersion.AutoSize = true;
            this.LblNewVersion.Location = new System.Drawing.Point(159, 6);
            this.LblNewVersion.Name = "LblNewVersion";
            this.LblNewVersion.Size = new System.Drawing.Size(11, 12);
            this.LblNewVersion.TabIndex = 1;
            this.LblNewVersion.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "更新内容";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(129, 205);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(64, 16);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "忽略";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpgrade
            // 
            this.BtnUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpgrade.Location = new System.Drawing.Point(198, 205);
            this.BtnUpgrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnUpgrade.Name = "BtnUpgrade";
            this.BtnUpgrade.Size = new System.Drawing.Size(64, 16);
            this.BtnUpgrade.TabIndex = 5;
            this.BtnUpgrade.Text = "更新";
            this.BtnUpgrade.UseVisualStyleBackColor = true;
            this.BtnUpgrade.Click += new System.EventHandler(this.BtnUpgrade_Click);
            // 
            // TxtLog
            // 
            this.TxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLog.Location = new System.Drawing.Point(10, 32);
            this.TxtLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(253, 169);
            this.TxtLog.TabIndex = 6;
            this.TxtLog.Text = "";
            // 
            // LblVersionOverdue
            // 
            this.LblVersionOverdue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVersionOverdue.AutoSize = true;
            this.LblVersionOverdue.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.LblVersionOverdue.ForeColor = System.Drawing.Color.Red;
            this.LblVersionOverdue.Location = new System.Drawing.Point(10, 207);
            this.LblVersionOverdue.Name = "LblVersionOverdue";
            this.LblVersionOverdue.Size = new System.Drawing.Size(104, 17);
            this.LblVersionOverdue.TabIndex = 7;
            this.LblVersionOverdue.Text = "当前版本已经停用";
            this.LblVersionOverdue.Visible = false;
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 229);
            this.Controls.Add(this.LblVersionOverdue);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.BtnUpgrade);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblNewVersion);
            this.Controls.Add(this.LblCurrentVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label LblCurrentVersion;
        private Label label2;
        private Label LblNewVersion;
        private Label label3;
        private Button BtnCancel;
        private Button BtnUpgrade;
        private RichTextBox TxtLog;
        private Label LblVersionOverdue;
    }
}