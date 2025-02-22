using Final_CFF.BL.DTOs.Auth;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService _service,IEmailService _emailService) : ControllerBase
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
            await _service.LoginAsync(DTO);
            return Ok();
        }
        

    }
}
