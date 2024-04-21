using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressService _addressService = addressService;

    #region Account Details
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        try
        {
            var claims = HttpContext.User.Identities.FirstOrDefault();

            var viewModel = new AccountDetailsViewModel()
            {
                ProfileInfo = await PopulateProfileInfoAsync()
            };

            viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }


    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(viewModel);
        //}
        try
        {
            if (viewModel.BasicInfo != null)
            {
                if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.Email != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        user.FirstName = viewModel.BasicInfo.FirstName;
                        user.LastName = viewModel.BasicInfo.LastName;
                        user.Email = viewModel.BasicInfo.Email;
                        user.PhoneNumber = viewModel.BasicInfo.Phone;
                        user.Biography = viewModel.BasicInfo.Biography;

                        var result = await _userManager.UpdateAsync(user);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                            ViewData["ErrorMessage"] = "Something went wrong! Unable to update basic information.";
                        }
                    }
                }
            }

            if (viewModel.AddressInfo != null)
            {
                if (viewModel.AddressInfo.AddressLine_1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        var address = await _addressService.GetAddressAsync(user.Id);
                        if (address != null)
                        {

                            address.StreetName = viewModel.AddressInfo.AddressLine_1;
                            address.StreetName_2 = viewModel.AddressInfo.AddressLine_2;
                            address.PostalCode = viewModel.AddressInfo.PostalCode;
                            address.City = viewModel.AddressInfo.City;

                            var result = await _addressService.UpdateAddressAsync(address, user.Id);
                            if (!result)
                            {
                                ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                                ViewData["ErrorMessage"] = "Something went wrong! Unable to update address information";

                            }
                        }
                        else
                        {
                            address = new AddressModel
                            {
                                UserId = user.Id,
                                StreetName = viewModel.AddressInfo.AddressLine_1,
                                StreetName_2 = viewModel.AddressInfo.AddressLine_2,
                                PostalCode = viewModel.AddressInfo.PostalCode,
                                City = viewModel.AddressInfo.City
                            };

                            var result = await _addressService.CreateAddressAsync(address);
                            if (!result)
                            {
                                ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                                ViewData["ErrorMessage"] = "Something went wrong! Unable to update address information";
                            }
                        }
                    }
                }
            }

            viewModel.ProfileInfo = await PopulateProfileInfoAsync();
            viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }
    #endregion

    #region Populate Profile Info
    private async Task<ProfileInfoModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            //ProfileImageUrl = user.ProfileImageUrl,
            IsExternalAccount = user.IsExternalAccount,
        };
    }
    #endregion

    #region Populate Basic Info
    private async Task<AccountDetailsBasicInfoModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsBasicInfoModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber!,
            Biography = user.Biography
        };
    }
    #endregion

    #region Populate Address Info
    private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
    {
        var userId = _userManager.GetUserId(User);
        if (userId != null)
        {
            var userAddress = await _addressService.GetAddressAsync(userId);
            if (userAddress != null) 
            {
                return new AccountDetailsAddressInfoModel
                {
                    AddressLine_1 = userAddress.StreetName,
                    AddressLine_2 = userAddress.StreetName_2,
                    PostalCode = userAddress.PostalCode,
                    City = userAddress.City,
                };
            }

            return null!;
        }

        return null!;

    }
    #endregion

    #region Account Security
    [HttpGet]
    [Route("/account/security")]
    public async Task<IActionResult> Security()
    {
        var viewModel = new AccountSecurityViewModel()
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };

        return View(viewModel);
    }

    [HttpPost]
    [Route("/account/security")]
    public async Task<IActionResult> Security(AccountSecurityViewModel viewModel)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("login");
            }

            var result = await _userManager.ChangePasswordAsync(user, viewModel.Form!.Password, viewModel.Form.NewPassword);
            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);
                ViewBag.Success = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                ViewData["ErrorMessage"] = "Something went wrong! Unable to update password.";
            }

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }


    [HttpPost]
    [Route("/account/delete")]
    public async Task<IActionResult> Delete(AccountSecurityViewModel viewModel)
    {

            try
            {
                if (viewModel.Form?.DeleteAccount != null && viewModel.Form.DeleteAccount)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user == null)
                    {
                        return RedirectToAction("login");
                    }

                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "Please enter the checkbox.";
                }
            }
            catch
            {
                ViewData["ErrorMessage"] = "Failed to delete account.";
            }

        return View("Security", viewModel);

    }
    #endregion

}
