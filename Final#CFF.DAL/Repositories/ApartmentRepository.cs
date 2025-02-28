using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.ApartmentRepository;
using Final_CFF.DAL.Context;

namespace Final_CFF.DAL.Repositories;

public class ApartmentRepository:GenericRepository<Apartment>,IApartmentRepository
{
    public ApartmentRepository(FinalDbContext _context):base(_context)
    {
        
    }
}
