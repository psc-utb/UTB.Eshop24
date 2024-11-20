using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class OrderCartService : IOrderCartService
    {
        EshopDbContext _eshopDbContext;

        public OrderCartService(EshopDbContext eshopDbContext)
        {
            _eshopDbContext = eshopDbContext;
        }


        public double AddOrderItem(int? productId, List<OrderItem> orderItems, double totalPrice)
        {
            //get product which should be added to cart/session
            Product? product = _eshopDbContext.Products.FirstOrDefault(prod => prod.Id == productId);

            if (product != null)
            {
                //find the order item with the ProductID (if exists)
                OrderItem? orderItemInList = orderItems.FirstOrDefault(oi => oi.ProductID == product.Id);

                //if there is order item with ProductID, increase amount and price, otherwise, add new OrderItem
                if (orderItemInList != null)
                {
                    ++orderItemInList.Amount;
                    orderItemInList.Price += product.Price;
                }
                else
                {
                    //create order item with connected product and add it to the list
                    OrderItem orderItem = new OrderItem()
                    {
                        ProductID = product.Id,
                        Product = product,
                        Amount = 1,
                        Price = product.Price
                    };

                    orderItems.Add(orderItem);
                }

                //increase the total price and set it to the session
                totalPrice += product.Price;
            }

            //return total price
            return totalPrice;
        }


        public bool ApproveOrder(int userId, List<OrderItem> orderItems, double totalPrice)
        {
            if (orderItems != null)
            {
                //reference to the product must be null; otherwise, it tries to add it to the database again
                orderItems.ForEach(orderItem => orderItem.Product = null);

                ////alternate option for the problem above
                //double totalPriceCheck = 0;
                //foreach (OrderItem orderItem in orderItems)
                //{
                //    //recalculate total price (just to be sure; the total price is in the session too and the value should be same)
                //    totalPriceCheck += orderItem.Product.Price * orderItem.Amount;
                //    //reference to the product must be null; otherwise, it tries to add it to the database again
                //    orderItem.Product = null;
                //}


                //create new order and connect it with the list of the order items
                Order order = new Order()
                {
                    OrderNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                    TotalPrice = totalPrice,
                    OrderItems = orderItems,
                    UserId = userId
                };



                //We can add just the order; connected order items will be added automatically to the database.
                _eshopDbContext.Add(order);
                _eshopDbContext.SaveChanges();


                //success
                return true;

            }


            //failure
            return false;
        }

    }
}

