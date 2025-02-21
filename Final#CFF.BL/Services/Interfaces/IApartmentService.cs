using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.AparmentDTOs;
using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.Core.Entity;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IApartmentService
    {
        Task<IEnumerable<Building>> GetAllAsync();
        Task<Guid> CreateAsync(CreateApartmentDTO DTO);
        Task<Guid> UpdateAsync(UpdateApartmentDTO DTO, Guid id);
        Task<Guid> DeleteAsync(Guid id);
    }
}
