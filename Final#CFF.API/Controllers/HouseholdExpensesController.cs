using Final_CFF.BL.DTOs.HouseholdExpensesDTOs;
using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdExpensesController (IHouseholdExpensesService _service): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHouseholdExpensesDTO DTO)
        {
            await _service.CreateAsync(DTO);
            return Ok(DTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateHoueholdExpenesDTO DTO)
        {
            await _service.UpdateAsync(DTO, id);
            return Ok(DTO);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> EachApartmentHasToPay(Guid id)
        {
            return Ok(await _service.EachApartmentHasToPay(id));
        }
    }
}
