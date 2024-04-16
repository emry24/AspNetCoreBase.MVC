using Infrastructure.Dtos;
using WebApp.Models.Courses;

namespace WebApp.ViewModels;

public class CourseViewModel
{
    public IEnumerable<CategoryModel>? Categories { get; set; }

    public IEnumerable<CourseModel>? Courses { get; set; }
    public PaginationDto? Pagination { get; set; }

}
