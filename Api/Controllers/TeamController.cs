using Application.DTOs.Team;
using Application.Features.Teams.Requests.Commands;
using Application.Features.Teams.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamListDto>>> Get()
    {
        var teams = await _mediator.Send(new GetTeamListRequest());
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> Get(int id)
    {
        var team = await _mediator.Send(new GetTeamRequest { Id = id });
        return Ok(team);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateTeamDto team)
    {
        var command = new CreateTeamCommand { TeamDto = team };
        var response = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateTeamDto teamDto)
    {
        teamDto.Id = id;
        var command = new UpdateTeamCommand { TeamDto = teamDto };
        await _mediator.Send(command);
        return NoContent();
    }
    // [HttpPut("{id}/UpdateFoundedCountry")]
    // public async Task<ActionResult> Put(int id, [FromBody] UpdateTeamFoundedCountryDto teamDto)
    // {
    //     teamDto.Id = id;
    //     var command = new UpdateTeamCommand { FoundedCountryDto = teamDto };
    //     await _mediator.Send(command);
    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTeamCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}