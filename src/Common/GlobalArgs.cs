using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUpgrade.Models;

namespace AutoUpgrade.Common
{
    internal class GlobalArgs
    {
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string AppConfigPath = $"{AppPath}AutoUpgrade.config.json";
        public static AppConfigInfo AppConfig = new();
    }
}
