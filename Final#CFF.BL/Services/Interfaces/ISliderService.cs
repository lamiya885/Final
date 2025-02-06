using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.SliderDTOs;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface ISliderService
    {

        Task<IEnumerable<SliderGetDTO>> GatAllAsync();
        Task<Guid> CreateAsync(CreateSliderDTO dto);
        Task<Guid> UpdateAsync(UpdateSliderDTO dto,Guid id);
        Task<Guid> DeleteAsync(Guid id);
    }
}
