using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace MyMoney.Search
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddConfiguration();
            services.AddServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Inject custom middleware to work around a bug with the CORS module giving
            // the wrong response (HTTP 204) when invoked with the OPTIONS method.
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type, Accept" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "DELETE, PUT, GET, POST" });

                if(context.Request.Method == "OPTIONS") {
                    context.Response.StatusCode = 200;
                    return;
                }

                await next();
            });

            app.UseErrorPage();
            app.UseMvc();
        }
    }
}
