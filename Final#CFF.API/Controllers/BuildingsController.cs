using Final_CFF.BL.DTOs.BuildingDTOs;
using Final_CFF.BL.Services.Implements;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingsController (IBuildingService _service): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
            //try
            //{
            //return Ok(await _service.GetAllAsync());
            //}
            //catch (Exception ex) {

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBuildingDTO dto)
        {
            await _service.CreateAsync(dto);    
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult>Update(Guid id, UpdateBuildingDTO dto)
        {
            await _service.UpdateAsync(dto, id);
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
