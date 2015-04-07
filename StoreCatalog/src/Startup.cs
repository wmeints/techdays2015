using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;

namespace Catalog {
	public class Startup {
		public void Configure(IApplicationBuilder app) {
			app.UseErrorPage();
			app.UseMvc();
			app.UseWelcomePage();
		}

		public void ConfigureServices(IServiceCollection services) {
			var configuration = new  Configuration();
			configuration.AddJsonFile("settings.json");

			services.AddMvc();

			// When asked for a IBookRepository,
			// return a new book repository based on the mongo connection settings.
			services.AddScoped<IBookRepository>(provider => {
				var serverName = configuration.Get("Mongo:Server");
				var databaseName = configuration.Get("Mongo:Database");

				var connectionString = string.Format("mongodb://{0}/",serverName);
				return new BookRepositoryImpl(connectionString, databaseName);
			});
		}
	}
}
