using Application.Contracts.Persistence;
using Application.DTOs.Person;
using Application.Features.Persons.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Persons.Handlers.Queries;

public class GetPersonRequestHandler : IRequestHandler<GetPersonRequest, PersonDto>
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public GetPersonRequestHandler(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
    {
        var person = await _repository.Get(request.Id);
        return _mapper.Map<PersonDto>(person);
    }
}