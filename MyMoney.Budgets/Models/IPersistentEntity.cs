using MongoDB.Bson;

namespace MyMoney.Budgets.Models {
	public interface IPersistentEntity {
		ObjectId Id { get; set; }
	}
}