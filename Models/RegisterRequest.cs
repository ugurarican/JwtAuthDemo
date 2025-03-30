using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo.Models
{
    public class RegisterRequest
    {
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
