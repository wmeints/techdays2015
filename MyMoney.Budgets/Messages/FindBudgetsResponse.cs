using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Messages {
	public class FindBudgetsResponse {
		
		public FindBudgetsResponse(IEnumerable<BudgetData> budgets) {
			this.Budgets = budgets;
		}
		
		[JsonProperty("budgets")]
		public IEnumerable<BudgetData> Budgets { get; }
	}
}