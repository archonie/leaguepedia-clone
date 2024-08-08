using Application.Contracts.Persistence;
using Application.DTOs.Country;
using Application.Features.Countries.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Countries.Handlers.Queries;

public class GetCountryListRequestHandler : IRequestHandler<GetCountryListRequest, List<CountryListDto>>
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;

    public GetCountryListRequestHandler(ICountryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<CountryListDto>> Handle(GetCountryListRequest request, CancellationToken cancellationToken)
    {
        var teams = await _repository.Get();
        return _mapper.Map<List<CountryListDto>>(teams);
    }
}