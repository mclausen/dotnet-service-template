using System.Reflection;
using __BoundedContext__.__ServiceName__.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace __BoundedContext__.__ServiceName__.Api.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection servicesCollection
        , Assembly assembly)
    {
        var endpointServiceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false }
                           && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(endpoint => ServiceDescriptor.Transient(typeof(IEndpoint), endpoint))
            .ToArray();

        servicesCollection.TryAddEnumerable(endpointServiceDescriptors);

        return servicesCollection;
    }

    public static IApplicationBuilder MapEndpoints(
        this WebApplication app
        , RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}