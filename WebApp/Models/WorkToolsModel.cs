namespace WebApp.Models;

public class WorkToolsModel
{
    public string Heading { get; set; } = null!;
    public string Text { get; set; } = null!;

    public List<ToolsItem> ToolsItems { get; set; } = null!;
};

public class ToolsItem
{
    public string Image { get; set; } = null!;
    public string AltText { get; set; } = null!;
    public string Description { get; set; } = null!;
};
