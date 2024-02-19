using LeagueTracker.Data.Enum;

namespace LeagueTracker.Models;

public class Match
{
    public int Id { get; set; }
    public ClubStatistics Guest { get; set; }
    public int GuestId { get; set; }
    public string GuestName { get; set; }
    public int GuestGoals { get; set; }
    public ClubStatistics Home { get; set; }
    public int HomeId { get; set; }
    public string HomeName { get; set; }
    public int HomeGoals { get; set; }
    public DateTime StartDate { get; set; }
    public MatchStatus Status { get; set; }
    public Season Season { get; set; }
    public int SeasonId { get; set; }
}