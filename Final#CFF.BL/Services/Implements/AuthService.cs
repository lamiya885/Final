using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Final_CFF.BL.Services.Implements;

public class AuthService(UserManager<User> _userManager,
    SignInManager<User> _signInManager,IOptions<SmtpOptions> option) :IAuthService
{
    private readonly SmtpOptions _smtpOptions = option.Value;
    public async Task LoginAsync(LoginDTO DTO)
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

       var result= await _signInManager.PasswordSignInAsync(user, DTO.Password, DTO.RememberMe, true);
        if (!result.Succeeded)
            throw new NotFoundException<User>();
      
    }
    public async Task<string> RegisterAsync(RegisterDTO DTO)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == DTO.Email))
        {
            throw new ExistException<User>();
        }
        else if (await _userManager.Users.AnyAsync(x => x.UserName == DTO.UserName))
        {
            throw new ExistException<User>();
        }
        User user = new User
        {
            Email = DTO.Email,
            FullName = DTO.FullName,
            UserName = DTO.UserName
        };
        var result = await _userManager.CreateAsync(user, DTO.Password);
        if (result.Succeeded)
        {
            return "User registered successfully";
        }
        return "User  was not registered successfully";
    }
    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }
    //public async Task ForgotPassword(string Email)
    //{
    //    var user = await _userManager.FindByEmailAsync(Email);

    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    var frontendUrl = "https://yourfrontend.com/reset-password";
    //    var resetLink = $"{frontendUrl}?token={token}&email={user.Email}";
    //    SmtpClient smtp = new SmtpClient
    //    {
    //        Host = _smtpOptions.Host,
    //        Port = _smtpOptions.Port,
    //        EnableSsl = true,
    //        Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password)
    //    };

    //    MailMessage msg = new MailMessage
    //    {
    //        From = new MailAddress(_smtpOptions.Username, ""),
    //        Subject = "Reset Password",
    //        Body = $"<p>Şifrənizi  sıfırlamaq üçün <a href='{resetLink}'>bu linkə</a> klikləyin.</p>",
    //        IsBodyHtml = true
    //    };

    //    smtp.Send(msg);

    //}
   
    
    //public Task ResetPassword(string Password)
    //{
    //    var user = await _usermanager.FindByEmailAsync(vm.Email);
    //    if (user == null)
    //    {
    //        throw new NotFoundException<User>();
    //    }

    //    var resetPassResult = await _usermanager.ResetPasswordAsync(user, vm.Token, vm.NewPassword);
    //    if (resetPassResult.Succeeded)
    //    {
    //        return Ok("Everything was successfully completed");
    //    }

    //   
    //}

}
