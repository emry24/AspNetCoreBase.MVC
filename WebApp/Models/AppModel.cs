

namespace WebApp.Models;

public class AppModel
{
    public string Image { get; set; } = null!;
    public string Heading { get; set; } = null!;
    public List<AppInfo> AppInfo { get; set; } = null!;
}

public class AppInfo
{
    public string Store { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Rating { get; set; } = null!;
    public string Reviews { get; set; } = null!;
    public string IconUrl { get; set; } = null!;
    public string AltText { get; set; } = null!;
}
