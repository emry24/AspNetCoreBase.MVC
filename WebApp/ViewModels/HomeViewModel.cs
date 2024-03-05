using WebApp.Models;

namespace WebApp.ViewModels;

public class HomeViewModel
{
    public string Title { get; set; } = "Home";
    public ShowcaseModel Showcase { get; set; } = new ShowcaseModel()
    {
        Heading = "Task Management Assistant You Gonna Love",
        Description = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Brands = new List<(string Url, string AltText)>
        {
            ("images/brands/brand_1.svg", "brand1"),
            ("images/brands/brand_2.svg", "brand2"),
            ("images/brands/brand_3.svg", "brand3"),
            ("images/brands/brand_4.svg", "brand4")
        }
    };

    public FeaturesModel Features { get; set; } = new FeaturesModel()
    {
        Title = "What Do You Get With Your Tool?",
        Description = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
        FeatureItems = new List<FeatureItem>
        {
            new FeatureItem
            {
                Icon = "images/icons/chat.svg",
                AltText = "chat-icon",
                Title = "Comments on Tasks",
                Description = "Id mollis consectetur congue egestas suspendisse blandit justo."
            },
            new FeatureItem
            {
                Icon = "images/icons/presentation.svg",
                AltText = "presentation-icon",
                Title = "Tasks Analytics",
                Description = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipscing vuluptate."
            },
            new FeatureItem
            {
                Icon = "images/icons/add-group.svg",
                AltText = "add-group-icon",
                Title = "Multiple Assignees",
                Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."
            },
            new FeatureItem
            {
                Icon = "images/icons/bell.svg",
                AltText = "bell-icon",
                Title = "Notifications",
                Description = "Diam, suspendisse velit cras ac.Lobortis diam voluptat, eget pellentesque viverra."
            },
            new FeatureItem
            {
                Icon = "images/icons/tests.svg",
                AltText = "tests-icon",
                Title = "Sections & Subtasks",
                Description = "Mi feugiat hac id in. Sit ellit placerat lacus nibh lorem ridiculus lectus."
            },
            new FeatureItem
            {
                Icon = "images/icons/shield.svg",
                AltText = "shield-icon",
                Title = "Data Security",
                Description = "Alaiquam malesuada neque eget elit nulla vestibulum nunc cras."
            }
        }
    };

    public WorkManagementModel WorkManagement { get; set; } = new WorkManagementModel()
    {
        Title = "Manage Your work",
        ChecklistItems = new List<ChecklistItem> 
        {
            new ChecklistItem
            {
            Icon = "images/icons/bx-check-circle.svg",
            AltText = "check-circle",
            Text = "Powerful project management",
            },
            new ChecklistItem
            {
            Icon = "images/icons/bx-check-circle.svg",
            AltText = "check-circle",
            Text = "Transparent work management",
            },
            new ChecklistItem
            {
            Icon = "images/icons/bx-check-circle.svg",
            AltText = "check-circle",
            Text = "Manage work & focus on the most important tasks",
            },
            new ChecklistItem
            {
            Icon = "images/icons/bx-check-circle.svg",
            AltText = "check-circle",
            Text = "Track your progress with interactive charts",
            },
            new ChecklistItem
            {
            Icon = "images/icons/bx-check-circle.svg",
            AltText = "check-circle",
            Text = "Easiest way to track time spent on tasks",
            },

        }
    };

    public AppModel AppModel { get; set; } = new AppModel()
    {
        Image = "images/app_image.svg",
        Heading = "Download Our App for Any Devices:",
        AppInfo = new List<AppInfo>
        {
        new AppInfo
            {
                Store = "App Store",
                Title = "Editor's Choice",
                Rating = "4.7",
                Reviews = "187K+",
                IconUrl = "images/icons/appstore.svg",
                AltText = "App Store",
            },
            new AppInfo
            {
                Store = "Google Play",
                Title = "App of the Day",
                Rating = "4.8",
                Reviews = "30K+",
                IconUrl = "images/icons/googleplay.svg",
                AltText = "Google Play",
            }
         }
    };

    public WorkToolsModel WorkTools { get; set; } = new WorkToolsModel()
    {
        Heading = "Integrate Top Work Tools",
        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam\r\nluctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",

        ToolsItems = new List<ToolsItem>
        {
            new ToolsItem
            {
            Image = "images/icons/google.svg",
            AltText = "google-icon",
            Description = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis."
            },
            new ToolsItem
            {
            Image = "images/icons/camera.svg",
            AltText = "camera-icon",
            Description = "In eget a mauris quis.Tortor dui tempus quis integer est sit natoque placerat dolor."
            },
            new ToolsItem
            {
            Image = "images/icons/colors-logo.svg",
            AltText = "colors-icon",
            Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo."
            },
            new ToolsItem
            {
            Image = "images/icons/mail-logo.svg",
            AltText = "mail-icon",
            Description = "Rutrum interdum tortor, sed at nulla.A cursus bibendum elit purus cras praesent."
            },
            new ToolsItem
            {
            Image = "images/icons/pages-logo.svg",
            AltText = "paiges-icon",
            Description = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna."
            },
            new ToolsItem
            {
            Image = "images/icons/monkey-logo.svg",
            AltText = "monkey-icon",
            Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris"
            },
            new ToolsItem
            {
            Image = "images/icons/dropbox-logo.svg",
            AltText = "dropbox-icon",
            Description = "Ut in turpis consequat odio diam lectus elementum.Est faucibus blandit platea."
            },
            new ToolsItem
            {
            Image = "images/icons/elephant-logo.svg",
            AltText = "elephants-icon",
            Description = "Faucibus cursus maecenas lorem cursus nibh.Sociis sit risus id.Sit facilisis dolor arcu."
            }
        }
    };
}
