using Contacts.Application.Interfaces.Persistence;

namespace Contacts.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IContactsRepository, ContactsRepository>();
        return services;
    }
}