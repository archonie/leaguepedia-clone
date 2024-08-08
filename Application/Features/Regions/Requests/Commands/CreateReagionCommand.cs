using Application.DTOs.Region;
using MediatR;

namespace Application.Features.Regions.Requests.Commands;

public class CreateRegionCommand : IRequest<int>
{
    public CreateRegionDto RegionDto { get; set; }
}