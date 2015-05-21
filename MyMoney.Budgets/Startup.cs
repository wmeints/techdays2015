using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using MyMoney.Budgets.Utilities;

namespace MyMoney.Budgets
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddConfiguration();
            services.AddRepositories();
            services.AddApplicationServices();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(policy => policy.WithOrigins("*"));
            app.UseErrorPage();
            app.UseMvc();
        }
    }
}
