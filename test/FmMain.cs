using System.Diagnostics;
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
                string upgradeUrl = "https://raw.githubusercontent.com/JiuLing-zhang/AutoUpgrade/main/test/AppInfo.json";
                AutoUpgradeFactory
                    .Create()
                    .SetUpgradeUrl(upgradeUrl)
                    .Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }
    }
}