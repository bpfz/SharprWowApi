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
        /// <summary>
        /// Takes json string, downloads it with webclient, 
        /// initializes memorystream, read stream w streamreader
        /// returns deserliazed object.
        /// </summary>
        /// <typeparam name="T">Class model</typeparam>
        /// <param name="url">Url for the json</param>
        /// <returns>Deserialized json object.
        /// </returns>
        public T DeserializeJson<T>(string url) where T : class
        {
            try
            {
                using (var webClient = new WebClient())
                {

                    var jsonString = webClient.DownloadString(url);

                    using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(jsonString)))
                    {
                        var sr = new StreamReader(memoryStream);

                        var jsonTextReader = new JsonTextReader(sr);

                        var serializer = new JsonSerializer();

                        return serializer.Deserialize<T>(jsonTextReader);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        private async Task<String> DownloadStringAsync(string url)
        {
            var downloadedString = await new WebClient().DownloadStringTaskAsync(url);

            return downloadedString;
        }
        public async Task<T> DeserializeJsonAsync<T>(string url) where T : class
        {
            string downloadedString = await DownloadStringAsync(url);

            try
            {
                using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(downloadedString)))
                {
                    using (var sr = new StreamReader(memoryStream))
                    {
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            var serializer = new JsonSerializer();
                            var deserialize = new Task<T>(() => serializer.Deserialize<T>(jsonTextReader));
                            deserialize.Start();
                            T apiResponseObject = await deserialize;

                            return apiResponseObject;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.GetType().FullName);
                // Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
