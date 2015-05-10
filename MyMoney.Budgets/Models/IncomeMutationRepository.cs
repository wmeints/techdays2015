using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	public interface IIncomeMutationRepository {
		Task<IncomeMutation> Create(IncomeMutation mutation);		
	}
	
	public class IncomeMutationRepository: IIncomeMutationRepository {
		private IMongoCollection<IncomeMutation> _collection;
		
		public IncomeMutationRepository(IConfiguration configuration) {
			var hostName = configuration.Get("database:hostName");
			var databaseName = configuration.Get("database:name");

			var mongoClient = new MongoClient(string.Format("mongodb://{0}/{1}", hostName, databaseName));
			var database = mongoClient.GetDatabase(databaseName);

			_collection = database.GetCollection<IncomeMutation>("IncomeMutations");
		}
		
		public async Task<IncomeMutation> Create(IncomeMutation mutation) {
			await _collection.InsertOneAsync(mutation);
			return mutation;
		}
	}
}