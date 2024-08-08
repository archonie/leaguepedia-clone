using Application.DTOs.League;
using Application.Features.Leagues.Requests.Commands;
using Application.Features.Leagues.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeagueController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeagueController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeagueListDto>>> Get()
    {
        var leagues = await _mediator.Send(new GetLeagueListRequest());
        return Ok(leagues);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeagueDto>> Get(int id)
    {
        var league = await _mediator.Send(new GetLeagueRequest { Id = id });
        return Ok(league);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeagueDto league)
    {
        var command = new CreateLeagueCommand { LeagueDto = league };
        var response = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeagueDto leagueDto)
    {
        leagueDto.Id = id;
        var command = new UpdateLeagueCommand { LeagueDto = leagueDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeagueCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}