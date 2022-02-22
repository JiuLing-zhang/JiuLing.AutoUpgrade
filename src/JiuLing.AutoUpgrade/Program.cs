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
        private static readonly List<string> EmbeddedAssemblyList = new List<string>() { "Newtonsoft.Json", "System.IO.Compression.ZipFile", "JiuLing.CommonLibs" };
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string dllName = args.Name.Split(',')[0];
                if (!EmbeddedAssemblyList.Contains(dllName))
                {
                    return null;
                }

                byte[] ba = null;
                string resource = $"JiuLing.AutoUpgrade.lib.{dllName}.dll";
                Assembly curAsm = Assembly.GetExecutingAssembly();
                using (Stream stm = curAsm.GetManifestResourceStream(resource))
                {
                    ba = new byte[(int)stm.Length];
                    stm.Read(ba, 0, (int)stm.Length);

                    return Assembly.Load(ba);
                }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FmMain());
        }
    }
}
