using MediatR;

namespace Application.Features.Leagues.Requests.Commands;

public class DeleteLeagueCommand : IRequest<Unit>
{
    public int Id { get; set; }
}