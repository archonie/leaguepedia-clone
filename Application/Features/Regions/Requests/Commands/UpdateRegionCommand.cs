using Application.DTOs.Region;
using MediatR;

namespace Application.Features.Regions.Requests.Commands;

public class UpdateRegionCommand : IRequest<Unit>
{
    public UpdateRegionDto UpdateRegionDto { get; set; }
}