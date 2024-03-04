using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class FeaturesModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<FeatureItem> FeatureItems { get; set; } = null!;
}

public class FeatureItem
{
    public string Icon { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
