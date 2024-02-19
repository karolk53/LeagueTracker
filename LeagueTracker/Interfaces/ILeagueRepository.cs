using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface ILeagueRepository
{
    Task<IEnumerable<League>> GetAllLeaguesAsync();
}