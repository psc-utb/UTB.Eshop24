using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;
using UTB.Eshop.Infrastructure.Identity.Enums;
using UTB.Eshop24.Controllers;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrderCartController : Controller
    {
        public const string totalPriceString = "TotalPrice";
        public const string orderItemsString = "OrderItems";


        ISecurityService _securityService;
        IOrderCartService _orderCartService;

        public CustomerOrderCartController(ISecurityService securityService, IOrderCartService orderCartService)
        {
            _securityService = securityService;
            _orderCartService = orderCartService;
        }


        [HttpPost]
        public double AddOrderItemsToSession(int? productId)
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                //get total price from the session
                double totalPrice = HttpContext.Session.GetDouble(totalPriceString).GetValueOrDefault();

                //get list of order items from the session
                List<OrderItem> orderItems = HttpContext.Session.GetObject<List<OrderItem>>(orderItemsString);
                //if the order items are not in the session, create new list
                if (orderItems == null)
                    orderItems = new List<OrderItem>();


                totalPrice = _orderCartService.AddOrderItem(productId, orderItems, totalPrice);


                //set total price to the session
                HttpContext.Session.SetDouble(totalPriceString, totalPrice);

                //set the list to the session
                HttpContext.Session.SetObject(orderItemsString, orderItems);


                return totalPrice;
            }

            return 0;
        }


        public async Task<IActionResult> ApproveOrderInSession()
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                User currentUser = await _securityService.GetCurrentUser(User);


                //get order items from the session
                List<OrderItem> orderItems = HttpContext.Session.GetObject<List<OrderItem>>(orderItemsString);
                if (orderItems != null)
                {
                    //get total price from session
                    double totalPrice = HttpContext.Session.GetDouble(totalPriceString).GetValueOrDefault();

                    if (_orderCartService.ApproveOrder(currentUser.Id, orderItems, totalPrice) == true)
                    {
                        //remove the informations from the session
                        HttpContext.Session.Remove(orderItemsString);
                        HttpContext.Session.Remove(totalPriceString);

                        return RedirectToAction(nameof(CustomerOrdersController.Index), nameof(CustomerOrdersController).Replace(nameof(Controller), String.Empty), new { Area = nameof(Customer) });
                    }
                }
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { Area = String.Empty });

        }
    }
}
