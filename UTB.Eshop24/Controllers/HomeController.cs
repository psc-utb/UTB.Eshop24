using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop24.Models;

namespace UTB.Eshop24.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IHomeService _homeService;

    public HomeController(ILogger<HomeController> logger,
                          IHomeService homeService)
    {
        _logger = logger;
        _homeService = homeService;
    }

    public IActionResult Index()
    {
        CarouselProductViewModel viewModel = _homeService.GetIndexViewModel();
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

