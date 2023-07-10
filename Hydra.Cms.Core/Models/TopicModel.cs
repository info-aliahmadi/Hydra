
namespace Hydra.Cms.Core.Models
{
    public record TopicModel 
    {

        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TopicModel? Parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentId { get; set; }

        public List<TopicModel>? Childs { get; set; } = new List<TopicModel>();
    }
}