using Application.DTOs.Common;

namespace Application.DTOs.Team;

public record CreateTeamDto : BaseDto
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public int LeagueId { get; set; }
    public int FoundedCountryId { get; set; }
    public int CurrentCountryId { get; set; }
    public int RegionId { get; set; }
}