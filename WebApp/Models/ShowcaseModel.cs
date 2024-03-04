
namespace WebApp.Models;

public class ShowcaseModel
{
    public string Heading { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<(string Url, string AltText)> Brands { get; set; } = new List<(string, string)>();

}

