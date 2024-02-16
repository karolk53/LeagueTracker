using LeagueTracker.Models;

namespace LeagueTracker.DTOs;

public class ClubAndStatsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WonMatches { get; set; }
    public int TiedMatches { get; set; }
    public int LostMatches { get; set; }
    public int PlayedMatches { get; set; }
    public int Points { get; set; }
}