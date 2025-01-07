

using Hydra.Kernel.Models;

namespace Hydra.Infrastructure.Security.Models
{
    public class SendCodeModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
        
    }
}
