using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}