using LeagueTracker.DTOs;
using LeagueTracker.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTracker.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueStatisticsRepository _leagueStatisticsRepository;
        private readonly IClubStatisticsRepository _clubStatisticsRepository;
        private readonly IClubRepository _clubRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ILeagueRepository _leagueRepository;

        public LeagueController(
            ILeagueStatisticsRepository leagueStatisticsRepository, 
            IClubStatisticsRepository clubStatisticsRepository,
            IClubRepository clubRepository,
            ISeasonRepository seasonRepository,
            ILeagueRepository leagueRepository)
        {
            _leagueStatisticsRepository = leagueStatisticsRepository;
            _clubStatisticsRepository = clubStatisticsRepository;
            _clubRepository = clubRepository;
            _seasonRepository = seasonRepository;
            _leagueRepository = leagueRepository;
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

            var userClubs = await _clubRepository.GetUserClubsAsync(User.Identity.Name);

            ViewData["Seasons"] = await _seasonRepository.GetAllSeasonAsync();
            ViewData["Leagues"] = await _leagueRepository.GetAllLeaguesAsync();
            ViewData["LeagueStatistics"] = leagueStatistics;
            ViewData["ClubsAndStats"] = clubsAndStats.OrderByDescending(x=>x.Points).ThenBy(x=>x.Name).ToList();
            ViewData["UserClubs"] = userClubs;
            
            return View();
        }
    }
}