using Application.DTOs.Common;

namespace Application.DTOs.Country;

public record CreateCountryDto
{
    public string Name { get; set; }
    public int RegionId { get; set; }
    public string Abrv { get; set; }
}