using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Core.Models
{
    public record ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
