using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;

namespace UTB.Eshop.Application.Implementation
{
    public class HomeService : IHomeService
    {
        IProductAppService _productAppService;
        ICarouselAppService _carouselAppService;

        public HomeService(IProductAppService productAppService,
                           ICarouselAppService carouselAppService)
        {
            _productAppService = productAppService;
            _carouselAppService = carouselAppService;
        }

        public CarouselProductViewModel GetIndexViewModel()
        {
            CarouselProductViewModel viewModel = new CarouselProductViewModel();
            viewModel.Products = _productAppService.Select();
            viewModel.Carousels = _carouselAppService.Select();
            return viewModel;
        }
    }
}
