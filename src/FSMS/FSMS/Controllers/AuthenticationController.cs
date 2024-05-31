using FSMS.Auth;
using FSMS.Models;
using FSMS.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace FSMS.Controllers
{
    public class AuthenticationController(IUserService userService, Authenticate authenticate) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = await userService.GetUser(model.Username, cancellationToken);

            switch (user)
            {
                case null:
                    ModelState.AddModelError("Username", "Invalid username");
                    return View("Index", model);

                case var _ when !user.Password.Equals(model.Password):
                    ModelState.AddModelError("Password", "Invalid password");
                    return View("Index", model);

                case var _ when !user.IsActive:
                    ModelState.AddModelError("Username", "User is inactive");
                    return View("Index", model);

                default:
                    // Handle other cases if needed
                    break;
            }

            var userSession = new UserSession
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Roles = user.Role!.Role
            };

            authenticate.UpdateAuthenticationState(userSession);

            return RedirectToAction("Index", "Home");
        }
    }
}
