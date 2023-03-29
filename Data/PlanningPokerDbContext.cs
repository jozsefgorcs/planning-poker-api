using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlanningPoker.Api.Data;

public class PlanningPokerDbContext : IdentityDbContext<ApiUser>
{
    public PlanningPokerDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Story> Stories { get; set; }
    public DbSet<Vote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Story>().HasData(new Story
        {
            Id = 1,
            Title = "Test story from backend",
            Description = "Test Story description from backend"
        });
        modelBuilder.Entity<Vote>().HasData(
            new Vote()
            {
                Id = 1,
                Value = 420,
                StoryId = 1
            },
            new Vote()
            {
                Id = 2,
                Value = 555,
                StoryId = 1
            }
        );
    }
}