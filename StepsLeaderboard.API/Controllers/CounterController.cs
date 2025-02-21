using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Features.Counters.Queries;
using StepsLeaderboard.Application.Features.Counters.DTOs;

namespace StepsLeaderboard.API.Controllers;

/// <summary>
/// API Controller for managing Counters.
/// </summary>
[ApiController]
[Route("api/counters")]
public class CounterController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CounterController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CounterController"/> class.
    /// </summary>
    /// <param name="mediator">Mediator instance.</param>
    /// <param name="logger">Logger instance.</param>
    public CounterController(IMediator mediator, ILogger<CounterController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new Counter.
    /// </summary>
    /// <param name="request">The Counter creation request.</param>
    /// <returns>The created Counter.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCounter([FromBody] CreateCounterCommand request)
    {
        _logger.LogInformation("Creating new counter: {CounterName}", request.Name);

        var command = request.Id == Guid.Empty
            ? new CreateCounterCommand(Guid.NewGuid(), request.Name, request.TeamId)
            : request;

        try
        {
            var counter = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCounterById), new { id = counter.Id }, counter);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning("Counter creation failed: {Message}", ex.Message);
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// Retrieves a Counter by ID.
    /// </summary>
    /// <param name="id">The ID of the Counter.</param>
    /// <returns>The requested Counter.</returns>
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

    /// <summary>
    /// Updates the step count of a Counter.
    /// </summary>
    /// <param name="id">The ID of the Counter to update.</param>
    /// <param name="request">The update request containing the step increment.</param>
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCounterSteps([FromRoute] Guid id, [FromBody] UpdateCounterStepsCommand request)
    {
        if (request.Steps <= 0)
        {
            return BadRequest(new { Message = "Steps must be greater than zero." });
        }

        var command = new UpdateCounterStepsCommand(id, request.Steps);
        _logger.LogInformation("Updating counter {CounterId} with {Steps} steps", id, request.Steps);
        await _mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Deletes a Counter.
    /// </summary>
    /// <param name="id">The ID of the Counter to delete.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCounter(Guid id)
    {
        _logger.LogInformation("Deleting counter with ID: {CounterId}", id);
        await _mediator.Send(new DeleteCounterCommand(id));
        return NoContent();
    }
}
