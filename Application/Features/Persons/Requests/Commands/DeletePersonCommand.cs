using MediatR;

namespace Application.Features.Persons.Requests.Commands;

public class DeletePersonCommand : IRequest<Unit>
{
    public int Id { get; set; }
}