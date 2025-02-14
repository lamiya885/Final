using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.UserRerpository;

namespace Final_CFF.BL.Services.Implements;

public class UserService(IUserRepository _repo) : IUserService
{
    public async Task<string> Create(RegisterDTO DTO)
    {

        var existUser = await _repo.GetFirstAsync(x => x.Email == dto.Email || x.Username == dto.Username);
        if (existUser != null) throw new ExistException<User>();

    }

    public Task<Guid> Delete(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Login(LoginDTO DTO)
    {
        throw new NotImplementedException();
    }
}
