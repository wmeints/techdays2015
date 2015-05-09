using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class UpdateBudgetRequest {
		
		[JsonProperty("description")]
		public string Description { get; set; }
		
		[JsonProperty("maxAmountAvailable")]
		public double MaxAmountAvailable { get; set; }
	}
}