using HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SMS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(typeof(IDomainEvent).Assembly);
        // services.AddValidatorsFromAssembly(typeof(ApproveShareholderCommand).Assembly);
        // services.AddScoped<IPaymentService, PaymentService>();
        //services.AddScoped<IDividendService, DividendService>();
        //services.AddScoped<IShareholderChangeLogService, ShareholderChangeLogService>();
        //services.AddMediatR(typeof(CreateBusinessUnitCommand).Assembly);
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateBusinessUnitCommand).Assembly);
            //    //  config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //    // config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            //    // config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        return services;
    }
}
