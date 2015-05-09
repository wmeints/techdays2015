using System;
using MongoDB.Bson;

namespace MyMoney.Budgets.Models {
	public class Budget {
		public ObjectId Id { get; set; }
		public string Description { get; set; }
		public double MaxAmountAvailable { get; set; }
	}
}
