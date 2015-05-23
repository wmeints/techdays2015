using Microsoft.AspNet.Mvc;

namespace MyMoney.Frontend.Controllers {
  [Route("/Search")]
  public class SearchController : Controller {
      public IActionResult Index(string query) {
          return View();
      }
  }
}
