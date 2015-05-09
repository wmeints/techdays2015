using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class GenericErrorResponse
    {
        public GenericErrorResponse(string message)
        {
            this.Message = message;
        }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}