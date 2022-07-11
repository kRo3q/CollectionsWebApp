using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionsWebApp.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Tags { get; set; }
        public int LikeCount { get; set; } = 0;

        public virtual Collection Collection { get; set; }
        public int CollectionId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
