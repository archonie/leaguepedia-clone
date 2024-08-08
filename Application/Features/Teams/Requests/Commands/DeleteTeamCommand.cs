using MediatR;

namespace Application.Features.Teams.Requests.Commands;

public class DeleteTeamCommand : IRequest<Unit>
{
    public int Id { get; set; }
}