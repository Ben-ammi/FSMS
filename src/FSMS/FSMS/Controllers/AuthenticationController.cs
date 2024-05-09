using Microsoft.AspNetCore.Mvc;

namespace FSMS.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
