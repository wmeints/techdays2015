﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Budgets.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }

    }
}