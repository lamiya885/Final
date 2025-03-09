using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.HeatingSystemDTOs;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IHeatingSystemService
    {
        Task<IEnumerable<HeatingGetDTO>> GetAllAsync();
        Task<Guid> CreateAsync(CreateHeatingDTO DTO);
        Task<IEnumerable<double>> ArithmeticMean();
    }
}
