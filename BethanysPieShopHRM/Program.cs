using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Components;
using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Repositories;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.State;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanyConnection"]));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ITimeRegistrationRepository, TimeRegistrationRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>();
builder.Services.AddScoped<ITimeRegistrationDataService, TimeRegistrationDataService>();
builder.Services.AddScoped<IJobCategoryDataService, JobCategoryDataService>();
builder.Services.AddScoped<ICountryDataService, CountryDataService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ApplicationState>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BethanysPieShopHRM.Client._Imports).Assembly);

app.MapGet("/api/employee",
    async (IEmployeeDataService employeeDataService) => await employeeDataService.GetAllEmployees());
app.Run();
