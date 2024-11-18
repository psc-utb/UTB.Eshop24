using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IOrderAppService
    {
        IList<Order> Select();
        IList<Order> SelectForUser(int userId);
        void Create(Order order);
    }
}

