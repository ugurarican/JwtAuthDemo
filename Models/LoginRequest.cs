using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo.Models
{
    public class LoginRequest
    {

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
