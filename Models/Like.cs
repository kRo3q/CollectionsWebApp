using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionsWebApp.Models
{
    public class Like
    {
        public int Id { get; set; }
        bool isLiked { get; set; }

        public virtual User User { get; set; }
        public string UserId { get; set; }

    }
}
