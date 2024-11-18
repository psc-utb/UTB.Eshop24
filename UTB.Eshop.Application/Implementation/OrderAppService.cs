using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class OrderAppService : IOrderAppService
    {
        EshopDbContext _eshopDbContext;

        public OrderAppService(EshopDbContext eshopDbContext)
        {
            _eshopDbContext = eshopDbContext;
        }

        public IList<Order> Select()
        {
            return _eshopDbContext.Orders
                                  .Include(oi => oi.User)
                                  .ToList();
        }

        public IList<Order> SelectForUser(int userId)
        {
            return _eshopDbContext.Orders.Where(or => or.UserId == userId)
                                         .Include(o => o.User)
                                         .Include(o => o.OrderItems)
                                         .ThenInclude(oi => oi.Product)
                                         .ToList();
        }

        public void Create(Order order)
        {
            _eshopDbContext.Orders.Add(order);
            _eshopDbContext.SaveChanges();
        }
    }
}

