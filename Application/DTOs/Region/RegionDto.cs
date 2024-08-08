using Application.DTOs.Common;
using Application.DTOs.Country;

namespace Application.DTOs.Region;

public record RegionDto : BaseDto
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public List<CountryListDto> Countries { get; set; }
}
