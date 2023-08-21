
namespace Hydra.Cms.Core.Models
{
    public record LinkSectionModel 
    {

        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public List<LinkModel> Links { get; set; } = new List<LinkModel>();

    }
}