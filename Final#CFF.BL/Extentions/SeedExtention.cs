﻿using System;
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
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any())
            {
                foreach (var item in Enum.GetValues(typeof(Roles)))
                {
                    roleManager.CreateAsync(new IdentityRole(item.ToString())).Wait();
                }
            }
            if (!userManager.Users.Any(x => x.NormalizedUserName == "ADMIN"))
            {
                User user = new User()
                {
                    FullName = "admin",
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    ImageUrl = "photo.jpg",

                    ApertmentId= new Guid("4a8b1bb8-74d0-4b0b-b1c5-ff6f318401e8")
                };
                userManager.AddToRoleAsync(user, nameof(Roles.Admin)).Wait();
            }
        }
    }
}
