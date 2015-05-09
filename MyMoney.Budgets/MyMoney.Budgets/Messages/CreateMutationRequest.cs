using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class CreateMutationRequest
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}