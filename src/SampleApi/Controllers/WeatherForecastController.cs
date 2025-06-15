using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)],
            Source = "WeatherForecastController",
            OperatorName = GetOperatorByHour(DateTime.Now.Hour)
        })
        .ToArray();
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast input)
    {
        input.Source = "WeatherForecastController";
        input.OperatorName = GetOperatorByHour(DateTime.Now.Hour);
        return Ok(input);
    }

    private static string GetOperatorByHour(int hour)
    {
        if (hour >= 0 && hour < 8)
            return "operator_night";
        if (hour >= 8 && hour < 16)
            return "operator_day";
        return "operator_evening";
    }
}