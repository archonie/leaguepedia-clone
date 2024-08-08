using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Teams.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teams.Handlers.Commands;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Unit>
{
    private readonly ITeamRepository _repository;

    public DeleteTeamCommandHandler(ITeamRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _repository.Get(request.Id);
        if (team == null)
        {
            throw new NotFoundException(nameof(Team), request.Id);
        }

        await _repository.Delete(team);
        return Unit.Value;
    }
}