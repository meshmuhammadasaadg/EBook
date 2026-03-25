using EBook.Domain.Entities;
using EBook.Infrastructure.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EBook.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("No connection string with this name");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddMapsterConfig()
                .AddAuthenticationConfig();

        return services;
    }
    private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    private static IServiceCollection AddAuthenticationConfig(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }


    //private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    //{
    //    // Register FluentValidation 
    //    services.AddFluentValidationAutoValidation()
    //                        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    //    return services;
    //}
}
