using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace MyMoney.Search {
	public static class ConfigurationExtensions {
		public static void AddConfiguration(this IServiceCollection services) {
			Configuration configuration = new Configuration();
			
			configuration.AddJsonFile("config.json");
			configuration.AddEnvironmentVariables();
			
			services.AddInstance<IConfiguration>(configuration);
		}		
	}
}