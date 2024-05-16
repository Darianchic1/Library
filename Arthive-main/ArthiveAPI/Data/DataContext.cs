using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class DataContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public DataContext(DbContextOptions<DataContext> options) 
    : base(options) 
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<IdentityUserLogin<long>> identityUserLogins { get; set; }
    public DbSet<IdentityUserRole<long>> identityUserRoles { get; set; }
    public DbSet<IdentityUserToken<long>> identityUserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<User>().HasKey(u=>u.Id);
        modelBuilder.Entity<IdentityUserLogin<long>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<long>>().HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<IdentityUserToken<long>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        modelBuilder.Entity<User>()
            .HasMany(u => u.FromArticles)
            .WithOne(p => p.Author);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SavedListPosts);


        modelBuilder.Entity<User>()
            .HasMany(u => u.Subscriptions)
            .WithMany(u => u.Subscribers);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Contents);
    }
}