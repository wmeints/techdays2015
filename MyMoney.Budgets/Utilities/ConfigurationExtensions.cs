using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Utilities {
  public static class ConfigurationExtensions {
    public static void AddConfiguration(this IServiceCollection services) {
      var configuration = new Configuration();
      configuration.AddJsonFile("config.json");

      services.AddInstance<IConfiguration>(configuration);
    }
  }
}
