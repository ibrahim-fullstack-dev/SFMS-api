using MediatR;
using Microsoft.AspNetCore.Mvc;
using SFMS.Application.Features.Cities.Commands.CreateCity;
using SFMS.Application.Features.Cities.Commands.DeleteCity;
using SFMS.Application.Features.Cities.Commands.UpdateCity;
using SFMS.Application.Features.Cities.DTOs;
using SFMS.Application.Features.Cities.Queries.GetCities;
using SFMS.Application.Features.Cities.Queries.GetCity;

namespace SFMS.Api.Controllers.Setups;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly ISender _sender;

    public CitiesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CityDto>>> GetAll(
        CancellationToken cancellationToken)
    {
        var query = new GetCitiesQuery();

        var cities = await _sender.Send(
            query,
            cancellationToken);

        return Ok(cities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CityDto>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var query = new GetCityQuery(id);

        var city = await _sender.Send(
            query,
            cancellationToken);

        if (city is null)
        {
            return NotFound();
        }

        return Ok(city);
    }

    [HttpPost]
    public async Task<ActionResult<CityDto>> Create(
        CreateCityCommand command,
        CancellationToken cancellationToken)
    {
        var city = await _sender.Send(
            command,
            cancellationToken);

        return Ok(city);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CityDto>> Update(
        int id,
        UpdateCityCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest(
                "Route ID does not match command ID.");
        }

        var city = await _sender.Send(
            command,
            cancellationToken);

        return Ok(city);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        await _sender.Send(
            new DeleteCityCommand(id),
            cancellationToken);

        return NoContent();
    }
}