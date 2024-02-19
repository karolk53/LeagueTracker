using LeagueTracker.Interfaces;
using LeagueTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTracker.Controllers;

public class ClubController : Controller
{
    private readonly IClubRepository _clubRepository;
    private readonly IAppUserClubRepository _appUserClubRepository;
    private readonly UserManager<AppUser> _userManager;
    

    public ClubController(
        IClubRepository clubRepository, 
        IAppUserClubRepository appUserClubRepository,
        UserManager<AppUser> userManager)
    {
        _clubRepository = clubRepository;
        _appUserClubRepository = appUserClubRepository;
        _userManager = userManager;
    }

    public async Task<IActionResult> GetClubMatchesById(int clubId)
    {
        var matches = await _clubRepository.GetClubMatchesByIdAsync(clubId);
        return PartialView("_ClubMatches", matches);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddClubToFavorites(int clubId)
    {
        var club = await _clubRepository.GetGlubByIdAsync(clubId);
        if (User.Identity != null)
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var userClubs = await _clubRepository.GetUserClubsAsync(username);
            if (!userClubs.Contains(club.Name))
            {
                var userClub = new AppUserClub
                {
                    Club = club,
                    User = user
                };
                _appUserClubRepository.AddNewRecord(userClub);
                if (await _appUserClubRepository.SaveAllChangesAsync())
                {
                    return RedirectToAction("Index", "League");
                }
            }
            else
            {
                var userClub = await _appUserClubRepository.GetAppUserClubAsync(user, club);
                _appUserClubRepository.RemoveRecord(userClub);
                if (await _appUserClubRepository.SaveAllChangesAsync())
                {
                    return RedirectToAction("Index", "League");
                }
            }
        }
        return RedirectToAction("Index", "Home");
    }
}