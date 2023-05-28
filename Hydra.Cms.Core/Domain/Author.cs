using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel;

namespace Hydra.Cms.Core.Domain
{
    public class Author : BaseEntity<int>
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }
    }
}
