using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CollectionsWebApp.Models
{
    public class User : IdentityUser
    {
        public List<Collection>? Collections { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Like>? Likes { get; set; }
    }
}
