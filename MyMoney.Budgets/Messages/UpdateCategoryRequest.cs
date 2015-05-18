using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class UpdateCategoryRequest {
		[JsonPropertyAttribute("name")]
		public string Name { get; set; }
		
		[JsonPropertyAttribute("type")]
		public CategoryType Type { get; set; }
	}
}