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
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
            return services;
        }
    }
}
