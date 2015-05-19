using MyMoney.Budgets.Models;

namespace MyMoney.Budgets.Services {
	public interface IBudgetEventPublisher {
		void PublishMutation(Category category, Mutation mutation);
	}
}