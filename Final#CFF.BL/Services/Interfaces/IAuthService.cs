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
        Task RegisterAsync(RegisterDTO DTO);

    }
}
