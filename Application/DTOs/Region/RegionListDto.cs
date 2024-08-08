using Application.DTOs.Common;

namespace Application.DTOs.Region;

public record RegionListDto : BaseDto
{
    public string Name { get; set; }
    public string Abrv { get; set; }
}