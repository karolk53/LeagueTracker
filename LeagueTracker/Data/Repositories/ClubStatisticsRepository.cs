using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeagueTracker.DTOs;
using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class ClubStatisticsRepository : IClubStatisticsRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ClubStatisticsRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ClubAndStatsDto> GetClubInfo(Club club)
    {
        return await _context.ClubStatistics
            .Include(c => c.Club)
            .Where(x => x.Club.Id.Equals(club.Id))
            .ProjectTo<ClubAndStatsDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}