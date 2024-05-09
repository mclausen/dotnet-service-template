using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace __ServiceName__.IntegrationTests.Api.Endpoints.WeatherForecast;

public class ReportWeatherForecastEndpointTests
{
    [Fact]
    public async Task ReportWeatherForecastEndpointReturnsSuccess()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        
        var response = await client.PostAsync("/weatherforecast", JsonContent.Create(new
        {
            Date = "2022-12-25",
            TemperatureC = 25,
            Summary = "Sunny"
        
        }));

        response
            .IsSuccessStatusCode
            .Should().BeTrue();
    }
    
    [Fact]
    public async Task ReportWeatherForecastEndpointWithInvalidPayloadReturnsFailed()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        
        var response = await client.PostAsync("/weatherforecast", JsonContent.Create(new
        {
            Date = "2022-12-25",
            TemperatureC = -55,
            Summary = "Sunny"
        
        }));

        response
            .IsSuccessStatusCode
            .Should().BeFalse();
    }
}