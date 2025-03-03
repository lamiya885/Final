using System.Configuration;
using System.Text;
using Final_CFF.BL.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace Final_CFF.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));
            return services;
        }
        public static IServiceCollection AddEmailOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<EmailOptions>(Configuration.GetSection(EmailOptions.Name));
            return services;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            JwtOptions options = new JwtOptions();
            options.Issuer = Configuration.GetRequiredSection("JwtOptions")["Issuer"];
            options.Audience = Configuration.GetRequiredSection("JwtOptions")["Audience"];
            options.SecretKey = Configuration.GetRequiredSection("JwtOptions")["SecretKey"];
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt=>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey =signInKey,
                    ValidAudience=options.Audience,
                    ValidIssuer=options.Issuer,
                    ClockSkew=TimeSpan.Zero 
                };
            });
            return services;
        }
        public static IServiceCollection AddJwt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(l =>
            {
                l.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                l.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                l.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(m =>
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
                m.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = securitykey
                };
            });
            return services;
        }
       
        public static IServiceCollection AddStripe(this IServiceCollection services,IConfiguration configuration)
        {

            StripeConfiguration.ApiKey = configuration.GetConnectionString("Stripe");
            return services;
        }
    }
}
