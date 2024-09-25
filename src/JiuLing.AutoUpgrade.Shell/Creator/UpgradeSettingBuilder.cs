using JiuLing.AutoUpgrade.Shared;
using JiuLing.AutoUpgrade.Shell.Enums;
using System.IO;

namespace JiuLing.AutoUpgrade.Shell.Creator
{
    /// <summary>
    /// 参数设置构建器
    /// </summary>
    public class UpgradeSettingBuilder
    {
        private readonly UpgradeSetting _upgradeSetting;

        /// <summary>
        /// 初始化
        /// </summary>
        public UpgradeSettingBuilder()
        {
            _upgradeSetting = new UpgradeSetting();
        }

        /// <summary>
        /// 是否在后台进行更新检查
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithBackgroundCheck(bool value)
        {
            _upgradeSetting.IsBackgroundCheck = value;
            return this;
        }

        /// <summary>
        /// 是否对下载的文件启用签名校验
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithSignCheck(bool value)
        {
            _upgradeSetting.IsCheckSign = value;
            return this;
        }

        /// <summary>
        /// 设置检查更新时的请求超时时间
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithTimeout(int second)
        {
            _upgradeSetting.TimeoutSecond = second;
            return this;
        }

        /// <summary>
        /// 设置主题
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithTheme(ThemeEnum theme)
        {
            _upgradeSetting.Theme = theme;
            return this;
        }

        /// <summary>
        /// 设置语言
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithLang(string lang)
        {
            _upgradeSetting.Lang = lang;
            return this;
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithIcon(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"图标文件不存在: {path}");
                }
                _upgradeSetting.IconPath = path;
            }
            return this;
        }

        /// <summary>
        /// 设置版本展示格式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public UpgradeSettingBuilder WithVersionFormat(VersionFormatEnum format)
        {
            _upgradeSetting.VersionFormat = format;
            return this;
        }

        /// <summary>
        /// 构建配置
        /// </summary>
        /// <returns></returns>
        internal UpgradeSetting Build()
        {
            return _upgradeSetting;
        }
    }
}
