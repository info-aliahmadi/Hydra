using System.ComponentModel.DataAnnotations;

namespace Hydra.Infrastructure.Security.Models
{
    public class AddPhoneNumberModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
