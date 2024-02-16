using System.Text.Json;
using LeagueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if(await context.Leagues.AnyAsync()) return;

        var league = new League
        {
            Name = "Pro League",
        };

        context.Leagues.Add(league);
        
        if(await context.Seasons.AnyAsync()) return;

        var season = new Season
        {
            StartYear = 2022,
            EndYear = 2023
        };

        context.Seasons.Add(season);
        
        if(await context.LeagueStatistics.AnyAsync()) return;

        var leaguestatistics = new LeagueStatistics
        {
            Season = season,
            League = league,
            MostGoalsPlayer = "Jan Kowalski",
            Clubs = new List<Club>()
        };

        context.LeagueStatistics.Add(leaguestatistics);
        
        if(await context.Clubs.AnyAsync()) return;

        var clubData = await File.ReadAllTextAsync("Data/ClubsData.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var clubs = JsonSerializer.Deserialize<List<Club>>(clubData, options);

        foreach (var club in clubs)
        {

            var match = new Match
            {
                Guest = club,
                GuestName = club.Name,
                Home = club,
                HomeName = club.Name,
                Season = season,
                StartDate = DateTime.Today
            };

            club.GuestMatches = new List<Match>();
            club.GuestMatches.Add(match);
            club.HomeMatches = new List<Match>();
            club.HomeMatches.Add(match);
            
            context.Clubs.Add(club);
            
            var clubStatistics = new ClubStatistics
            {
                Club = club,
                Season = season,
                LostMatches = club.GuestMatches.Count(),
                WonMatches = club.HomeMatches.Count(),
                TiedMatches = 0,
                PlayedMatches = club.GuestMatches.Count() + club.GuestMatches.Count(),
                Points = club.HomeMatches.Count() * 3
            };
            
            context.ClubStatistics.Add(clubStatistics);
            leaguestatistics.Clubs.Add(club);
        }
        
        await context.SaveChangesAsync();
    }
}