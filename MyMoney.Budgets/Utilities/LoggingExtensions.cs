using Microsoft.Framework.Logging;
using Microsoft.Framework.DependencyInjection;

namespace MyMoney.Budgets.Utilities {
	public static class LoggingExtensions {
		public static void AddLoggers(this IServiceCollection services) {
			var loggingFactory = new LoggerFactory();
			
			loggingFactory.AddConsole();		
			services.AddInstance<ILoggerFactory>(loggingFactory);	
		}
	}
}