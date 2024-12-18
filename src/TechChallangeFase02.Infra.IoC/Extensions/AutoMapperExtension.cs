using Microsoft.Extensions.DependencyInjection;
using TechChallangeFase02.Application.Mappings;

namespace TechChallangeFase02.Infra.IoC.Extensions;

public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoToEntityMap));
        return services;
    }
}