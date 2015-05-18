using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Framework.ConfigurationModel;
using MongoDB.Driver;

namespace MyMoney.Budgets.Models {
	public interface IMutationRepository: IRepository<Mutation> {
		Task<IEnumerable<Mutation>> FindByYearAndMonth(int year, int month);
	}
	
	public class MutationRepository: Repository<Mutation>, IMutationRepository {
		public MutationRepository(IConfiguration configuration): base(configuration, "mutations") {}
		
		public async Task<IEnumerable<Mutation>> FindByYearAndMonth(int year, int month) {
			return await Collection.Find(x => x.Year == year && x.Month == month).ToListAsync();
		}
	}
}