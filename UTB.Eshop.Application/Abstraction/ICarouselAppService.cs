using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface ICarouselAppService
    {
        IList<Carousel> Select();
    }
}
