//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Final_CFF.Core.Entity;
//using Final_CFF.Core.Repositories.UserRerpository;
//using Final_CFF.DAL.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Final_CFF.DAL.Repositories;

//public class UserRepository : GenericRepository<User>, IUserRepository
//{
//    private readonly FinalDbContext _context;
//    public UserRepository(FinalDbContext context) : base(context)
//    {
//        _context = context;
//    }
//    public User GetCurrentUser()
//    {
//        return new();
//    }

//    public Guid GetCurrentUserId()
//    {
//        throw new NotImplementedException();
//    }

//    public string GetCurrentUserName()
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<User> GetByUserName(string username)
//    {
//        return await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
//    }
//}
