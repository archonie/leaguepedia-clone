using Application.DTOs.Person;
using MediatR;

namespace Application.Features.Persons.Requests.Commands;

public class UpdatePersonCommand : IRequest<Unit>
{
    public UpdatePersonDto PersonDto { get; set; }
}