using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        return services;
    }
}
