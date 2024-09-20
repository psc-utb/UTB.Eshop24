using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class CarouselAppService : ICarouselAppService
    {
        EshopDbContext _eshopDbContext;

        public CarouselAppService(EshopDbContext eshopDbContext)
        {
            _eshopDbContext = eshopDbContext;
        }

        public IList<Carousel> Select()
        {
            return _eshopDbContext.Carousels.ToList();
        }
    }
}
