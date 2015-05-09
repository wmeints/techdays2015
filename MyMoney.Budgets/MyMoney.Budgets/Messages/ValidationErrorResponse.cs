using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class ValidationErrorResponse
    {
        public ValidationErrorResponse()
        {
            Message = "Validation of the request failed.";
            Errors = new ValidationResult();
        }

        public ValidationErrorResponse(ValidationResult result)
        {
            this.Message = "Validation of the request failed.";
            this.Errors = result;
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}