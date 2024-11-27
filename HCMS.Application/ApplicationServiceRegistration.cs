using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Services;
using HCMS.Service.ValueConverterService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SMS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateBusinessUnitCommand).Assembly);
        });
        services.AddScoped<IGenerateBusinessUnitCodeService, GenerateBusinessUnitCodeService>();

        return services;
    }
}
