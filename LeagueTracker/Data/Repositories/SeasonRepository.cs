using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class SeasonRepository : ISeasonRepository
{
    private readonly DataContext _context;

    public SeasonRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Season>> GetAllSeasonAsync()
    {
        return await _context.Seasons.ToListAsync();
    }
}