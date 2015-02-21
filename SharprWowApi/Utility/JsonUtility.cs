using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharprWowApi.Models.Character;
using SharprWowApi.Models.Quest;

namespace SharprWowApi.Utility
{
    public class JsonUtility
    {
        internal T GetDataFromURL<T>(string url) where T : class
        {
            try
            {
                return this.DeserializeJson<T>(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        private string DownloadString(string url)
        {
            using (var webClient = new GzipWebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                var downloadedString = webClient.DownloadString(url);

                return downloadedString;
            }
        }

        private async Task<byte[]> DownloadStringAsync(string url)
        {
            using (var httpClient = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
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

        /// <summary>
        /// Takes a json string, downloads it with webclient, 
        /// initializes memorystream, read stream w streamreader
        /// returns deserialized object.
        /// </summary>
        /// <typeparam name="T">Class model</typeparam>
        /// <param name="url">Url for the json</param>
        /// <returns>Deserialized object
        /// </returns>
        private T DeserializeJson<T>(string url) where T : class
        {
            try
            {
                var downloadedString = this.DownloadString(url);

                using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(downloadedString)))
                {
                    var sr = new StreamReader(memoryStream);
                    var jsonTextReader = new JsonTextReader(sr);

                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<T> DeserializeJsonAsync<T>(string url) where T : class
        {
            try
            {
                var downloadedByte = await this.DownloadStringAsync(url);

                using (var memoryStream = new MemoryStream(downloadedByte, false))
                {
                    var sr = new StreamReader(memoryStream);
                    var jsonTextReader = new JsonTextReader(sr);
                    var serializer = new JsonSerializer();
                    var deserialize = new Task<T>(() => serializer.Deserialize<T>(jsonTextReader));

                    deserialize.Start();
                    var apiResponseObject = await deserialize;

                    return apiResponseObject;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
