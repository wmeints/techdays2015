using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class UpdateBudgetRequest
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maxAmountAvailable")]
        public double MaxAmountAvailable { get; set; }
    }
}