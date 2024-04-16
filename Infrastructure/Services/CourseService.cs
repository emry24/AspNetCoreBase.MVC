using Infrastructure.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class CourseService(HttpClient http, IConfiguration configuration)
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    public async Task<CourseResultDto> GetCoursesAsync(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {

        var response = await _http.GetAsync($"{_configuration["ApiUris:Courses"]}?category={Uri.UnescapeDataString(category)}&searchQuery={Uri.UnescapeDataString(searchQuery)}&pageNumber={pageNumber}&pagesize={pageSize}");
        if (response.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<CourseResultDto>(await response.Content.ReadAsStringAsync());
            if (result != null && result.Succeeded)
            {
                return result;
            }              
        }

        return null!;
    }
}
