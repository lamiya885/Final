using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.BL.DTOs.HouseholdExpensesDTOs;
using Final_CFF.Core.Entity;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IHouseholdExpensesService
    {
        Task<IEnumerable<HouseholdExpenses>> GetAllAsync();
        Task<Guid> CreateAsync(CreateHouseholdExpensesDTO DTO);
        Task<Guid> UpdateAsync(UpdateHoueholdExpenesDTO DTO, Guid id);
        Task<Guid> DeleteAsync(Guid id);
        Task<decimal> EachApartmentHasToPay(Guid id);
        Task<decimal> EachApartmentHasToPayAll();
    }
}
