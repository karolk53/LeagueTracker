﻿namespace LeagueTracker.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfCreation { get; set; }
    public ICollection<ClubStatistics> ClubStatistics { get; set; }
    public ICollection<LeagueStatistics> LeagueStatistics { get; set; }
    public ICollection<AppUserClub> Followers { get; set; }
}