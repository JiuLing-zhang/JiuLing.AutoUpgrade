using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpgrade.Common
{
    internal class MessageUtils
    {
        private const string Title = "自动更新";
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
            MessageBox.Show(msg, Title, MessageBoxButtons.OK, messageBoxIcon);
        }
    }
}
