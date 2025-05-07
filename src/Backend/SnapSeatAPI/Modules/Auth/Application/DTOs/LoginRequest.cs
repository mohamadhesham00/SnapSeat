using System.ComponentModel.DataAnnotations;

namespace Auth.Application.DTOs
{
    public record LoginRequest
    {

        [Required]
        [MinLength(5, ErrorMessage = "Username must be atleast 5 characters")]
        [MaxLength(25, ErrorMessage = "Username must be less than 25 characters")]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        [MaxLength(30, ErrorMessage = "Password must be less than 30 characters")]
        public string Password { get; set; } = null!;

    }
}
