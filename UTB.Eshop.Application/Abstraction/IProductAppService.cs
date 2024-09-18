using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IProductAppService
    {
        IList<Product> Select();
        void Create(Product product);
    }
}

