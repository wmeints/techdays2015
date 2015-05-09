namespace MyMoney.Budgets.Messages {
	public class CreateBudgetRequest {
		public string Description { get; set; }
		public double MaxAmountAvailable { get; set; }
	}
}