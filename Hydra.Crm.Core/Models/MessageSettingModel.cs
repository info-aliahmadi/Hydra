using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Crm.Core.Models
{
    public class MessageSettingModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] RecipientIdsForContactMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int[] RecipientIdsForRequestMessage { get; set; }

    }
}
