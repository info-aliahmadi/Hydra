using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Models
{
    public class VerifyAuthenticatorCodeModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}
