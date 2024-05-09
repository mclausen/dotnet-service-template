using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace __BoundedContext__.__ServiceName__.Api.Endpoints.WeatherForecast;

public class ReportWeatherForecastEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/weatherforecast", async (IValidator<WeatherForecastRequest> validator, [FromBody]WeatherForecastRequest request) =>
        {
            var validationResult = await validator.ValidateAsync(request);
            return validationResult.IsValid == false ? 
                Results.ValidationProblem(validationResult.ToDictionary()) : 
                Results.Ok(new WeatherForecast(request.Date, request.TemperatureC, request.Summary));
        })
        .WithTags(Tags.WeatherForecast)
        .Produces<WeatherForecast>()
        .ProducesProblem(400)
        .WithOpenApi();
    }
}