using System;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class CreateIncomeCategoryRequest {
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}