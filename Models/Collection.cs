using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionsWebApp.Models
{
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string? Image { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }
        public List<Item>? Items { get; set; }
    }
}