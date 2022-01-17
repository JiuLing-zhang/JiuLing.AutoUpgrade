using System.Text.Json;
using AutoUpgrade.Common;
using AutoUpgrade.Models;

namespace AutoUpgrade
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadingAppConfig();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"初始化失败：{ex.Message}");
                Application.Exit();
            }
        }

        private void LoadingAppConfig()
        {
            if (!File.Exists(GlobalArgs.AppConfigPath))
            {
                throw new FileNotFoundException($"未找到配置文件{GlobalArgs.AppConfigPath}");
            }
            string configString = File.ReadAllText(GlobalArgs.AppConfigPath);
            try
            {
                GlobalArgs.AppConfig = JsonSerializer.Deserialize<AppConfigInfo>(configString) ?? throw new JsonException($"配置文件解析失败{GlobalArgs.AppConfigPath}");
            }
            catch (JsonException)
            {
                throw new JsonException($"配置文件格式错误{GlobalArgs.AppConfigPath}");
            }
        }
    }
}