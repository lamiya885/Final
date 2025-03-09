using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.HeatingSystemDTOs;
using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.Core.Repositories.HeatingSystemRepository;

namespace Final_CFF.BL.Services.Implements
{
    public class HeatingSystemService(IHeatingSystemRepository _repo):IHeatingSystemService
    {
        public async Task<IEnumerable<HeatingGetDTO>> GetAllAsync()
        {
            var entities = _repo.GetAll();

            return entities.Select(x => new HeatingGetDTO
            {
                HotWaterSupply = x.HotWaterSupply,
                RadiatorTemperature = x.RadiatorTemperature,    
                IsOn=x.IsOn
            });
        }

        public async Task<Guid> CreateAsync(CreateHeatingDTO DTO)
        {

            HeatingSystem heating = new HeatingSystem()
            {
              RadiatorTemperature= DTO.RadiatorTemperature,
              HotWaterSupply= DTO.HotWaterSupply,
              IsOn= DTO.IsOn
            };

            await _repo.AddAsync(heating);
            await _repo.SaveAsync();
            return heating.Id;
        }
        public async Task<IEnumerable<double>> ArithmeticMean()
        {
            double sumRadiator = 0;
            double sumWater = 0;
            var entities = _repo.GetAll();

            foreach (var entity in entities)
            {
                sumRadiator += entity.RadiatorTemperature;
                sumWater += entity.HotWaterSupply;

            }
            double meanRadiator = sumRadiator / entities.Count();
            double meanWater = sumWater / entities.Count();

            return new List<double>{ meanRadiator, meanWater };


        }
    }
}
