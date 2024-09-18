using Microsoft.AspNetCore.Mvc;

namespace UTB.Eshop24.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Select()
        {
            return View();
        }
    }
}

