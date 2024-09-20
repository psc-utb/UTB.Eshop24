using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.ViewModels
{
    public class CarouselProductViewModel
    {
        public IList<Carousel>? Carousels { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
