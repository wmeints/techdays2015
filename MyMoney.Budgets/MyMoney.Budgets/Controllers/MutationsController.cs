using MyMoney.Budgets.Domain;
using MyMoney.Budgets.Messages;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyMoney.Budgets.Controllers
{
    [RoutePrefix("api/budgets/{id}/mutations")]
    public class MutationsController : ControllerBase
    {
        private IBudgetRepository _budgetRepository;
        private IMutationRepository _mutationRepository;

        [Route("{year}/{month}")]
        [ResponseType(typeof(FindMutationsResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Budget not found",Type = typeof(GenericErrorResponse))]
        public HttpResponseMessage Get(int id, int year, int month)
        {
            return WithEntity(() => _budgetRepository.FindById(id), budget =>
            {
                var result = _mutationRepository
                    .FindByBudget(id, year, month)
                    .Select(m => new MutationData(m.Date, m.Description, m.Amount));

                return Request.CreateResponse(HttpStatusCode.OK,
                    new FindMutationsResponse(result));
            });
        }

        /// <summary>
        /// Stores a new mutation for a specific budget
        /// </summary>
        /// <param name="id">ID of the budget</param>
        /// <param name="data">Mutation data</param>
        /// <returns></returns>
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Mutation stored", Type = typeof(CreateMutationResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Budget not found", Type = typeof(GenericErrorResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Validation error", Type = typeof(ValidationErrorResponse))]
        public HttpResponseMessage Post(int id, [FromBody] CreateMutationRequest data)
        {
            return WithValidator(() => ValidateRequest(data), () =>
            {
                return WithEntity(() => _budgetRepository.FindById(id), budget =>
                {
                    _mutationRepository.Create(new Mutation(id, data.Date, data.Description, data.Amount));
                    return Request.CreateResponse(new CreateMutationResponse());
                });
            });
        }

        private ValidationResult ValidateRequest(CreateMutationRequest request)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                result.AddErrorMessage("description", "Please specify a valid description");
            }

            if (request.Amount == 0.0)
            {
                result.AddErrorMessage("amount", "Please specify a postive or negative amount.");
            }

            return result;
        }
    }
}