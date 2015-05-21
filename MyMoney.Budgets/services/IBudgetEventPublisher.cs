using MyMoney.Budgets.Models;
using System.Threading.Tasks;

namespace MyMoney.Budgets.Services {
    /// <summary>
    /// Can be used to publish mutations to the service bus
    /// </summary>
	public interface IBudgetEventPublisher {
        /// <summary>
        /// Posts a new mutation to the indexing request queue
        /// </summary>
        /// <param name="category">Category for which the mutation is created</param>
        /// <param name="mutation">Mutation that was created</param>
        /// <returns>Returns the task for the operation</returns>
		Task PublishMutation(Category category, Mutation mutation);
	}
}