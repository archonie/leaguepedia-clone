using Application.DTOs.Person;
using Application.Features.Persons.Requests.Commands;
using Application.Features.Persons.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var persons = await _mediator.Send(new GetPersonListRequest());
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var person = await _mediator.Send(new GetPersonRequest { Id = id });
        return Ok(person);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreatePersonDto person)
    {
        var command = new CreatePersonCommand { PersonDto = person };
        var response = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdatePersonDto personDto)
    {
        personDto.Id = id;
        var command = new UpdatePersonCommand { PersonDto = personDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePersonCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}