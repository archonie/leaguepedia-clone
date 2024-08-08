using Application.DTOs.Country;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Requests.Commands;

public class CreateCountryCommand : IRequest<int>
{
    public CreateCountryDto CountryDto { get; set; }
}