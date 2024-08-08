using Application.DTOs.Common;

namespace Application.DTOs.Country;

public record UpdateCountryDto : BaseDto
{
    public string Name { get; set; }
    public int RegionId { get; set; }
    public string Abrv { get; set; }

}