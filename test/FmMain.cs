using JiuLing.AutoUpgrade.Shell;

namespace JiuLing.AutoUpgrade.Test
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            LblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }

        private void BtnCheckUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                var app = AutoUpgradeFactory.Create();
                app.SetUpgrade(config =>
                {
                    config.IsCheckSign = true;
                });
                app.UseHttpMode(txtUpgradeUrl.Text)
                     .Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }

        private async void BtnCheckUpgradeAsync_Click(object sender, EventArgs e)
        {
            try
            {
                var app = AutoUpgradeFactory.Create();
                app.SetUpgrade(config =>
                {
                    config.IsCheckSign = true;
                });
                await app.UseHttpMode(txtUpgradeUrl.Text)
                      .RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }

        private void BtnCheckUpgradeUsingFtp_Click(object sender, EventArgs e)
        {
            try
            {
                var app = AutoUpgradeFactory.Create();
                app.UseFtpMode(TxtFtpUpgradePath.Text, TxtUserName.Text, TxtPassword.Text)
                    .Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }

        private async void BtnCheckUpgradeUsingFtpAsync_Click(object sender, EventArgs e)
        {
            try
            {
                var app = AutoUpgradeFactory.Create();
                await app.UseFtpMode(TxtFtpUpgradePath.Text, TxtUserName.Text, TxtPassword.Text)
                      .RunAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }
    }
}