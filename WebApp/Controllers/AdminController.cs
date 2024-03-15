using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize(Policy = "AdminAccess")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [Authorize(Policy = "CIOAccess")]
    public IActionResult Settings()
    {
        return View();
    }
}
