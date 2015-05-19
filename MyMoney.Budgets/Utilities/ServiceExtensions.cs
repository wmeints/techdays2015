using Microsoft.Framework.DependencyInjection;
using MyMoney.Budgets.Services;

namespace MyMoney.Budgets.Utilities
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IBudgetEventPublisher, BudgetEventPublisher>();
        }
    }
}