using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Domain
{
    public class Budget
    {
        public Budget()
        {

        }

        public Budget(string description, double maxAmountAvailable)
        {
            this.Description = description;
            this.MaxAmountAvailable = maxAmountAvailable;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public double MaxAmountAvailable { get; set; }
    }
}