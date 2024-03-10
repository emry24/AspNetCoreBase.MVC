using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
//{
    //private readonly AccountService _accountService;

    //public AccountController(AccountService accountService)
    //{
    //    _accountService = accountService;
    //}

    [Route("/account/details")]

    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Account");

        var userEntity = await _userManager.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel()
        {
            BasicInfo = new AccountDetailsBasicInfoModel
            {
                ProfileImage = userEntity.ProfileImageUrl, 
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Phone = userEntity.PhoneNumber,
                Biography = userEntity.Biography
            },
        };



        return View(viewModel);
    }

    //[Route("/account")]

    //public IActionResult Details()
    //{
    //    var viewModel = new AccountDetailsViewModel();
    //    //viewModel.BasicInfo = _accountService.GetBasicInfo();
    //    //viewModel.AddressInfo = _accountService.GetAddressInfo();

    //    return View(viewModel);
    //}

    //[HttpPost]
    //public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    //{
        //var result = await _userManager.UpdateAsync(viewModel.User);

        //if (!result.Succeeded) 
        //{
        //    ModelState.AddModelError("Failed To Save Data", "Unable To Save The Data");
        //    ViewData["ErrorMessage"] = "Unable to save the data";
        //}

        //return RedirectToAction("Details", "Account", viewModel);

        //_accountService.SaveBasicInfo(viewModel.BasicInfo);
        //return RedirectToAction(nameof(Details));
    //}

    [HttpPost]
    public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
    {
        //_accountService.SaveAddressInfo(viewModel.AddressInfo);
        return RedirectToAction(nameof(Details));
    }
}
