using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;

namespace Catalog {
	public class Startup {
		public void Configure(IApplicationBuilder app) {
			// Enable CORS support for the frontend
			app.Use((context, next) => {
				context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
				context.Response.Headers.Add("Access-Control-Allow-Headers", new [] { "Content-Type", "Accept" });

				return next();
			});

			app.UseErrorPage();
			app.UseMvc();
			app.UseWelcomePage();
		}

		public void ConfigureServices(IServiceCollection services) {
			var configuration = new  Configuration();
			configuration.AddJsonFile("settings.json");

			services.AddMvc();

			services.AddScoped<IBookRepository>(provider => {
				var serverName = configuration.Get("Mongo:Server");
				var databaseName = configuration.Get("Mongo:Database");

				var connectionString = string.Format("mongodb://{0}/",serverName);
				return new BookRepositoryImpl(connectionString, databaseName);
			});
		}
	}
}
