namespace MyMoney.Budgets.Messages {
	public class GenericErrorResponse {
		public GenericErrorResponse(string message) {
			this.Message = message;
		}
		
		public string Message { get; set; }
	}
}