using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class AccountDetailsAddressInfoModel
{
    [DataType(DataType.Text)]
    [Display(Name = "Address 1", Prompt = "Enter your address", Order = 0)]
    [Required(ErrorMessage = "Address is required")]
    [MinLength(2, ErrorMessage = "Address is required")]
    public string AddressLine_1 { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Address 2", Prompt = "Enter your address", Order = 1)]
    //[Required(ErrorMessage = "Address is required")]
    public string? AddressLine_2 { get; set; }

    [DataType(DataType.PostalCode)]
    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
    [Required(ErrorMessage = "Postal code is required")]
    [MinLength(2, ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "City is required")]
    [MinLength(2, ErrorMessage = "Postal code is required")]
    public string City { get; set; } = null!;

}
