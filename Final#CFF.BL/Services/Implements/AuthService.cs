using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.UserRerpository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_CFF.BL.Services.Implements;

public class AuthService(UserManager<User> _userManager,
    SignInManager<User> _signInManager) : IAuthService
{
    public async Task<string> LoginAsync(LoginDTO DTO)
    {
        User user = null;
        if (DTO.UserNameOrUserEmail.Contains('@'))
        {
            user = await _userManager.FindByEmailAsync(DTO.UserNameOrUserEmail);
        }
        else
        {
            user = await _userManager.FindByNameAsync(DTO.UserNameOrUserEmail);
        }

        await _signInManager.PasswordSignInAsync(user, DTO.Password, DTO.RememberMe, true);
    }

    public async Task RegisterAsync(RegisterDTO DTO)
    {
        User user = new User
        {
            Email = DTO.Email,
            FullName = DTO.FullName,
            UserName = DTO.UserName
        };
        var result = await _userManager.CreateAsync(user, DTO.Password);

        //if(!result.Succeeded)
        //{
        //    foreach(var error in result.Errors)
        //    {
        //        ModelState.AddModelError("",error.Description);
        //    }
        //}
    }
    [Authorize]
    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }
}
