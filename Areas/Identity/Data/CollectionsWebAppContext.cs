using CollectionsWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollectionsWebApp.Data;

public class CollectionsWebAppContext : IdentityDbContext<User>
{
    public CollectionsWebAppContext(DbContextOptions<CollectionsWebAppContext> options)
        : base(options)
    {
    }
    DbSet<Collection> Collections { get; set; }
    DbSet<Item> Items { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Like> Like { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
