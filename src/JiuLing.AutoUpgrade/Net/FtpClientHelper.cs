using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiuLing.AutoUpgrade.Net
{
    internal class FtpClientHelper
    {
        private readonly string _username;
        private readonly string _password;
        public FtpClientHelper(string username, string password)
        {
            _username = username;
            _password = password;
        }
        /// <summary>
        /// 读取文本
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public async Task<string> ReadFileText(string filePath, TimeSpan timeout)
        {
            var request = (FtpWebRequest)WebRequest.Create(filePath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Timeout = Convert.ToInt32(timeout.TotalMilliseconds);
            request.Credentials = new NetworkCredential(_username, _password);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new Exception($"{lang.ExTextReadingFailed}{lang.StreamIsEmpty}");
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await responseStream.CopyToAsync(memoryStream);
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
        }

        public async Task<byte[]> GetFileByteArray(string filePath, IProgress<float> progress, int bufferSize = 8192)
        {
            progress?.Report(0);

            var request = (FtpWebRequest)WebRequest.Create(filePath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential(_username, _password);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new Exception($"{lang.ExFileReadingFailed}{lang.StreamIsEmpty}");
                    }
                    long contentLength = GetFileSize(filePath);
                    var buffer = new byte[bufferSize];
                    int length;
                    long downloadLength = 0;
                    var bytes = new byte[contentLength];

                    while ((length = await responseStream.ReadAsync(buffer, 0, bufferSize)) > 0)
                    {

                        Array.Copy(buffer, 0, bytes, downloadLength, length);
                        downloadLength += length;
                        progress?.Report((float)downloadLength / contentLength);
                    }
                    progress?.Report(1);
                    return bytes.ToArray();
                }
            }
        }
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private long GetFileSize(string filePath)
        {
            var request = (FtpWebRequest)WebRequest.Create(filePath);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = new NetworkCredential(_username, _password);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return response.ContentLength;
            }
        }
    }
}
