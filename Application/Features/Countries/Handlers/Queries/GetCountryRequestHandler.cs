using Application.Contracts.Persistence;
using Application.DTOs.Country;
using Application.Features.Countries.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Countries.Handlers.Queries;

public class GetCountryRequestHandler : IRequestHandler<GetCountryRequest, CountryDto>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountryRequestHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<CountryDto> Handle(GetCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetCountryWithRegion(request.Id);
        return _mapper.Map<CountryDto>(country);
    }
}