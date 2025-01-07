using System.ComponentModel.DataAnnotations;

namespace Hydra.Infrastructure.Security.Models
{
    public record ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
