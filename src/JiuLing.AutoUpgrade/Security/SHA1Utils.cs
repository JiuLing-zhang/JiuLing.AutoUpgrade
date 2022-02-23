using System;
using System.IO;
using System.Security.Cryptography;

namespace JiuLing.AutoUpgrade.Security
{
    /// <summary>
    /// SHA1的帮助类
    /// </summary>
    public class SHA1Utils
    {
        /// <summary>
        /// 计算文件的SHA1值（小写）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回文件的SHA1值</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string GetFileValueToLower(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            var file = new FileStream(fileName, FileMode.Open);
            var sha1 = new SHA1CryptoServiceProvider();
            var byteHash = sha1.ComputeHash(file);
            file.Close();

            string tmpValue = "";
            for (int i = 0; i < byteHash.Length; i++)
            {
                tmpValue += byteHash[i].ToString("X").PadLeft(2, '0').ToLower();
            }
            return tmpValue;
        }
    }
}
