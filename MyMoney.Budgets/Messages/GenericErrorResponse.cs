using System;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class GenericErrorResponse {
		public GenericErrorResponse(string message) {
			this.Message = message;
		}

		[JsonProperty("message")]		
		public string Message { get; set; }
	}
}