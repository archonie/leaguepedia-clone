using Application.Contracts.Persistence;
using Application.DTOs.Person;
using Application.Features.Persons.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Persons.Handlers.Queries;

public class GetPersonListRequestHandler : IRequestHandler<GetPersonListRequest, List<PersonDto>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public GetPersonListRequestHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public async Task<List<PersonDto>> Handle(GetPersonListRequest request, CancellationToken cancellationToken)
    {
        var people = await _personRepository.Get();
        return _mapper.Map<List<PersonDto>>(people);
    }
}