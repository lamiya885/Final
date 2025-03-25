using Final_CFF.BL.DTOs.HouseholdExpensesDTOs;
using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseholdExpensesController (IHouseholdExpensesService _service): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHouseholdExpensesDTO DTO)
        {
            await _service.CreateAsync(DTO);
            return Ok(DTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateHoueholdExpenesDTO DTO)
        {
            await _service.UpdateAsync(DTO, id);
            return Ok(DTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [Authorize(Roles = "Resident")]
        [HttpPost]
        public async Task<IActionResult> EachApartmentHasToPay(Guid id)
        {
            return Ok(await _service.EachApartmentHasToPay(id));
        }
        [Authorize(Roles = "Resident")]
        [HttpPost]
        public async Task<IActionResult> EachApartmentHasToPayAll()
        {
            return Ok(await _service.EachApartmentHasToPayAll());
        }
    }
}
