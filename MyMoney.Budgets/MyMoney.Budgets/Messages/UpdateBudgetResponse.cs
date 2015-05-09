﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class UpdateBudgetResponse
    {
        public UpdateBudgetResponse(int id, string description, double maxAmountAvailable)
        {
            this.Id = id;
            this.Description = description;
            this.MaxAmountAvailable = maxAmountAvailable;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maxAmountAvailable")]
        public double MaxAmountAvailable { get; set; }
    }
}