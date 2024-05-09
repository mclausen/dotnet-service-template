using FluentValidation;

namespace __BoundedContext__.__ServiceName__.Api.Filters;

/// <summary>
/// Allows to extend the endpoint pipeline with a validator for the given entity.
/// </summary>
/// <remarks>https://medium.com/@malarsharmila/minimal-apis-with-filters-in-net-188afffce40a</remarks>
/// <typeparam name="T"></typeparam>
public class CustomValidatorFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext ctx, EndpointFilterDelegate next)
    {
        var validator = ctx.HttpContext.RequestServices.GetService<IValidator<T>>();
        if (validator is not null)
        {
            var entity = ctx.Arguments
                .OfType<T>()
                .FirstOrDefault(a => a?.GetType() == typeof(T));
            if (entity is not null)
            {
                var results = await validator.ValidateAsync((entity));
                if (!results.IsValid)
                {
                    return Results.ValidationProblem(results.ToDictionary());
                }
            }
            else
            {
                return Results.Problem("Error Not Found");
            }
        }

        return await next(ctx);
    }
}