using Application.DTOs.Team;
using MediatR;

namespace Application.Features.Teams.Requests.Commands;

public class UpdateTeamCommand : IRequest<Unit>
{
    public UpdateTeamDto TeamDto { get; set; }
}