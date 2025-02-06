using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Models
{
    public class RecoveryCodesModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }
    }
}
