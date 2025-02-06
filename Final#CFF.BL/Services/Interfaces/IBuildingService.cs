using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.BuildingRepository;

namespace Final_CFF.BL.Services.Interfaces;

public interface IBuildingService
{
    Task<IEnumerable<Building>> GetAllAsync();
    Task<Guid> CreateAsync(CreateBuildingDTO DTO);
    Task<Guid> UpdateAsync(UpdateBuildingDTO DTO,Guid id);
    Task<Guid> DeleteAsync(Guid id);
}
