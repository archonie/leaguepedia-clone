using Application.DTOs.Country;
using Application.DTOs.Region;
using Application.Features.Countries.Requests.Commands;
using Application.Features.Countries.Requests.Queries;
using Application.Features.Regions.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryListDto>>> Get()
    {
        var countries = await _mediator.Send(new GetCountryListRequest());
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var country = await _mediator.Send(new GetCountryRequest { Id = id });
        return Ok(country);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateCountryDto country)
    {
        var command = new CreateCountryCommand { CountryDto = country };
        var response = await _mediator.Send(command);
        return Ok(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCountryDto countryDto)
    {
        countryDto.Id = id;
        var command = new UpdateCountryCommand { UpdateCountryDto = countryDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCountryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}