using Final_CFF.BL.DTOs.AparmentDTOs;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "BuildingManager")]
    public class ApartmentsController(IApartmentService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateApartmentDTO DTO)
        {
            await _service.CreateAsync(DTO);
            return Ok(DTO);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id,UpdateApartmentDTO DTO)
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
    }
}
