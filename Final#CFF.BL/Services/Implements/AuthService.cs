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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_CFF.BL.Services.Implements;

public class AuthService(UserManager<User> _userManager,SignInManager<User>) : IAuthService
{
    public async Task<string> LoginAsync(LoginDTO DTO)
    {
        var user = await _repo.GetAll()
            .Where(x => x.UserEmail == DTO.UserNameOrUserEmail || x.UserEmail == DTO.UserNameOrUserEmail).FirstOrDefaultAsync();
        return HashHelper.VerifyHashedPassword(user.PasswordHash, DTO.Password).ToString();
    }

    public async Task RegisterAsync(RegisterDTO DTO)
    {

        var user = await _repo.GetAll()
            .Where(x => x.UserEmail == DTO.UserName || x.UserEmail == DTO.Email).FirstOrDefaultAsync();
        if (user is null)
        {
            if (user.UserName == DTO.UserName)
            {
                throw new ExistException("User Name already using ");
            }
            else
            {
                throw new ExistException("Email already using");
            }
            var entity = new User()
            {
                UserName = DTO.UserName,
                UserEmail = DTO.Email,
                FullName = DTO.FullName,

            };


            await _repo.AddAsync(entity);
            await _repo.SaveAsync();


        }
    }
}
