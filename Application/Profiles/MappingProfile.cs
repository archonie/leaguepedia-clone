using Application.DTOs;
using Application.DTOs.ApplicationUser;
using Application.DTOs.Country;
using Application.DTOs.League;
using Application.DTOs.Person;
using Application.DTOs.Region;
using Application.DTOs.Team;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, AppUserDto>().ReverseMap();
        CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
        CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, CountryListDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<Region, RegionListDto>().ReverseMap();
        CreateMap<Region, UpdateRegionDto>().ReverseMap();
        CreateMap<Region, CreateRegionDto>().ReverseMap();
        CreateMap<Team, TeamDto>().ReverseMap();
        CreateMap<Team, TeamListDto>().ReverseMap();
        CreateMap<Team, UpdateTeamDto>().ReverseMap();
        CreateMap<Team, CreateTeamDto>().ReverseMap();
        CreateMap<League, LeagueDto>().ReverseMap();
        CreateMap<League, LeagueListDto>().ReverseMap();
        CreateMap<League, UpdateLeagueDto>().ReverseMap();
        CreateMap<League, CreateLeagueDto>().ReverseMap();
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Person, UpdatePersonDto>().ReverseMap();
        CreateMap<Person, CreatePersonDto>().ReverseMap();
    }
}