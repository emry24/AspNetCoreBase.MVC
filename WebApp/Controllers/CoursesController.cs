using AutoMapper;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebApp.Models.Courses;
using WebApp.ViewModels;

namespace WebApp.Controllers;

//[Authorize]
public class CoursesController(HttpClient http, CategoryService categoryService, CourseService courseService, IMapper mapper) : Controller
{
    private readonly HttpClient _http = http;
    private readonly CategoryService _categoryService = categoryService;
    private readonly CourseService _courseService = courseService;
    private readonly IMapper _mapper = mapper;

    #region Get all courses

    //public async Task<IActionResult> Index()
    //{
    //    try
    //    {
    //        var viewModel = new CourseViewModel();

    //        using var http = new HttpClient();
    //        var response = await http.GetAsync("https://localhost:7279/api/courses");
    //        viewModel.Courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(await response.Content.ReadAsStringAsync())!;

    //        return View(viewModel);
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
    //    return null!;

    //}

    public async Task<IActionResult> Index()
    {
        try
        {
            var viewModel = new CourseViewModel
            {
                Categories = _mapper.Map<IEnumerable<CategoryModel>>(await _categoryService.GetCategoriesAsync()),
                Courses = _mapper.Map<IEnumerable<CourseModel>>(await _courseService.GetCoursesAsync()),
            };

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    #endregion

    #region Create course

    [HttpPost]
    public async Task<IActionResult> Create(CourseRegistrationFormViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();

                var json = JsonConvert.SerializeObject(viewModel);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7279/api/courses", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    #endregion

    #region Get one course

    [Route("/details")]
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            //using var http = new HttpClient();
            //var response = await _http.GetAsync($"https://localhost:7279/api/courses/{id}");

            //var json = await response.Content.ReadAsStringAsync();
            //var courseDto = JsonConvert.DeserializeObject<CourseDto>(json);

            //var courseViewModel = _mapper.Map<CourseModel>(courseDto);

            //return View(courseViewModel);

            var response = await _http.GetAsync($"https://localhost:7279/api/courses/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var courseDto = JsonConvert.DeserializeObject<CourseDto>(json);

            var courseModel = new CourseModel
            {
                CourseId = courseDto!.CourseId,
                Title = courseDto.Title,
                Ingress = courseDto.Ingress,
                IsBestseller = courseDto.IsBestseller,
                Reviews = courseDto.Reviews,
                RatingImage = courseDto.RatingImage,
                LikesInProcent = courseDto.LikesInProcent,
                LikesInNumbers = courseDto.LikesInNumbers,
                DurationHours = courseDto.DurationHours,
                Description = courseDto.Description,
                Creator = new CreatorModel
                {
                    CreatorName = courseDto.Creator?.CreatorName!,
                    CreatorBio = courseDto.Creator?.CreatorBio,
                    CreatorImage = courseDto.Creator?.CreatorImage,
                    FacebookFollowers = courseDto.Creator?.FacebookFollowers,
                    YoutubeSubscribers = courseDto.Creator?.YoutubeSubscribers,
                },
                Category = new CategoryModel
                {
                    CategoryName = courseDto.Category!.CategoryName
                },
                Details = new CourseDetailsModel
                {
                    NumberOfArticles = courseDto.Details!.NumberOfArticles,
                    NumberOfResources = courseDto.Details.NumberOfResources,
                    LifetimeAccess = courseDto.Details.LifetimeAccess,
                    Certificate = courseDto.Details.Certificate,
                    Price = courseDto.Details.Price,
                    DiscountedPrice = courseDto.Details.DiscountedPrice,
                },
                ProgramDetails = courseDto.ProgramDetails?.Select(pd => new ProgramDetailsModel
                {
                    ProgramDetailsNumber = pd.ProgramDetailsNumber,
                    ProgramDetailsTitle = pd.ProgramDetailsTitle,
                    ProgramDetailsDescription = pd.ProgramDetailsDescription,
                }).ToList(),
                LearningDetails = courseDto.LearningDetails?.Select(ld => new LearningDetailsModel
                {
                    LearningsDescription = ld.LearningsDescription,
                }).ToList()
            };

            return View(courseModel);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    #endregion
}
