using Application.DTOs.Team;
using MediatR;

namespace Application.Features.Teams.Requests.Queries;

public class GetTeamRequest : IRequest<TeamDto>
{
    public int Id { get; set; }
}