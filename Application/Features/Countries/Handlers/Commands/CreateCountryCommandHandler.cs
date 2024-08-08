using Application.Contracts.Persistence;
using Application.DTOs.Country;
using Application.Exceptions;
using Application.Features.Countries.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Handlers.Commands;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;

    public CreateCountryCommandHandler(ICountryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = _mapper.Map<Country>(request.CountryDto);
        country = await _repository.Add(country);
        return country.Id;
    }
}