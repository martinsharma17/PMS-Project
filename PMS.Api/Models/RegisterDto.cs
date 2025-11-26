// File: PMS.Api/Models/RegisterDto.cs
namespace PMS.Api.Models
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        // No NRN, no citizenship → just normal user
    }
}