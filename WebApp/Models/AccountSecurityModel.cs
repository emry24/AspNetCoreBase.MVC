using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AccountSecurityModel
{
    public string UserId { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Current password", Prompt = "Enter your current password")]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Invalid, must be strong password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "New password", Prompt = "Enter your new password")]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Invalid, must be strong password")]
    public string NewPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = " Confirm new password", Prompt = "Confirm your new password")]
    [Required(ErrorMessage = "Password must be comfirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Fields does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Yes, I want to delete my account.")]
    public bool DeleteAccount { get; set; }
}
