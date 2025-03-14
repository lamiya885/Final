using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity;

namespace Final_CFF.Core.Repositories.HouseholdExpensesRepository
{
    public interface IHouseholdExpensesRepository:IGenericRepository<HouseholdExpenses>
    {
         Task<int> ApartmentCountAsync();
    }
}
