using FluentValidation;
using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using HCMS.Application.Features.BusinessUnits.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HCMS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(typeof(CreateBusinessUnitCommand).Assembly);
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateBusinessUnitCommand).Assembly);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        services.AddScoped<IGenerateBusinessUnitCodeService, GenerateBusinessUnitCodeService>();

        return services;
    }
}
