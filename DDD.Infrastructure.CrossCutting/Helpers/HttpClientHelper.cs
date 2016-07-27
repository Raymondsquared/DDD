using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class HttpClientHelper
    {
        public static T Get<T>(string URL)
        {
            var obj = default(T);

            using (var client = new HttpClient())
            {
                var result = client.GetAsync(URL).Result;

                if (result.IsSuccessStatusCode)
                {
                    obj = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);
                }
            }

            return obj;
        }
        public static HttpResponseMessage Post(string url, string jsonInput)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonInput, Encoding.UTF8, "application/json");

                return client.PostAsync(url, content).Result;
            }
        }
    }
}
