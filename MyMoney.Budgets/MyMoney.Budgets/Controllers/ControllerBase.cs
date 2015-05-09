using MyMoney.Budgets.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyMoney.Budgets.Controllers
{
    public class ControllerBase: ApiController
    {
        protected HttpResponseMessage WithEntity<TEntity>(Func<TEntity> finder, Func<TEntity, HttpResponseMessage> processor)
        {
            var result = finder();

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new GenericErrorResponse("Specified entity not found"));
            }

            return processor(result);
        }

        protected HttpResponseMessage WithValidator(Func<ValidationResult> validator, Func<HttpResponseMessage> processor)
        {
            var validationResults = validator();

            if (!validationResults.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new ValidationErrorResponse(validationResults));
            }

            return processor();
        }
    }
}