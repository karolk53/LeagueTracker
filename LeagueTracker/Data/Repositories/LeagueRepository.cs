using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class LeagueRepository : ILeagueRepository
{
    private readonly DataContext _context;

    public LeagueRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<League>> GetAllLeaguesAsync()
    {
        return await _context.Leagues.ToListAsync();
    }
}