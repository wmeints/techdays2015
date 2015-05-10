using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Messages;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Utilities;

namespace MyMoney.Budgets.Controllers {
	[Route("/api/")]
	public class MutationsController: ControllerBase {
		private IBudgetRepository _budgetRepository;
		private IIncomeCategoryRepository _incomeCategoryRepository;
		private IBudgetMutationRepository _budgetMutationRepository;
		private IIncomeMutationRepository _incomeMutationRepository;
		
		public MutationsController(IBudgetRepository budgetRepository,
				IIncomeCategoryRepository incomeCategoryRepository, 
				IBudgetMutationRepository budgetMutationRepository, 
				IIncomeMutationRepository incomeMutationRepository) {
			_budgetRepository = budgetRepository;
			_incomeCategoryRepository = incomeCategoryRepository;
			_budgetMutationRepository = budgetMutationRepository;
			_incomeMutationRepository = incomeMutationRepository;
		}
		
		[HttpPost("income/categories/{id}/mutations")]
		public async Task<object> CreateIncomeMutation(string id, CreateIncomeMutationRequest request) {
			return await WithValidator(() => ValidateCreateIncomeMutation(request), async () => {
				return await WithEntity(() => _incomeCategoryRepository.FindById(id), async incomeCategory => {
					await _incomeMutationRepository.Create(new IncomeMutation() {
						IncomeCategoryId = incomeCategory.Id,
						Date = request.Date,
						Description = request.Description,
						Amount = request.Amount	
					});
					
					//TODO: Publish mutation on the service bus
						
					return Task.FromResult((object)"OK");	
				});
			});
		}
		
		[HttpPost("budget/categories/{id}/mutations")]
		public async Task<object> CreateBudgetMutation(string id, CreateBudgetMutationRequest request) {
			return await WithValidator(() => ValidateCreateBudgetMutation(request), async () => {
				return await WithEntity(() => _budgetRepository.FindById(id), async budget => {
					await _budgetMutationRepository.Create(new BudgetMutation() {
						BudgetId = budget.Id,
						Date = request.Date,
						Description = request.Description,
						Amount = request.Amount	
					});
					
					//TODO: Publish mutation on the service bus
					
					return Task.FromResult((object)"OK");	
				});
			});
		}
		
		private ValidationResults ValidateCreateBudgetMutation(CreateBudgetMutationRequest data) {
			ValidationResults results = new ValidationResults();
			
			if(string.IsNullOrWhiteSpace(data.Description)) {
				results.AddError("description","Please provide a valid description");
			}
			
			if(data.Amount == 0) {
				results.AddError("amount","Please specify an amount greater than zero.");
			}
			
			return results;
		}
		
		private ValidationResults ValidateCreateIncomeMutation(CreateIncomeMutationRequest data) {
			ValidationResults results = new ValidationResults();
			
			if(string.IsNullOrWhiteSpace(data.Description)) {
				results.AddError("description","Please provide a valid description");
			}
			
			if(data.Amount == 0) {
				results.AddError("amount","Please specify an amount greater than zero.");
			}
			
			return results;
		}
	}
}