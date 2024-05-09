namespace __BoundedContext__.__ServiceName__.Api.Endpoints.WeatherForecast;

public class GetWeatherForecastEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithTags(Tags.WeatherForecast)
            .WithOpenApi();
    }
    
    
}