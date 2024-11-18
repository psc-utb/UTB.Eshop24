using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IOrderAppService
    {
        IList<Order> Select();
        void Create(Order order);
    }
}

