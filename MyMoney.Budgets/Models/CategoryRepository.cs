using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Framework.ConfigurationModel;

namespace MyMoney.Budgets.Models {
	public interface ICategoryRepository: IRepository<Category> {
		Task<Category> FindById(ObjectId id);
	}
	
	public class CategoryRepository: Repository<Category>, ICategoryRepository {
		public CategoryRepository(IConfiguration configuration): base(configuration, "categories") { }
		
		public async Task<Category> FindById(ObjectId id) {
			return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
		} 	
	}
}