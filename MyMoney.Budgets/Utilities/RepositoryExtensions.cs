using System;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using MyMoney.Budgets.Models;

namespace MyMoney.Budgets.Utilities {
  public static class RepositoryExtensions {
    public static void AddRepositories(this IServiceCollection services) {
      services.AddScoped<IBudgetRepository,BudgetRepository>();
      services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
      services.AddScoped<IBudgetMutationRepository, BudgetMutationRepository>();
      services.AddScoped<IIncomeMutationRepository, IncomeMutationRepository>();
    }
  }
}
