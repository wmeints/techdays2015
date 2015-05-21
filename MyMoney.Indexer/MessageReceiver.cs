using Microsoft.Framework.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyMoney.Indexer
{
    public class MessageReceiver
    {
        SharedSignatureGenerator signatureGenerator;
        HttpClient client;
        string queueName;
        string baseAddress;

        public MessageReceiver(IConfiguration configuration, string baseAddress, string queueName)
        {
            this.baseAddress = baseAddress;
            this.queueName = queueName;

            client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri(baseAddress,UriKind.RelativeOrAbsolute);

            signatureGenerator = new SharedSignatureGenerator(
                configuration.Get("servicebus:keyName"),
                configuration.Get("servicebus:keyValue"));
        }

        public async Task<dynamic> ReceiveAsync()
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, "/" + queueName + "/messages/head?timeout=60");
            message.Headers.Add("Authorization", signatureGenerator.Generate(baseAddress));

            var response = await client.SendAsync(message);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(responseContent);

                return data;
            } else
            {
                throw new Exception("Failed to read message from queue");
            }
        }
    }
}
