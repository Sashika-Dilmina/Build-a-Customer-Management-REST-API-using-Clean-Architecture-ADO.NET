using CustomerManagement.Application.Interfaces;
using CustomerManagement.Infrastructure.Persistence;
using CustomerManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}