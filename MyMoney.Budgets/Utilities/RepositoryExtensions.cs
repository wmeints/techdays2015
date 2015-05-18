using Microsoft.Framework.DependencyInjection;
using MyMoney.Budgets.Models;

namespace MyMoney.Budgets.Utilities {
  public static class RepositoryExtensions {
    public static void AddRepositories(this IServiceCollection services) {
      services.AddScoped<ICategoryRepository,CategoryRepository>();
      services.AddScoped<IMutationRepository,MutationRepository>();
    }
  }
}
