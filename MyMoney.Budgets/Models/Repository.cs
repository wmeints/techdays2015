using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	/// <summary>
	/// Provides a basic interface definition for a repository
	/// </summary>
	public interface IRepository<TEntity> where TEntity: IPersistentEntity {
		/// <summary>
		/// Finds all entities in the collection
		/// </summary>
		Task<IEnumerable<TEntity>> FindAll();
		
		/// <summary>
		/// Inserts a new entity in the collection
		/// </summary>
		Task<TEntity> Insert(TEntity entity);
		
		/// <summary>
		/// Updates an existing entity in the collection
		/// </summary>
		Task<TEntity> Update(TEntity entity);
		
		/// <summary>
		/// Removes an existing entity from the collection
		/// </summary>
		Task Remove(TEntity entity);
	}
	
	/// <summary>
	/// Provides a basic implementation for a repository
	/// </summary>
	public class Repository<TEntity>: IRepository<TEntity> where TEntity: IPersistentEntity {
		private IMongoCollection<TEntity> _collection;
		
		/// <summary>
		/// Initializes a new instance of Repository
		/// </summary>
		public Repository(IConfiguration configuration, string collectionName) {
			var hostName = configuration.Get("database:hostName");
			var databaseName = configuration.Get("database:name");

			var mongoClient = new MongoClient(string.Format("mongodb://{0}/{1}", hostName, databaseName));
			var database = mongoClient.GetDatabase(databaseName);

			_collection = database.GetCollection<TEntity>(collectionName);		
		}
		
		/// <summary>
		/// Provides access to the collection for various operations
		/// </summary>
		protected IMongoCollection<TEntity> Collection { get { return _collection; } }
		
		/// <summary>
		/// Finds all entities in the collection
		/// </summary>
		public async Task<IEnumerable<TEntity>> FindAll() {
			return await _collection.Find(x => true).ToListAsync();
		}
		
		/// <summary>
		/// Inserts a new entity in the collection
		/// </summary>
		public async Task<TEntity> Insert(TEntity entity) {
			await _collection.InsertOneAsync(entity);
			return entity;
		}
		
		/// <summary>
		/// Updates an existing entity in the collection
		/// </summary>
		public async Task<TEntity> Update(TEntity entity) {
			await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
			return entity;	
		}
		
		/// <summary>
		/// Removes an existing entity from the collection
		/// </summary>
		public async Task Remove(TEntity entity) {
			await _collection.DeleteOneAsync(x => x.Id == entity.Id);
		}
	}
}