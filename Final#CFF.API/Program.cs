using System.Text;
using Final_CFF.BL;
using Final_CFF.BL.Exceptions;
using Final_CFF.BL.Helpers;
using Final_CFF.Core.Entity;
using Final_CFF.DAL;
using Final_CFF.DAL.Context;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver.Core.Misc;
using Stripe;

namespace Final_CFF.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<FinalDbContext>(option =>
            {
                option.UseSqlServer(
                builder.Configuration.GetConnectionString("MSSQL"));
            });
            builder.Services.AddControllers();
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddJwtOptions(builder.Configuration);
            builder.Services.AddEmailOptions(builder.Configuration);
            builder.Services.AddJwt(builder.Configuration);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddMemoryCache();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                       new OpenApiSecurityScheme
                       {
                          Reference = new OpenApiReference
                          {
                              Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                          }
                       },
                        Array.Empty<string>()
                    }
                });

            });



            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.MaxFailedAccessAttempts = 1;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(2);

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<FinalDbContext>();
            SmtpOptions opt = new();
            builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(SmtpOptions.Name));


            var configuration = builder.Configuration;

            StripeConfiguration.ApiKey = configuration.GetConnectionString("Stripe");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt=>
                {
                    opt.EnablePersistAuthorization();
                });
            }

            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<ExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException bEx)
                        {
                            context.Response.StatusCode = bEx.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = bEx.ErrorMessage
                            });

                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = "Bir xeta bas verdi!"
                            });
                        }
                    }
                        );
                }
            );

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
