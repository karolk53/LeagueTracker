using System.Text.Json;
using LeagueTracker.Models;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace LeagueTracker.Data;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        var league = await SeedLeagues(context);
        var season = await SeedSeasons(context);
        var leagueStatistics = await SeedLeagueStatistics(context, league, season);
        var clubStats = await SeeClubs(context, leagueStatistics, league, season);
        await SeedMatches(context, leagueStatistics, league, season, clubStats);
    }

    private static async Task<League> SeedLeagues(DataContext context)
    {
        if(await context.Leagues.AnyAsync()) return null;

        var league = new League
        {
            Name = "Pro League",
        };
        var league1 = new League
        {
            Name = "La Liga",
        };

        context.Leagues.AddRange(league, league1);
        await context.SaveChangesAsync();

        return league;
    }

    private static async Task<Season> SeedSeasons(DataContext context)
    {
        if(await context.Seasons.AnyAsync()) return null;

        var season = new Season
        {
            StartYear = 2022,
            EndYear = 2023
        };
        var season1 = new Season
        {
            StartYear = 2023,
            EndYear = 2024
        };

        context.Seasons.AddRange(season,season1);
        
        await context.SaveChangesAsync();

        return season;
    }

    private static async Task<LeagueStatistics> SeedLeagueStatistics(DataContext context, League league, Season season)
    {
        if(await context.LeagueStatistics.AnyAsync()) return null;

        var leaguestatistics = new LeagueStatistics
        {
            Season = season,
            League = league,
            MostGoalsPlayer = "Jan Kowalski",
            Clubs = new List<Club>()
        };

        context.LeagueStatistics.Add(leaguestatistics);
        await context.SaveChangesAsync();

        return leaguestatistics;
    }

    private static async Task<List<ClubStatistics>> SeeClubs(DataContext context, LeagueStatistics leagueStatistics, League league, Season season)
    {
        if(await context.Clubs.AnyAsync()) return null;

        var clubData = await File.ReadAllTextAsync("Data/ClubsData.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var clubs = JsonSerializer.Deserialize<List<Club>>(clubData, options);
        var clubStatsList = new List<ClubStatistics>();
        
        foreach (var club in clubs)
        {
            context.Clubs.Add(club);
            
            var clubStatistics = new ClubStatistics
            {
                Club = club,
                Season = season,
                GuestMatches = new List<Match>(),
                HomeMatches = new List<Match>(),
                TiedMatches = 0
            };
            
            clubStatsList.Add(clubStatistics);
            context.ClubStatistics.Add(clubStatistics);
            leagueStatistics.Clubs.Add(club);
        }
        
        await context.SaveChangesAsync();
        return clubStatsList;
    }

    private static async Task SeedMatches(DataContext context, LeagueStatistics leagueStatistics, League league, Season season, List<ClubStatistics> clubStatisticsList)
    {

        if(await context.Matches.AnyAsync()) return;
        
        foreach (var home in clubStatisticsList)
        {
            var guest = new ClubStatistics();
            if (clubStatisticsList.IndexOf(home) == 0)
            {
                guest = clubStatisticsList.Last();
            }
            else
            {
                guest = clubStatisticsList[clubStatisticsList.IndexOf(home) - 1];
            }
            
            
            var match = new Match
            {
                Guest = guest,
                GuestName = guest.Club.Name,
                GuestGoals = 1,
                Home = home,
                HomeName = home.Club.Name,
                HomeGoals = 2,
                Season = season,
                StartDate = DateTime.Today
            };
            
            
            home.HomeMatches.Add(match);
            home.WonMatches += 1;
            home.PlayedMatches += 1;
            home.Points += 3;
            
            guest.GuestMatches.Add(match);
            guest.LostMatches += 1;
            guest.PlayedMatches += 1;
            
            context.UpdateRange(home, guest);
            await context.SaveChangesAsync();
        }
    }
    
}