
namespace Hydra.Cms.Core.Models
{
    public record ContentModel
    {

        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AuthorId { get; set; }


    }

}
