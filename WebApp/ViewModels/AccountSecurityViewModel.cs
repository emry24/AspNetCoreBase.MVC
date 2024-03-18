using WebApp.Models;

namespace WebApp.ViewModels;

public class AccountSecurityViewModel
{
    public string Title { get; set; } = "Account Security";

    public ProfileInfoModel? ProfileInfo { get; set; }
    public AccountSecurityModel? Form { get; set; }
}
