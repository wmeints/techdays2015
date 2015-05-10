using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using MyMoney.Budgets.Messages;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Utilities;
using MongoDB.Bson;

namespace MyMoney.Budgets.Controllers {
	/// <summary>
	/// Manages budgets for the user
	/// </summary>
	[Route("api/budget/categories")]
	public class BudgetsController: ControllerBase {
		private IBudgetRepository _budgetRepository;
		private ILogger _logger;

		public BudgetsController(IBudgetRepository budgetRepository, ILoggerFactory loggerFactory) {
			_budgetRepository = budgetRepository;
			_logger = loggerFactory.CreateLogger(typeof(BudgetsController).Name);
		}

		[HttpGet]
		public async Task<object> FindAll() {
			return await _budgetRepository.FindAll();
		}

		[HttpGet("{id}")]
		public Task<object> FindById(string id) {
			return WithValidator(() => ValidateFindBudgetRequest(id), async () => {
				return await WithEntity(() => _budgetRepository.FindById(id), budget => {
					var response = new BudgetData(budget.Id.ToString(), budget.Description, budget.MaxAmountAvailable);
					return Task.FromResult((object)response);
				});
			});
		}

		[HttpPut("{id}")]
		public async Task<object> Update(string id, [FromBody] UpdateBudgetRequest request) {
			return WithValidator(() => ValidateUpdateRequest(id, request), async () => {
				return await WithEntity(() => _budgetRepository.FindById(id), async budget => {
					budget.Description = request.Description;
					budget.MaxAmountAvailable = request.MaxAmountAvailable;

					var updatedBudget = await _budgetRepository.Update(budget);
					
					return new BudgetData(updatedBudget.Id.ToString(), 
						updatedBudget.Description, updatedBudget.MaxAmountAvailable);
				});
			});
		}

		[HttpPost("")]
		public async Task<object> Create([FromBody] CreateBudgetRequest request) {
			_logger.LogInformation("Received create request");

			return await WithValidator(() => ValidateCreateRequest(request), async () => {
				var createdBudget = await _budgetRepository.Create(new Budget {
					Description = request.Description,
					MaxAmountAvailable = request.MaxAmountAvailable
				});

				return new CreateBudgetResponse(createdBudget.Id.ToString(),
						createdBudget.Description,createdBudget.MaxAmountAvailable);
			});
		}

		[HttpDelete("{id}")]
		public async Task<object> Remove(string id) {
			return await WithValidator(() => ValidateDeleteRequest(id), async () => {
				return await WithEntity(() => _budgetRepository.FindById(id), async budget => {
					await _budgetRepository.Remove(budget);

					Context.Response.StatusCode = 204;
					return null;
				});
			});
		}

		private ValidationResults ValidateDeleteRequest(string id) {
			var validationResults = new ValidationResults();
			ObjectId objectId;

			if (!ObjectId.TryParse(id, out objectId))
			{
				validationResults.AddError("","The identifier part of the URL is invalid.");
			}

			return validationResults;
		}

		private ValidationResults ValidateCreateRequest(CreateBudgetRequest request) {
			var validationResults = new ValidationResults();

			if (string.IsNullOrWhiteSpace(request.Description))
			{
				validationResults.AddError("description","Please specify a valid description");
			}

			if (request.MaxAmountAvailable < 0)
			{
				validationResults.AddError("maxAmountAvailable","Please specify a max amount available of zero or greater");
			}

			return validationResults;
		}

		private ValidationResults ValidateUpdateRequest(string id, UpdateBudgetRequest request) {
			var validationResults = new ValidationResults();
			ObjectId objectId;

			if (!ObjectId.TryParse(id, out objectId))
			{
				validationResults.AddError("","The identifier part of the URL is invalid.");
			}

			if (string.IsNullOrWhiteSpace(request.Description))
			{
				validationResults.AddError("description","Please specify a valid description");
			}

			if (request.MaxAmountAvailable < 0)
			{
				validationResults.AddError("maxAmountAvailable","Please specify a max amount available of zero or greater");
			}

			return validationResults;
		}

		private ValidationResults ValidateFindBudgetRequest(string id) {
			ObjectId identifier;
			var validationResults = new ValidationResults();
			
			if (!ObjectId.TryParse(id, out identifier))
			{
				validationResults.AddError("","The specified identifier is invalid.");
			}
			
			return validationResults;
		}
	}
}
