using PetaPoco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyMoney.Budgets.Domain
{
    public interface IBudgetRepository
    {
        Budget FindById(int id);
        Budget Create(Budget budget);
        Budget Update(Budget budget);
        void Remove(Budget budget);
    }

    public class BudgetRepository : IBudgetRepository
    {
        private Database _database;

        public BudgetRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Budgets"].ConnectionString;
            _database = new Database(connectionString);
        }

        public Budget Create(Budget budget)
        {
            _database.Insert("Budgets", "Id", budget);
            return budget;
        }

        public Budget FindById(int id)
        {
            return _database.Query<Budget>(Sql.Builder.From("Budgets")
                .Where("id = {0}", id)).FirstOrDefault();
        }

        public void Remove(Budget budget)
        {
            _database.Delete("Budgets", "Id", budget);
        }

        public Budget Update(Budget budget)
        {
            _database.Update("Budgets", "Id", budget, 
                new string[] { "Description", "MaxAmountAvailable" });

            return budget;
        }
    }
}