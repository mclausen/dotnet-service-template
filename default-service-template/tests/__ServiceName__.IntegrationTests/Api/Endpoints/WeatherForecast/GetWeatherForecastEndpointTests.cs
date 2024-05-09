using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace __ServiceName__.IntegrationTests.Api.Endpoints.WeatherForecast;

public class GetWeatherForecastEndpointTests
{
    [Fact]
    public async Task GetWeatherForecastEndpointReturnsSuccess()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        
        var response = await client.GetAsync("/weatherforecast");

        response
            .IsSuccessStatusCode
            .Should().BeTrue();
    }
}