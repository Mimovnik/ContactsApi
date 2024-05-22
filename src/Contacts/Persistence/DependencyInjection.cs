using Contacts.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactsContext>(
        options =>
            options.UseSqlite(configuration.GetConnectionString("ContactsConnection"))
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(loggerBuilder => loggerBuilder.AddConsole()))
            .EnableSensitiveDataLogging()
        );

        services.AddTransient<IContactsRepository, ContactsRepository>();
        return services;
    }
}