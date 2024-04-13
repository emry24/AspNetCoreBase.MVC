using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Configuration;
using WebApp.Helpers.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(SettingsAutoMapper));

//Register your services here.. (se connectionsstring i appsettings.json)
builder.Services.AddDbContext<UserDbContext>( x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));



builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();



builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressService>();
//builder.Services.AddScoped<UserRepository>();
//builder.Services.AddScoped<UserService
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CourseService>();

// COOKIES
builder.Services.ConfigureApplicationCookie( x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/denied";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});

// POLICYS
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("SuperAdminAccess", policy => policy.RequireRole("SuperAdmin"));
    x.AddPolicy("CIOAccess", policy => policy.RequireRole("SuperAdmin", "CIO"));
    x.AddPolicy("AdminAccess", policy => policy.RequireRole("SuperAdmin", "CIO", "Admin"));
    x.AddPolicy("ManagerAccess", policy => policy.RequireRole("SuperAdmin", "CIO", "Admin", "Manager"));
    x.AddPolicy("UserAccess", policy => policy.RequireRole("SuperAdmin", "CIO", "Admin", "Manager", "User"));
});

builder.Services.AddAuthentication().AddFacebook(x =>
{
    x.AppId = "791297515859482";
    x.AppSecret = "065006deb04106a0bf9f3b6bc1efb5e7";
    x.Fields.Add("first_name");
    x.Fields.Add("last_name");
});

builder.Services.AddAuthentication().AddGoogle(x =>
{
    x.ClientId = "449878733056-o9f6crftbm4abvn4sv2pfe2ui288d76g.apps.googleusercontent.com";
    x.ClientSecret = "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";
    x.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "first_name");
    x.ClaimActions.MapJsonKey(ClaimTypes.Surname, "last_name");
});

var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseUserSessionValidation();
app.UseAuthorization();

// ROLES
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = ["SuperAdmin","CIO","Admin","Manager", "User"];
    foreach (var role in roles)
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
}

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
