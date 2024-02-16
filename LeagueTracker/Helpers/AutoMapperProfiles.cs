using AutoMapper;
using LeagueTracker.DTOs;
using LeagueTracker.Models;

namespace LeagueTracker.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ClubStatistics, ClubAndStatsDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Club.Name));
    }
}