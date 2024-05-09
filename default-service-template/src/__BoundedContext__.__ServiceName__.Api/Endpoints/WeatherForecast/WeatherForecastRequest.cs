namespace __BoundedContext__.__ServiceName__.Api.Endpoints.WeatherForecast;

public record WeatherForecastRequest(DateOnly Date, int TemperatureC, string? Summary);