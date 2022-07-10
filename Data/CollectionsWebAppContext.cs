using CollectionsWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionsWebApp.Data
{
    public class CollectionsWebAppContext : IdentityDbContext
    {
        public CollectionsWebAppContext(DbContextOptions<CollectionsWebAppContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Collection> Collections { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Like> Likes { get; set; }
    }
}
