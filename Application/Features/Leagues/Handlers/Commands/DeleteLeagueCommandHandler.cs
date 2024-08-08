using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Leagues.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Leagues.Handlers.Commands;

public class DeleteLeagueCommandHandler : IRequestHandler<DeleteLeagueCommand, Unit>
{
    private readonly ILeagueRepository _repository;

    public DeleteLeagueCommandHandler(ILeagueRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteLeagueCommand request, CancellationToken cancellationToken)
    {
        var league = await _repository.Get(request.Id);
        if (league == null)
        {
            throw new NotFoundException(nameof(League), request.Id);
        }
        await _repository.Delete(league);
        return Unit.Value;
    }
}