using LeagueTracker.DTOs;
using LeagueTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTracker.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueStatisticsRepository _leagueStatisticsRepository;
        private readonly IClubStatisticsRepository _clubStatisticsRepository;

        public LeagueController(
            ILeagueStatisticsRepository leagueStatisticsRepository, 
            IClubStatisticsRepository clubStatisticsRepository)
        {
            _leagueStatisticsRepository = leagueStatisticsRepository;
            _clubStatisticsRepository = clubStatisticsRepository;
        }
        
        public async Task<IActionResult> Index([FromQuery]string leagueName,[FromQuery]int seasonId)
        {
            var leagueStatistics = await _leagueStatisticsRepository.GetLeagueInfoBySeasonAsync(leagueName, seasonId);

            var clubsAndStats = new List<ClubAndStatsDto>();
            if (leagueStatistics != null)
            {
                foreach (var club in leagueStatistics.Clubs)
                {
                    clubsAndStats.Add(await _clubStatisticsRepository.GetClubInfo(club));
                }
            }
            

            ViewData["LeagueStatistics"] = leagueStatistics;
            ViewData["ClubsAndStats"] = clubsAndStats;
            
            return View();
        }
    }
}