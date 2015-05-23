using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Budgets.Models;

namespace MyMoney.Budgets.Controllers
{
    [Route("/api/state/{year}/{month}")]
    public class StateController : ControllerBase
    {
        private ICategoryRepository _categoriesRepository;
        private IMutationRepository _mutationsRepository;

        public StateController(
            ICategoryRepository categoriesRepository,
            IMutationRepository mutationsRepository)
        {
            _categoriesRepository = categoriesRepository;
            _mutationsRepository = mutationsRepository;
        }

        [HttpGetAttribute()]
        public async Task<object> FindAll(int year, int month)
        {
            var categories = await _categoriesRepository.FindAll();
            var mutations = await _mutationsRepository.FindByYearAndMonth(year, month);

            var results = new List<object>();

            foreach (var category in categories)
            {
                double totalSpend = 0;

                foreach (var mutation in mutations.Where(mutation => mutation.CategoryId == category.Id))
                {
                    totalSpend += mutation.Amount;
                }

                results.Add(new
                {
                    name = category.Name,
                    amount = totalSpend,
                    max = category.Max
                });
            }

            return results;
        }
    }
}
