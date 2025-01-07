using System.ComponentModel.DataAnnotations;

namespace Hydra.Infrastructure.Security.Models
{
    public class VerifyPhoneNumberModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
