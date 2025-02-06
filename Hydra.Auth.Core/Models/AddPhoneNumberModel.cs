using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Models
{
    public class AddPhoneNumberModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
