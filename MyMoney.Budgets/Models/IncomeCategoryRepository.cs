using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	public interface IIncomeCategoryRepository {
		Task<IncomeCategory> FindById(string id);
		Task<IEnumerable<IncomeCategory>> FindAll();
		Task<IncomeCategory> Create(IncomeCategory incomeCategory);
		Task<IncomeCategory> Update(IncomeCategory incomeCategory);
		Task Delete(IncomeCategory incomeCategory);		
	}
	
	public class IncomeCategoryRepository: IIncomeCategoryRepository {
		private IMongoCollection<IncomeCategory> _collection;
		
		public IncomeCategoryRepository(IConfiguration configuration) {
			var hostName = configuration.Get("database:hostName");
			var databaseName = configuration.Get("database:name");

			var mongoClient = new MongoClient(string.Format("mongodb://{0}/{1}", hostName, databaseName));
			var database = mongoClient.GetDatabase(databaseName);

			_collection = database.GetCollection<IncomeCategory>("IncomeCategories");
		}
		
		public async Task<IncomeCategory> FindById(string id) {
			return await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
		}
		
		public async Task<IEnumerable<IncomeCategory>> FindAll() {
			return await _collection.Find(x => true).ToListAsync();
		}
		
		public async Task<IncomeCategory> Create(IncomeCategory incomeCategory) {
			await _collection.InsertOneAsync(incomeCategory);
			return incomeCategory;
		}
		
		public async Task<IncomeCategory> Update(IncomeCategory incomeCategory) {
			await _collection.ReplaceOneAsync(x => x.Id == incomeCategory.Id, incomeCategory);
			return incomeCategory;
		}
		
		public async Task Delete(IncomeCategory incomeCategory) {
			await _collection.DeleteOneAsync(x => x.Id == incomeCategory.Id);
		}
	}
}