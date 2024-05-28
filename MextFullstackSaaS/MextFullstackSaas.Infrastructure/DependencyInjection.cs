using MextFullstackSaas.Application.Common.Interfaces;
using MextFullstackSaas.Infrastructure.Services;
using MextFullstackSaaS.Domain.Identity;
using MextFullstackSaaS.Domain.Settings;
using MextFullstackSaaS.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;

//extensiions örneği

namespace MextFullstackSaaS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(
                container => container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(JwtSettings=>configuration.GetSection("JwtSettings").Bind(JwtSettings));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;


                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IJwtService, JwtManager>();

            //resend
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>(o =>
            {
                o.ApiToken = configuration.GetSection("ReSendApiKey").Value!;
            });
            services.AddTransient<IResend, ResendClient>();

            return services;
        }
    }
}