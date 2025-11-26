// File: PMS.Api/Models/LoginDto.cs
namespace PMS.Api.Models
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}