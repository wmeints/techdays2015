using Microsoft.Practices.Unity;
using MyMoney.Budgets.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyMoney.Budgets
{
    public class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var container = new UnityContainer();

            container.RegisterType<IBudgetRepository, BudgetRepository>();
            
            configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}