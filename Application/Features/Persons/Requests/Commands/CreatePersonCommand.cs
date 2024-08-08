using Application.DTOs.Person;
using MediatR;

namespace Application.Features.Persons.Requests.Commands;

public class CreatePersonCommand : IRequest<int>
{
    public CreatePersonDto PersonDto { get; set; }
}