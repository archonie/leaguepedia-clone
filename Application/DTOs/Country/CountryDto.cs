using Application.DTOs.Common;
using Application.DTOs.League;
using Application.DTOs.Person;
using Application.DTOs.Region;
using Application.DTOs.Team;

namespace Application.DTOs.Country;

public record CountryDto : BaseDto
{
    public string Name { get; set; }
    public int RegionId { get; set; }
    public List<LeagueListDto> Leagues { get; set; }
    public virtual List<TeamListDto> NativeTeams { get; set; }
    public virtual List<TeamListDto> OperatingTeams { get; set; }
    public virtual List<PersonDto> Persons { get; set;  }
    public string Abrv { get; set; }
}