using System.ComponentModel.DataAnnotations;

namespace Hydra.Infrastructure.Security.Models
{
    public class UseRecoveryCodeModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
