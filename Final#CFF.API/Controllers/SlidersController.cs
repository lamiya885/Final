﻿using Final_CFF.BL.DTOs.SliderDTOs;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SlidersController(ISliderService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GatAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderDTO DTO)
        {
            await _service.CreateAsync(DTO);
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
