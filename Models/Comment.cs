using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionsWebApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual User User { get; set; }
    }
}
