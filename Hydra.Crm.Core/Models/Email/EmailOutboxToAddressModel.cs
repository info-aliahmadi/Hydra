

namespace Hydra.Crm.Core.Models.Email
{
    public record EmailOutboxToAddressModel
    {

        /// <summary>
        /// 
        /// </summary>
        public int EmailOutboxId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

    }

}
