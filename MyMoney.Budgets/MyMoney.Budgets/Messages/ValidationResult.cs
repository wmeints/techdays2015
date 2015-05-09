using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Messages
{
    public class ValidationResult: Dictionary<string ,List<string>>
    {
        public void AddErrorMessage(string key, string message)
        {
            List<string> errorMessages = null;

            if(!this.TryGetValue(key, out errorMessages))
            {
                errorMessages = new List<string>();
            }

            errorMessages.Add(message);
            this[key] = errorMessages;
        }

        public bool IsValid
        {
            get { return !this.Keys.Any(); }
        }
    }
}