using UTB.Eshop.Application.ViewModels;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselProductViewModel GetIndexViewModel();
    }
}
