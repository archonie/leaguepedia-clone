using Application.DTOs.League;
using MediatR;

namespace Application.Features.Leagues.Requests.Queries;

public class GetLeagueRequest : IRequest<LeagueDto>
{
    public int Id { get; set; }
}