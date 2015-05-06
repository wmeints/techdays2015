using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyMoney.Budgets.Messages;
using System.Web.Http.Description;
using Swashbuckle.Swagger.Annotations;
using MyMoney.Budgets.Domain;

namespace MyMoney.Budgets.Controllers
{
    /// <summary>
    /// Manage budgets
    /// </summary>
    [RoutePrefix("api/budgets")]
    public class BudgetsController : ControllerBase
    {
        private IBudgetRepository _budgetRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="BudgetsController"/>
        /// </summary>
        /// <param name="budgetRepository"></param>
        public BudgetsController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        /// <summary>
        /// Finds a single budget
        /// </summary>
        /// <param name="id">ID of the budget</param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(FindBudgetResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Budget not found", Type = typeof(GenericErrorResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Validation error", Type = typeof(ValidationErrorResponse))]
        public HttpResponseMessage Get(int id)
        {
            return WithEntity(() => _budgetRepository.FindById(id), budget =>
            {
                var result = new FindBudgetResponse(budget.Id, budget.Description, budget.MaxAmountAvailable);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            });
        }

        /// <summary>
        /// Creates a new budget
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Budget created", Type = typeof(CreateBudgetResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Validation error", Type = typeof(ValidationErrorResponse))]
        public HttpResponseMessage Post([FromBody] CreateBudgetRequest data)
        {
            return WithValidator(() => ValidateCreateRequest(data), () =>
            {
                var createdBudget = _budgetRepository.Create(new Budget(data.Description, data.MaxAmountAvailable));

                return Request.CreateResponse(HttpStatusCode.Created, new CreateBudgetResponse(createdBudget.Id, 
                    createdBudget.Description, createdBudget.MaxAmountAvailable));
            });
        }

        /// <summary>
        /// Updates an existing budget
        /// </summary>
        /// <param name="id">ID of the budget</param>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(UpdateBudgetResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Budget not found", Type = typeof(GenericErrorResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Validation error", Type = typeof(ValidationErrorResponse))]
        public HttpResponseMessage Put(int id, [FromBody] UpdateBudgetRequest data)
        {
            return WithValidator(() => ValidateUpdateRequest(data), () =>
            {
                return WithEntity(() => _budgetRepository.FindById(id), budget =>
                {
                    budget.Description = data.Description;
                    budget.MaxAmountAvailable = data.MaxAmountAvailable;

                    var updatedBudget = _budgetRepository.Update(budget);

                    var result = new UpdateBudgetResponse(updatedBudget.Id,
                        updatedBudget.Description, updatedBudget.MaxAmountAvailable);

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                });
            });
        }

        /// <summary>
        /// Removes a budget
        /// </summary>
        /// <param name="id">ID of the budget</param>
        /// <returns></returns>
        [Route("{id}")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Budget removed", Type = null)]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Budget not found", Type = typeof(GenericErrorResponse))]
        public HttpResponseMessage Delete(int id)
        {
            return WithEntity(() => _budgetRepository.FindById(id), budget =>
            {
                _budgetRepository.Remove(budget);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            });
        }

        private ValidationResult ValidateCreateRequest(CreateBudgetRequest request)
        {
            var result = new ValidationResult();

            if(string.IsNullOrWhiteSpace(request.Description))
            {
                result.AddErrorMessage("description", "Please specify a description.");
            }

            if(request.MaxAmountAvailable < 0)
            {
                result.AddErrorMessage("maxAmountAvailable", "Please specify a max amount of zero or more");
            }

            return result;
        }

        private ValidationResult ValidateUpdateRequest(UpdateBudgetRequest request)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                result.AddErrorMessage("description", "Please specify a description.");
            }

            if (request.MaxAmountAvailable < 0)
            {
                result.AddErrorMessage("maxAmountAvailable", "Please specify a max amount of zero or more");
            }

            return result;
        }
    }
}