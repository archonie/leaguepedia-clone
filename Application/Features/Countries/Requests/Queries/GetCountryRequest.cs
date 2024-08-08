using Application.DTOs.Country;
using MediatR;

namespace Application.Features.Countries.Requests.Queries;

public class GetCountryRequest : IRequest<CountryDto>
{
    public int Id { get; set; }
}