using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JiuLing.AutoUpgrade.Security
{
    /// <summary>
    /// MD5的帮助类
    /// </summary>
    public class MD5Utils
    {
        /// <summary>
        /// 计算文件的MD5（小写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToLower(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            using (var md5Instance = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hashResult = md5Instance.ComputeHash(stream);
                    return BitConverter.ToString(hashResult).Replace("-", "").ToLower();
                }
            }
        }
    }
}
