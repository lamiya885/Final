using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Extentions;
using Final_CFF.BL.ExternalServices.Abstracts;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Final_CFF.BL.Services.Implements;

public class AuthService(UserManager<User> _userManager,
    SignInManager<User> _signInManager, IOptions<SmtpOptions> option, IEmailService _emailService,ITokenHandler _tokenHandler) : IAuthService
{
    private readonly SmtpOptions _smtpOptions = option.Value;
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

        if (user == null)
            throw new NotFoundException<User>();

        var roles=await _userManager.GetRolesAsync(user);
        string userRole = roles.FirstOrDefault();

        var result = await _signInManager.PasswordSignInAsync(user, DTO.Password, DTO.RememberMe, true);
        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                throw new Exception("Wait untill" + user.LockoutEnd!.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (result.IsNotAllowed)
            {
                throw new Exception("Please confirm your email. If you have confirmed your email ,UserName or Email is incorrect!");
            }
        }



        return _tokenHandler.CreateToken(new DTOs.CommonDTOs.JwtDTO
       { 
            FullName=user.FullName,
            Email=user.Email,
            Role=userRole
            //Role=(int)user.Role
        });

    }
    public async Task<string> RegisterAsync(RegisterDTO DTO)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == DTO.Email))
        {
            throw new Exception();
            //throw new ExistException<User>();
        }
        if (await _userManager.Users.AnyAsync(x => x.UserName == DTO.UserName))
        {
            throw new Exception();
            //throw new ExistException<User>();
        }
        User user = new User
        {
            Email = DTO.Email,
            FullName = DTO.FullName,
            ApartmentNo = DTO.ApartmentNo,
            UserName = DTO.UserName,
            ImageUrl = await DTO.Image.UploadAsync()
        };


        var result = await _userManager.CreateAsync(user, DTO.Password);
        if (!result.Succeeded)
        {
            string errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return $"User was not registered successfully: {errors}";
        }
        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        _emailService.SendEmailConfirmationAsync(user.Email, user.UserName, token);
        return "User registered successfully";
    }
    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }
    public async Task VerifyEmail(string token, string user)
    {
        var entity = await _userManager.FindByNameAsync(user);
        var result = await _userManager.ConfirmEmailAsync(entity, token.Replace(' ', '+'));
        if (!result.Succeeded)
        {
            string errors = string.Join(", ", result.Errors.Select(e => e.Description));
        }
        await _signInManager.SignInAsync(entity, true);
    }

    //public async Task<string> SendVerificationEmailAsync(string email, string token)
    //{
    //    var user = await _userManager.FindByEmailAsync(email);
    //    if (user == null)
    //        throw new NotFoundException<User>();

    //    await _emailService.SendEmailVereficationAsync(email, token);

    //    return "Verification email sent.";
    //}

    //public async Task<bool> VerifyAccountAsync(string email, string token)
    //    => await _emailService.VerifyEmailAsync(email, token);


    //public async Task ForgotPassword(string Email)
    //{
    //    var user = await _userManager.FindByEmailAsync(Email);

    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    SmtpClient smtp = new SmtpClient
    //    {
    //        Host = _smtpOptions.Host,
    //        Port = _smtpOptions.Port,
    //        EnableSsl = true,
    //        Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password)
    //    };

    //    MailMessage message = new MailMessage
    //    {
    //        From = new MailAddress(_smtpOptions.Username, ""),
    //        Subject = "Reset Password",
    //        Body = $"<p>Şifrənizi  sıfırlamaq üçün <a href='{resetLink}'>bu linkə</a> klikləyin.</p>",
    //        IsBodyHtml = true
    //    };

    //    smtp.Send(message);

    //}


    //public Task ResetPassword(string Password)
    //{
    //    var user = await _usermanager.FindByEmailAsync(vm.Email);
    //    if (user == null)
    //    {
    //        throw new NotFoundException<User>();
    //    }

    //    var resetPasswordResult = await _usermanager.ResetPasswordAsync(user, vm.Token, vm.NewPassword);
    //    if (resetPasswordResult.Succeeded)
    //    {
    //        return Ok("Everything was successfully completed");
    //    }

    //   
    //}

}
