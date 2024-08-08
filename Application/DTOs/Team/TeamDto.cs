using Application.DTOs.Common;
using Application.DTOs.Person;

namespace Application.DTOs.Team;

public record TeamDto: BaseDto
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public int LeagueId { get; set; }
    public List<PersonDto> Players { get; set; }
    public int FoundedCountryId { get; set; }
    public int CurrentCountryId { get; set; }
    public int RegionId { get; set; }
}