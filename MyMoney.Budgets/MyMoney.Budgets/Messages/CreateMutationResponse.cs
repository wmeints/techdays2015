using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class CreateMutationResponse
    {
        public CreateMutationResponse()
        {
            Message = "OK";
        }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}