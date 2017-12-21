namespace UserRegistration.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using UserRegistration.Models;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}