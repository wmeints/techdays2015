using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class UpdateCategoryRequest {
		[JsonPropertyAttribute("name")]
		public string Name { get; set; }
				
		[JsonPropertyAttribute("max")]
		public double Max { get; set; }
	}
}