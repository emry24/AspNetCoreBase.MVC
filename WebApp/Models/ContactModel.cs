//using System.ComponentModel.DataAnnotations;

//namespace WebApp.Models;

//public class ContactModel
//{
//    [DataType(DataType.Text)]
//    [Display(Name = "Full name", Prompt = "Enter your full name")]
//    [Required(ErrorMessage = "Full name is required")]
//    [MinLength(2, ErrorMessage = "Full name is required")]
//    public string FullName { get; set; } = null!;

//    [DataType(DataType.EmailAddress)]
//    [Display(Name = "Email Address", Prompt = "Enter your email address")]
//    [Required(ErrorMessage = "Enter a valid email address")]
//    [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]{2,}$", ErrorMessage = "Your email address is invalid")]
//    public string Email { get; set; } = null!;
//    public string? Service { get; set; }

//    [DataType(DataType.MultilineText)]
//    [Display(Name = "Message", Prompt = "Message")]
//    [Required(ErrorMessage = "Message is required")]
//    [MinLength(2, ErrorMessage = "Message is required")]
//    public string? Message { get; set; } = null!;

//    public DateTime? Created { get; set; }
//    public DateTime? LastUpdated { get; set; }
//}
