using WebApp.Models;

namespace WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";

    public ProfileInfoModel? ProfileInfo { get; set; } 
    public AccountDetailsBasicInfoModel? BasicInfo { get; set; } 
    public AccountDetailsAddressInfoModel? AddressInfo { get; set; } 
}

