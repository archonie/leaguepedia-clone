using Application.DTOs.Team;
using MediatR;

namespace Application.Features.Teams.Requests.Commands;

public class CreateTeamCommand : IRequest<int>
{
    public CreateTeamDto TeamDto { get; set; }
}