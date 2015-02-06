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
            var webClient = new GzipWebClient();
            webClient.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            var downloadedString = webClient.DownloadString(url);

            return downloadedString;
        }

        private async Task<String> DownloadStringAsync(string url)
        {

            var webClient = new GzipWebClient();
            webClient.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            var downloadedString = await webClient.DownloadStringTaskAsync(url);

            return downloadedString;
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

                using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(downloadedString)))
                using (var sr = new StreamReader(memoryStream))
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    var deserialize = new Task<T>(() => serializer.Deserialize<T>(jsonTextReader));
                    deserialize.Start();
                    T apiResponseObject = await deserialize;

                    return apiResponseObject;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getData
        public T GetDataFromURL<T>(string url) where T : class
        {
            try
            {
                return DeserializeJson<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURL");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<T> GetDataFromURLAsync<T>(string url) where T : class
        {
            try
            {
                return await DeserializeJsonAsync<T>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDataFromURLAsync");
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}
