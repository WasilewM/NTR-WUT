using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using NTRLab4Backend.Data;
using NTRLab4Backend.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NTRLab4BackendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcLibraryContext") ?? throw new InvalidOperationException("Connection string 'NTRLab4BackendContext' not found.")));


// Add services to the container.

// Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => 
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed the Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialiaze(services);
}

// Enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
