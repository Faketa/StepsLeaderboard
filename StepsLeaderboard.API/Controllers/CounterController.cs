using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;

namespace StepsLeaderboard.API.Controllers;

[ApiController]
[Route("api/counters")]
public class CounterController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CounterController> _logger;

    public CounterController(IMediator mediator, ILogger<CounterController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCounter([FromBody] CreateCounterCommand request)
    {
        _logger.LogInformation("Creating new counter: {CounterName}", request.Name);

        try
        {
            var counter = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetCounterById), new { id = counter.Id }, counter);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning("Attempted to create counter for a non-existent team. Error: {Message}", ex.Message);
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCounterById(Guid id)
    {
        _logger.LogInformation("Fetching counter with ID: {CounterId}", id);
        var counter = await _mediator.Send(new GetCounterByIdQuery(id));

        if (counter == null)
        {
            _logger.LogWarning("Counter with ID {CounterId} not found", id);
            return NotFound(new { Message = "Counter not found." });
        }

        return Ok(counter);
    }

    [HttpPatch("{id}/increment")]
    public async Task<IActionResult> IncrementCounter(Guid id, [FromBody] int steps)
    {
        _logger.LogInformation("Incrementing counter {CounterId} by {Steps} steps", id, steps);
        await _mediator.Send(new IncrementCounterCommand(id, steps));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCounter(Guid id)
    {
        _logger.LogInformation("Deleting counter with ID: {CounterId}", id);
        await _mediator.Send(new DeleteCounterCommand(id));
        return NoContent();
    }
}
