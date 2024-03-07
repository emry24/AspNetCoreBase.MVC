using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();

//Register your services here.. (se connectionsstring i appsettings.json)
builder.Services.AddDbContext<DataContext>( x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

//builder.Services.AddScoped<AddressRepository>();
//builder.Services.AddScoped<UserRepository>();
//builder.Services.AddScoped<AddressService>();
//builder.Services.AddScoped<UserService>();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
