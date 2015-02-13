using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SharprWowApi.Utility
{
    public class JsonUtility
    {
        #region downloadstring

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
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                }))
            {
                // var downloadedString = await httpClient.GetStringAsync(url);
                var download = ProcessURLAsync(url, httpClient);
                var downloaded = await download;

                return downloaded;
            }
        }

        private async Task<byte[]> ProcessURLAsync(string url, HttpClient client)
        {
            var byteArray = await client.GetByteArrayAsync(url);

            return byteArray;
        }

        #endregion

        #region deserialize

        /// <summary>
        /// Takes json string, downloads it with webclient, 
        /// initializes memorystream, read stream w streamreader
        /// returns deserliazed object.
        /// </summary>
        /// <typeparam name="T">Class model</typeparam>
        /// <param name="url">Url for the json</param>
        /// <returns>Deserialized json object.
        /// </returns>
        private T DeserializeJson<T>(string url) where T : class
        {
            try
            {
                var downloadedString = DownloadString(url);

                using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(downloadedString)))
                {
                    var sr = new StreamReader(memoryStream);
                    var jsonTextReader = new JsonTextReader(sr);

                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task<T> DeserializeJsonAsync<T>(string url) where T : class
        {
            try
            {
                var downloadedString = await DownloadStringAsync(url);

                //using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(downloadedString)))
                using (var memoryStream = new MemoryStream(downloadedString, false))
                {
                    var sr = new StreamReader(memoryStream);
                    var jsonTextReader = new JsonTextReader(sr);

                    var serializer = new JsonSerializer();
                    var deserialize = new Task<T>(() => serializer.Deserialize<T>(jsonTextReader));
                    deserialize.Start();
                    T apiResponseObject = await deserialize;

                    return apiResponseObject;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region getData

        internal T GetDataFromURL<T>(string url) where T : class
        {
            try
            {
                return DeserializeJson<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURL Exception ---");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        internal async Task<T> GetDataFromURLAsync<T>(string url) where T : class
        {
            try
            {
                return await DeserializeJsonAsync<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURLAsync Exception ---");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion
    }
}
