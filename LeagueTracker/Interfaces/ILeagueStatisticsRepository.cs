using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface ILeagueStatisticsRepository
{
    Task<LeagueStatistics> GetLeagueInfoBySeasonAsync(string name, int seasonId);
}