using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;
using UTB.Eshop.Infrastructure.Identity.Enums;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrdersController : Controller
    {

        ISecurityService _securityService;
        IOrderAppService _orderService;

        public CustomerOrdersController(ISecurityService securityService, IOrderAppService orderService)
        {
            _securityService = securityService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _securityService.GetCurrentUser(User);
            if (currentUser != null)
            {
                IList<Order> userOrders = _orderService.SelectForUser(currentUser.Id);
                return View(userOrders);
            }

            return NotFound();
        }
    }
}
