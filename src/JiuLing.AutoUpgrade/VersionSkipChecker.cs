using System.IO;
using System.Linq;
using System.Text;
using JiuLing.CommonLibs.Security;

namespace JiuLing.AutoUpgrade
{
    internal class VersionSkipChecker
    {
        private readonly string _version;
        private readonly string _skipPath;
        public VersionSkipChecker(string versionKey, string version)
        {
            _version = version;
            string skipDirectory = Path.Combine(Path.GetTempPath(), "JiuLing.AutoUpgrade");
            if (!Directory.Exists(skipDirectory))
            {
                Directory.CreateDirectory(skipDirectory);
            }
            //为了防止非法文件名，对 versionKey 进行一个 md5
            var fileName = $"skip_{MD5Utils.GetStringValueToLower(versionKey)}.tmp";
            _skipPath = Path.Combine(skipDirectory, fileName);

        }

        public bool CheckSkip()
        {
            if (!File.Exists(_skipPath))
            {
                return false;
            }
            var versionArray = File.ReadAllLines(_skipPath);
            return versionArray.Any(x => x == _version);
        }

        public void SetSkip()
        {
            using (var sw = new StreamWriter(_skipPath, true, Encoding.UTF8))
            {
                sw.WriteLine(_version);
                sw.Close();
            }
        }
    }
}
