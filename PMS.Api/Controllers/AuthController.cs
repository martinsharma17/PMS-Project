// File: PMS.Api/Controllers/AuthController.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PMS.Api.Models;
using PMS.Api.Models.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PMS.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config; // To read Jwt settings

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        // POST: api/auth/register → creates normal user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User"); // Everyone is normal user
                return Ok(new { message = "Registered successfully" });
            }
            return BadRequest(result.Errors);
        }

        // POST: api/auth/login → returns JWT token
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized("Wrong email or password");

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Unauthorized("User not found");

            var token = GenerateJwtToken(user); // ← This is where JWT magic happens

            return Ok(new { token }); // ← React will save this
        }

        // ←←← JWT TOKEN GENERATION (This is the core) ←←←
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),     // Token valid 30 days
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}