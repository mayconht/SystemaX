using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleApi;


namespace ApiIntegrationTests;

[UsesVerify]
public class WeatherForecastTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public WeatherForecastTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccessStatusCode()
    {
        var response = await _client.GetAsync("/weatherforecast");
        await Verify(new
        {
            StatusCode = response.StatusCode,
            IsSuccess = response.IsSuccessStatusCode
        });
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsValidData()
    {
        var response = await _client.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
        Assert.NotNull(response);

        Assert.All(response, f => Assert.Equal("WeatherForecastController", f.Source));

        var expectedOperator = GetExpectedOperator();
        Assert.All(response, f => Assert.Equal(expectedOperator, f.OperatorName));

        await Verify(response)
            .ScrubMember("TemperatureC")
            .ScrubMember("TemperatureF")
            .ScrubMember("Date")
            .ScrubMember("Summary");
    }

    [Theory]
    [InlineData(-10, "Freezing")]
    [InlineData(0, "Cool")]
    [InlineData(25, "Warm")]
    public async Task PostWeatherForecast_ReturnsValidData(int temperatureC, string summary)
    {
        var input = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = temperatureC,
            Summary = summary,
            OperatorName = "WeatherForecastController",
            Source = "WeatherForecastController"
        };

        var response = await _client.PostAsJsonAsync("/weatherforecast", input);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<WeatherForecast>();
        Assert.NotNull(result);
        Assert.Equal("WeatherForecastController", result.Source);

        var expectedOperator = GetExpectedOperator();
        Assert.Equal(expectedOperator, result.OperatorName);
        Assert.Equal(temperatureC, result.TemperatureC);
        Assert.Equal(summary, result.Summary);

        await Verify(result)
            .ScrubMember("TemperatureC")
            .ScrubMember("TemperatureF")
            .ScrubMember("Date")
            .ScrubMember("Summary");
    }

    private static string GetExpectedOperator()
    {
        var hour = DateTime.Now.Hour;
        if (hour >= 0 && hour < 8)
            return "operator_night";
        if (hour >= 8 && hour < 16)
            return "operator_day";
        return "operator_evening";
    }
}