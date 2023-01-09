using Microsoft.EntityFrameworkCore;
using MvcLibraryLab4.Data;

namespace MvcLibraryLab4.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcLibraryLab4Context(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<MvcLibraryLab4Context>>()))
            {
                // Look for any WeatherForecasts.
                if (context.WeatherForecasts.Any())
                {
                    return;   // DB has been seeded
                }

                context.WeatherForecasts.AddRange(
                    new WeatherForecast
                    {
                        Date = DateTime.Now,
                        TemperatureC = 5,
                        Summary = "Rainy"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
