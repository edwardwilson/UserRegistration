namespace UserRegistration.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using UserRegistration.Models;
    using UserRegistration.Services;

    public class UsersController : Controller
    {
        private readonly IUserStore userStore;
        private readonly ILogger<UsersController> logger;

        public UsersController(IUserStore userStore, ILogger<UsersController> logger)
        {
            this.userStore = userStore;
            this.logger = logger;
        }

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
                return View(model);
            }

            try
            {
                userStore.AddUser(model);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error registering user");
                return Error();
            }

            return View(model);
            }

        [HttpGet]
        public IActionResult RegistrationSuccess()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string emailAddress)
        {
            if (!userStore.EmailUnique(emailAddress))
            {
                return Json($"Email {emailAddress} is already in use.");
            }

            return Json(true);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}