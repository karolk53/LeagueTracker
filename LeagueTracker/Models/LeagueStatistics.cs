namespace LeagueTracker.Models;

public class LeagueStatistics
{
    public int Id { get; set; }
    public ICollection<Club> Clubs { get; set; }
    public string MostGoalsPlayer { get; set; }
    public League League { get; set; }
    public int LeagueId { get; set; }
    public Season Season { get; set; }
    public int SeasonId { get; set; }
}