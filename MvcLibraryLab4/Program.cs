using Microsoft.EntityFrameworkCore;
using MvcLibraryLab4.Data;
using MvcLibraryLab4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<MvcLibraryLab4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcLibraryLab4Context")));

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
