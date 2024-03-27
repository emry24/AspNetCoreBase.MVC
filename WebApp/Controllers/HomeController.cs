using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;
using WebApp.ViewModels;
using static System.Net.WebRequestMethods;

namespace WebApp.Controllers;

public class HomeController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    //[Authorize]
    [Route("/")]
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (viewModel.DailyNewsletter || viewModel.AdvertisingUpdates || viewModel.WeekInReview || viewModel.EventUpdates || viewModel.StartUpsWeekly || viewModel.Podcasts)
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                    var response = await _http.PostAsync("https://localhost:7279/api/subscribers?key=YTc4YTQ3ZjMtYjNiZC00Mzc2LTlmM2MtZGQ3MDg0ZGI0YzNk", content);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData["Status"] = "Success";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ViewData["Status"] = "AlreadyExists";
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ViewData["Status"] = "Unauthorized";
                    }                  
                }
                catch
                {
                    ViewData["Status"] = "ConnectionFailed";
                }
            }
            else
            {
                ViewData["Status"] = "AtLeastOneCheckboxRequired";
            }
        }
        else
        {
            ViewData["Status"] = "Invalid";
        }

        return View("Subscribe", viewModel);
    }

    //[AllowAnonymous]
    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();

    //[AllowAnonymous]
    [Route("/denied")]
    public IActionResult AccessDenied(int statusCode) => View();
}




