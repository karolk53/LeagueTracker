namespace LeagueTracker.Models;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }
    private ICollection<LeagueStatistics> LeagueStatistics { get; set; }
}