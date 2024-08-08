using MediatR;

namespace Application.Features.Regions.Requests.Commands;

public class DeleteRegionCommand : IRequest<Unit>
{
    public int Id { get; set; }
}