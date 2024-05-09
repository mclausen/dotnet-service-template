using __BoundedContext__.__ServiceName__.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace __BoundedContext__.__ServiceName__.Api.Endpoints.WeatherForecast;

public class ReportWeatherForecastEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/weatherforecast",  ([FromBody]WeatherForecastRequest request) 
                => Results.Ok(new WeatherForecast(request.Date, request.TemperatureC, request.Summary)))
        .AddEndpointFilter<CustomValidatorFilter<WeatherForecastRequest>>()
        .WithDisplayName("Report a weather forecast")
        .WithDescription("Used to report a weather forecast")
        .WithTags(Tags.WeatherForecast)
        .Produces<WeatherForecast>()
        .ProducesProblem(400)
        .WithOpenApi();
    }
}