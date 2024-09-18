using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Application.Abstraction;

namespace UTB.Eshop24.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: /<controller>/
        public IActionResult Select()
        {
            IList<Product> products = _productAppService.Select();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productAppService.Create(product);

            return RedirectToAction(nameof(ProductController.Select));
        }
    }
}

