using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO DTO);
        Task<string> RegisterAsync(RegisterDTO DTO);
        Task LogOut();
        Task VerifyEmail(string token, string user);
        //Task ForgotPassword(string Email);
    }
}
