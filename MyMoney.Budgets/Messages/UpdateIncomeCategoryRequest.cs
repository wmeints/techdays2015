using System;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class UpdateIncomeCategoryRequest {
		[JsonProperty("description")]
		public string Description { get; set; }		
	}
}