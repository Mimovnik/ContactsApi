
using Contacts.Api.Mapping;

namespace Contacts.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        return services;
    }
}