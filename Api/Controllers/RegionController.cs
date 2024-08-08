using Application.DTOs.Region;
using Application.Features.Regions.Requests.Commands;
using Application.Features.Regions.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RegionController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionListDto>>> Get()
    {
        var regions = await _mediator.Send(new GetRegionListRequest());
        return Ok(regions);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<RegionDto>> Get(int id)
    {
        var region = await _mediator.Send(new GetRegionRequest{Id = id});
        return Ok(region);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateRegionDto regionDto)
    {
        var command = new CreateRegionCommand { RegionDto = regionDto };
        var response = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateRegionDto regionDto)
    {
        regionDto.Id = id;
        var command = new UpdateRegionCommand { UpdateRegionDto = regionDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRegionCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}