using Microsoft.EntityFrameworkCore;

namespace PlanningPoker.Api.Data;

public class PlanningPokerDbContext : DbContext
{
    public PlanningPokerDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Story> Stories { get; set; }
    public DbSet<Vote> Votes { get; set; }
}