using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JiuLing.AutoUpgrade
{
    internal static class Program
    {
        private static System.Threading.Mutex _mutex;
        private static readonly List<string> EmbeddedAssemblyList = new List<string>() { "Newtonsoft.Json", "System.IO.Compression.ZipFile", "JiuLing.CommonLibs" };
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            _mutex = new System.Threading.Mutex(true, "JiuLing.AutoUpgrade");
            if (!_mutex.WaitOne(0, false))
            {
                MessageBox.Show("不能重复运行 JiuLing.AutoUpgrade");
                return;
            }

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string dllName = args.Name.Split(',')[0];
                if (!EmbeddedAssemblyList.Contains(dllName))
                {
                    return null;
                }

                string resource = $"JiuLing.AutoUpgrade.lib.{dllName}.dll";
                Assembly curAsm = Assembly.GetExecutingAssembly();
                using (Stream stream = curAsm.GetManifestResourceStream(resource))
                {
                    var buffer = new byte[(int)stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);

                    return Assembly.Load(buffer);
                }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FmMain());
        }
    }
}
