using Microsoft.EntityFrameworkCore;
using NeighbourhoodWatch.Domain.Entities;

namespace NeighbourhoodWatch.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Profile> Profiles => Set<Profile>();

    public DbSet<Neighbourhood> Neighbourhoods => Set<Neighbourhood>();

    public DbSet<PostCategory> PostCategories => Set<PostCategory>();

    public DbSet<Post> Posts => Set<Post>();

    public DbSet<PostMedia> PostMediaItems => Set<PostMedia>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<PostLike> PostLikes => Set<PostLike>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}