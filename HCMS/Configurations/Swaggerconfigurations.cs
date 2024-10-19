using Swashbuckle.AspNetCore.Filters;

namespace HCMS.API.Configurations
{
    public static class Swaggerconfigurations
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HCMS Api", Version = "v1" });
                //  opt.CustomSchemaIds(type => type.FriendlyId().Replace("[", "Of").Replace("]", ""));
                opt.CustomOperationIds(options => $"{options.ActionDescriptor.RouteValues["action"]}");
                opt.DescribeAllParametersInCamelCase();
                opt.OrderActionsBy(x => x.RelativePath);
                opt.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                opt.OperationFilter<SecurityRequirementsOperationFilter>();
                //   opt.SchemaFilter<EnumSchemaFilter>();
            });

            return services;
        }
    }
}
