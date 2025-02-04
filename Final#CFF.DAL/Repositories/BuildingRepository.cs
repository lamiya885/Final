using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.BuildingRepository;
using Final_CFF.DAL.Context;

namespace Final_CFF.DAL.Repositories
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(FinalDbContext _context) : base(_context)
        {
        }
    }
}
