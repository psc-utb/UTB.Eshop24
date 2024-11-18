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

        public void Create(Order order)
        {
            _eshopDbContext.Orders.Add(order);
            _eshopDbContext.SaveChanges();
        }
    }
}

