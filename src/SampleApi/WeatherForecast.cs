namespace SampleApi;

public class WeatherForecast
{
    public string System { get; set; } = Environment.OSVersion.Platform.ToString();
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
    public required string OperatorName { get; set; }
    public required string Source { get; set; } 
}