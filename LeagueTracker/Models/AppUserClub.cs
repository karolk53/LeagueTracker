namespace LeagueTracker.Models;

public class AppUserClub
{
    public AppUser User { get; set; }
    public int UserId { get; set; }
    public Club Club { get; set; }
    public int ClubId { get; set; }
}