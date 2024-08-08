using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Persons.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Handlers.Commands;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Unit>
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePersonCommandHandler(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _repository.Get(request.PersonDto.Id);
        if (person == null)
        {
            throw new NotFoundException(nameof(Person), request.PersonDto.Id);
        }

        _mapper.Map(request.PersonDto, person);
        await _repository.Update(person);
        return Unit.Value;
    }
}