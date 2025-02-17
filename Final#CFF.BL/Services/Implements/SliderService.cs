using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Extentions;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.SliderRepository;

namespace Final_CFF.BL.Services.Implements;

public class SliderService(ISliderRepository _repo) : ISliderService
{
    public async Task<IEnumerable<SliderGetDTO>> GatAllAsync()
    {
        var entities = _repo.GetAll();

        return entities.Select(x => new SliderGetDTO
        {
            Title = x.Title,
            Subtitle = x.Subtitle,
           //Image=x.ImageUrl.UploadAsync
        });

    }
    public async Task<Guid> CreateAsync(CreateSliderDTO dto)
    {
        Slider slider = new Slider()
        {
            Title = dto.Title,
            Subtitle = dto.Subtitle,
            ImageUrl= await dto.Image.UploadAsync()
        };

        await _repo.AddAsync(slider);
        await _repo.SaveAsync();
        return slider.Id;

    }

    public async Task<Guid> UpdateAsync(UpdateSliderDTO dto, Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        entity.Title = dto.Title;
        entity.Subtitle = dto.Subtitle;
        //entity.ImageUrl=dto.Image
        await _repo.AddAsync(entity);
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

}
