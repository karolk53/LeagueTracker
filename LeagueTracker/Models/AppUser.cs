using Microsoft.AspNetCore.Identity;

namespace LeagueTracker.Models;

public class AppUser : IdentityUser<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
    public ICollection<AppUserClub> Clubs { get; set; }
}