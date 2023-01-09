using Microsoft.AspNetCore.Mvc;
using MvcLibraryLab4.Data;
using MvcLibraryLab4.Models;

namespace MvcLibraryLab4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly MvcLibraryLab4Context _context;

        public WeatherForecastController(MvcLibraryLab4Context context)
        {
            _context = context;
        }


        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };
        //
        // private readonly ILogger<WeatherForecastController> _logger;


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var forecasts = from w in _context.WeatherForecasts
                select w;
            return forecasts.ToArray();

        }
    }
}