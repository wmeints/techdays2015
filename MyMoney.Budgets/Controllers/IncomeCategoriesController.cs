using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using MyMoney.Budgets.Messages;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Utilities;

namespace MyMoney.Budgets.Controllers {
	[Route("/api/income/categories")]
	public class IncomeCategoriesController: ControllerBase {
		private IIncomeCategoryRepository _incomeCategoryRepository;
		
		public IncomeCategoriesController(IIncomeCategoryRepository incomeCategoryRepository) {
			_incomeCategoryRepository = incomeCategoryRepository;
		}
		
		[HttpGet("")]
		public async Task<object> FindAll() { 
			var categories = await _incomeCategoryRepository.FindAll();
			return categories.Select(category => new IncomeCategoryData(
				category.Id.ToString(),category.Description));
		}
		
		[HttpGet("{id}")]
		public async Task<object> FindById(string id) {
			return await WithValidator(() => ValidateFindByIdRequest(id), async () => {
				return await WithEntity(() => _incomeCategoryRepository.FindById(id), incomeCategory => {
					return Task.FromResult((object)new IncomeCategoryData(
						incomeCategory.Id.ToString(), incomeCategory.Description));
				});
			});		
		}
		
		[HttpPost("")]
		public async Task<object> Create([FromBody] CreateIncomeCategoryRequest request) {
			return await WithValidator(() => ValidateCreateIncomeCategoryRequest(request), async () => {
				var createdCategory = await _incomeCategoryRepository.Create(new IncomeCategory {
					Description = request.Description
				});
				
				return new IncomeCategoryData(createdCategory.Id.ToString(), createdCategory.Description);
			});
		}		
		
		[HttpPut("{id}")]
		public async Task<object> Update(string id, [FromBody] UpdateIncomeCategoryRequest request) {
			return await WithValidator(() => ValidateUpdateIncomeCategoryRequest(id, request), async () => {
				return await WithEntity(() => _incomeCategoryRepository.FindById(id), async incomeCategory => {
					incomeCategory.Description = request.Description;
					
					var updatedCategory = await _incomeCategoryRepository.Update(incomeCategory);
					
					return new IncomeCategoryData(updatedCategory.Id.ToString(), updatedCategory.Description);	
				});
			});
		}
		
		[HttpDelete("{id}")]
		public async Task<object> Delete(string id) {
			return await WithValidator(() => ValidateDeleteIncomeCategoryRequest(id), async () => {
				return await WithEntity(() => _incomeCategoryRepository.FindById(id), async incomeCategory => {
					await _incomeCategoryRepository.Delete(incomeCategory);
					Response.StatusCode = 204;
					
					return null;	
				});	
			});
		}
		
		private ValidationResults ValidateFindByIdRequest(string id) {
			ValidationResults results = new ValidationResults();
			ObjectId identifier;
			
			if(!ObjectId.TryParse(id, out identifier)) {
				results.AddError("","Specified identifier is invalid");
			}
			
			return results;
		}
		
		private ValidationResults ValidateCreateIncomeCategoryRequest(CreateIncomeCategoryRequest request) {
			ValidationResults results = new ValidationResults();
			
			if(string.IsNullOrWhiteSpace(request.Description)) {
				results.AddError("description","Please provide a valid description.");
			}
			
			return results;
		}
		
		private ValidationResults ValidateUpdateIncomeCategoryRequest(string id, UpdateIncomeCategoryRequest request) {
			ValidationResults results = new ValidationResults();
			ObjectId identifier;
			
			if(!ObjectId.TryParse(id, out identifier)) {
				results.AddError("","Specified identifier is invalid");
			}
			
			if(string.IsNullOrWhiteSpace(request.Description)) {
				results.AddError("description","Please provide a valid description.");
			}
			
			return results;
		}
		
		private ValidationResults ValidateDeleteIncomeCategoryRequest(string id) {
			ValidationResults results = new ValidationResults();
			ObjectId identifier;
			
			if(!ObjectId.TryParse(id, out identifier)) {
				results.AddError("","Specified identifier is invalid");
			}
			
			return results;
		}
	}
}