using System;
using MyMoney.Budgets.Models;
using Microsoft.Framework.ConfigurationModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyMoney.Budgets.Services
{
    public class BudgetEventPublisher : IBudgetEventPublisher, IDisposable
    {
        HttpClient client;
        string hostAddress;
        Uri hostUri;
        string keyName;
        string keyValue;

        public BudgetEventPublisher(IConfiguration configuration)
        {
            hostAddress = "https://mymoney.servicebus.windows.net/";
            hostUri = new Uri(hostAddress, UriKind.RelativeOrAbsolute);

            HttpClientHandler handler = new HttpClientHandler();
            client = new HttpClient(handler);

            client.BaseAddress = hostUri;

            this.keyName = configuration.Get("servicebus:keyName");
            this.keyValue = configuration.Get("servicebus:keyValue");
        }

        /// <summary>
        /// Posts a new mutation to the indexing request queue
        /// </summary>
        /// <param name="category">Category for which the mutation is created</param>
        /// <param name="mutation">Mutation that was created</param>
        /// <returns>Returns the task for the operation</returns>
        public async Task PublishMutation(Category category, Mutation mutation)
        {
            var messageBody = new
            {
                category = category.Name,
                amount = mutation.Amount,
                year = mutation.Year,
                month = mutation.Month,
                description = mutation.Description
            };

            var message = new HttpRequestMessage(HttpMethod.Post, "/mutations/messages");

            message.Content = new StringContent(JsonConvert.SerializeObject(messageBody));
            message.Headers.Add("Authorization", CreateSASToken(keyName, keyValue));

            //var messageContent = new StringContent(JsonConvert.SerializeObject(messageBody));
            await client.SendAsync(message);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private string CreateSASToken(string keyName, string keyValue)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(keyValue));
            TimeSpan fromEpochStart = DateTime.UtcNow - new DateTime(1970, 1, 1);

            string expiry = Convert.ToString((int)fromEpochStart.TotalSeconds + 3600);
            string stringToSign = Uri.EscapeDataString(hostAddress) + "\n" + expiry;

            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));

            string sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                Uri.EscapeDataString(hostAddress), Uri.EscapeDataString(signature), expiry, keyName);

            return sasToken;
        }
    }
}