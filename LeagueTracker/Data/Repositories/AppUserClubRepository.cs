using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data.Repositories;

public class AppUserClubRepository : IAppUserClubRepository
{
    private readonly DataContext _context;

    public AppUserClubRepository(DataContext context)
    {
        _context = context;
    }
    
    public void AddNewRecord(AppUserClub appUserClub)
    {
        _context.AppUserClubs.Add(appUserClub);
    }

    public void RemoveRecord(AppUserClub appUserClub)
    {
        _context.AppUserClubs.Remove(appUserClub);
    }

    public async Task<AppUserClub> GetAppUserClubAsync(AppUser user, Club club)
    {
        return await _context.AppUserClubs.FirstOrDefaultAsync(x => x.User.Equals(user) && x.Club.Equals(club));
    }

    public async Task<bool> SaveAllChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}