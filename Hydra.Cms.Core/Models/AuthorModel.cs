

namespace Hydra.Cms.Core.Models
{
    public record AuthorModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? FullName => FirstName + " " + LastName;
    }
}