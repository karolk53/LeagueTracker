using LeagueTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTracker.Controllers;

public class ClubController : Controller
{
    private readonly IClubStatisticsRepository _clubStatisticsRepository;
    private readonly IClubRepository _clubRepository;

    public ClubController(IClubStatisticsRepository clubStatisticsRepository, IClubRepository clubRepository)
    {
        _clubStatisticsRepository = clubStatisticsRepository;
        _clubRepository = clubRepository;
    }

    public async Task<IActionResult> GetClubMatchesById(int clubId)
    {
        var matches = await _clubRepository.GetClubMatchesByIdAsync(clubId);
        return PartialView("_ClubMatches", matches);
    }
    
}