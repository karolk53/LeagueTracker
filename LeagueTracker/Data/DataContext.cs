using LeagueTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
    IdentityUserClaim<int>, AppUserRole,IdentityUserLogin<int>,
    IdentityRoleClaim<int>,IdentityUserToken<int>>
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
    public DbSet<AppUserClub> AppUserClubs { get; set; }

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

        modelBuilder.Entity<AppUserClub>().HasKey(k => new { k.UserId, k.ClubId });
        
        modelBuilder.Entity<AppUserClub>()
            .HasOne<AppUser>(x => x.User)
            .WithMany(c => c.Clubs)
            .HasForeignKey(fk => fk.UserId);
        
        modelBuilder.Entity<AppUserClub>()
            .HasOne<Club>(x => x.Club)
            .WithMany(f => f.Followers)
            .HasForeignKey(fk => fk.ClubId);

    }
    
}