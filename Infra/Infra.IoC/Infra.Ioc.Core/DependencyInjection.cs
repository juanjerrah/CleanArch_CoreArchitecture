using Domain.Core.Bus;
using Domain.Core.Interfaces;
using Domain.Core.Security;
using Domain.Core.Token;
using Infra.Data.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc.Core;

public class DependencyInjection
{
    public static IServiceCollection AddServices(IServiceCollection services)
    {
        services.AddScoped<IBus, Bus>();
        services.AddScoped<ISecurity, SecurityService>();
        services.AddTransient<ITokenService, TokenService>();

        services.AddScoped<IBaseRepository, BaseRepository>();
        return services;
    }
}