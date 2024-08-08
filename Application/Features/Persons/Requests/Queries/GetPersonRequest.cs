using Application.DTOs.Person;
using MediatR;

namespace Application.Features.Persons.Requests.Queries;

public class GetPersonRequest : IRequest<PersonDto>
{
    public int Id { get; set; }
}