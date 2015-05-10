using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	public interface IBudgetMutationRepository {
		Task<BudgetMutation> Create(BudgetMutation mutation);
	}	
	
	public class BudgetMutationRepository: IBudgetMutationRepository {
		private IMongoCollection<BudgetMutation> _collection;
		
		public BudgetMutationRepository(IConfiguration configuration) {
			var hostName = configuration.Get("database:hostName");
			var databaseName = configuration.Get("database:name");

			var mongoClient = new MongoClient(string.Format("mongodb://{0}/{1}", hostName, databaseName));
			var database = mongoClient.GetDatabase(databaseName);

			_collection = database.GetCollection<BudgetMutation>("BudgetMutations");
		}
		
		public async Task<BudgetMutation> Create(BudgetMutation mutation) {
			await _collection.InsertOneAsync(mutation);
			return mutation;
		}
	}
}