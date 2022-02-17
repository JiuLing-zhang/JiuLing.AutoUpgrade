using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuLing.AutoUpgrade
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
 
            string resource1 = "JiuLing.AutoUpgrade.lib.Newtonsoft.Json.dll";
            string resource2 = "JiuLing.AutoUpgrade.lib.System.IO.Compression.ZipFile.dll";
            EmbeddedAssembly.Load(resource1, "Newtonsoft.Json.dll");
            EmbeddedAssembly.Load(resource2, "System.IO.Compression.ZipFile.dll");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FmMain());
        }
    }
}
