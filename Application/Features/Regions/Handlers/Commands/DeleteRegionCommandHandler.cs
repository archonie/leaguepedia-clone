using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Regions.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Regions.Handlers.Commands;

public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand, Unit>
{
    private readonly IRegionRepository _repository;

    public DeleteRegionCommandHandler(IRegionRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        var region = await _repository.Get(request.Id);
        if (region == null)
        {
            throw new NotFoundException(nameof(Region), request.Id);
        }

        await _repository.Delete(region);
        return Unit.Value;
        
    }
}