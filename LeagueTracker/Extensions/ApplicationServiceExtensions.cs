using LeagueTracker.Data.Repositories;
using LeagueTracker.Interfaces;

namespace LeagueTracker.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<ILeagueStatisticsRepository, LeagueStatisticsRepository>();
        services.AddScoped<IClubStatisticsRepository, ClubStatisticsRepository>();
        services.AddScoped<IAppUserClubRepository, AppUserClubRepository>();
        services.AddScoped<ISeasonRepository, SeasonRepository>();
        services.AddScoped<ILeagueRepository, LeagueRepository>();
        services.AddScoped<IClubRepository, ClubRepository>();

        return services;
    }
}