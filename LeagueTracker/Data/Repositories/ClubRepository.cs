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
        var club = await _context.Clubs
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
}