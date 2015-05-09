using System.Collections.Generic;

namespace MyMoney.Budgets.Utilities {
	/// <summary>
	/// Contains all the validation errors of a validation method
	/// </summary>
	public class ValidationResults: Dictionary<string, List<string>> {
		/// <summary>
		/// Adds a new error message
		/// </summary>
		/// <param name="key">The key for which to register the error</param>
		/// <param name="message">The message to add</param>
		public void AddError(string key, string message) {
			List<string> errorMessages = null;
			
			if(!this.TryGetValue(key, out errorMessages)) {
				errorMessages = new List<string>();
			}
			
			errorMessages.Add(message);
			
			this[key] = errorMessages;
		}		
		
		/// <summary>
		/// Gets whether this instance has any errors
		/// </summary>
		public bool IsValid { get { return this.Count == 0; } }
	}
}