using MediatR;

namespace Application.Features.Countries.Requests.Commands;

public class DeleteCountryCommand : IRequest<Unit>
{
    public int Id { get; set; }
}