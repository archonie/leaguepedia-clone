using Application.DTOs.League;
using MediatR;

namespace Application.Features.Leagues.Requests.Commands;

public class CreateLeagueCommand : IRequest<int>
{
    public CreateLeagueDto LeagueDto { get; set; }   
}