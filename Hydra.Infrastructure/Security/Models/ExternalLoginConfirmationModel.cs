using System.ComponentModel.DataAnnotations;

namespace Hydra.Infrastructure.Security.Models
{
    public class ExternalLoginConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
