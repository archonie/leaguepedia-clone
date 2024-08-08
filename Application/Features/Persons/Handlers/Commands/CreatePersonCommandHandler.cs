using Application.Contracts.Persistence;
using Application.Features.Persons.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Handlers.Commands;

public class CreatePersonCommandHandler: IRequestHandler<CreatePersonCommand, int>
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public CreatePersonCommandHandler(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request.PersonDto);
        person = await _repository.Add(person);
        return person.Id;
    }
}