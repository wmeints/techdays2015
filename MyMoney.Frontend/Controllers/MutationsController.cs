using System;
using Microsoft.AspNet.Mvc;

namespace MyMoney.Frontend {
	public class MutationsController: Controller {
		public IActionResult Index() {
			return View();
		}		
	}
}