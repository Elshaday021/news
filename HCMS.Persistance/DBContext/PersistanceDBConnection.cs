using HCMS.ApplicationLayer.UserAccount;
using HCMS.Services.DataService;
using HCMS.Services.EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HCMS.Persistance.DBContext
{
    public static class PersistanceDBConnection
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<HCMSDBContext>(item => item.UseSqlServer(configuration.GetConnectionString("HCMSConnectionString")));
            services.AddScoped<IDataService, HCMSDBContext>();
            services.AddScoped<IExchangeEmail, Exchange>();
            services.AddScoped<IUserAccount, UserAccountRegister>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<HCMSDBContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            //services.AddSingleton(configuration.GetSection("EmailConfiguration")
            //    .Get<EmailConfiguration>());
            // services.AddScoped<IDataService, SMSDbContext>();
            services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);
            return services;
        }
    }
}
