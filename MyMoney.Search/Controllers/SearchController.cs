using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMoney.Search.Services;

namespace MyMoney.Search.Controllers {
	[RouteAttribute("/api/search")]
	public class SearchController: Controller {
		private ISearchClient _searchClient;
		
		public SearchController(ISearchClient searchClient) {
			_searchClient = searchClient;
		}
		
		[HttpGetAttribute]
		public async Task<object> FindByQuery(string q) {
			return await _searchClient.Find(q);
		}
	}
}