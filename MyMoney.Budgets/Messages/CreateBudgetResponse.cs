using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class CreateBudgetResponse {
		public CreateBudgetResponse(string id, string description, double maxAmountAvailable) {
			this.Id = id;
			this.Description = description;
			this.MaxAmountAvailable = maxAmountAvailable;
		}
				
		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("description")]
		public string Description { get; set; }
		
		[JsonProperty("maxAmountAvailable")]
		public double MaxAmountAvailable { get; set; }		
	}
}