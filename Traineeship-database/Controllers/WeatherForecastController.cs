using Microsoft.AspNetCore.Mvc;

namespace Traineeship_database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetWeatherForecastFromDb")]
        public IEnumerable<WeatherForecast> GetFromDb()
        {
            return _dbContext.WeatherForecast;
        }

        [HttpPost(Name = "WeatherForecast")]
        public ActionResult Insert([FromBody] WeatherForecast weatherForecast)
        {
            _dbContext.WeatherForecast.Add(weatherForecast);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}