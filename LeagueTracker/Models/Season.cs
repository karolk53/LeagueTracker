using System.Collections;

namespace LeagueTracker.Models;

public class Season
{
    public int Id { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public ICollection<Match> Matches { get; set; }
    public ICollection<ClubStatistics> ClubStatistics { get; set; }
    public ICollection<LeagueStatistics> LeagueStatistics { get; set; }
}