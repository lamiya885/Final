using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;

namespace Final_CFF.BL.Services.Interfaces;

public  interface IUserService
{
     //Task<string> Create(RegisterDTO DTO);
    Task<Guid> Delete(string username);
    Task<bool> Login(LoginDTO DTO);
}
