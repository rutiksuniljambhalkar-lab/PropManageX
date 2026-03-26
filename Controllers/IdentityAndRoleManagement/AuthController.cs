using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropManageX.DTOs.OAuth;
using PropManageX.Services.IdentityAndRoleManagement;

namespace PropManageX.Controllers.IdentityAndRoleManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        

        //---------------Register---------------------------

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (result == "User already exists")
                return BadRequest(result);
            return Ok(result);
        }
        

        //---------------Login---------------------------

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)

        {

        

            var token = await _authService.Login(loginDto);

            if (token == null)

            {

                return Unauthorized("Invalid email or password.");

            }

            // Return the token as a JSON object

            return Ok(new { Token = token });

        }





    }
}