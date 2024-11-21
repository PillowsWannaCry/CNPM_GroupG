using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Repositories;
using KoiOrderingSystem.Services.Interfaces;
using KoiOrderingSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// DI
builder.Services.AddDbContext<KoiOrderingSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.SlidingExpiration = true;
    });


// DI Repositories
builder.Services.AddScoped<IKoiOrderCustomerRepository, KoiOrderCustomerRepository>();
builder.Services.AddScoped<IKoiOrderEmployeeRepository, KoiOrderEmployeeRepository>();
builder.Services.AddScoped<IKoiOrderRoleRepository, KoiOrderRoleRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// DI   Service
builder.Services.AddScoped<IKoiOrderCustomerService, KoiOrderCustomerService>();
builder.Services.AddScoped<IKoiOrderEmployeeService, KoiOrderEmployeeService>();
builder.Services.AddScoped<IKoiOrderRoleService, KoiOrderRoleService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

app.UseAuthentication();
