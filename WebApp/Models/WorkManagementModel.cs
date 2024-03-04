namespace WebApp.Models
{
    public class WorkManagementModel
    {
        public string Title { get; set; } = null!;

        public List<ChecklistItem> ChecklistItems{ get; set; } = null!;
    }

    public class ChecklistItem
    {
        public string Icon { get; set; } = null!;
        public string AltText { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
