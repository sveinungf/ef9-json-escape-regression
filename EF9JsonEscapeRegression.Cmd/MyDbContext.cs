using Microsoft.EntityFrameworkCore;

namespace EF9JsonEscapeRegression.Cmd;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .OwnsOne(x => x.Name, b => b.ToJson());
    }
}
