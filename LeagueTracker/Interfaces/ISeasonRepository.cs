using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface ISeasonRepository
{
    Task<IEnumerable<Season>> GetAllSeasonAsync();
}