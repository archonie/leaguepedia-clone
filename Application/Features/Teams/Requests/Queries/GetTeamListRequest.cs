using Application.DTOs.Team;
using MediatR;

namespace Application.Features.Teams.Requests.Queries;

public class GetTeamListRequest : IRequest<List<TeamListDto>>
{
    
}