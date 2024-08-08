using Application.DTOs.Country;
using MediatR;

namespace Application.Features.Countries.Requests.Queries;

public class GetCountryListRequest : IRequest<List<CountryListDto>>
{
    
}