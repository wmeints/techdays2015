using Microsoft.Framework.DependencyInjection;
using MyMoney.Search.Services;

namespace MyMoney.Search {
	public static class ServiceExtensions {
		public static void AddServices(this IServiceCollection services) {
			services.AddScoped<ISearchClient, ElasticSearchClient>();
		}		
	}
}