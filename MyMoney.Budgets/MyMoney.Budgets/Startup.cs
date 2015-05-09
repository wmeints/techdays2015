using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyMoney.Budgets.Startup))]

namespace MyMoney.Budgets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
               
        }
    }
}
