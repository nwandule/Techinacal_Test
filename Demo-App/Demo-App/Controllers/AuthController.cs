using Demo_App.Model;
using Demo_App.Model.Dto;
using Demo_App.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRep tokenrep;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRep tokenrep)
        {
            this.userManager = userManager;
            this.tokenrep = tokenrep;
        }

        // POST: /api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName
            };

            var result = await userManager.CreateAsync(user, registerRequestDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                var roleResult = await userManager.AddToRolesAsync(user, registerRequestDto.Roles);
                if (!roleResult.Succeeded)
                    return BadRequest(roleResult.Errors);
            }

            return Ok(new { message = "Registration Successful. Please login" });
        }

        // POST: /api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user == null) return BadRequest("Username or Password incorrect");

            var validPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (!validPassword) return BadRequest("Username or Password incorrect");

            var roles = await userManager.GetRolesAsync(user);
            var token = tokenrep.CreateJWToken(user, roles.ToList());

            return Ok(new { token });
        }
    }
}
