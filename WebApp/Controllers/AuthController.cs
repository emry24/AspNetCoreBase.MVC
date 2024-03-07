﻿using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AuthController : Controller
{

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp() => View(new SignUpViewModel());

    //[HttpGet]
    //[Route("/signup")]
    //public IActionResult SignUp()
    //{
    //    var viewModel = new SignUpViewModel();
    //    return View(viewModel);
    //}

    [HttpPost]
    [Route("/signup")]
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        return RedirectToAction("SignIn", "Auth");

        //if (ModelState.IsValid)
        //{
        //    var result = await _userService.CreateUserAsync(viewModel.Form);
        //    if (result.StatusCode = Infrastructure.Models.StatusCode.OK)
        //    return RedirectToAction("SignIn", "Auth");
        //}

        //return View(viewModel);
    }


    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signin")]
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        //var result = _authService.SignIn(viewModel.Form);
        //if (result)
        //    return RedirectToAction("Account", "Index");

        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
    }

}
