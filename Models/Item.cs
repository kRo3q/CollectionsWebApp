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

        public int? OptionalInt1 { get; set; }
        public int? OptionalInt2 { get; set; }
        public int? OptionalInt3 { get; set; }
        public string? OptionalString1 { get; set; }
        public string? OptionalString2 { get; set; }
        public string? OptionalString3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string? OptionalMultiLine1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string? OptionalMultiLine2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string? OptionalMultiLine3 { get; set; }
        public bool? OptionalCheckBox1 { get; set; }
        public bool? OptionalCheckBox2 { get; set; }
        public bool? OptionalCheckBox3 { get; set; }
        [DataType(DataType.Date)]
        public DateTime OptionalDate1 { get; set; }
        [DataType(DataType.Date)]
        public DateTime OptionalDate2 { get; set; }
        [DataType(DataType.Date)]
        public DateTime OptionalDate3 { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
