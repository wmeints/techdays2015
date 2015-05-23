using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyMoney.Search.Services {
	public interface ISearchClient {
		Task<List<dynamic>> Find(string query);
	}
}