using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Core.Models
{
    public class AddPhoneNumberModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
