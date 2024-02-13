namespace LeagueTracker.Models;

public class ClubStatistics
{
    public int Id { get; set; }
    public int WonMatches { get; set; }
    public int TiedMatches { get; set; }
    public int LostMatches { get; set; }
    public int PlayedMatches { get; set; }
    public int Points { get; set; }
    public Club Club { get; set; }
    public int ClubId { get; set; }
    public Season Season { get; set; }
    public int SeasonId { get; set; }
}