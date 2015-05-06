using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class MutationData
    {
        public MutationData(DateTime date, string description, double amount)
        {
            this.Date = date;
            this.Description = description;
            this.Amount = amount;
        }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    public class FindMutationsResponse
    {
        public FindMutationsResponse(IEnumerable<MutationData> mutations)
        {
            this.Mutations = mutations;
        }

        [JsonProperty("mutations")]
        public IEnumerable<MutationData> Mutations { get; set; }
    }
}