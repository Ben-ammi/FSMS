using FSMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FSMS.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Authenticate user
            return RedirectToAction("Index", "Home");
        }
    }
}
