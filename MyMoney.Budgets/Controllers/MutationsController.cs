using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Utilities;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Messages;
using MongoDB.Bson;

namespace MyMoney.Budgets.Controllers
{
    [Route("/api/mutations/{year}/{month}")]
    public class MutationsController : ControllerBase
    {
        private ICategoryRepository _categoriesRepository;
        private IMutationRepository _mutationsRepository;

        public MutationsController(ICategoryRepository categoriesRepository, IMutationRepository mutationsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _mutationsRepository = mutationsRepository;
        }
        
        [HttpGetAttribute]
        public async Task<object> FindByYearAndMonth(int year, int month) {
            return await _mutationsRepository.FindByYearAndMonth(year,month);
        }

        [HttpPostAttribute]
        public async Task<object> Create(int year, int month, [FromBodyAttribute] CreateMutationRequest request)
        {
            return await WithValidator(() => ValidateCreateRequest(year, month, request), async () =>
            {
                return await WithEntity(() => _categoriesRepository.FindById(ObjectId.Parse(request.Category)), async category =>
                {
					return await _mutationsRepository.Insert(new Mutation {
                        CategoryId = ObjectId.Parse(request.Category),
                        Amount = request.Amount,
                        Description = request.Description,
                        Year = year,
                        Month = month
                    });
                    
                    //TODO: Send the mutation to the service bus for indexing
                });
            });
        }

        private ValidationResults ValidateCreateRequest(int year, int month, CreateMutationRequest request)
        {
            ValidationResults results = new ValidationResults();
            ObjectId parsedCategoryId;

            if (year <= 0)
            {
                results.AddError("year", "The year parameter must be greater or equal to zero.");
            }

            if (month < 1 || month > 12)
            {
                results.AddError("month", "The month parameter must be between 1 and 12.");
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                results.AddError("description", "Please provide a description for your mutation");
            }

            if (!ObjectId.TryParse(request.Category, out parsedCategoryId))
            {
                results.AddError("category", "The provided category ID is invalid. Please provide a valid Object ID");
            }

            return results;
        }
    }
}