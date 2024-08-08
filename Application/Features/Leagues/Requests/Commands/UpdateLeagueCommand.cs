using Application.DTOs.League;
using MediatR;

namespace Application.Features.Leagues.Requests.Commands;

public class UpdateLeagueCommand : IRequest<Unit>
{
    public UpdateLeagueDto LeagueDto { get; set; }
}