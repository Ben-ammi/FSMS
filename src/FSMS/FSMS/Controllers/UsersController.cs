using Microsoft.AspNetCore.Mvc;

namespace FSMS.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
