using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Models
{
    public class UseRecoveryCodeModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
