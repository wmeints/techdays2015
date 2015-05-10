using System;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class IncomeCategoryData {
		public IncomeCategoryData(string id, string description) {
			this.Id = id;
			this.Description = description;	
		}
		
		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}