using Application.DTOs.Person;
using MediatR;

namespace Application.Features.Persons.Requests.Queries;

public class GetPersonListRequest : IRequest<List<PersonDto>>
{
    
}