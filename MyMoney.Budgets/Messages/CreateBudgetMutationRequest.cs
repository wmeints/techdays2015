using System;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class CreateBudgetMutationRequest {
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		
		[JsonProperty("description")]
		public string Description { get; set; }
		
		[JsonProperty("amount")]
		public double Amount { get; set; }	
	}
}