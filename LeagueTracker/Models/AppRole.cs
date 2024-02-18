using Microsoft.AspNetCore.Identity;

namespace LeagueTracker.Models;

public class AppRole : IdentityRole<int>
{
    private ICollection<AppUserRole> UserRoles { get; set; }
}