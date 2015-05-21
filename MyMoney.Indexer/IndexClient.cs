using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyMoney.Indexer
{
    public class IndexClient
    {
        HttpClient client;

        public IndexClient(string baseAddress)
        {
            client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri(baseAddress, UriKind.RelativeOrAbsolute);
        }

        public async Task WriteAsync(string index, string type, dynamic data)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "/" + index + "/" + type);
            message.Headers.Add("Content-Type", "application/json");
            message.Headers.Add("Accept", "application/json");

            message.Content = new StringContent(JsonConvert.SerializeObject(data));

            await client.SendAsync(message);
        }
    }
}
