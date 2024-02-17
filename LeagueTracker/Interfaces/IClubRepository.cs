using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface IClubRepository
{
    Task<IEnumerable<Match>> GetClubMatchesByIdAsync(int clubId);
}