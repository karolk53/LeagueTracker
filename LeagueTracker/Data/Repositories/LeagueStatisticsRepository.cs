using AutoMapper;
using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class LeagueStatisticsRepository : ILeagueStatisticsRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public LeagueStatisticsRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<LeagueStatistics> GetLeagueInfoBySeasonAsync(string name, int seasonId)
    {
        return await _context.LeagueStatistics
            .Include(l => l.League)
            .Include(c => c.Clubs)
            .FirstOrDefaultAsync(x => x.League.Name.Equals(name) && x.SeasonId.Equals(seasonId));
    }
}