using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IOrderItemAppService
    {
        IList<OrderItem> Select();
        void Create(OrderItem orderItem);
    }
}

