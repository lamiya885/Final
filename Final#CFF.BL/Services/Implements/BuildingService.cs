using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.BuildingRepository;

namespace Final_CFF.BL.Services.Implements
{
    public class BuildingService(IBuildingRepository _repo) : IBuildingService
    {
        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            var entities= _repo.GetAll();
            return entities.Select(x => new Building
            {
                BuildingName = x.BuildingName
            });
        }

        public async Task<Guid> CreateAsync(CreateBuildingDTO DTO)
        {
            var entity = new Building()
            {
                BuildingName = DTO.BuildingName
            };

            await _repo.AddAsync(entity);
            await _repo.SaveAsync();
            return entity.Id;
        }
        public async Task<Guid> UpdateAsync(UpdateBuildingDTO DTO, Guid id)
        {
            var entity= await _repo.GetByIdAsync(id);

            entity.BuildingName = DTO.BuildingName;

            await _repo.AddAsync(entity);
            await _repo.SaveAsync();
            return entity.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var entity=await _repo.GetByIdAsync(id);
           _repo.Remove(entity);
            await _repo.SaveAsync();
            return entity.Id;
        }
    }
}
