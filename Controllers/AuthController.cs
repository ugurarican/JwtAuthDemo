
using JwtAuthDemo.Dtos;
using JwtAuthDemo.Jwt;
using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var dto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };
            var result = await _service.AddUser(dto);
            if (result.IsSucceed)
                return Ok(result.Message);
            else 
                return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginUserDto = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };
            var result = await _service.LoginUser(loginUserDto);

            if (!result.IsSucceed)
                return BadRequest(result.Message);
            var user = result.Data;
            // TOKEN ÜRET
            // DI ile servis çekiyorum ( constructorda çekmiyorum çünkü yalnızca bu actionda kullanılacak.
            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwt(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinute = int.Parse(configuration["Jwt:ExpireMinute"]!)
            });
            return Ok(token);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Test()
        {
            return Ok("Test end-pointi response'u");
        }

    }
}
