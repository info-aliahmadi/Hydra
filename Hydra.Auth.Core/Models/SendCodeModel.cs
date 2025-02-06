

using Hydra.Kernel.GeneralModels;

namespace Hydra.Auth.Models
{
    public class SendCodeModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
        
    }
}
