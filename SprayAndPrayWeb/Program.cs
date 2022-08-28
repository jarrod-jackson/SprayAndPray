using Microsoft.EntityFrameworkCore;
using SprayAndPray.Business;
using SprayAndPray.Business.CustomerServices;
using SprayAndPray.Business.PricingServices;
using SprayAndPray.Business.ServicesProvidedServices;
using SprayAndPray.DAL;
using SprayAndPray.DAL.Data.Repository;
using SprayAndPray.DAL.Data.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Allow DbContext to use SQL Server and configure connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IPricingManager, PricingManager>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IServicesManager, ServicesManager>();

builder.Services.AddScoped<IDatabase, Database>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=General}/{controller=Home}/{action=Index}/{id?}");

app.Run();
public partial class Program { };
