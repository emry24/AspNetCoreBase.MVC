using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
using WebApp.ViewModels;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    //[Authorize]
    public IActionResult Index()
    {
        var viewModel = new ContactViewModel();

        return View(viewModel);
    }


    //[HttpPost]
    //public async Task<IActionResult> ContactForm(ContactViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //            try
    //            {
    //                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
    //                var response = await _http.PostAsync("https://localhost:7279/api/subscribers?key=YTc4YTQ3ZjMtYjNiZC00Mzc2LTlmM2MtZGQ3MDg0ZGI0YzNk", content);

    //                if (response.IsSuccessStatusCode)
    //                {
    //                    ViewData["Status"] = "Success";
    //                }
    //                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
    //                {
    //                    ViewData["Status"] = "AlreadyExists";
    //                }
    //                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
    //                {
    //                    ViewData["Status"] = "Unauthorized";
    //                }
    //            }
    //            catch
    //            {
    //                ViewData["Status"] = "ConnectionFailed";
    //            }
    //    }
    //    else
    //    {
    //        ViewData["Status"] = "Invalid";
    //    }

    //    return View("Contact", viewModel);
    //}
}
