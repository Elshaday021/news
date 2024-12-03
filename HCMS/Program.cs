using HCMS.Api;
using HCMS.Api.Filters;
using HCMS.API.Configurations;
using HCMS.Application;
using HCMS.ApplicationLayer.UserAccount;
using HCMS.Infrastructure;
using HCMS.Persistance.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserAccount, UserAccountRegister>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ApiExceptionFilterAttribute>();

builder.Services.AddEndpointsApiExplorer()
    .AddSwagger()
      .AddInfrastructureService()
    .AddPersistenceService(builder.Configuration)
    .AddApplicationServices()
    .AddScoped<HttpContextAccessor>(); ;
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await DataSeeder.SeedData(app);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
