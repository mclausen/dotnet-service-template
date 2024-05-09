using FluentValidation;

namespace __BoundedContext__.__ServiceName__.Api.Endpoints.WeatherForecast;

public class WeatherForecastRequestValidator : AbstractValidator<WeatherForecastRequest>
{
    public WeatherForecastRequestValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.TemperatureC)
            .InclusiveBetween(-20, 55);
    }
}