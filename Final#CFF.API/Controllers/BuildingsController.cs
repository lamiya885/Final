using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController (IBuildingService _service): ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBuildingDTO dto)
        {
            await _service.CreateAsync(dto);    
            return Ok(dto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
