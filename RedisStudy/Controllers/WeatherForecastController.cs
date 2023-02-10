using Microsoft.AspNetCore.Mvc;

using StackExchange.Redis;

namespace RedisStudy.Controllers
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
        private readonly IConnectionMultiplexer _redis;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
        }

        [HttpGet(Name = "WeatherForecast")]
        public Enumerable<UserInfo> GetUser()
        {
            var db = _redis.GetDatabase();
            var user = db.StringAppend("user", "haroong");
            Console.WriteLine(db);


        }
    }
}