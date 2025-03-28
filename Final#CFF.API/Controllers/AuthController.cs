﻿using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO DTO)
        {
            await _service.RegisterAsync(DTO);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO DTO)
        {
            return Ok(await _service.LoginAsync(DTO));
        }
        [HttpPost]
        public  async Task<IActionResult> LogOut()
        {
            await  _service.LogOut();
            return Ok();
        }

    }
}
