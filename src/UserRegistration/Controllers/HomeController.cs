namespace UserRegistration.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using UserRegistration.Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(object model)
        {
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}