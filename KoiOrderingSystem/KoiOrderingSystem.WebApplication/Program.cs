using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services;
using KoiOrderingSystem.Services.Interfaces;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// DI
builder.Services.AddDbContext<KoiOrderingSystemContext>();
// DI Repositories
builder.Services.AddScoped<IKoiOrderCustomerRepository, KoiOrderCustomerRepository>();
builder.Services.AddScoped<IKoiOrderEmployeeRepository, KoiOrderEmployeeRepository>();
// DI   Service
builder.Services.AddScoped<IKoiOrderCustomerService, KoiOrderCustomerService>();
builder.Services.AddScoped<IKoiOrderEmployeeService, KoiOrderEmployeeService>();
var app = builder.Build();  

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
