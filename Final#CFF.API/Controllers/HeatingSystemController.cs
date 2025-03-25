using Final_CFF.BL.DTOs.HeatingSystemDTOs;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HeatingSystemController(IHeatingSystemService _service) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [Authorize(Roles = "Resident")]
        [HttpPost]  
        public async Task<IActionResult> Create(CreateHeatingDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok(dto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AriithmeticMean()
        {
            return Ok(await _service.ArithmeticMean());

        }

    }
}
