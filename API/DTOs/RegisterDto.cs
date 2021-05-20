using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 5)]
        public string password { get; set; }
    }
}