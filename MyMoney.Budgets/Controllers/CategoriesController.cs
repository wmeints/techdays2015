using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Models;
using MyMoney.Budgets.Utilities;
using MyMoney.Budgets.Messages;
using MongoDB.Bson;

namespace MyMoney.Budgets.Controllers
{

    [RouteAttribute("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoriesRepository;

        public CategoriesController(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGetAttribute]
        public async Task<object> FindAll()
        {
            return await _categoriesRepository.FindAll();
        }

        [HttpGetAttribute("{id}")]
        public async Task<object> FindById(string id)
        {
            return await WithValidator(() => ValidateFindByIdRequest(id), async () =>
            {
                return await WithEntity(() => _categoriesRepository.FindById(ObjectId.Parse(id)), category =>
                {
                    return Task.FromResult((object)category);
                });
            });
        }

        [HttpPostAttribute()]
        public async Task<object> Create([FromBodyAttribute] CreateCategoryRequest request)
        {
            return await WithValidator(() => ValidateCreateRequest(request), async () =>
            {
                return await _categoriesRepository.Insert(new Category
                {
                    Name = request.Name,
                    Type = (int)request.Type
                });
            });
        }

        [HttpPutAttribute("{id}")]
        public async Task<object> Update(string id, [FromBodyAttribute] UpdateCategoryRequest request)
        {
            return await WithValidator(() => ValidateUpdateRequest(id, request), async () =>
            {
                return await WithEntity(() => _categoriesRepository.FindById(ObjectId.Parse(id)), async category =>
                {
                    category.Name = request.Name;
                    category.Type = (int)request.Type;

                    return await _categoriesRepository.Update(category);
                });
            });
        }

        [HttpDeleteAttribute("{id}")]
        public async Task<object> Delete(string id)
        {
            return await WithValidator(() => ValidateDeleteRequest(id), async () =>
            {
                return await WithEntity(() => _categoriesRepository.FindById(ObjectId.Parse(id)), async category =>
                {
                    await _categoriesRepository.Remove(category);
                    Response.StatusCode = 204;

                    return null;
                });
            });
        }

        private ValidationResults ValidateDeleteRequest(string id)
        {
            ValidationResults results = new ValidationResults();
            ObjectId parsedId;

            if (!ObjectId.TryParse(id, out parsedId))
            {
                results.AddError("id", "ID could not be parsed as a " +
                    "valid ObjectID. Please supply a valid ID");
            }

            return results;
        }

        private ValidationResults ValidateUpdateRequest(string id, UpdateCategoryRequest request)
        {
            ValidationResults results = new ValidationResults();
            ObjectId parsedId;

            if (!ObjectId.TryParse(id, out parsedId))
            {
                results.AddError("id", "ID could not be parsed as a " +
                    "valid ObjectID. Please supply a valid ID");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                results.AddError("description", "The provided description is empty." +
                    "Please provide a valid description");
            }

            return results;
        }

        private ValidationResults ValidateCreateRequest(CreateCategoryRequest request)
        {
            ValidationResults results = new ValidationResults();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                results.AddError("description", "The provided description is empty." +
                    "Please provide a valid description");
            }

            return results;
        }

        private ValidationResults ValidateFindByIdRequest(string id)
        {
            ValidationResults results = new ValidationResults();
            ObjectId parsedId;

            if (!ObjectId.TryParse(id, out parsedId))
            {
                results.AddError("id", "ID could not be parsed as a " +
                    "valid ObjectID. Please supply a valid ID");
            }

            return results;
        }
    }
}