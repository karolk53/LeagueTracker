using Microsoft.AspNetCore.Identity;

namespace LeagueTracker.Models;

public class AppUserRole : IdentityUserRole<int>
{
    public AppUser AppUser { get; set; }
    public AppRole AppRole { get; set; }
}