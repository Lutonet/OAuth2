using System.ComponentModel.DataAnnotations;

namespace OAuth2Web.Models
{
    public class LoginModel
    {
        [Required]
        public string AppliationId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}