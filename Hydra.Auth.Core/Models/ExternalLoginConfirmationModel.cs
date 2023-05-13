using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Core.Models
{
    public class ExternalLoginConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
