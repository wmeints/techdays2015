using MongoDB.Bson;

namespace MyMoney.Budgets.Models {
	public class Category: IPersistentEntity {
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public double Max { get; set; }
	}
}
