using JiuLing.AutoUpgrade.Shared;
using JiuLing.AutoUpgrade.Shell;
using JiuLing.AutoUpgrade.Shell.Creator;
using JiuLing.AutoUpgrade.Shell.Enums;

namespace JiuLing.AutoUpgrade.Test;
public partial class FmMain : Form
{
    private IUpgradeApp _upgradeApp;
    public FmMain()
    {
        InitializeComponent();
    }

    private void FmMain_Load(object sender, EventArgs e)
    {
        LblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        comboBoxTheme.SelectedIndex = 0;
        comboBoxLang.SelectedIndex = 0;
        comboBoxIcon.SelectedIndex = 0;
        comboBoxVersionFormat.SelectedIndex = 0;
        checkBoxDefaultConfig.Checked = true;
    }

    private void BtnCheckUpgrade_Click(object sender, EventArgs e)
    {
        try
        {
            BuildUpgradeHttpApp().Run();
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
            await BuildUpgradeHttpApp().RunAsync();
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
            BuildUpgradeFtpApp().Run();
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
            await BuildUpgradeFtpApp().RunAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"操作失败：{ex.Message}");
        }
    }

    private void checkBoxDefaultConfig_CheckedChanged(object sender, EventArgs e)
    {
        var enabled = !checkBoxDefaultConfig.Checked;
        foreach (Control control in groupBoxSetting.Controls)
        {
            control.Enabled = enabled;
        }
    }

    private IUpgradeApp BuildUpgradeHttpApp()
    {
        _upgradeApp = UpgradeFactory.CreateHttpApp(txtUpgradeUrl.Text);
        if (!checkBoxDefaultConfig.Checked)
        {
            _upgradeApp.SetUpgrade(BuildUpgradeSetting);
        }
        return _upgradeApp;
    }

    private IUpgradeApp BuildUpgradeFtpApp()
    {
        _upgradeApp = UpgradeFactory.CreateFtpApp(TxtFtpUpgradePath.Text, TxtUserName.Text, TxtPassword.Text);
        if (!checkBoxDefaultConfig.Checked)
        {
            _upgradeApp.SetUpgrade(BuildUpgradeSetting);
        }
        return _upgradeApp;
    }

    private void BuildUpgradeSetting(UpgradeSettingBuilder builder)
    {
        builder.WithSignCheck(checkBoxSignCheck.Checked);
        builder.WithTimeout(Convert.ToInt32(numericUpDownTimeoutSecond.Value));

        var theme = comboBoxTheme.Text;
        if (!string.IsNullOrEmpty(theme))
        {
            builder.WithTheme((ThemeEnum)Enum.Parse(typeof(ThemeEnum), theme));
        }

        var lang = comboBoxLang.Text;
        if (!string.IsNullOrEmpty(lang))
        {
            builder.WithLang(lang);
        }

        var icon = comboBoxIcon.Text;
        if (!string.IsNullOrEmpty(icon))
        {
            builder.WithIcon(icon);
        }

        var versionFormat = comboBoxVersionFormat.Text;
        if (!string.IsNullOrEmpty(versionFormat))
        {
            builder.WithVersionFormat((VersionFormatEnum)Enum.Parse(typeof(VersionFormatEnum), versionFormat));
        }
    }

    private void BtnCheckUpgradeUsingGitHub_Click(object sender, EventArgs e)
    {
        try
        {
            BuildUpgradeGitHubApp().Run();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"操作失败：{ex.Message}");
        }
    }

    private async void BtnCheckUpgradeUsingGitHubAsync_Click(object sender, EventArgs e)
    {
        try
        {
            await BuildUpgradeGitHubApp().RunAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"操作失败：{ex.Message}");
        }
    }

    private IUpgradeApp BuildUpgradeGitHubApp()
    {
        _upgradeApp = UpgradeFactory.CreateGitHubApp(TxtUser.Text, TxtRepo.Text, TxtAssetName.Text);
        if (!checkBoxDefaultConfig.Checked)
        {
            _upgradeApp.SetUpgrade(BuildUpgradeSetting);
        }
        return _upgradeApp;
    }
}