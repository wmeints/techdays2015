using System;
using MongoDB.Bson;

namespace MyMoney.Budgets.Models {
	public class IncomeMutation {
		public ObjectId Id { get; set; }
		public Object IncomeCategoryId { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public double Amount { get; set; }
	}
}