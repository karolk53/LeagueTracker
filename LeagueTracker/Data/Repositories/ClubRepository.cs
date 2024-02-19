using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class ClubRepository : IClubRepository
{
    private readonly DataContext _context;

    public ClubRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Match>> GetClubMatchesByIdAsync(int clubId)
    {
        var club = await _context.ClubStatistics
            .Include(g => g.GuestMatches)
            .Include(h => h.HomeMatches)
            .FirstOrDefaultAsync(x => x.Id.Equals(clubId));
        var matches = new List<Match>();

        if (club != null)
        {
            if (club.GuestMatches != null) matches.AddRange(club.GuestMatches);
            if (club.HomeMatches != null) matches.AddRange(club.HomeMatches);
        }

        return matches;
    }

    public async Task<Club> GetGlubByIdAsync(int clubId)
    {
        return await _context.Clubs
            .Include(f => f.Followers)
            .FirstOrDefaultAsync(x => x.Id.Equals(clubId));
    }

    public async Task<bool> SaveAllChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<string>> GetUserClubsAsync(string userName)
    {
        var userClubs =  await _context.AppUserClubs
            .Include(c => c.Club)
            .Where(x => x.User.UserName.Equals(userName))
            .ToListAsync();
        var clubs = new List<string>();
        
        foreach (var userClub in userClubs)
        {
            clubs.Add(userClub.Club.Name);
        }

        return clubs;
    }
}