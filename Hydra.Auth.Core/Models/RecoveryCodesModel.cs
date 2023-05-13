using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hydra.Auth.Core.Models
{
    public class RecoveryCodesModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }
    }
}
