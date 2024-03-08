using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();

        return View(viewModel);
    }

    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();
}




