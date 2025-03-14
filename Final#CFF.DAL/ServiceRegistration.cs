﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Repositories.ApartmentRepository;
using Final_CFF.Core.Repositories.BuildingRepository;
using Final_CFF.Core.Repositories.HeatingSystemRepository;
using Final_CFF.Core.Repositories.HouseholdExpensesRepository;
using Final_CFF.Core.Repositories.SliderRepository;
using Final_CFF.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Final_CFF.DAL
{
    public static  class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IHeatingSystemRepository, HeatingSytemRepository>();
            services.AddScoped<IHouseholdExpensesRepository, HouseholdExpensesRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
