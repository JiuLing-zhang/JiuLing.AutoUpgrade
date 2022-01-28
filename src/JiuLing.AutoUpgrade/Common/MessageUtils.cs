namespace JiuLing.AutoUpgrade.Common
{
    internal class MessageUtils
    {
        private static string _title = "";

        public static void SetWindowTitle(string title)
        {
            _title = title;
        }
        public static void ShowInfo(string msg)
        {
            Show(msg, MessageBoxIcon.Information);
        }

        public static void ShowError(string msg)
        {
            Show(msg, MessageBoxIcon.Error);
        }

        private static void Show(string msg, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(msg, _title, MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
