using Microsoft.AspNetCore.Mvc;

namespace UTB.Eshop24.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}

