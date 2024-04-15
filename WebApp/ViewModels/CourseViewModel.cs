using WebApp.Models.Courses;

namespace WebApp.ViewModels;

public class CourseViewModel
{
    //public IEnumerable<CourseModel> Courses { get; set; } = [];

    public IEnumerable<CategoryModel>? Categories { get; set; }

    public IEnumerable<CourseModel>? Courses { get; set; }

}
