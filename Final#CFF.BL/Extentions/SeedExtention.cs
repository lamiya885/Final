using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace Final_CFF.BL.Extentions;

public static class SeedExtention
{
    public static void UseUserSeed(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<User>>();

            //if (!roleManager.Roles.Any())
            //{
            //    foreach (var item in Enum.GetValues(typeof(Roles)))
            //    {
            //        roleManager.CreateAsync(new IdentityRole(item.ToString())).Wait();
            //    }
            //}
        }
    }
}
