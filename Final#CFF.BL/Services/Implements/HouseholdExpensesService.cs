using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.BL.DTOs.HeatingSystemDTOs;
using Final_CFF.BL.DTOs.HouseholdExpensesDTOs;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.HouseholdExpensesRepository;

namespace Final_CFF.BL.Services.Implements
{
    public class HouseholdExpensesService(IHouseholdExpensesRepository _repo) : IHouseholdExpensesService
    {
        public Task<IEnumerable<HouseholdExpenses>> GetAllAsync()
        {
            var entities = _repo.GetAll();

            return (Task<IEnumerable<HouseholdExpenses>>)entities.Select(x => new HouseholdExpensesGetDTO
            {
                Price = x.Price,
                Title = x.Title,
                IsPaid = x.IsPaid
            });
        }
        public async Task<Guid> CreateAsync(CreateHouseholdExpensesDTO DTO)
        {
            HouseholdExpenses expenses = new HouseholdExpenses
            {
                Price = DTO.Price,
                Title = DTO.Title,
                IsPaid = DTO.IsPaid
            };
            await _repo.AddAsync(expenses);
            await _repo.SaveAsync();
            return expenses.Id;
        }
        public async Task<Guid> UpdateAsync(UpdateHoueholdExpenesDTO DTO, Guid id)
        {
            var entity= await _repo.GetByIdAsync(id);

            entity.Price = DTO.Price;
            entity.IsPaid = DTO.IsPaid;
            entity.Title = DTO.Title;

            await _repo.SaveAsync();
            return entity.Id;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            _repo.Remove(entity);
            await _repo.SaveAsync();
            return entity.Id;
        }

        public async Task<decimal> EachApartmentHasToPay(Guid id)
        {
            var entity=await _repo.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException<HouseholdExpenses>();

            var count = await _repo.ApartmentCountAsync();

            var result = entity.Price / count;
            return result;
        }

        public async Task<decimal> EachApartmentHasToPayAll()
        {
            var entities =  _repo.GetAll();

            var count= await _repo.ApartmentCountAsync();

            var result = entities.Sum(e => e.Price) / count;
            return (decimal)result;
        }
    }
}
