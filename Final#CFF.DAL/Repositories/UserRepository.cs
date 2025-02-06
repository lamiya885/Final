using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.UserRepository;
using Final_CFF.DAL.Context;

namespace Final_CFF.DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(FinalDbContext _context) : base(_context)
    {
    }
}
