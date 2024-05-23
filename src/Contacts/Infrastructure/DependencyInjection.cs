using System.Text;
using Contacts.Application.Interfaces.Authentication;
using Contacts.Application.Interfaces.Persistence;
using Contacts.Application.Interfaces.Services;
using Contacts.Infrastructure.Authentication;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Contacts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDbContext<DatabaseContext>(
        options =>
            options.UseSqlite(configuration.GetConnectionString("ContactsConnection"))
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(loggerBuilder => loggerBuilder.AddConsole()))
            .EnableSensitiveDataLogging()
        );

        services.AddTransient<IContactsRepository, ContactsRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }
    public static IServiceCollection AddAuth(
    this IServiceCollection services,
    ConfigurationManager configuration)
    {
        var JwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSettings.Secret)),

                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
}