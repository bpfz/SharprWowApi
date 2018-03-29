using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Utility
{
    public class JsonUtility
    {
        #region async
        internal async Task<T> GetDataFromURLAsync<T>(string url) where T : class
        {
            try
            {
                return await this.DeserializeJsonAsync<T>(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<byte[]> DownloadBytesAsync(string url)
        {
            using (var httpClient = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                }))
            {
                var download = this.ProcessURLAsync(url, httpClient);
                var downloaded = await download;

                return downloaded;
            }
        }

        private async Task<byte[]> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);

            return byteArray;
        }

        private async Task<T> DeserializeJsonAsync<T>(string url) where T : class
        {
            try
            {
                var downloadedByte = await DownloadBytesAsync(url);

                using (var memoryStream = new MemoryStream(downloadedByte, false))
                {
                    using (var sr = new StreamReader(memoryStream))
                    {
                        var content = await sr.ReadToEndAsync();
                        var deserialized = JsonConvert.DeserializeObject<T>(content);
                        return deserialized;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
        #endregion
    }
}
