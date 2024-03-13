using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    //[Authorize]
    [Route("/")]
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();

        return View(viewModel);
    }

    //[AllowAnonymous]
    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();
}




