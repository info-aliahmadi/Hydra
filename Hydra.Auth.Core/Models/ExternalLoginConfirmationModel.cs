using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Models
{
    public class ExternalLoginConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
