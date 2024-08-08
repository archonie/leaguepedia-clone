using Application.DTOs.Country;
using MediatR;

namespace Application.Features.Countries.Requests.Commands;

public class UpdateCountryCommand : IRequest<Unit>
{
    public UpdateCountryDto UpdateCountryDto { get; set; }
}