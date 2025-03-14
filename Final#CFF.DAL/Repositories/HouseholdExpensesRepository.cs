using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.HouseholdExpensesRepository;
using Final_CFF.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Final_CFF.DAL.Repositories
{
    public class HouseholdExpensesRepository:GenericRepository<HouseholdExpenses>,IHouseholdExpensesRepository
    {
        private readonly FinalDbContext _context;
        public HouseholdExpensesRepository(FinalDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<int> ApartmentCountAsync()
        {
          var result= await _context.Apartments.CountAsync();
            return result;
        }
    }
}
