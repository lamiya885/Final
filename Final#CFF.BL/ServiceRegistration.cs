using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Services.Implements;
using Final_CFF.BL.ExternalServices.Abstracts;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.ExternalServices.Implements;
using Microsoft.Extensions.Configuration;

namespace Final_CFF.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenHandler,TokenHandler>();
            services.AddScoped<IStripeService,StripeService>();
            services.AddScoped<IHeatingSystemService,HeatingSystemService>();
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
          services.Configure<StripeSettings>(configuration.GetSection("Stripe"));
            return services;
        }

    }
}
