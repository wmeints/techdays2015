using System;
using MongoDB.Bson;

namespace MyMoney.Budgets.Models {
	public class IncomeCategory {
		public ObjectId Id { get; set; }
		public string Description { get; set; }
	}
}