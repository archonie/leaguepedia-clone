using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Countries.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Handlers.Commands;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
{
    private readonly ICountryRepository _repository;

    public DeleteCountryCommandHandler(ICountryRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.Get(request.Id);
        if (country == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }
        await _repository.Delete(country);
        return Unit.Value;
    }
}