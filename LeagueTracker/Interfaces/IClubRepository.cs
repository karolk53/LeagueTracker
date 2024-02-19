using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface IClubRepository
{
    Task<IEnumerable<Match>> GetClubMatchesByIdAsync(int clubId);
    Task<Club> GetGlubByIdAsync(int clubId);
    Task<bool> SaveAllChangesAsync();
    Task<IEnumerable<string>> GetUserClubsAsync(string userName);
}