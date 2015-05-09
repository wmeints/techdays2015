using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Messages;
using MyMoney.Budgets.Utilities;

namespace MyMoney.Budgets.Controllers {
	/// <summary>
	/// Manages budgets for the user
	/// </summary>
	public abstract class ControllerBase: Controller {	
		/// <summary>
		/// Retrieves an entity using the finder method and processes that entity with the processor function.
		/// When the finder returns a null reference a generic error is returned.
		/// </summary>
		protected async Task<object> WithEntity<TEntity>(Func<Task<TEntity>> finder, Func<TEntity,Task<object>> processor) {
			var entity = await finder();
			
			if (entity == null)
			{
				Context.Response.StatusCode = 404;
				return new GenericErrorResponse("Entity not found.");
			}
			
			return await processor(entity);
		}
		
		/// <summary>
		/// Validates the input using a validation method.
		/// </summary>
		/// <returns>
		/// Returns validation errors when the input is invalid. Otherwise it returns the result
		// of the processor function passed to this method.
		/// </returns>
		protected async Task<object> WithValidator(Func<ValidationResults> validator, Func<Task<object>> processor) {
			var validationResult = validator();
			
			if (!validationResult.IsValid)
			{
				Context.Response.StatusCode = 400;
				return validationResult;
			}
			
			return await processor();
		}
	}		
}