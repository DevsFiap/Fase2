using Microsoft.Extensions.DependencyInjection;
using TechChallangeFase02.Application.Interfaces;
using TechChallangeFase02.Application.Services;
using TechChallangeFase02.Domain.Interfaces.Repositories;
using TechChallangeFase02.Domain.Interfaces.Services;
using TechChallangeFase02.Domain.Services;
using TechChallangeFase02.Infra.Data.Repository;

namespace TechChallangeFase02.Infra.IoC.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        //Application Layer
        services.AddScoped<IContatosAppService, ContatosAppService>();

        //Domain Layer
        services.AddScoped<IContatoDomainService, ContatoDomainService>();

        //Infrastructure Layer
        services.AddScoped<IContatosRepository, ContatoRepository>();

        return services;
    }
}