using LeagueTracker.Models;

namespace LeagueTracker.Interfaces;

public interface IAppUserClubRepository
{
    void AddNewRecord(AppUserClub appUserClub);
    void RemoveRecord(AppUserClub appUserClub);
    Task<AppUserClub> GetAppUserClubAsync(AppUser user, Club club);
    Task<bool> SaveAllChangesAsync();
}