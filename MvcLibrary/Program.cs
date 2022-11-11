using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLibrary.Data;
using MvcLibrary.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcLibraryContext") ?? throw new InvalidOperationException("Connection string 'MvcLibraryContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Enable the session middleware
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(180);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Seed the Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialiaze(services);
}


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

// "The order of the middleware is important:
// call `UseSession` after `UserRouting`(...)"
// See: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0#configure-session-state
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
