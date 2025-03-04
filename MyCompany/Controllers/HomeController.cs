using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // simple view, so I do it without async shit
        public IActionResult Contats(){
            return View();
        }
    }
}
