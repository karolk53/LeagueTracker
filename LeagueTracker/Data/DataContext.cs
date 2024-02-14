using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Club> Clubs { get; set; }
    public DbSet<ClubStatistics> ClubStatistics { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<LeagueStatistics> LeagueStatistics { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Season> Seasons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Match>()
            .HasOne(x => x.Guest)
            .WithMany(x => x.GuestMatches)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Match>()
            .HasOne(x => x.Home)
            .WithMany(x => x.HomeMatches)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}