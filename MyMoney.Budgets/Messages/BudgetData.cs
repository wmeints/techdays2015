namespace MyMoney.Budgets.Messages {
	public class BudgetData {
		
		public BudgetData(string id, string description, double maxAmountAvailable) {
			this.Id = id;
			this.Description = description;
			this.MaxAmountAvailable = maxAmountAvailable;
		}
		
		public string Id { get; set; }
		public string Description { get; set; }
		public double MaxAmountAvailable { get; set; }
	}
}