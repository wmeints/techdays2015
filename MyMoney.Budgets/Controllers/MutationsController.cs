using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Utilities;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Messages;
using MongoDB.Bson;
using MyMoney.Budgets.Services;

namespace MyMoney.Budgets.Controllers
{
    [Route("/api/mutations/{year}/{month}")]
    public class MutationsController : ControllerBase
    {
        private ICategoryRepository _categoriesRepository;
        private IMutationRepository _mutationsRepository;
        private IBudgetEventPublisher _budgetEventPublisher;

        public MutationsController(
            ICategoryRepository categoriesRepository,
            IMutationRepository mutationsRepository,
            IBudgetEventPublisher budgetEventPublisher)
        {
            _categoriesRepository = categoriesRepository;
            _mutationsRepository = mutationsRepository;
            _budgetEventPublisher = budgetEventPublisher;
        }

        [HttpGetAttribute]
        public async Task<object> FindByYearAndMonth(int year, int month)
        {
            var results = await _mutationsRepository.FindByYearAndMonth(year, month);
            return results.Select(mutation => new
            {
                id = mutation.Id,
                amount = mutation.Amount,
                category = mutation.CategoryId,
                description = mutation.Description,
                year = mutation.Year,
                month = mutation.Month
            });
        }

        [HttpPostAttribute]
        public async Task<object> Create(int year, int month, [FromBodyAttribute] CreateMutationRequest request)
        {
            return await WithValidator(() => ValidateCreateRequest(year, month, request), async () =>
            {
                return await WithEntity(() => _categoriesRepository.FindById(ObjectId.Parse(request.Category)), async category =>
                {
                    var insertedMutation = await _mutationsRepository.Insert(new Mutation
                    {
                        CategoryId = ObjectId.Parse(request.Category),
                        Amount = request.Amount,
                        Description = request.Description,
                        Year = year,
                        Month = month
                    });

                    // Publish the mutation towards the service bus
                    await _budgetEventPublisher.PublishMutation(category, insertedMutation);

                    return insertedMutation;
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
