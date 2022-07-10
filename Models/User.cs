using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CollectionsWebApp.Models
{
    public class User : IdentityUser
    {
        public ICollection<Collection>? Collections { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }
    }
}
