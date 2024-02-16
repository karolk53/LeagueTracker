using LeagueTracker.DTOs;
using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface IClubStatisticsRepository
{
    Task<ClubAndStatsDto> GetClubInfo(Club club);
}