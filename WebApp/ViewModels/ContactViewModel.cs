using WebApp.Models;

namespace WebApp.ViewModels;

public class ContactViewModel
{
    public string Title { get; set; } = "Contact";

    public ContactFormViewModel ContactForm { get; set; } = new ContactFormViewModel();

}
