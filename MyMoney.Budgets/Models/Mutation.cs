using MongoDB.Bson;

namespace MyMoney.Budgets.Models
{
    public class Mutation: IPersistentEntity
    {
        public ObjectId Id { get; set; }
        public ObjectId CategoryId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}