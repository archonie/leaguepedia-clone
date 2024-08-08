using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Persons.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Handlers.Commands;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.Get(request.Id);
        if (person == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }
        await _personRepository.Delete(person);
        return Unit.Value;
    }
}