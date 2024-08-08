using Application.DTOs.League;
using MediatR;

namespace Application.Features.Leagues.Requests.Queries;

public class GetLeagueListRequest : IRequest<List<LeagueListDto>>
{
    
}