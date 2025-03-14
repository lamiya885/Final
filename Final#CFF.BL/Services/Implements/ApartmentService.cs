using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.AparmentDTOs;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.ApartmentRepository;
using Final_CFF.DAL.Context;

namespace Final_CFF.BL.Services.Implements;

public class ApartmentService(IApartmentRepository _repo) : IApartmentService
{
    public Task<IEnumerable<Apartment>> GetAllAsync()
    {
        var entities = _repo.GetAll();
        return Task.FromResult<IEnumerable<Apartment>>(entities.Select(x => new Apartment
        {
            HouseNo = x.HouseNo,
            BuildingId=x.BuildingId,
            BuildingName=x.BuildingName,
        }));
    }

    public async Task<Guid> CreateAsync(CreateApartmentDTO DTO)
    {
        Apartment apartment = new Apartment
        {
            HouseNo=DTO.No,
            BuildingId=DTO.BuildingId,
            BuildingName=DTO.BuildingName
        };

        await _repo.AddAsync(apartment);
        await _repo.SaveAsync();
        //await _context.SaveChangesAsync();
        return apartment.Id;

    }

    public async Task<Guid> UpdateAsync(UpdateApartmentDTO DTO, Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);

        entity.BuildingName = DTO.BuildingName;

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
