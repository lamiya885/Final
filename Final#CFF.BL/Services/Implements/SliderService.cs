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
using Microsoft.AspNetCore.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_CFF.BL.Services.Implements;

public class SliderService(ISliderRepository _repo, IWebHostEnvironment _env) : ISliderService
{
    public async Task<IEnumerable<SliderGetDTO>> GatAllAsync()
    {
        var entities = _repo.GetAll();

        return entities.Select(x => new SliderGetDTO
        {
            Title = x.Title,
            Subtitle = x.Subtitle,
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
        slider.ImageUrl = await dto.Image!.UploadAsync(_env.WebRootPath, "img", "slider");

        await _repo.AddAsync(slider);
        await _repo.SaveAsync();
        return slider.Id;

    }

    public async Task<Guid> UpdateAsync(UpdateSliderDTO dto, Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        entity.Title = dto.Title;
        entity.Subtitle = dto.Subtitle;
        string path = Path.Combine(_env.WebRootPath, "img", "slider", entity.ImageUrl);
        using (Stream stream = System.IO.File.Create(path))
        {
            await dto.Image!.CopyToAsync(stream);
        }
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
