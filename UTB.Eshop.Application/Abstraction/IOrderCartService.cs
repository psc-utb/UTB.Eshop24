using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItem(int? productId, List<OrderItem> orderItems, double totalPrice);
        bool ApproveOrder(int userId, List<OrderItem> orderItems, double totalPrice);
    }
}

