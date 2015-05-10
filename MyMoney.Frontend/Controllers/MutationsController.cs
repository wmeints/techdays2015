using System;
using Microsoft.AspNet.Mvc;

namespace MyMoney.Frontend {
	public class MutationsController: Controller {
		public IActionResult Index() {
			return View();
		}
		
		[HttpGetAttribute]
		public IActionResult Import() {
			return View();
		}	
		
		[HttpPostAttribute]
		[ActionNameAttribute("Import")]
		public IActionResult PerformImport() {
			return View();
		}	
	}
}