using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Domain
{
    public class Mutation
    {
        public Mutation()
        {

        }

        public Mutation(int budgetId, DateTime date, string description, double amount)
        {
            this.BudgetId = BudgetId;
            this.Date = date;
            this.Description = description;
            this.Amount = amount;
        }

        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}