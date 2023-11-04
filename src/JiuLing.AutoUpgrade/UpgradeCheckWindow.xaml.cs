using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JiuLing.AutoUpgrade
{
    /// <summary>
    /// UpgradeCheckWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpgradeCheckWindow : ModernWindow
    {
        public UpgradeCheckWindow()
        {
            InitializeComponent();
        }

        private async void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTitle.Text = UpgradeInfo.MainProcess.Title;
            await CheckUpdateAsync();
        }

        private void ModernWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private async Task CheckUpdateAsync()
        {
            try
            {
                PanelCheckUpdate.Visibility = Visibility.Visible;
                PanelMessage.Visibility = Visibility.Hidden;

                await UpgradeChecker.DoAsync();
                if (UpgradeInfo.IsNeedUpdate == false)
                {
                    ShowMessage(lang.MsgNoNeedUpdate);
                    BtnRetry.Visibility = Visibility.Hidden;
                    return;
                }

                new UpgradeWindow().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessage($"{lang.ExCheck}{ex.Message}");
            }
        }

        private void ShowMessage(string message)
        {
            PanelCheckUpdate.Visibility = Visibility.Hidden;
            PanelMessage.Visibility = Visibility.Visible;
            TxtMessage.Text = message;
        }

        private async void BtnRetry_Click(object sender, RoutedEventArgs e)
        {
            await CheckUpdateAsync();
        }
    }
}
