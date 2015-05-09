using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	public interface IBudgetRepository {
		Task<Budget> FindById(String id);
		Task<IEnumerable<Budget>> FindAll();
		Task<Budget> Update(Budget budget);
		Task<Budget> Create(Budget budget);
		Task Remove(Budget budget);
	}

	public class BudgetRepository: IBudgetRepository {
		IMongoCollection<Budget> _collection;

		public BudgetRepository(IConfiguration configuration) {
			var hostName = configuration.Get("database:hostName");
			var databaseName = configuration.Get("database:name");

			var mongoClient = new MongoClient(string.Format("mongodb://{0}/{1}", hostName, databaseName));
			var database = mongoClient.GetDatabase(databaseName);

			_collection = database.GetCollection<Budget>("Budgets");
		}

		public async Task<Budget> FindById(String id) {
			return await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Budget>> FindAll() {
			return await _collection.Find(x => true).ToListAsync();
		}

		public async Task<Budget> Create(Budget budget) {
			await _collection.InsertOneAsync(budget);
			return budget;
		}

		public async Task<Budget> Update(Budget budget) {
			return await _collection.FindOneAndReplaceAsync(x => x.Id == budget.Id, budget);
		}

		public async Task Remove(Budget budget) {
			await _collection.DeleteOneAsync(x => x.Id == budget.Id);
		}
	}
}
