using PetaPoco;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Domain
{
    public interface IMutationRepository
    {
        Mutation Create(Mutation mutation);
        IEnumerable<Mutation> FindByBudget(int budgetId, int year, int month);
    }

    public class MutationRepository : IMutationRepository
    {
        private Database _database;

        public MutationRepository()
        {
            _database = new Database("Budgets");
        }

        public Mutation Create(Mutation mutation)
        {
            _database.Insert("Mutations", "Id", mutation);
            return mutation;
        }

        public IEnumerable<Mutation> FindByBudget(int budgetId, int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month + 1, 1).AddDays(-1);

            return _database.Query<Mutation>(Sql.Builder
                .From("Mutations")
                .Where("BudgetId = {0}", budgetId)
                .Where("Date BETWEEN {0} AND {1}", startDate.ToShortDateString(), endDate.ToShortDateString())
                .OrderByDesc("Date"));
        }
    }
}